using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LanGuideCerovac
{
    public partial class HomePage : ContentPage
    {
        IAuth auth;
        public HomePage()
        {
            InitializeComponent();
            auth = DependencyService.Get<IAuth>();
        }

        private async void Button_is_Clicked(object sender, EventArgs E)
        {
            try
            {
                App.Current.MainPage = new UsersPage();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private async void Button_is_Clicked1(object sender, EventArgs E)
        {
            try
            {
                App.Current.MainPage = new ResultsPage();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private async void Button_is_Clicked2(object sender, EventArgs E)
        {
            try
            {
                App.Current.MainPage = new LanguagesPage();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        async void Button_is_Clicked3(object sender, EventArgs E)
        {
            try
            {
                App.Current.MainPage = new MainPage();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}