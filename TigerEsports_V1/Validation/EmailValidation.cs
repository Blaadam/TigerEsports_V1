using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TigerEsports_V1.Validation
{
    public class EmailValidation : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += BindableOnTextChanged;
        }

        // method called when behaviour is detatched
        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= BindableOnTextChanged;
        }

        private void BindableOnTextChanged(object? sender, TextChangedEventArgs e)
        {
            var Email = e.NewTextValue;
            var entry = sender as Entry;

            if (entry != null)
            {
                ValidationVault.Email = IsEmailValid(Email);
                entry.TextColor = ValidationVault.Email ? Color.FromArgb("000000") : Color.FromArgb("FF0000");
            }
        }

        private bool IsEmailValid(string email)
        {
            return Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
    }
}
