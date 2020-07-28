using System;
using System.Collections.Generic;

using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyWatercolorBox.ViewModels;

namespace MyWatercolorBox
{

	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CanvasControl : ContentView
	{
		
		public CanvasControl()
		{
			InitializeComponent();
		}

		private void OnPainting(object sender, SKPaintSurfaceEventArgs e)
		{
			// we get the current surface from the event args
			var surface = e.Surface;
			// then we get the canvas that we can draw on
			var canvas = surface.Canvas;
			// clear the canvas / view
			canvas.Clear(SKColors.Linen);


			// draw the paths
			foreach (var id in ViewModelLocator.MainViewModel.TemporaryPaths.Keys)
			{
				canvas.DrawPath(ViewModelLocator.MainViewModel.TemporaryPaths[id], ViewModelLocator.MainViewModel.TemporaryStrokes[id]);
			}
			foreach (var touchPath in ViewModelLocator.MainViewModel.Paths.Keys)
			{
				canvas.DrawPath(touchPath, ViewModelLocator.MainViewModel.Paths[touchPath]);
			}
		}

		private void OnTouch(object sender, SKTouchEventArgs e)
		{
			var touchPathStroke = new SKPaint
			{
				IsAntialias = true,
				Style = SKPaintStyle.Stroke,
				Color = ViewModelLocator.MainViewModel.SelectedColor,
				//BlendMode = SKBlendMode.Overlay,
				StrokeWidth = ViewModelLocator.MainViewModel.SelectedWidth
			};

			switch (e.ActionType)
			{
				case SKTouchAction.Pressed:
					// start of a stroke
					var p = new SKPath();
					p.MoveTo(e.Location);
					ViewModelLocator.MainViewModel.TemporaryPaths[e.Id] = p;
					ViewModelLocator.MainViewModel.TemporaryStrokes[e.Id] = touchPathStroke;
					break;
				case SKTouchAction.Moved:
					// the stroke, while pressed
					if (e.InContact && ViewModelLocator.MainViewModel.TemporaryPaths.TryGetValue(e.Id, out var moving))
						moving.LineTo(e.Location);
					break;
				case SKTouchAction.Released:
					// end of a stroke
					if (ViewModelLocator.MainViewModel.TemporaryPaths.TryGetValue(e.Id, out var releasing))
					{
						ViewModelLocator.MainViewModel.Paths.Add(releasing, touchPathStroke);

					}
					ViewModelLocator.MainViewModel.TemporaryPaths.Remove(e.Id);
					break;
				case SKTouchAction.Cancelled:
					// we don't want that stroke
					ViewModelLocator.MainViewModel.TemporaryPaths.Remove(e.Id);
					break;
			}

			// update the UI
			if (e.InContact)
				((SKCanvasView)sender).InvalidateSurface();

			// we have handled these events
			e.Handled = true;
		}
	}
}