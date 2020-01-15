using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using de.df.points.Data;
using de.df.points.ViewModel;

namespace de.df.points.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgegroupListView : ContentPage
    {
        public AgegroupListView()
        {
            InitializeComponent();
        }

        async void ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //Agegroup ag = ((ListView)sender).SelectedItem as Agegroup;

            //if (ag == null)
            //{
            //    return;
            //}
            ////Deselect Item
            //((ListView)sender).SelectedItem = null;

            //PointsController.Instance.Show(ag);
        }
    }
}
