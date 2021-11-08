using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligUno
{
    public class Person
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public int? BirthYear { get; set; }
        public Person Father { get; set; }
        public Person Mother { get; set; }
        public string LastName { get; set; }
        public int? DeathYear { get; set; }
        public string GetDescription(bool asMother = false, bool asFather = false ,bool asChild = false)
        {
            var firstNameStr = FormatField(FirstName, asChild ? "    " : "");
            var idStr = FormatField(Id, "(Id=", ") ");
            var birthYearStr = FormatField(BirthYear, "Født: ");
            if (asFather) return "Far: " + firstNameStr + idStr.Trim();
            if (asMother) return "Mor: " + firstNameStr + idStr;
            if (asChild) return firstNameStr + idStr + birthYearStr;
            var text = firstNameStr
                       + FormatField(LastName)
                       + idStr
                       + FormatField(BirthYear, "Født: ")
                       + FormatField(DeathYear, "Død: ")
                       + FormatField(Father?.GetDescription(false, true))
                       + FormatField(Mother?.GetDescription(true));
            return text.Trim();
        }

        private static string FormatField(object value, string preLabel = "", string postLabel = " ")
        {
            if (value == null) return "";
            return preLabel + value + postLabel;
        }
    }
}
