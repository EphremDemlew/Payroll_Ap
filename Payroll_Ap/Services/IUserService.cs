namespace Payroll_Ap.Services
{
    public interface IUserService
    {
        string GetUserId();
        bool IsAuthenticated();
    }
}