using FreshMvvm;
using PropertyChanged;
using Xamarin.Forms;

namespace de.df.points.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    class MiniViewModel : FreshBasePageModel
    {
        public Color Background { get { return Color.LightGray; } }
    }
}