using System;

namespace DesignPatterns.Creational.Builder
{

    public interface IMealBuilder
    {
        void AddStarter(string starter);
        void AddMainCourse(string mainCourse);
        void AddDessert(string dessert);
    }

    public class MealBuilder : IMealBuilder
    {
        private Meal _meal = new Meal();

        public void AddStarter(string starter)
        {
            _meal.Starter = starter;
        }

        public void AddMainCourse(string mainCourse)
        {
            _meal.MainCourse = mainCourse;
        }

        public void AddDessert(string dessert)
        {
            _meal.Dessert = dessert;
        }

        public Meal GetMeal()
        {
            return _meal;
        }
    }

    public class Meal
    {
        public string Starter { get; set; }
        public string Dessert { get; set; }
        public string MainCourse { get; set; }
    }

    public class MealServer
    {
        public MealBuilder MealBuilder { get; set; }

        public MealServer(MealBuilder builder)
        {
            this.MealBuilder = builder;
        }

        public Meal GetVegMeal()
        {
            MealBuilder.AddStarter("Aloo 65");
            MealBuilder.AddMainCourse("Veg biryani, raita");
            MealBuilder.AddDessert("Gulab jamun");
            return MealBuilder.GetMeal();
        }

        public Meal GetNonVegMeal()
        {
            MealBuilder.AddStarter("Chicken 65");
            MealBuilder.AddMainCourse("Chicken biryani, raita");
            MealBuilder.AddDessert("Gulab jamun");
            return MealBuilder.GetMeal();
        }
    }

    public class Program
    {
        public static void Run()
        {
            MealBuilder builder = new MealBuilder();
            MealServer server = new MealServer(builder);
            var vegMeal = server.GetVegMeal();
            Console.WriteLine($"{vegMeal.Starter} | {vegMeal.MainCourse} | {vegMeal.Dessert}");
            var nonVegMeal = server.GetNonVegMeal();
            Console.WriteLine($"{nonVegMeal.Starter} | {nonVegMeal.MainCourse} | {nonVegMeal.Dessert}");
        }
    }
}
