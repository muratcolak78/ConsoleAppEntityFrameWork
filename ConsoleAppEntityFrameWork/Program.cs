using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEntityFrameWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AddPerson("Murat", new DateTime(1978, 1, 1), "1234567890", 180);

        }
        static void AddPerson(string name, DateTime birthDate, string phone, int height)
        {
            using (var context = new PersonContext())
            {
                var person = new Person
                {
                    Name = name,
                    BirthDate = birthDate,
                    Phone = phone,
                    Height = height
                };

                context.Persons.Add(person);
                context.SaveChanges();

                Console.WriteLine("Person added successfully.");
            }
        }

    }
    public class Person
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        public int? Height { get; set; }

        public virtual List<Address> Addresses { get; set; }
    }

    public class Address
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Street { get; set; }

        [StringLength(10)]
        public string ZipCode { get; set; }

        [StringLength(50)]
        [Required]
        public string City { get; set; }

        public virtual Person Person { get; set; }
    }
    public class PersonContext : DbContext
    {
        public PersonContext() : base("name=PersonContext")
        {
        }

        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
    }

}
