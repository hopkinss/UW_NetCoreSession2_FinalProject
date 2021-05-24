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
        public LookupItemViewModel(int id,string displayValue,IEventAggregator eventAggregator)
        {
            Id = id;
            Display = displayValue;
            OpenLabTestDetailViewCommand = new DelegateCommand(OnOpenLabTestDetailView);
            _eventAggregator = eventAggregator;
        }

        private void OnOpenLabTestDetailView()
        {
            _eventAggregator.GetEvent<OpenLabTestDetailViewEvent>().Publish(Id);
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
        public ICommand OpenLabTestDetailViewCommand { get; }

        
    }
}
