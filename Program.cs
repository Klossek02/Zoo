using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project3;
using Project1.Representation_0;
using Project2;
using System.IO;
using System.Xml;


//class Program
//{
//    public static void PrintIfAverageAgeBelow3(Enclosure enclosure)
//    {
//        double averageAge = 0;
//        foreach (Animal animal in enclosure.Animals)
//        {
//            averageAge += animal.Age;
//        }
//        averageAge /= enclosure.Animals.Count;

//        if (averageAge < 3.0)
//        {
//            Console.Write(enclosure.Name + ": ");
//            foreach (Animal animal in enclosure.Animals)
//            {
//                Console.Write(animal.Name + " ");
//            }
//            Console.WriteLine();
//        }
//    }

//    public static void PrintZoo(List<Enclosure> enclosures, List<Animal> animals, List<Species> species, List<Visitor> visitors, List<Employee> employees)
//    {
//        Console.WriteLine("\t\t\t\t\t\t\t{ZOO}");
//        Console.WriteLine("PART 1");

//        Console.WriteLine("\n\nEnclosure - name, animals, employee");
//        for (int enclosureIndex = 0; enclosureIndex < enclosures.Count; enclosureIndex++)
//        {
//            Console.Write(enclosureIndex + 1 + ". ");
//            enclosures[enclosureIndex].Print();
//        }

//        Console.WriteLine("\n\nAnimal - name, age, species");
//        for (int animalIndex = 0; animalIndex < animals.Count; animalIndex++)
//        {
//            Console.Write(animalIndex + 1 + ". ");
//            animals[animalIndex].Print();
//        }

//        Console.WriteLine("\n\nSpecies - name, favouriteFoods");
//        for (int speciesIndex = 0; speciesIndex < species.Count; speciesIndex++)
//        {
//            Console.Write(speciesIndex + 1 + ". ");
//            species[speciesIndex].Print();
//        }

//        Console.WriteLine("\n\nEmployee - name, surname, age, enclosures");
//        for (int employeeIndex = 0; employeeIndex < employees.Count; employeeIndex++)
//        {
//            Console.Write(employeeIndex + 1 + ". ");
//            employees[employeeIndex].Print();
//        }

//        Console.WriteLine("\n\nVisitor - name, surname, visitedEnclosures");
//        for (int visitorIndex = 0; visitorIndex < visitors.Count; visitorIndex++)
//        {
//            Console.Write(visitorIndex + 1 + ". ");
//            visitors[visitorIndex].Print();
//        }
//    }

//    public static void Main(string[] args)
//    {
//        // Representation 0
//        Employee emp1 = new("Ricardo", "Stallmano", 73);
//        Employee emp2 = new("Steve", "Irvin", 43);

//        Visitor vis1 = new("Tomas", "German");
//        Visitor vis2 = new("Silvester", "Ileen");
//        Visitor vis3 = new("Basil", "Bailey");
//        Visitor vis4 = new("Ryker", "Polly");

//        Species spec1 = new("Meerkat");
//        Species spec2 = new("Kakapo");
//        Species spec3 = new("Bengal Tiger");
//        Species spec4 = new("Panda");
//        Species spec5 = new("Python");
//        Species spec6 = new("Dungeness Crab");
//        Species spec7 = new("Gopher");
//        Species spec8 = new("Cats");
//        Species spec9 = new("Penguin");

//        spec1.AddFavouriteFood(ref spec1);
//        spec3.AddFavouriteFood(ref spec4);
//        spec3.AddFavouriteFood(ref spec7);
//        spec3.AddFavouriteFood(ref spec8);
//        spec5.AddFavouriteFood(ref spec4);
//        spec5.AddFavouriteFood(ref spec3);
//        spec6.AddFavouriteFood(ref spec5);
//        spec8.AddFavouriteFood(ref spec7);
//        spec9.AddFavouriteFood(ref spec3);

//        Animal anim1 = new("Harold", 2, ref spec1);
//        Animal anim2 = new("Ryan", 1, ref spec1);
//        Animal anim3 = new("Jenkins", 15, ref spec2);
//        Animal anim4 = new("Kaka", 10, ref spec2);
//        Animal anim5 = new("Ada", 13, ref spec3);
//        Animal anim6 = new("Jett", 2, ref spec4);
//        Animal anim7 = new("Conda", 4, ref spec5);
//        Animal anim8 = new("Samuel", 2, ref spec5);
//        Animal anim9 = new("Claire", 2, ref spec6);
//        Animal anim10 = new("Andy", 3, ref spec7);
//        Animal anim11 = new("Arrow", 5, ref spec8);
//        Animal anim12 = new("Arch", 1, ref spec9);
//        Animal anim13 = new("Ubuntu", 1, ref spec9);
//        Animal anim14 = new("Fedora", 1, ref spec9);

