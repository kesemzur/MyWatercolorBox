using System;
using MyWatercolorBox.ViewModels;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyWatercolorBox
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WatercolorControl : ContentView
    {		

        public WatercolorControl()
        {
            InitializeComponent();
        }

		private void OnPurpleColorSelected(object sender, EventArgs e)
		{
			ViewModelLocator.MainViewModel.SelectedColor = SKColors.MediumPurple;
		}

		private void OnBlueColorSelected(object sender, EventArgs e)
		{
			ViewModelLocator.MainViewModel.SelectedColor = SKColors.SteelBlue;
		}

		private void OnBrownColorSelected(object sender, EventArgs e)
		{
			ViewModelLocator.MainViewModel.SelectedColor = SKColors.SaddleBrown;
		}

		private void OnRedColorSelected(object sender, EventArgs e)
		{
			ViewModelLocator.MainViewModel.SelectedColor = SKColors.Red;
		}

		private void OnBlackColorSelected(object sender, EventArgs e)
		{
			ViewModelLocator.MainViewModel.SelectedColor = SKColors.Black;
		}

		private void OnYellowColorSelected(object sender, EventArgs e)
		{
			ViewModelLocator.MainViewModel.SelectedColor = SKColors.Gold;
		}

		private void OnWhiteColorSelected(object sender, EventArgs e)
		{
			ViewModelLocator.MainViewModel.SelectedColor = SKColors.White;
		}

		private void OnGreenColorSelected(object sender, EventArgs e)
		{
			ViewModelLocator.MainViewModel.SelectedColor = SKColors.MediumSeaGreen;
		}

		private void OnWideBrushSelected(object sender, EventArgs e)
		{
			ViewModelLocator.MainViewModel.SelectedWidth = 50;
		}

		private void OnNarrowBrushSelected(object sender, EventArgs e)
		{
			ViewModelLocator.MainViewModel.SelectedWidth = 25;
		}

		private void OnPencilSelected(object sender, EventArgs e)
		{
			this.PencilSelected();
		}

		internal void PencilSelected()
		{
			ViewModelLocator.MainViewModel.SelectedWidth = 10;
			ViewModelLocator.MainViewModel.SelectedColor = SKColors.DarkSlateGray;
		}

	}
}