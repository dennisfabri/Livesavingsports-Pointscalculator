using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace de.df.points.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage
    {
        public AboutPage()
        {
            InitializeComponent();

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) =>
            {
                Launcher.TryOpenAsync(new Uri(((Label)s).Text));
            };
            Hyperlink.GestureRecognizers.Add(tapGestureRecognizer);
        }
    }
}