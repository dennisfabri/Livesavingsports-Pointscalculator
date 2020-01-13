﻿using de.df.points.Data;
using de.df.points.View;
using System;
using System.Linq;
using Xamarin.Forms;

namespace de.df.points
{
    class PointsController
    {
        private OverviewPage OverviewPage { get; set; }

        private AgegroupListPage AgegroupsSingle
        {
            get {
                if (agegroupsSingle == null)
                {
                    agegroupsSingle = new AgegroupListPage();
                    AgegroupsSingleData = new Agegroups();
                    AgegroupsSingleData.Title = "Einzel";
                    AgegroupsSingleData.Items = DataModel.GetCurrentSingle();
                    agegroupsSingle.BindingContext = AgegroupsSingleData;
                }
                return agegroupsSingle;
            }
        }
        private AgegroupListPage AgegroupsTeam
        {
            get {
                if (agegroupsTeam == null)
                {
                    agegroupsTeam = new AgegroupListPage();
                    AgegroupsTeamData = new Agegroups();
                    AgegroupsTeamData.Title = "Mannschaft";
                    AgegroupsTeamData.Items = DataModel.GetCurrentTeam();
                    agegroupsTeam.BindingContext = AgegroupsTeamData;
                }
                return agegroupsTeam;
            }
        }

        private NavigationPage NavigationPage { get { return (NavigationPage)OverviewPage.Detail; } }

        private AgegroupPage AgegroupPage
        {
            get {
                if (agegroupPage == null)
                {
                    agegroupPage = new AgegroupPage();
                }
                return agegroupPage;
            }
        }

        internal void Start()
        {
            OverviewPage.Select(0);
        }

        private AgegroupPage agegroupPage;
        private SettingsPage settingsPage;
        private AboutPage aboutPage;
        private IntroductionPage introductionPage;

        private AgegroupListPage agegroupsSingle;
        private AgegroupListPage agegroupsTeam;

        private Agegroups AgegroupsSingleData { get; set; }
        private Agegroups AgegroupsTeamData { get; set; }

        internal void Show(Agegroup ag)
        {
            AgegroupPage.BindingContext = ag;

            OverviewPage.Show(AgegroupPage);
        }


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
            OverviewPage = new OverviewPage();
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