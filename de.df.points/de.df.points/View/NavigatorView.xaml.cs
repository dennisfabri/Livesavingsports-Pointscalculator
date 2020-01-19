using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace de.df.points.View
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class NavigatorView
  {
    public NavigatorView(Page page) : base(page)
    {
      InitializeComponent();
    }

    public NavigatorView()
    {
      InitializeComponent();
    }
  }
}