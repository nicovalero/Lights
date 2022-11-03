using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using UI.Models.Structs;
using UI.Models.ViewModel_Config_Sets.Interfaces;

namespace UI.Models.ViewModel_Config_Sets.Classes
{
    internal class ColorChangeConfig_VMSet : IConfigVMSet
    {
        private ColorConfig_ViewModel _finalColor;
        public ColorConfig_ViewModel FinalColor { get { return _finalColor; } set { _finalColor = value; } }

        public ColorChangeConfig_VMSet()
        {
        }

        public ColorChangeConfig_VMSet(ColorConfig_ViewModel viewModel)
        {
            _finalColor = viewModel;
        }

        public List<object> GetConfigViewModels()
        {
            List<object> models = new List<object>();
            models.Add(_finalColor);
            return models;
        }
    }
}
