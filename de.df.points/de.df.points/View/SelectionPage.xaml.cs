using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace de.df.points.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectionPage : ContentPage
    {
        private bool onInitialize = true;

        public SelectionPage()
        {
            InitializeComponent();

            var YearItems = PointsController.Instance.getYears();

            Year.ItemsSource = YearItems;

            Year.SelectedIndex = YearItems.Length - 1;

            onInitialize = false;
        }

        private void OnClicked(object sender, EventArgs e)
        {
            if (onInitialize)
            {
                return;
            }
            PointsController.Instance.Set((int)Year.SelectedItem);
        }
    }
}