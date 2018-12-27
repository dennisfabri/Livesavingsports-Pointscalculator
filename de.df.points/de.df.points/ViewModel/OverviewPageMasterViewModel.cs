using de.df.points.Layer;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace de.df.points.ViewModel
{
  internal class OverviewPageMasterViewModel : INotifyPropertyChanged
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

    #region INotifyPropertyChanged Implementation

    public event PropertyChangedEventHandler PropertyChanged;

    void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
      if (PropertyChanged == null) {
        return;
      }

      PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion
  }
}