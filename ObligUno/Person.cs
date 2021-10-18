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

        public Person()
        {
            
        }

        public string GetDescription()
        {
            if (FirstName == null && BirthYear == null && Father == null && Mother == null && LastName == null &&
                DeathYear == null) return $"(Id={Id})";
            if (FirstName is not null && BirthYear != 0 && Father is not null && Mother is not null &&
                LastName is not null && DeathYear != 0)
            {
                var x = $"{FirstName} {LastName} (Id={Id}) Født: {BirthYear} Død: {DeathYear} Far: {Father.FirstName} (Id={Father.Id}) Mor: {Mother.FirstName} (Id={Mother.Id})";
                return x;
            }

            var text = "";
            if (FirstName != null) text += $"{FirstName} ";
            if (LastName != null) text += $"{LastName}";
            if (Id != null) text += $"(Id={Id}) ";
            if (BirthYear != null) text += $"Født: {BirthYear} ";
            if (DeathYear != null) text += $"Død: {DeathYear}";
            if (Father != null)
            {
                text += $"Far: {Father?.FirstName}";
                text += $"(Id={Father?.Id})";
            }
            if (Mother != null)
            {
                text += $"Mor: {Mother?.FirstName}";
                text += $"(Id={Mother?.Id})";
            }
            return text;
        }
    }
}
