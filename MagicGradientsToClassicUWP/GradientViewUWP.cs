using MagicGradients.Renderers;
using SkiaSharp;
using SkiaSharp.Views.UWP;
using System;
using Windows.UI.Xaml;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

namespace MagicGradients
{
    [ContentProperty(nameof(GradientSource))]
    public class GradientViewUWP : SKXamlCanvas
    {
        static GradientViewUWP()
        {
            StyleSheets.RegisterStyle("background", typeof(GradientViewUWP), nameof(GradientSourceProperty));
        }

        public static readonly DependencyProperty GradientSourceProperty = DependencyProperty.Register(nameof(GradientSource),
            typeof(IGradientSource), typeof(GradientViewUWP), new PropertyMetadata(null, new PropertyChangedCallback((x, y) =>
            {
                var GradientViewUWP = (GradientViewUWP)x;
                GradientViewUWP.Invalidate();
            })
                ));

        public IGradientSource GradientSource
        {
            get => (IGradientSource)GetValue(GradientSourceProperty);
            set => this.SetValue(GradientSourceProperty, value);
        }

        private IGradientSource GetValue(BindableProperty gradientSourceProperty)
        {
            CssGradientSource gradientSource = new CssGradientSource();
            gradientSource.BindingContext = gradientSourceProperty;
            return gradientSource;
        }

        protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            base.OnPaintSurface(e);

            var canvas = e.Surface.Canvas;
            canvas.Clear();

            if (GradientSource == null)
                return;

            using (var paint = new SKPaint())
            {
                var context = new RenderContext(canvas, paint, e.Info);

                foreach (var gradient in GradientSource.GetGradients())
                {
                    gradient.Measure(e.Info.Width, e.Info.Height);
                    gradient.Render(context);
                }
            }
        }
    }
}
