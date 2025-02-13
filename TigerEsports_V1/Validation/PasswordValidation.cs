﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TigerEsports_V1.Validation
{
    public class PasswordValidation : Behavior<Entry>
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
                ValidationVault.RegPassword = IsPasswordValid(Password);
                entry.TextColor = ValidationVault.RegPassword ? Color.FromArgb("000000") : Color.FromArgb("FF0000");   
            }
        }

        private bool IsPasswordValid(string password)
        {

#if DEBUG
            var longEnough = password.Length >= 3;
            if (longEnough)
                ValidationVault.StoredPasswordValidation = password;
            return longEnough;
#else
            bool passwordMatches = Regex.IsMatch(password, "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,}$");
            if (passwordMatches)
                ValidationVault.StoredPasswordValidation = password;
            return passwordMatches;
#endif
        }
    }
}
