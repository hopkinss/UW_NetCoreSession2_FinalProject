using Lab.UI.Events;
using Lab.UI.Utility;
using Prism.Commands;
using Prism.Events;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private IEventAggregator _eventAggregator;
        private Func<ILabTestDetailViewModel> _labTestDetailViewModelCreator;
        private ILabTestDetailViewModel labTestDetailViewModel;
        private IMessageService _messageService;

        public MainViewModel(ILabTestViewModel labTestViewModel, 
            Func<ILabTestDetailViewModel> labTestDetailViewModelCreator,
            IEventAggregator eventAggregator,
            IMessageService messageService
            )
        {            
            _labTestDetailViewModelCreator = labTestDetailViewModelCreator;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<OpenLabTestDetailViewEvent>().Subscribe(OnOpenTestDetailView, true);
            _eventAggregator.GetEvent<AfterLabTestDeletedEvent>().Subscribe(AfterLabTestDeleted, true);
            _messageService = messageService;

            LabTestViewModel = labTestViewModel;
            CreateNewTestCommand = new DelegateCommand(OnCreateNewLabTestExecute);
        }



        public ILabTestViewModel LabTestViewModel { get; }
        public ICommand CreateNewTestCommand { get; }

        public ILabTestDetailViewModel LabTestDetailViewModel
        {
            get { return labTestDetailViewModel; }
            private set
            {
                labTestDetailViewModel = value;
                OnPropertyChanged();
            }
        }
        public async void OnOpenTestDetailView(int? testId)
        {
            if(LabTestDetailViewModel!=null && LabTestDetailViewModel.HasChanges)
            {
                if (_messageService.ShowOkCancelDialog("You have made changes. Navigate away?", "Changes") == MessageDialogResult.Cancel)
                    return;
            }
            LabTestDetailViewModel = _labTestDetailViewModelCreator();
            await LabTestDetailViewModel.LoadAsync(testId);
        }

        public async Task LoadAsync()
        {
            await LabTestViewModel.LoadAsync();
        }

        private void OnCreateNewLabTestExecute()
        {
            OnOpenTestDetailView(null);
        }
        private void AfterLabTestDeleted(int id)
        {
            LabTestDetailViewModel = null;
        }
        


    }
}
