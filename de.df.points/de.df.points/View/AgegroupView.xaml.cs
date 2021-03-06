﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using de.df.points.View.Extensions;

namespace de.df.points.View
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class AgegroupView : ContentPage
  {
    private static EntryLengthValidatorBehavior EntryLengthValidator = new EntryLengthValidatorBehavior() { MaxLength = 6 };

    private Entry[] entries;
    private Label[] timeLabels;
    private Label[] pointsLabels;

    public AgegroupView()
    {
      InitializeComponent();

      entries = new Entry[] { Entry1, Entry2, Entry3, Entry4, Entry5, Entry6 };
      timeLabels = new Label[] { TimeLabel1, TimeLabel2, TimeLabel3, TimeLabel4, TimeLabel5, TimeLabel6 };
      pointsLabels = new Label[] { PointsLabel1, PointsLabel2, PointsLabel3, PointsLabel4, PointsLabel5, PointsLabel6 };

      int x = 0;
      foreach (Entry e in entries) {
        e.Behaviors.Add(EntryLengthValidator);
        e.SetBinding(Entry.TextColorProperty, new Binding(string.Format("IsValid{0}", x + 1), BindingMode.OneWay, new IsValidConverter()));

        timeLabels[x].SetBinding(Label.TextColorProperty, new Binding(string.Format("IsValid{0}", x + 1), BindingMode.OneWay, new IsValidConverter()));
        pointsLabels[x].SetBinding(Label.TextColorProperty, new Binding(string.Format("IsValid{0}", x + 1), BindingMode.OneWay, new IsValidConverter()));

        x++;
      }
    }

    private void Entry1Completed(object sender, EventArgs e)
    {
      if (Entry2.IsVisible) {
        Entry2.Focus();
      }
    }

    private void Entry2Completed(object sender, EventArgs e)
    {
      if (Entry3.IsVisible) {
        Entry3.Focus();
      }
    }

    private void Entry3Completed(object sender, EventArgs e)
    {
      if (Entry4.IsVisible) {
        Entry4.Focus();
      }
    }

    private void Entry4Completed(object sender, EventArgs e)
    {
      if (Entry5.IsVisible) {
        Entry5.Focus();
      }
    }

    private void Entry5Completed(object sender, EventArgs e)
    {
      if (Entry6.IsVisible) {
        Entry6.Focus();
      }
    }

    private void Entry6Completed(object sender, EventArgs e)
    {
      // Nothing to do
    }
  }
}