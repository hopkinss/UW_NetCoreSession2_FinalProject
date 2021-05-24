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
        private IDetailViewModel detailViewModel;
        private IMessageService _messageService;

        public MainViewModel(ILabTestViewModel labTestViewModel, 
            Func<ILabTestDetailViewModel> labTestDetailViewModelCreator,
            IEventAggregator eventAggregator,
            IMessageService messageService
            )
        {            
            _labTestDetailViewModelCreator = labTestDetailViewModelCreator;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<OpenDetailViewEvent>().Subscribe(OnOpenDetailView, true);
            _eventAggregator.GetEvent<AfterDetailDeletedEvent>().Subscribe(AfterDetailDeleted, true);
            _messageService = messageService;

            LabTestViewModel = labTestViewModel;
            CreateNewDetailCommand = new DelegateCommand<Type>(OnCreateNewDetailExecute);
        }



        public ILabTestViewModel LabTestViewModel { get; }
        public ICommand CreateNewDetailCommand { get; }

        public IDetailViewModel DetailViewModel
        {
            get { return detailViewModel; }
            private set
            {
                detailViewModel = value;
                OnPropertyChanged();
            }
        }
        public async void OnOpenDetailView(OpenDetailViewEventArgs args)
        {
            if(DetailViewModel!=null && DetailViewModel.HasChanges)
            {
                if (_messageService.ShowOkCancelDialog("There are unsaved changes for this form. Do you want to continue?", 
                    "Unsaved Changes") == MessageDialogResult.Cancel)
                    return;
            }

            switch (args.ViewModelName)
            {
                case (nameof(LabTestDetailViewModel)):
                    DetailViewModel = _labTestDetailViewModelCreator();
                    break;
                    
            }
            
            await DetailViewModel.LoadAsync(args.Id);
        }

        public async Task LoadAsync()
        {
            await LabTestViewModel.LoadAsync();
        }

        private void OnCreateNewDetailExecute(Type viewModelType)
        {
            OnOpenDetailView(new OpenDetailViewEventArgs { ViewModelName = viewModelType.Name});
        }
        private void AfterDetailDeleted(AfterDetailsDeletedEventArgs args)
        {
            DetailViewModel = null;
        }
        


    }
}
