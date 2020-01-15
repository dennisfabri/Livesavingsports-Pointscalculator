using de.df.points.Data;
using de.df.points.Framework.VM;
using FreshMvvm;
using PropertyChanged;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace de.df.points.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class AgegroupsViewModel : FreshBasePageModel
    {
        public string Title { get; set; }

        private ObservableCollection<Agegroup> items;
        private Agegroup item;

        public ObservableRangeCollection<Agegroup> Items { get; } = new ObservableRangeCollection<Agegroup>();

        public Agegroup Item
        {
            get { return item; }
            set {
                if (item != value)
                {
                    item = value;

                    if (item != null)
                    {
                        PointsController.Instance.Show(item);
                    }
                }
            }
        }

        // 03A9F4
        public Color Background { get; } = new Color(3.0 / 255.0, 169.0 / 255.0, 244.0 / 255.0);

        protected override void ViewIsDisappearing(object sender, EventArgs e)
        {
            base.ViewIsDisappearing(sender, e);
        }
    }
}
