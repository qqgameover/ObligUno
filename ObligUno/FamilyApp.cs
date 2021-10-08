using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ObligUno
{
    public class FamilyApp
    {
        public static List<Person> People { get; set; }
        public string WelcomeMessage { get; set; }
        public string CommandPrompt { get; set; }

        public FamilyApp(params Person[] people)
        {
            People = new List<Person>(people);
            WelcomeMessage = "Velkommen: ";
            foreach (var person in People)
            {
                WelcomeMessage += $"{person.FirstName}, ";
            }

            CommandPrompt =
                "hjelp => viser en hjelpetekst som forklarer alle kommandoene\r\n" +
                "liste => lister alle personer med id, fornavn, fødselsår, dødsår og navn og id på mor og far om det finnes registrert. \r\nvis " +
                "<id> => viser en bestemt person med mor, far og barn (og id for disse, slik at man lett kan vise en av dem) vis 3 \r\n";
        }

        public string HandleCommand(string command)
        {
            var response = "";
            if (command == "liste")
            {
                foreach (var person in People)
                {
                    response += person.GetDescription();
                    response += "\n";
                }

                return response;
            }
            if (command == "hjelp")
            {
                response = CommandPrompt;
                return response;
            }
            if (command.Contains("vis"))
            {
                var idSplit = command.Split(" ");
                var id = idSplit[1];
                foreach (var person in People)
                {
                    if (person.Id == Convert.ToInt32(id))
                    {
                        var text = person.GetDescription();
                        if (FindChildren(person) != "\n  Barn:\n")
                        {
                            text += FindChildren(person);
                        }
                        return text;
                    }
                }
            }
            return response;
        }

        public static string FindChildren(Person p)
        {
            var children = "\n  Barn:\n";
            foreach (var person in People)
            {
                if ((person.Father != null && p.Id == person.Father.Id) || (person.Mother != null && p.Id == person.Mother.Id))
                {
                    if (person.FirstName != null) children += $"    {person.FirstName}";
                    if (person.Id != 0) children += $" (Id={person.Id}) ";
                    if (person.BirthYear != 0) children += $"Født: {person.BirthYear}";
                    children += "\n";
                }
            }

            return children;
        }
    }
}
