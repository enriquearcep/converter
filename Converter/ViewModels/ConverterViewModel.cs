using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using UnitsNet;

namespace Converter.ViewModels
{
    public class ConverterViewModel : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Properties
        public string QuantityName { get; set; }
        public ObservableCollection<string> FromMeasures { get; set; }
        public ObservableCollection<string> ToMeasures { get; set; }
        public string CurrentFromMeasure { get; set; }
        public string CurrentToMeasure { get; set; }
        public double FromValue { get; set; } = 1;
        #endregion

        #region Full properties
        private double result;

        public double Result
        {
            get
            {
                return result;
            }

            set
            {
                if (result != value)
                {
                    result = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Result)));
                }
            }
        }

        #endregion

        #region Commands
        public ICommand FromValueChangedCommand => new Command(() =>
        {
            Convert();
        });
        #endregion

        #region Constructors
        public ConverterViewModel()
        {
            QuantityName = "Length";
            FromMeasures = LoadMeasures();
            ToMeasures = LoadMeasures();

            CurrentFromMeasure = "Meter";
            CurrentToMeasure = "Centimeter";

            Convert();
        }
        #endregion

        #region Functions
        private ObservableCollection<string> LoadMeasures()
        {
            var types = Quantity.Infos
                .FirstOrDefault(x => x.Name == QuantityName)
                .UnitInfos
                .Select(s => s.Name)
                .ToList();

            return new ObservableCollection<string>(types);
        }

        public void Convert()
        {
            Result = UnitConverter
                .ConvertByName(FromValue, QuantityName, CurrentFromMeasure, CurrentToMeasure);
        }
        #endregion
    }
}