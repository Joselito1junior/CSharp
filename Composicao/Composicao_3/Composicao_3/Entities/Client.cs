using System;

namespace Composicao_3.Entities
{
    class Client
    {
        public string Name { get; set; }
        public String Email { get; set; }
        public DateTime BirthDate { get; set; }

        public Client()
        {

        }

        public Client(string name, string email, DateTime birthDate)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }

        public override string ToString()
        {
            return Name
                + " ("
                + BirthDate.ToShortDateString()
                + ") - "
                + Email;
        }
    }
}