//        List<Animal> encl1Animals = new() { anim12, anim13, anim14, anim7, anim8, anim6 };
//        Enclosure encl1 = new("311", ref encl1Animals, ref emp1);

//        List<Animal> encl2Animals = new() { anim11, anim10, anim1, anim2 };
//        Enclosure encl2 = new("Break", ref encl2Animals, ref emp2);

//        List<Animal> encl3Animals = new() { anim3, anim4, anim5, anim9 };
//        Enclosure encl3 = new("Jurasic Park", ref encl3Animals, ref emp2);

//        vis1.Visit(ref encl1);
//        vis1.Visit(ref encl2);
//        vis2.Visit(ref encl3);
//        vis3.Visit(ref encl1);
//        vis3.Visit(ref encl3);
//        vis4.Visit(ref encl2);

//        List<Employee> employees = new() { emp1, emp2 };
//        List<Enclosure> enclosures = new() { encl1, encl2, encl3 };
//        List<Visitor> visitors = new() { vis1, vis2, vis3, vis4 };
//        List<Species> species = new() { spec1, spec2, spec3, spec4, spec5, spec6, spec7, spec8, spec9 };
//        List<Animal> animals = new() { anim1, anim2, anim3, anim4, anim5, anim6, anim7, anim8, anim9, anim10, anim11, anim12, anim13, anim14 };
//        PrintZoo(enclosures, animals, species, visitors, employees);

//        // Representation 6
//        var zoo = new Dictionary<string, string>();
//        Representation6.AddEnclosureToMap(zoo, encl1);
//        Representation6.AddEnclosureToMap(zoo, encl2);
//        Representation6.AddEnclosureToMap(zoo, encl3);

//        Console.WriteLine("\n");
//        foreach (var pair in zoo)
//        {
//            Console.WriteLine($"{pair.Key} = {pair.Value}");
//        }


//        //// Representation 8
//        var tuple1 = Representation8.GetTuple(encl1, 1);
//        var tuple2 = Representation8.GetTuple(encl2, 2);
//        var tuple3 = Representation8.GetTuple(encl3, 3);

//        //Console.WriteLine($"Tuple ID: {tuple.Item1}");

//        //foreach (string item in tuple.Item2)
//        //{
//        //    Console.WriteLine(item);
//        //}
//        //Enclosure enclosure = new Enclosure("Enclosure 1", new List<Animal>(), new Employee("John", "Doe", 25));
//        //Tuple<int, Stack<string>> tuple1 = Representation8.GetTuple(encl1, 1);
//        //Console.WriteLine($"Tuple ID: {tuple1.Item1}");
//        //foreach (string item in tuple1.Item2)
//        //{
//        //    Console.WriteLine(item);
//        //}

//        //Tuple<int, Stack<string>> tuple2 = Representation8.GetTuple(encl2, 1);
//        //Console.WriteLine($"Tuple ID: {tuple2.Item1}");
//        //foreach (string item2 in tuple2.Item2)
//        //{
//        //    Console.WriteLine(item2);
//        //}

//        //Tuple<int, Stack<string>> tuple3 = Representation8.GetTuple(encl3, 1);

//        //Console.WriteLine($"Tuple ID: {tuple3.Item1}");

//        //foreach (string item3 in tuple3.Item2)
//        //{
//        //    Console.WriteLine(item3);
//        //}

//        // Task 2
//        // Representation 0
//        Console.WriteLine("\n\nCages with average age below 3");
//        PrintIfAverageAgeBelow3(encl1);
//        PrintIfAverageAgeBelow3(encl2);
//        PrintIfAverageAgeBelow3(encl3);

//        // Representation 6
//        Console.WriteLine("\n\nCages with average age below 3");
//        List<Enclosure> adaptedEnclosuresFromMap = Representation6.GetEnclosures(zoo, animals, employees);
//        foreach (Enclosure enclosure in adaptedEnclosuresFromMap)
//        {
//            PrintIfAverageAgeBelow3(enclosure);
//        }

