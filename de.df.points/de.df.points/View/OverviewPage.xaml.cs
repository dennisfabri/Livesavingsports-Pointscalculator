using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace de.df.points.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OverviewPage : MasterDetailPage
    {
        private NavigationPage npage = new NavigationPage();

        public OverviewPage()
        {
            InitializeComponent();
            try
            {
                MasterPage.Select = Select;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }
        }

        internal void Show(Page page)
        {
            try
            {
                Navigator np = Detail as Navigator;
                if (np == null)
                {
                    np = new Navigator(page);
                    Detail = np;
                }
                else
                {
                    np.Navigation.PushAsync(page);
                    // np.PopToRootAsync();
                }

                bool isLandscape = this.Width > this.Height;

                if (Device.Idiom == TargetIdiom.Phone || !isLandscape)
                {
                    IsPresented = false;
                }
            }
            catch (Exception)
            {
            }
        }

        internal void Select(int id)
        {
            try
            {
                Page page = PointsController.Instance.GetPage(id);

                Navigator np = Detail as Navigator;
                if (np == null)
                {
                    np = new Navigator(page);
                    Detail = np;
                }
                else
                {
                    np.Navigation.InsertPageBefore(page, np.RootPage);
                    np.PopToRootAsync();
                }

                bool isLandscape = this.Width > this.Height;

                if (Device.Idiom == TargetIdiom.Phone || !isLandscape)
                {
                    IsPresented = false;
                }
            }
            catch (Exception)
            {
            }
        }
    }
}