using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace de.df.points.Data
{
  public abstract class ViewModelBase : INotifyPropertyChanged
  {
    #region INotifyPropertyChanged

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(params string[] properties)
    {
      if (PropertyChanged != null && properties != null) {
        foreach (string property in properties.Where(s => !string.IsNullOrWhiteSpace(s))) {
          PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
      }
    }

    protected void OnThisPropertyChanged([CallerMemberName] string property = null)
    {
      OnPropertyChanged(property);
    }

    #endregion


  }
}
