using Microsoft.AspNetCore.Identity;
using Payroll_Ap.Models;
using System.Threading.Tasks;

namespace Payroll_Ap.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpEmployeeModel userModel);
         Task<SignInResult> PasswordSignInAsync(SignInModel signInModel);
        Task SignOutAsync();

        Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel model);
    }
}