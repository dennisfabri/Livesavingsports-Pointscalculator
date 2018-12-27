﻿using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace de.df.points.View
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class OverviewPage : MasterDetailPage
  {
    private NavigationPage npage = new NavigationPage();

    public OverviewPage()
    {
      InitializeComponent();
      try {
        MasterPage.Select = Select;
        // MasterPage.Functions.ItemSelected += ListView_ItemSelected;
        // MasterPage.Options.ItemSelected += ListView_ItemSelected;
      } catch (Exception ex) {
        Debug.WriteLine(ex.Message);
        Debug.WriteLine(ex.StackTrace);
      }
      // Select(0);
    }

    //private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    //{
    //  OverviewPageMenuItem item = e.SelectedItem as OverviewPageMenuItem;
    //  if (item == null) {
    //    return;
    //  }

    //  Select(item.Id);
    //}

    internal void Select(int id)
    {
      try {
        Page page = PointsController.Instance.GetPage(id);

        Navigator np = Detail as Navigator;
        if (np == null) {
          np = new Navigator(page);
          Detail = np;
        } else {
          np.Navigation.InsertPageBefore(page, np.RootPage);
          np.PopToRootAsync();
        }

        bool isLandscape = this.Width > this.Height;

        if (Device.Idiom == TargetIdiom.Phone || !isLandscape) {
          IsPresented = false;
        }
      } catch (Exception) {
      }
    }
  }
}