using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TigerEsports_V1.Validation
{
    public static class ValidationVault
    {
        // Data shared across login and registration
        public static string StoredPasswordValidation = "";

        // Data for Registration Validation
        public static bool Email = false;
        public static bool RegPassword = false;
        public static bool RegConfirmPassword = false;

        // Data for Login Validation
        public static bool LoginPassword = false;
    }
}
