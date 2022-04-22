using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentStore.Core.Convertors
{
   public class FixedText
    {
        public static string FixedEmail(string email)
        {
            return email.Trim().ToLower();
        }
    }
}
