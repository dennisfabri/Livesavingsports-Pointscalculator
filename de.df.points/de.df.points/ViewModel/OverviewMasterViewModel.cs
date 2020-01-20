using de.df.points.Layer;
using PropertyChanged;
using System.Collections.ObjectModel;

namespace de.df.points.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    internal class OverviewMasterViewModel
    {
        public ObservableCollection<ItemLayer> FunctionsMenuItems { get; set; }
        public ObservableCollection<ItemLayer> OptionsMenuItems { get; set; }

        public OverviewMasterViewModel()
        {
            FunctionsMenuItems = new ObservableCollection<ItemLayer>(new[] {
                    new ItemLayer { Id = 0, Title = "Einzel"},
                    new ItemLayer { Id = 1, Title = "Mannschaft" },
                });
            OptionsMenuItems = new ObservableCollection<ItemLayer>(new[] {
                    new ItemLayer { Id = 101, Title = "Bedienung" },
                    new ItemLayer { Id = 102, Title = "Einstellungen" },
                    new ItemLayer { Id = 103, Title = "Über" },
                });
        }
    }
}