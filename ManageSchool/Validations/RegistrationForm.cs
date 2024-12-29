using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ManageSchool.Validations
{
    public partial class RegistrationForm : ObservableValidator
    {
        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Username is required.")]
        [MinLength(2, ErrorMessage = "Username must be at least 3 characters long.")]
        [MaxLength(30, ErrorMessage = "Username must be at most 30 characters long.")]
        private string username;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "Password must be between 4 and 30 characters.")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{4,}$", ErrorMessage = "Password must contain at least one digit, one lowercase letter, and one uppercase letter.")]
        string password;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Confirm Password is required.")]
        [CustomValidation(typeof(RegistrationForm), nameof(ValidateConfirmPassword))]
        string confirmPassword;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Email is required.")]
        [StringLength(70, ErrorMessage = "Email must not exceed 70 characters.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format.")]
        string email;
        public RegistrationForm()
        {
            Username = string.Empty;
            Password = string.Empty;
            ConfirmPassword = string.Empty;
            Email = string.Empty;
        }
        public void Clear()
        {
            Username = string.Empty;
            Password = string.Empty;
            ConfirmPassword = string.Empty;
            Email = string.Empty;
        }
        public void ValidateForm()
        {
            ValidateAllProperties();
        }
        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            if(e.PropertyName is not null )
                ValidateProperty(e.PropertyName);
        }
        public static ValidationResult ?ValidateConfirmPassword(string confirmPasswordValue, ValidationContext context)
        {
            var instance = context.ObjectInstance as RegistrationForm;
            if(instance == null || !string.Equals(instance.Password, confirmPasswordValue))
            {
                return new ValidationResult("Passwords do not match", [nameof(ConfirmPassword)]);
            }
            return ValidationResult.Success;
        }
    }
}
