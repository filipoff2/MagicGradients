using MagicGradients;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PlaygroundClassicUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            //magic = new MagicGradients.GradientViewUWP(); 


            var gradients = new GradientBuilder()
                .AddLinearGradient(45)
                .AddStop(Xamarin.Forms.Color.Green, 0.2f)
                .AddStop(Xamarin.Forms.Color.Aqua, 0.9f)
                .AddLinearGradient(90)
                .AddStop(Xamarin.Forms.Color.Blue)
                .AddStop(Xamarin.Forms.Color.DeepPink)
                .Build();

            magic.GradientSource = new MyGradientSource( gradients);
        }
    }
    class MyGradientSource : IGradientSource
    {
        Gradient[] _gradients;
  
        public MyGradientSource(Gradient[] gradients) {
            _gradients = gradients;
        }
        public IEnumerable<Gradient> GetGradients()
        {
            return _gradients;
        }
    }

}
