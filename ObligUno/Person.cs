using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligUno
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public int BirthYear { get; set; }
        public Person Father { get; set; }
        public Person Mother { get; set; }
        public string LastName { get; set; }
        public int DeathYear { get; set; }

        public Person()
        {
            
        }

        public string GetDescription()
        {
            if (FirstName == null && BirthYear == 0 && Father == null && Mother == null && LastName == null &&
                DeathYear == 0) return $"(Id={Id})";
            if (FirstName is not null && BirthYear != 0 && Father is not null && Mother is not null &&
                LastName is not null && DeathYear != 0)
                return
                    $"{FirstName} {LastName} (Id={Id}) Født: {BirthYear} Død: {DeathYear} Far: {Father.FirstName} (Id={Father.Id}) Mor: {Mother.FirstName} (Id={Mother.Id})";
            var text = "";
            if (FirstName != null) text += $"{FirstName} ";
            if (LastName != null) text += $"{LastName}";
            if (Id != 0) text += $"(Id={Id}) ";
            if (BirthYear != 0) text += $"Født: {BirthYear} ";
            if (DeathYear != 0) text += $"Død: {DeathYear}";
            if (Father is {FirstName: { }}) text += $"Far: {Father.FirstName}";
            if (Father != null && Father.Id != 0) text += $"(Id={Father.Id})";
            if (Mother is {FirstName: { }}) text += $"Mor: {Mother.FirstName}";
            if (Mother != null && Mother.Id != 0) text += $"(Id={Mother.Id})";
            return text;
        }
    }
}
