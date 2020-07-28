using System;
using System.Collections.Generic;
using System.Text;

namespace MyWatercolorBox.ViewModels
{
    public static class ViewModelLocator
    {
        private static WatercolorViewModel watercolorModel = new WatercolorViewModel();

        public static WatercolorViewModel MainViewModel
        {
            get
            {
                return watercolorModel;
            }
        }
    }
}
