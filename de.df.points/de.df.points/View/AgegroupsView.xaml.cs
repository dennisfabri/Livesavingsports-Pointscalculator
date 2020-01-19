using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using de.df.points.Data;
using de.df.points.ViewModel;

namespace de.df.points.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgegroupsView : ContentPage
    {
        public AgegroupsView()
        {
            InitializeComponent();
        }

        async void ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Agegroup ag = ((ListView)sender).SelectedItem as Agegroup;

            if (ag == null)
            {
                return;
            }

            ((AgegroupsViewModel)BindingContext).Item = null;
            ((AgegroupsViewModel)BindingContext).Item = ag;
        }
    }
}
