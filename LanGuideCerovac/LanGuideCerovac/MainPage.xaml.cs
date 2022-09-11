using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using Xamarin.Forms.Xaml;

namespace LanGuideCerovac
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        IAuth auth;
        public MainPage()
        {
            InitializeComponent();
            auth = DependencyService.Get<IAuth>();
        }

        async void Login_Button_Clicked(object sender, EventArgs e)
        {
            string token = await auth.LoginWithEmailAndPassword(EntryEmail.Text, EntryPassword.Text);
            if (token != "")
            {
                Application.Current.MainPage = new HomePage();
            }
            else
            {
                await DisplayAlert("Login failed", "Entered data is incorrect", "OK");
            }

        }
    }
}
