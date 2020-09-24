using System.Threading.Tasks;

namespace Mayordomo.Helpers
{
    public interface IDialogs
    {
        Task Show(string message);
        Task Hide();
        Task Snackbar(string message, string title, TypeSnackbar typeSnackbar);
        Task Toast(string message);
    }
    public enum TypeSnackbar
    {
        Error,
        Success
    }
}
