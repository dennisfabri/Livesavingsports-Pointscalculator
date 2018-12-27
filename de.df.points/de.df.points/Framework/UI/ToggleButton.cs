using Xamarin.Forms;
using System.Windows.Input;
using System;

namespace de.df.points.Framework.UI
{
    public class ToggleButton : ContentView
    {
        public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(ToggleButton), null);

        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(ToggleButton), null);

        public static readonly BindableProperty CheckedProperty = BindableProperty.Create(nameof(Checked), typeof(bool), typeof(ToggleButton), null, BindingMode.OneWay, null, CheckedChanged);

        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(ToggleButton), null, BindingMode.OneWay, null, TextChanged);

        public Action Clicked { get; set; }

        private ICommand _toggleCommand;

        public ToggleButton()
        {
            Initialize();
            CheckedView = new ToggleView()
            {
                BackgroundColor = Color.LightGray
            };
            UncheckedView = new ToggleView()
            {
                BackgroundColor = Color.Transparent
            };
        }

        private static void CheckedChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ToggleButton tb = bindable as ToggleButton;
            if (tb != null)
            {
                if (tb.Content == tb.UncheckedView)
                {
                    tb.Content = tb.CheckedView;
                }
                else
                {
                    tb.Content = tb.UncheckedView;
                }
            }
        }

        private static void TextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ToggleButton tb = bindable as ToggleButton;
            if (tb != null)
            {
                if (tb.CheckedView != null)
                {
                    tb.CheckedView.Text = newValue.ToString();
                }
                if (tb.UncheckedView != null)
                {
                    tb.UncheckedView.Text = newValue.ToString();
                }
            }
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public bool Checked
        {
            get { return (bool)GetValue(CheckedProperty); }
            set { SetValue(CheckedProperty, value); }
        }

        private ToggleView CheckedView { get; set; }

        private ToggleView UncheckedView { get; set; }

        public ICommand ToogleCommand
        {
            get {
                return _toggleCommand ?? (_toggleCommand = new Command(
                  () =>
                  {
                      Checked = true;
                      Clicked?.Invoke();
                      Command?.Execute(CommandParameter);
                  }
                ));
            }
        }

        private void Initialize()
        {
            GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = ToogleCommand
            });
            Content = Checked ? CheckedView : UncheckedView;
        }

        protected override void OnParentSet()
        {
            base.OnParentSet();
            Content = Checked ? CheckedView : UncheckedView;
        }
    }
}
