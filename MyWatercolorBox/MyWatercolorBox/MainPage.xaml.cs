using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms.DualScreen;
using MyWatercolorBox.ViewModels;

namespace MyWatercolorBox
{
	[DesignTimeVisible(false)]
	public partial class MainPage : ContentPage
	{
		bool wasSpanned = false;

		public MainPage()
		{
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			DualScreenInfo.Current.PropertyChanged += DualScreen_PropertyChanged;
			UpdateLayouts(); // for first page load
		}
		protected override void OnDisappearing()
		{
			DualScreenInfo.Current.PropertyChanged -= DualScreen_PropertyChanged;
			base.OnDisappearing();
		}

		void DualScreen_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			UpdateLayouts();
		}

		async void UpdateLayouts()
		{
			if (DeviceIsSpanned || DeviceIsBigScreen)
			{   // two screens: side by side
				twoPaneView.TallModeConfiguration = TwoPaneViewTallModeConfiguration.TopBottom;
				twoPaneView.WideModeConfiguration = TwoPaneViewWideModeConfiguration.LeftRight;
				this.singlePaneView.IsVisible = false;
				this.twoPaneView.IsVisible = true;
				wasSpanned = true;
			}
			else
			{   // single-screen: only list is shown
				twoPaneView.PanePriority = TwoPaneViewPriority.Pane1;
				twoPaneView.TallModeConfiguration = TwoPaneViewTallModeConfiguration.SinglePane;
				twoPaneView.WideModeConfiguration = TwoPaneViewWideModeConfiguration.SinglePane;
				// wasSpanned check is needed, or this will open on first-run or rotation
				// stack count is needed, or we might push multiple on rotation
				if (wasSpanned && Navigation.NavigationStack.Count == 1)
				{   // open the detail page
					this.singlePaneView.IsVisible = true;
					this.twoPaneView.IsVisible = false;
				}
				wasSpanned = false;
			}
		}

		bool DeviceIsSpanned => DualScreenInfo.Current.SpanMode != TwoPaneViewMode.SinglePane;
		bool DeviceIsBigScreen => (Device.Idiom == TargetIdiom.Tablet) || (Device.Idiom == TargetIdiom.Desktop);
	}
}