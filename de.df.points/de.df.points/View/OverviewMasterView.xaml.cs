using System;
using System.Windows.Input;
using de.df.points.Framework.UI;
using de.df.points.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace de.df.points.View
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class OverviewMasterView : ContentPage
  {
    private ToggleButton[] Buttons = new ToggleButton[0];

    public OverviewMasterView()
    {
      InitializeComponent();

      BindingContext = new OverviewMasterViewModel();

      Buttons = new ToggleButton[] {
        Single,Team,
        Doc,Settings,About
      };

      Single.Clicked = () => { MySelect(Single, 0); };
      Team.Clicked = () => { MySelect(Team, 1); };

      Doc.Clicked = () => { MySelect(Doc, 101); };
      Settings.Clicked = () => { MySelect(Settings, 102); };
      About.Clicked = () => { MySelect(About, 103); };
    }

    public Action<int> Select { get; internal set; }

    private void MySelect(ToggleButton source, int id)
    {
      foreach (ToggleButton tb in Buttons) {
        if (tb.Checked && tb != source) {
          tb.Checked = false;
        }
      }
      Select(id);
    }

    private void SingleClicked(object sender, SelectedItemChangedEventArgs e)
    {
      Select(0);
    }

    private void TeamClicked(object sender, SelectedItemChangedEventArgs e)
    {
      Select(1);
    }
  }
}