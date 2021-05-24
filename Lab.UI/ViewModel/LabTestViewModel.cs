using Lab.Model;
using Lab.UI.Data;
using Lab.UI.Data.Lookups;
using Lab.UI.Events;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.UI.ViewModel
{
    public class LabTestViewModel : ViewModelBase, ILabTestViewModel
    {
        private ILookupDataService _lookupDataService;
        private IEventAggregator _eventAggregator;


        public LabTestViewModel(ILookupDataService lookupService, IEventAggregator eventAggregator)
        {
            _lookupDataService = lookupService;
            LabTests = new ObservableCollection<LookupItemViewModel>();
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<LabTestSavedEvent>().Subscribe(AfterLabTestSaved,true);
            _eventAggregator.GetEvent<AfterLabTestDeletedEvent>().Subscribe(AfterLabTestDeleted,true);

            
        }



        public ObservableCollection<LookupItemViewModel> LabTests { get; }
        

        public async Task LoadAsync()
        {
            await LoadLabTests();

        }



        private void AfterLabTestSaved(AfterLabTestSavedEventArgs obj)
        {
            var item = LabTests.SingleOrDefault(x => x.Id == obj.Id);
            if (item == null)
            {
                LabTests.Add(new LookupItemViewModel(obj.Id,obj.Display,_eventAggregator));
            }
            else
            {
                item.Display = obj.Display;
            }
        }
        private void AfterLabTestDeleted(int id)
        {
            var item = LabTests.SingleOrDefault(x => x.Id == id);
            if (item != null)
            {
                LabTests.Remove(item);
            }
        }
        private async Task LoadLabTests()
        {
            var tests = await _lookupDataService.GetLabLookupAsync();
            LabTests.Clear();
            foreach (var test in tests)
            {
                LabTests.Add(new LookupItemViewModel(test.Id, test.Display, _eventAggregator));
            }
        }


    }
}
