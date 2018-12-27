using Xamarin.Forms.Xaml;

namespace de.df.points.Framework.UI
{
  public partial class ToggleView
  {
    public string Text
    {
      get {
        return MyText.Text;
      }
      set {
        MyText.Text = value;
      }
    }

    public ToggleView()
    {
      InitializeComponent();
    }
  }
}