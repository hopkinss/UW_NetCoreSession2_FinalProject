using Lab.Model;
using Lab.UI.Data;
using Lab.UI.Data.Lookups;
using Lab.UI.Data.Repository;
using Lab.UI.Events;
using Lab.UI.ModelWrapper;
using Lab.UI.Utility;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab.UI.ViewModel
{
    public class LabTestDetailViewModel :DetailViewModelBase, ILabTestDetailViewModel
    {
        private ILabTestRepository _labTestRespository;

        private LabTestWrapper labTest;
        private IMessageService _messageService;
        private ILookupDataService _lookupDataService;
        private LabTestRefernceRangeWrapper selectedReferenceRange;

        public LabTestDetailViewModel(ILabTestRepository labTestRepository,
            IEventAggregator eventAggregator,
            IMessageService messageService,
            ILookupDataService lookupDataService):base(eventAggregator)
        {
            _labTestRespository = labTestRepository;

            _messageService = messageService;
            CdiscTestCds = new ObservableCollection<LookupItem>();
            Units = new ObservableCollection<LookupItem>();
            _lookupDataService = lookupDataService;
            ReferenceRanges = new ObservableCollection<LabTestRefernceRangeWrapper>();
            AddReferenceRangeCommand = new DelegateCommand(OnAddReferenceRangeExecute);
            RemoveReferenceRangeCommand = new DelegateCommand(OnRemoveReferenceRangeExecute, CanRemoveReferenceRangeExecute);

        }

        public ObservableCollection<LookupItem> CdiscTestCds { get; }
        public ObservableCollection<LookupItem> Units { get; }
        public ObservableCollection<LabTestRefernceRangeWrapper> ReferenceRanges { get; }
        public LabTestRefernceRangeWrapper SelectedReferenceRange
        {
            get { return selectedReferenceRange; }
            set
            {
                selectedReferenceRange = value;
                OnPropertyChanged();
                ((DelegateCommand)RemoveReferenceRangeCommand).RaiseCanExecuteChanged();
            }
        }

        public ICommand AddReferenceRangeCommand { get; }
        public ICommand RemoveReferenceRangeCommand { get; }

        public LabTestWrapper LabTest
        {
            get { return labTest; }
            set
            {
                labTest = value;
                OnPropertyChanged();
            }
        }

        public override async Task LoadAsync(int? testId)
        {
            var labTest = testId.HasValue ? await _labTestRespository.GetByIdAsync(testId.Value)
                : CreateNewLabTest();

            InitLabTest(labTest);
            InitLabTestReferenceRanges(labTest.ReferenceRanges);

            await LoadCdiscTestCodes();
            await LoadUnits();
        }

        private void InitLabTestReferenceRanges(ICollection<LabTestRefRange> ranges)
        {
            foreach(var rr in ReferenceRanges)
            {
                rr.PropertyChanged -= LabTestReferenceRangesWrapper_PropertyChanged;
            }
            ReferenceRanges.Clear();
            foreach (var rr in ranges)
            {
                var wr = new LabTestRefernceRangeWrapper(rr);
                ReferenceRanges.Add(wr);
                wr.PropertyChanged += LabTestReferenceRangesWrapper_PropertyChanged;                
            }
        }
        private void LabTestReferenceRangesWrapper_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (!HasChanges)
            {
                HasChanges = _labTestRespository.HasChanges();
            }
            if (e.PropertyName == nameof(LabTestRefernceRangeWrapper.HasErrors))
            {
                ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
            }
        }
        private void InitLabTest(LabTest labTest)
        {
            LabTest = new LabTestWrapper(labTest);

            LabTest.PropertyChanged += (s, e) =>
            {
                if (!HasChanges)
                {
                    HasChanges = _labTestRespository.HasChanges();
                }
                if (e.PropertyName == nameof(LabTest.HasErrors))
                {
                    ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                }
            };
            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
            if (LabTest.Id == 0)
            {
                LabTest.TestName = String.Empty;
                LabTest.Specimen = (SpecimenType)(-1);
            }
        }
        private async Task LoadCdiscTestCodes()
        {
            CdiscTestCds.Clear();
            CdiscTestCds.Add(new NullLookupItem() { Display = "-none-" });
            var codes = await _lookupDataService.GetCdiscTestCodeLookupAsync();
            foreach (var code in codes)
            {
                CdiscTestCds.Add(code);
            }
        }

        private async Task LoadUnits()
        {
            Units.Clear();
            Units.Add(new NullLookupItem() { Display = "-none-" });
            var units = await _lookupDataService.GetUnitsLookupAsync();
            foreach (var unit in units)
            {
                Units.Add(unit);
            }
        }

        protected override async void OnSaveExecute()
        {
            await _labTestRespository.SaveAsync();
            HasChanges = _labTestRespository.HasChanges();
            RaiseDetailSavedEvent(LabTest.Id, labTest.TestName);
        }

        protected override bool OnSaveCanExectute()
        {
            return LabTest != null && !LabTest.HasErrors && HasChanges 
                && ReferenceRanges.All(x=>!x.HasErrors);
        }

        private LabTest CreateNewLabTest()
        {
            var test = new LabTest() { Specimen = (SpecimenType)(-1) };
            _labTestRespository.Add(test);
            return test;
        }


        protected override async void OnDeleteExecute()
        {
            if (_messageService.ShowOkCancelDialog($"Are you sure you want to delete {LabTest.Model.TestName}?", "Confirm delete") ==
                MessageDialogResult.Cancel)
                return;

            _labTestRespository.Remove(LabTest.Model);
            await _labTestRespository.SaveAsync();
            RaiseDetailDeletedEvent(LabTest.Id);
        }

        private void OnRemoveReferenceRangeExecute()
        {
            SelectedReferenceRange.PropertyChanged -= LabTestReferenceRangesWrapper_PropertyChanged;
            _labTestRespository.RemoveReferenceRange(SelectedReferenceRange.Model);
            ReferenceRanges.Remove(SelectedReferenceRange);
            SelectedReferenceRange = null;
            HasChanges = _labTestRespository.HasChanges();
            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
        }

        private void OnAddReferenceRangeExecute()
        {
            var range = new LabTestRefernceRangeWrapper(new LabTestRefRange());
            range.PropertyChanged += LabTestReferenceRangesWrapper_PropertyChanged;
            ReferenceRanges.Add(range);
            LabTest.Model.ReferenceRanges.Add(range.Model);
            range.Sex = Sex.All;
        }
        private bool CanRemoveReferenceRangeExecute()
        {
            return SelectedReferenceRange != null;
        }
    }
}
