using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using SkiaSharp;
using SkiaSharp.Views.Forms;


namespace MyWatercolorBox.ViewModels
{
    public class WatercolorViewModel : ViewModelBase
    {
        public int SelectedWidth { get; internal set; } = 10;

        public SKColor SelectedColor { get; internal set; } = SKColors.Black;

        public Dictionary<long, SKPath> TemporaryPaths { get; internal set; } = new Dictionary<long, SKPath>();
        public Dictionary<long, SKPaint> TemporaryStrokes { get; internal set; } = new Dictionary<long, SKPaint>();

        public Dictionary<SKPath, SKPaint> Paths { get; internal set; } = new Dictionary<SKPath, SKPaint>();
    }
}
