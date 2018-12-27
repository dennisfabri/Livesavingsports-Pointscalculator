using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace de.df.points.Data
{
  class Agegroups : ViewModelBase
  {
    private Agegroup current;
    private Agegroup[] items;

    public Agegroup Current
    {
      get { return current; }
      set {
        if (current != value) {
          current = value;
          OnThisPropertyChanged();
          OnPropertyChanged(nameof(Agegroups.Background));
        }
      }
    }

    public Color Background
    {
      get {
        if (Current == null) {
          // return Color.LightPink;
          if (Items != null && Items.Length > 0) {
            return Items[0].Background;
          }
          return Color.Blue;
        }
        return Current.Background;
      }
    }

    public Agegroup[] Items
    {
      get {
        return items;
      }
      set {
        if (items != value) {
          items = value;
          OnThisPropertyChanged();
          Current = items != null && items.Length > 0 ? items[0] : null;
        }
      }
    }

    internal async void JumpTo(Page page)
    {
      string[] agegroups = Items.Select(s => s.Name).ToArray();
      string action = await page.DisplayActionSheet("Altersklasse auswählen", null, null, agegroups);
      int index = agegroups.Select((ag, Index) => new { ag, Index }).Where(x => x.ag == action).Select(x => x.Index).DefaultIfEmpty(-1).FirstOrDefault();
      if (index >= 0) {
        Current = Items[index];
      }
    }
  }
}