//        // Representation 8
//        Console.WriteLine("\n\nCages with average age below 3");
//       PrintIfAverageAgeBelow3(Representation8.GetEnclosure(tuple1, animals, employees));
//       PrintIfAverageAgeBelow3(Representation8.GetEnclosure(tuple2, animals, employees));
//       PrintIfAverageAgeBelow3(Representation8.GetEnclosure(tuple3, animals, employees));

//        Console.WriteLine("\n");
//        Console.WriteLine("PART 2");
//        DoublyLinkedList<int> list = new();
//            list.Add(1);
//            list.Add(22);
//            list.Add(333);
//            list.Add(4444);
//            list.Add(55555);

//            Console.WriteLine("Print even numbers:");
//            Func<int, bool> isEven = IsEven;
//            Project_1.ICollection<int>.Print(list, isEven);

//            Console.WriteLine("Find first even number (reversed):");
//            int x = Project_1.ICollection<int>.Find(list, isEven, false);
//            Console.WriteLine(x);

//            Console.WriteLine("Iterate backwards:");
//            IEnumerator<int> enumerator = list.GetBackwardEnumerator();
//            while (enumerator.MoveNext())
//            {
//                Console.WriteLine(enumerator.Current);
//            }

//            Console.WriteLine("Remove 22, 5555 and 1");
//            list.Remove(22);
//            list.Remove(55555);
//            list.Remove(1);

//            Console.WriteLine("Iterate forwards:");
//            enumerator = list.GetForwardEnumerator();
//            while (enumerator.MoveNext())
//            {
//                Console.WriteLine(enumerator.Current);
//            }



//        //task 4

//        Console.WriteLine("\n");
//        Console.WriteLine("PART 3");
//        Console.WriteLine("Enter one of the commands (list, find, add, exit): ");
//        CommandLoop commandLoop = new CommandLoop();
//        commandLoop.Start();

//    }

//    public static bool IsEven(int x)
//    {
//        return x % 2 == 0;
//    }

//}



class Representation1
{

    public static void PrintIfAverageAgeBelow3(Enclosure enclosure)
    {
        double averageAge = 0;
        foreach (Animal animal in enclosure.Animals)
        {
            averageAge += animal.Age;
        }
        averageAge /= enclosure.Animals.Count;

        if (averageAge < 3.0)
        {
            Console.Write(enclosure.Name + ": ");
            foreach (Animal animal in enclosure.Animals)
            {
                Console.Write(animal.Name + " ");
            }
            Console.WriteLine();
        }
    }

    public static void PrintZoo(List<Enclosure> enclosures, List<Animal> animals, List<Species> species, List<Visitor> visitors, List<Employee> employees)
    {
        Console.WriteLine("\t\t\t\t\t\t\t{ZOO}");
        Console.WriteLine("PART 1");

        Console.WriteLine("\n\nEnclosure - name, animals, employee");
        for (int enclosureIndex = 0; enclosureIndex < enclosures.Count; enclosureIndex++)
        {
            Console.Write(enclosureIndex + 1 + ". ");
            enclosures[enclosureIndex].Print();
        }

        Console.WriteLine("\n\nAnimal - name, age, species");
        for (int animalIndex = 0; animalIndex < animals.Count; animalIndex++)
        {
            Console.Write(animalIndex + 1 + ". ");
            animals[animalIndex].Print();
        }

        Console.WriteLine("\n\nSpecies - name, favouriteFoods");
        for (int speciesIndex = 0; speciesIndex < species.Count; speciesIndex++)
        {
            Console.Write(speciesIndex + 1 + ". ");
            species[speciesIndex].Print();
        }

        Console.WriteLine("\n\nEmployee - name, surname, age, enclosures");
        for (int employeeIndex = 0; employeeIndex < employees.Count; employeeIndex++)
        {
            Console.Write(employeeIndex + 1 + ". ");
            employees[employeeIndex].Print();
        }

        Console.WriteLine("\n\nVisitor - name, surname, visitedEnclosures");
        for (int visitorIndex = 0; visitorIndex < visitors.Count; visitorIndex++)
        {
            Console.Write(visitorIndex + 1 + ". ");
            visitors[visitorIndex].Print();
        }
    }


    public static void Main(string[] args)
    {
        Console.WriteLine("\n");
        Console.WriteLine("PART 3");
        CommandLoop commandLoop = new CommandLoop();
        commandLoop.Start();
    }
}