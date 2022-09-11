using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using Xamarin.Forms;

namespace LanGuideCerovac
{
    public interface IAuth
    {
        Task<string> SignUpWithEmailAndPassword(string email, string password);
        Task<string> LoginWithEmailAndPassword(string email, string password);
        bool SignOut();
        bool IsSignIn();
    }
}
