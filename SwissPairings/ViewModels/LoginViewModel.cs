using System.Windows.Input;
using Prism.Commands;
using SwissPairings.Models;
using static SwissPairings.Utilities.SqlHelper;

namespace SwissPairings.ViewModels {
    public class LoginViewModel : BaseViewModel {
        private User UserModel { get; set; }

        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        private bool ValidEntry => !Username.Equals(string.Empty) && !Password.Equals(string.Empty);

        public ICommand LoginCommand => new DelegateCommand<object>(HandleLogin, CanLogin);

        public LoginViewModel() => Title = "Login";

        private void HandleLogin(object context) {
            if (!ValidEntry) {
                ErrorMessage = "All fields must be filled out";
                HasErrors = true;
            } else {
                HasErrors = false;
                ErrorMessage = string.Empty;
                UserModel = new User {
                    Username = Username,
                    Password = Password
                };
                var v = FindWhere(UserModel, null, null);
                Insert(UserModel);
            }
            OnPropertyChanged(nameof(HasErrors));
            OnPropertyChanged(nameof(ErrorMessage));
        }

        private bool CanLogin(object context) => true;
    }
}