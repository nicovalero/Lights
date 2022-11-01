using PhilipsHue.EffectConfig.Creators.Classes;
using System.Windows.Media;
using UI.Models.Structs;

namespace Control.Controllers
{
    public static class EffectConfigSetCreator
    {
        public static object CreateConfigSet(object viewModel)
        {
            switch(viewModel)
            {
                case ColorConfig_ViewModel colorConfig:
                    return CreateColorChangeConfigSet((ColorConfig_ViewModel)viewModel);
                default:
                    return null;
            }
        }
        private static ColorChangeConfigSet CreateColorChangeConfigSet(ColorConfig_ViewModel colorConfig)
        {
            if (colorConfig.SelectedColor.HasValue)
            {
                Color value = colorConfig.SelectedColor.Value;
                var color = System.Drawing.Color.FromArgb(value.A, value.R, value.G, value.B);
                return new ColorChangeConfigSet(color);
            }
            else
                return null;
        }
    }
}
