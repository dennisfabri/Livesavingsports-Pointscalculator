using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace de.df.points.View.Extensions
{
  public class EntryLengthValidatorBehavior : Behavior<Entry>
  {
    private static HashSet<char> validChars = new HashSet<char>(new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' });

    public int MaxLength { get; set; }

    protected override void OnAttachedTo(Entry bindable)
    {
      base.OnAttachedTo(bindable);
      bindable.TextChanged += OnEntryTextChanged;
    }

    protected override void OnDetachingFrom(Entry bindable)
    {
      base.OnDetachingFrom(bindable);
      bindable.TextChanged -= OnEntryTextChanged;
    }

    private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
    {
      try {
        var entry = (Entry)sender;

        if (entry.Text == null) {
          return;
        }

        if (entry.Text.Length > MaxLength || entry.Text.ToCharArray().Any(c => !validChars.Contains(c))) {
          string entryText = entry.Text;
          entry.TextChanged -= OnEntryTextChanged;
          entry.Text = e.OldTextValue;
          entry.TextChanged += OnEntryTextChanged;
        }
      } catch (Exception) {
        // Nothing to do
      }
    }
  }
}
