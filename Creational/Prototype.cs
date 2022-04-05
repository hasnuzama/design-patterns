using System;

namespace DesignPatterns.Creational.Prototype
{
    public class Student : ICloneable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }

        public object Clone()
        {
            Student stu = (Student)this.MemberwiseClone();
            stu.Address = (Address)this.Address.Clone();
            return stu;
        }
    }

    public class Address : ICloneable
    {
        public string City { get; set; }
        public string State { get; set; }

        public object Clone()
        {
            Address stu = (Address)this.MemberwiseClone();
            return stu;
        }
    }

    public class Program
    {
        public static void Run()
        {
            Student s1 = new Student()
            {
                Id = 1,
                Name = "Ram",
                Address = new Address()
                {
                    City = "Hyderabad",
                    State = "Telangana"
                }
            };
            //
            Student s2 = (Student)s1.Clone();
            s2.Name = "Bheem";
            s2.Address.City = "Warangal";
            //
            Console.WriteLine(s1.Name + "," + s1.Address.City);
            Console.WriteLine(s2.Name + "," + s2.Address.City);
        }
    }
}
