using de.df.points.Data;
using de.df.points.View;
using de.df.points.ViewModel;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace de.df.points
{
    class PointsController
    {
        private AgegroupView agegroupPage;
        private SettingsView settingsPage;
        private AboutView aboutPage;
        private IntroductionView introductionPage;

        private AgegroupsView agegroupsSingle;
        private AgegroupsView agegroupsTeam;

        private AgegroupViewModel agegroupViewModel;

        private AgegroupViewModel AgegroupViewModel
        {
            get {
                if (agegroupViewModel == null)
                {
                    agegroupViewModel = new AgegroupViewModel();
                }
                return agegroupViewModel;
            }
        }

        private OverviewView OverviewPage { get; set; }

        private AgegroupsViewModel agegroupsSingleVM;

        private AgegroupsViewModel AgegroupsSingleVM
        {
            get {
                if (agegroupsSingleVM == null)
                {
                    agegroupsSingleVM = new AgegroupsViewModel();
                    agegroupsSingleVM.Title = "Einzel";
                }
                return agegroupsSingleVM;
            }
        }
        private AgegroupsViewModel agegroupsTeamVM;

        private AgegroupsViewModel AgegroupsTeamVM
        {
            get {
                if (agegroupsTeamVM == null)
                {
                    agegroupsTeamVM = new AgegroupsViewModel();
                    agegroupsTeamVM.Title = "Einzel";
                }
                return agegroupsTeamVM;
            }
        }

        private AgegroupsView AgegroupsSingle
        {
            get {
                if (agegroupsSingle == null)
                {
                    agegroupsSingle = new AgegroupsView();
                    AgegroupsSingleVM.Items.ReplaceRange(DataModel.GetCurrentSingle());
                    agegroupsSingle.BindingContext = AgegroupsSingleVM;
                }
                return agegroupsSingle;
            }
        }
        private AgegroupsView AgegroupsTeam
        {
            get {
                if (agegroupsTeam == null)
                {
                    agegroupsTeam = new AgegroupsView();
                    AgegroupsTeamVM.Items.ReplaceRange(DataModel.GetCurrentTeam());
                    agegroupsTeam.BindingContext = AgegroupsTeamVM;
                }
                return agegroupsTeam;
            }
        }

        private NavigationPage NavigationPage { get { return (NavigationPage)OverviewPage.Detail; } }

        private AgegroupView AgegroupPage
        {
            get {
                if (agegroupPage == null)
                {
                    agegroupPage = new AgegroupView();
                    agegroupPage.BindingContext = AgegroupViewModel;
                }
                return agegroupPage;
            }
        }

        internal void Start()
        {
            OverviewPage.Select(0);
        }

        internal void Show(Agegroup ag)
        {
            AgegroupViewModel.Data = ag;
            OverviewPage.Show(AgegroupPage);
        }


        private SettingsView SettingsPage
        {
            get {
                if (settingsPage == null)
                {
                    settingsPage = new SettingsView()
                    {
                        BindingContext = new SettingsViewModel()
                    };
                }
                return settingsPage;
            }
        }

        internal Page GetPage(int id)
        {
            switch (id)
            {
                case 0:
                    return AgegroupsSingle;
                case 1:
                    return AgegroupsTeam;
                case 101:
                    return IntroductionPage;
                case 102:
                    return SettingsPage;
                default:
                    return AboutPage;
            }
        }

        private AboutView AboutPage
        {
            get {
                if (aboutPage == null)
                {
                    aboutPage = new AboutView()
                    {
                        BindingContext = new AboutViewModel()
                    };
                }
                return aboutPage;
            }
        }

        private IntroductionView IntroductionPage
        {
            get {
                if (introductionPage == null)
                {
                    introductionPage = new IntroductionView()
                    {
                        BindingContext = new IntroductionViewModel()
                    };
                }
                return introductionPage;
            }
        }

        public static PointsController Instance { get; } = new PointsController();

        public PointsController()
        {
            OverviewPage = new OverviewView();
            bool introduce = GetInt("FirstStart") < 1;
#if DEBUG
            introduce = true;
#endif
            if (introduce)
            {
                NavigationPage.PushAsync(IntroductionPage);
                SetInt("FirstStart", 1);
            }
        }

        private int GetInt(string key, int fallback = 0)
        {
            int result;
            object value;
            if (Application.Current.Properties.TryGetValue(key, out value) && (value is int))
            {
                result = (int)value;
            }
            else
            {
                result = fallback;
            }
            return result;
        }

        private void SetInt(string key, int value)
        {
            Application.Current.Properties[key] = value;
        }

        internal Page GetMainPage()
        {
            return OverviewPage;
        }

        internal int[] getYears()
        {
            return DataModel.GetYears();
        }

        internal void Set(int year)
        {
            AgegroupsSingleVM.Items.ReplaceRange(DataModel.GetSingle(year));
            AgegroupsTeamVM.Items.ReplaceRange(DataModel.GetTeam(year));
        }

        internal void Back()
        {
            NavigationPage.PopAsync();
        }
    }
}