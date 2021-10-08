using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligUno
{
    class FamilyApp
    {
        public List<Person> People { get; set; }
        public string WelcomeMessage { get; set; }

        public FamilyApp(params Person[] people)
        {
            People = new List<Person>(people);
            WelcomeMessage = "Velkommen: ";
            foreach (var person in People)
            {
                WelcomeMessage += $"{person.FirstName}, ";
            }
        }
    }
}
