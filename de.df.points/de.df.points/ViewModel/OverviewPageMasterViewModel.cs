using de.df.points.Framework.UI;
using de.df.points.Layer;
using System.Collections.ObjectModel;

namespace de.df.points.ViewModel
{
  internal class OverviewPageMasterViewModel : ViewModelBase
  {
    public ObservableCollection<ItemLayer> FunctionsMenuItems { get; set; }
    public ObservableCollection<ItemLayer> OptionsMenuItems { get; set; }

    public OverviewPageMasterViewModel()
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