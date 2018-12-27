using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace de.df.points.View
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class IntroductionPage
  {
    public IntroductionPage()
    {
      InitializeComponent();
    }

    private void OnClicked(object sender, System.EventArgs e)
    {
      PointsController.Instance.Back();
    }
  }
}