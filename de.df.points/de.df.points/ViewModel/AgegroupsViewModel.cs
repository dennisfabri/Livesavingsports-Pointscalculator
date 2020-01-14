using de.df.points.Data;
using de.df.points.Framework.UI;
using Xamarin.Forms;

namespace de.df.points.ViewModel
{
    class AgegroupsViewModel : ViewModelBase
    {
        public string Title { get; set; }

        private Agegroup[] items;

        public Agegroup[] Items
        {
            get {
                return items;
            }
            set {
                if (items != value)
                {
                    items = value;
                    OnThisPropertyChanged();
                }
            }
        }

        // 03A9F4
        public Color Background { get; } = new Color(3.0 / 255.0, 169.0 / 255.0, 244.0 / 255.0);
    }
}
