using de.df.points.Data;
using de.df.points.View;
using System;
using System.Linq;
using Xamarin.Forms;

namespace de.df.points
{
    class PointsController
    {
        private OverviewPage OverviewPage { get; set; }

        private AgegroupListPage AgegroupsSingle { get; set; }
        private AgegroupListPage AgegroupsTeam { get; set; }

        private NavigationPage NavigationPage { get { return (NavigationPage)OverviewPage.Detail; } }

        internal void Start()
        {
            OverviewPage.Select(0);
        }

        private SettingsPage settingsPage;
        private AboutPage aboutPage;
        private IntroductionPage introductionPage;

        private Agegroups AgegroupsSingleData { get; set; }

        internal void Show(Agegroup ag)
        {
            Page page = new AgegroupPage();
            page.BindingContext = ag;

            OverviewPage.Show(page);
        }

        private Agegroups AgegroupsTeamData { get; set; }

        private SettingsPage SettingsPage
        {
            get {
                if (settingsPage == null)
                {
                    settingsPage = new SettingsPage()
                    {
                        BindingContext = new MiniModel()
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

        private AboutPage AboutPage
        {
            get {
                if (aboutPage == null)
                {
                    aboutPage = new AboutPage()
                    {
                        BindingContext = new MiniModel()
                    };
                }
                return aboutPage;
            }
        }

        private IntroductionPage IntroductionPage
        {
            get {
                if (introductionPage == null)
                {
                    introductionPage = new IntroductionPage()
                    {
                        BindingContext = new MiniModel()
                    };
                }
                return introductionPage;
            }
        }

        public static PointsController Instance { get; } = new PointsController();

        public PointsController()
        {
            AgegroupsSingle = new AgegroupListPage();
            AgegroupsTeam = new AgegroupListPage();
            OverviewPage = new OverviewPage();

            AgegroupsSingleData = new Agegroups();
            AgegroupsSingleData.Title = "Einzel";
            AgegroupsSingleData.Items = DataModel.GetCurrentSingle();
            AgegroupsSingle.BindingContext = AgegroupsSingleData;

            AgegroupsTeamData = new Agegroups();
            AgegroupsTeamData.Title = "Mannschaft";
            AgegroupsTeamData.Items = DataModel.GetCurrentTeam();
            AgegroupsTeam.BindingContext = AgegroupsTeamData;

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
            AgegroupsSingleData.Items = DataModel.GetSingle(year);
            AgegroupsTeamData.Items = DataModel.GetTeam(year);
        }

        internal void Back()
        {
            NavigationPage.PopAsync();
        }
    }
}
