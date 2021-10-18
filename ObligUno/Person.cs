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


        public string GetDescription()
        {
            var text = "";
            if (FirstName != null) text += $"{GetFirstName()} ";
            if (LastName != null) text += $"{GetLastName()}";
            if (Id != null) text += $"(Id={Id})";
            if (BirthYear != null) text += $" Født: {BirthYear}";
            if (DeathYear != null) text += $" Død: {DeathYear}";
            if (Father != null && Mother != null)
            {
                text += GetFatherDesc().PadLeft(1, Convert.ToChar(" "));
                text += " ";
                text += GetMotherDesc();
                return text.Trim();
            }
            if (Father != null)
            {
                text += GetFatherDesc().PadLeft(1);
            }
            if (Mother != null)
            {
                text += GetMotherDesc();
            }
            return text.Trim();
        }

        private string GetBothParents()
        {
            var text = GetFatherDesc();
            text += GetMotherDesc();
            return text;
        }

        private string GetMotherDesc()
        {
            var str = "";
            str += $"Mor: {Mother?.FirstName}";
            str += $"(Id={Mother?.Id})";
            return str;
        }

        private string GetFullDesc()
        {
            return
                $"{GetFullName()}(Id={Id}) Født: {BirthYear} Død: {DeathYear} " +
                $"Far: {Father.FirstName} (Id={Father.Id}) Mor: {Mother.FirstName} (Id={Mother.Id})";
        }

        private string GetId()
        {
            return $"(Id={Id})";
        }

        private string GetFullName(string preVal = "", string postVal = " ")
        {
            return $"{preVal}{GetFirstName()} {GetLastName()}{postVal}";
        }

        private string GetFirstName()
        {
            return FirstName;
        }

        private string GetLastName()
        {
            return LastName + " ";
        }

        private string GetFatherDesc()
        {
            var text = "";
            text += $" Far: {Father?.FirstName}";
            text += $"(Id={Father?.Id})";
            return text;
        }
    }
}
