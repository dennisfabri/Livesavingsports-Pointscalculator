using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace de.df.points.View
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class SelectionPage : ContentPage
  {
    private int[] YearItems = new int[] { 2017, 2018, 2019 };

    private bool onInitialize = true;

    public SelectionPage()
    {
      InitializeComponent();

      Year.ItemsSource = YearItems;

      Year.SelectedIndex = YearItems.Length - 1;

      onInitialize = false;
    }

    private void OnClicked(object sender, EventArgs e)
    {
      if (onInitialize) {
        return;
      }
      PointsController.Instance.Set((int)Year.SelectedItem);
    }
  }
}