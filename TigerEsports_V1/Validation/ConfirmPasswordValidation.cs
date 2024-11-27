using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TigerEsports_V1.Validation
{
    public class ConfirmPasswordValidation : Behavior<Entry>
    {

        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);

            bindable.TextChanged += BindableOnTextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);

            bindable.TextChanged -= BindableOnTextChanged;
        }

        private void BindableOnTextChanged(object? sender, TextChangedEventArgs e)
        {
            var Password = e.NewTextValue;
            var entry = sender as Entry;

            if (entry != null)
            {
                ValidationVault.RegConfirmPassword = ConfirmPasswordIsValid(Password);
                entry.TextColor = ValidationVault.RegConfirmPassword ? Color.FromArgb("000000") : Color.FromArgb("FF0000");
            }
        }

        private bool ConfirmPasswordIsValid(string password)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(ValidationVault.StoredPasswordValidation)) return false;
            return ValidationVault.StoredPasswordValidation.Equals(password);
        }
    }
}
