using Lab.UI.Events;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Lab.UI.ViewModel
{
    public class LookupItemViewModel:ViewModelBase
    {
        private string display;
        private IEventAggregator _eventAggregator;
        private string _detailViewModelName;

        public LookupItemViewModel(int id,string displayValue
            ,string detailViewModelName
            ,IEventAggregator eventAggregator)
        {
            Id = id;
            Display = displayValue;
            OpenDetailViewCommand = new DelegateCommand(OnOpenDetailViewExecute);
            _eventAggregator = eventAggregator;
            _detailViewModelName = detailViewModelName;
        }

        private void OnOpenDetailViewExecute()
        {
            _eventAggregator.GetEvent<OpenDetailViewEvent>()
                .Publish(new OpenDetailViewEventArgs { Id=Id,ViewModelName= _detailViewModelName });
        }

        public int Id { get;}
        public string Display
        {
            get { return display; }
            set
            {
                display = value;
                OnPropertyChanged();
            }
        }
        public ICommand OpenDetailViewCommand { get; }

        
    }
}
