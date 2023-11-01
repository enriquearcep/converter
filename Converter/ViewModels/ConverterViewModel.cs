using System.Collections.ObjectModel;
using UnitsNet;

namespace Converter.ViewModels
{
    public class ConverterViewModel
    {
        #region Properties
        public string QuantityName { get; set; }
        public ObservableCollection<string> FromMeasures { get; set; }
        public ObservableCollection<string> ToMeasures { get; set; }
        public string CurrentFromMeasure { get; set; }
        public string CurrentToMeasure { get; set; }
        #endregion

        public ConverterViewModel()
        {
            QuantityName = "Length";
            FromMeasures = LoadMeasures();
            ToMeasures = LoadMeasures();

            CurrentFromMeasure = "Meter";
            CurrentToMeasure = "Centimeter";
        }

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
        #endregion
    }
}