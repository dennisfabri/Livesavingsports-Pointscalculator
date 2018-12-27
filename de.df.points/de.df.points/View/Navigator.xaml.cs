using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace de.df.points.View
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class Navigator
  {
    public Navigator(Page page) : base(page)
    {
      InitializeComponent();
    }

    public Navigator()
    {
      InitializeComponent();
    }
  }
}