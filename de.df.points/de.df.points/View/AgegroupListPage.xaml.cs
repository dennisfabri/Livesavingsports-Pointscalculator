﻿using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using de.df.points.Data;

namespace de.df.points.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgegroupListPage : ContentPage
    {
        public AgegroupListPage()
        {
            InitializeComponent();
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Agegroup ag = ((ListView)sender).SelectedItem as Agegroup;

            if (ag == null)
            {
                return;
            }
            //Deselect Item
            ((ListView)sender).SelectedItem = null;

            PointsController.Instance.Show(ag);
        }
    }
}