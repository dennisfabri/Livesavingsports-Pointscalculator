using PropertyChanged;
using Xamarin.Forms;

namespace de.df.points.ViewModel.Extension
{
    [AddINotifyPropertyChangedInterface]
    abstract class MiniViewModel
    {
        public Color Background { get { return Color.LightGray; } }
    }
}