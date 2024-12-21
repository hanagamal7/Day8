using System;
using System.Collections.Generic;

namespace Assignment
{
    // Problem 1: IVehicle Interface
    public interface IVehicle
    {
        void StartEngine();
        void StopEngine();
    }

    public class Car : IVehicle
    {
        public void StartEngine() => Console.WriteLine("Car engine started.");
        public void StopEngine() => Console.WriteLine("Car engine stopped.");
    }

    public class Bike : IVehicle
    {
        public void StartEngine() => Console.WriteLine("Bike engine started.");
        public void StopEngine() => Console.WriteLine("Bike engine stopped.");
    }

    //question1.1: Coding against an interface improves flexibility, testability, and scalability because it abstracts the implementation details and allows swapping concrete implementations without changing the client code.

    // Problem 2: Abstract Shape Class
    public abstract class Shape
    {
        public abstract double GetArea();
        public void Display() => Console.WriteLine("Displaying shape.");
    }

    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public override double GetArea() => Width * Height;
    }

    public class Circle : Shape
    {
        public double Radius { get; set; }

        public override double GetArea() => Math.PI * Radius * Radius;
    }

    //question1.2: Use an abstract class when classes share common behavior but need unique implementations, while interfaces are better for defining unrelated behaviors.

    // Problem 3: Product Class with IComparable
    public class Product : IComparable<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public int CompareTo(Product other) => Price.CompareTo(other.Price);
    }

    //question1.3: Implementing IComparable makes sorting more flexible and consistent, allowing custom sorting logic by attributes such as Price, Name, or any other.

    // Problem 4: Student Class with Copy Constructor
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Grade { get; set; }

        public Student(Student other)
        {
            Id = other.Id;
            Name = other.Name;
            Grade = other.Grade;
        }

        public Student() { }
    }

    //question1.4: The primary purpose of a copy constructor is to create a deep copy of an object, ensuring that changes to the new object do not affect the original.

    // Problem 5: Robot with Explicit Interface Implementation
    public interface IWalkable
    {
        void Walk();
    }

    public class Robot : IWalkable
    {
        void IWalkable.Walk() => Console.WriteLine("Robot walking via IWalkable.");
        public void Walk() => Console.WriteLine("Robot walking normally.");
    }

    //question1.5: Explicit interface implementation resolves naming conflicts when a class implements multiple interfaces with the same method names.

    // Problem 6: Struct Account with Encapsulation
    public struct Account
    {
        private int _accountId;
        private string _accountHolder;
        private double _balance;

        public int AccountId
        {
            get => _accountId;
            set => _accountId = value;
        }

        public string AccountHolder
        {
            get => _accountHolder;
            set => _accountHolder = value;
        }

        public double Balance
        {
            get => _balance;
            set => _balance = value;
        }
    }

    //question1.6: Encapsulation in structs is limited compared to classes since structs are value types and do not support inheritance.

    //question1.7: Abstraction hides complexity and provides a simplified interface to the user. Encapsulation is the technique used to achieve abstraction by restricting direct access to data and methods.

    // Problem 7: ILogger with Default Implementation
    public interface ILogger
    {
        void Log() => Console.WriteLine("Default logging...");
    }

    public class ConsoleLogger : ILogger
    {
        public void Log() => Console.WriteLine("Logging to console...");
    }

    //question1.8: Default implementations in interfaces improve backward compatibility by allowing new methods without breaking existing implementations.

    // Problem 8: Book Class with Constructor Overloading
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public Book() { }

        public Book(string title)
        {
            Title = title;
        }

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }
    }

    //question1.9: Constructor overloading improves usability by providing multiple ways to create an object, making it more flexible for different scenarios.

    public static class Program
    {
        public static void Main()
        {
            // Testing IVehicle
            IVehicle car = new Car();
            car.StartEngine();
            car.StopEngine();

            IVehicle bike = new Bike();
            bike.StartEngine();
            bike.StopEngine();

            // Testing Shape
            Shape rect = new Rectangle { Width = 5, Height = 10 };
            Shape circle = new Circle { Radius = 7 };
            Console.WriteLine($"Rectangle Area: {rect.GetArea()}");
            Console.WriteLine($"Circle Area: {circle.GetArea()}");

            // Testing Product Sorting
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Product A", Price = 15.0 },
                new Product { Id = 2, Name = "Product B", Price = 10.0 },
                new Product { Id = 3, Name = "Product C", Price = 20.0 }
            };
            products.Sort();
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Name}: {product.Price}");
            }

            // Testing Student Copy Constructor
            var student1 = new Student { Id = 1, Name = "John", Grade = 95.0 };
            var student2 = new Student(student1);
            Console.WriteLine($"Original Student: {student1.Name}, {student1.Grade}");
            Console.WriteLine($"Copied Student: {student2.Name}, {student2.Grade}");

            // Testing Robot with Explicit Interface Implementation
            var robot = new Robot();
            ((IWalkable)robot).Walk();
            robot.Walk();

            // Testing Account Struct
            var account = new Account { AccountId = 123, AccountHolder = "Alice", Balance = 500.0 };
            Console.WriteLine($"Account Holder: {account.AccountHolder}, Balance: {account.Balance}");

            // Testing ILogger
            ILogger logger = new ConsoleLogger();
            logger.Log();

            // Testing Book Constructor Overloading
            var book1 = new Book();
            var book2 = new Book("The Great Gatsby");
            var book3 = new Book("1984", "George Orwell");
            Console.WriteLine($"Book 1: {book1.Title}");
            Console.WriteLine($"Book 2: {book2.Title}");
            Console.WriteLine($"Book 3: {book3.Title}, {book3.Author}");
        }
    }
}
