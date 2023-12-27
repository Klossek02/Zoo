

//namespace Project_1
//{
//    class CommandLoop
//    {
//        private Dictionary<string, Func<string[], bool>> commands;
//        private DoublyLinkedList<Employee> employees;
//        private DoublyLinkedList<Animal> animals;
//        private DoublyLinkedList<Species> species;
//        private DoublyLinkedList<Visitor> visitors;
//        private DoublyLinkedList<Enclosure> enclosures;

//        public CommandLoop()
//        {
//            commands = new()
//            {
//                ["list"] = List,
//                ["find"] = Find
//            };

//            Employee emp1 = new("Ricardo", "Stallmano", 73);
//            Employee emp2 = new("Steve", "Irvin", 43);

//            Visitor vis1 = new("Tomas", "German");
//            Visitor vis2 = new("Silvester", "Ileen");
//            Visitor vis3 = new("Basil", "Bailey");
//            Visitor vis4 = new("Ryker", "Polly");

//            Species spec1 = new("Meerkat");
//            Species spec2 = new("Kakapo");
//            Species spec3 = new("Bengal Tiger");
//            Species spec4 = new("Panda");
//            Species spec5 = new("Python");
//            Species spec6 = new("Dungeness Crab");
//            Species spec7 = new("Gopher");
//            Species spec8 = new("Cats");
//            Species spec9 = new("Penguin");

//            spec1.AddFavouriteFood(ref spec1);
//            spec3.AddFavouriteFood(ref spec4);
//            spec3.AddFavouriteFood(ref spec7);
//            spec3.AddFavouriteFood(ref spec8);
//            spec5.AddFavouriteFood(ref spec4);
//            spec5.AddFavouriteFood(ref spec3);
//            spec6.AddFavouriteFood(ref spec5);
//            spec8.AddFavouriteFood(ref spec7);
//            spec9.AddFavouriteFood(ref spec3);

//            Animal anim1 = new("Harold", 2, ref spec1);
//            Animal anim2 = new("Ryan", 1, ref spec1);
//            Animal anim3 = new("Jenkins", 15, ref spec2);
//            Animal anim4 = new("Kaka", 10, ref spec2);
//            Animal anim5 = new("Ada", 13, ref spec3);
//            Animal anim6 = new("Jett", 2, ref spec4);
//            Animal anim7 = new("Conda", 4, ref spec5);
//            Animal anim8 = new("Samuel", 2, ref spec5);
//            Animal anim9 = new("Claire", 2, ref spec6);
//            Animal anim10 = new("Andy", 3, ref spec7);
//            Animal anim11 = new("Arrow", 5, ref spec8);
//            Animal anim12 = new("Arch", 1, ref spec9);
//            Animal anim13 = new("Ubuntu", 1, ref spec9);
//            Animal anim14 = new("Fedora", 1, ref spec9);

//            List<Animal> encl1Animals = new() { anim12, anim13, anim14, anim7, anim8, anim6 };
//            Enclosure encl1 = new("311", ref encl1Animals, ref emp1);

//            List<Animal> encl2Animals = new() { anim11, anim10, anim1, anim2 };
//            Enclosure encl2 = new("Break", ref encl2Animals, ref emp2);

//            List<Animal> encl3Animals = new() { anim3, anim4, anim5, anim9 };
//            Enclosure encl3 = new("Jurasic Park", ref encl3Animals, ref emp2);

//            vis1.Visit(ref encl1);
//            vis1.Visit(ref encl2);
//            vis2.Visit(ref encl3);
//            vis3.Visit(ref encl1);
//            vis3.Visit(ref encl3);
//            vis4.Visit(ref encl2);

//            employees = new();
//            employees.Add(emp1);
//            employees.Add(emp2);

//            enclosures = new();
//            enclosures.Add(encl1);
//            enclosures.Add(encl2);
//            enclosures.Add(encl3);

//            visitors = new();
//            visitors.Add(vis1);
//            visitors.Add(vis2);
//            visitors.Add(vis3);
//            visitors.Add(vis4);

//            species = new();
//            species.Add(spec1);
//            species.Add(spec2);
//            species.Add(spec3);
//            species.Add(spec4);
//            species.Add(spec5);
//            species.Add(spec6);
//            species.Add(spec7);
//            species.Add(spec8);
//            species.Add(spec9);

//            animals = new();
//            animals.Add(anim1);
//            animals.Add(anim2);
//            animals.Add(anim3);
//            animals.Add(anim4);
//            animals.Add(anim5);
//            animals.Add(anim6);
//            animals.Add(anim7);
//            animals.Add(anim8);
//            animals.Add(anim9);
//            animals.Add(anim10);
//            animals.Add(anim11);
//            animals.Add(anim12);
//            animals.Add(anim13);
//            animals.Add(anim14);
//        }

//        private static string? GetCommandFromUser()
//        {
//            Console.Write(">> ");
//            return Console.ReadLine();
//        }

//        private bool List(string[] args)
//        {
//            if (args.Length < 2)
//            {
//                return false;
//            }

//            Func<IFields, bool> SatisfiesCondition = (IFields item) =>
//            {
//                return true;
//            };

//            if (args.Length > 2)
//            {
//                string condition = args[2];
//                string[] conditionSplit = args[2].Split('<');
//                int conditionOperator = -1;

//                if (conditionSplit.Length == 1)
//                {
//                    conditionSplit = args[2].Split('>');
//                    conditionOperator = 1;
//                }

//                if (conditionSplit.Length == 1)
//                {
//                    conditionSplit = args[2].Split('=');
//                    conditionOperator = 0;
//                }

//                string fieldName = conditionSplit[0].ToLower();
//                string value = conditionSplit[1];

//                SatisfiesCondition = (IFields item) =>
//                {
//                    if (!item.Fields().ContainsKey(fieldName))
//                    {
//                        return false;
//                    }

//                    Type t1 = item.Fields()[fieldName].Item2;
//                    if (t1 == typeof(int))
//                    {
//                        return Convert.ToInt32(item.Fields()[fieldName].Item1).CompareTo(Convert.ToInt32(value)) == conditionOperator;
//                    }
//                    return item.Fields()[fieldName].Item1.CompareTo(value) == conditionOperator;
//                };
//            }

//            switch (args[1].ToLower())
//            {
//                case "animal":
//                    ICollection<Animal>.Print(animals, SatisfiesCondition);
//                    break;
//                case "species":
//                    ICollection<Species>.Print(species, SatisfiesCondition);
//                    break;
//                case "employee":
//                    ICollection<Employee>.Print(employees, SatisfiesCondition);
//                    break;
//                case "visitor":
//                    ICollection<Visitor>.Print(visitors, SatisfiesCondition);
//                    break;
//                case "enclosure":
//                    ICollection<Enclosure>.Print(enclosures, SatisfiesCondition);
//                    break;
//                default:
//                    return false;
//            }

//            return true;
//        }

//        private bool Find(string[] args)
//        {
//            if (args.Length < 2)
//            {
//                return false;
//            }

//            Func<IFields, bool> SatisfiesCondition = (IFields item) =>
//            {
//                return true;
//            };

//            if (args.Length > 2)
//            {
//                string condition = args[2];
//                string[] conditionSplit = args[2].Split('<');
//                int conditionOperator = -1;

//                if (conditionSplit.Length == 1)
//                {
//                    conditionSplit = args[2].Split('>');
//                    conditionOperator = 1;
//                }

//                if (conditionSplit.Length == 1)
//                {
//                    conditionSplit = args[2].Split('=');
//                    conditionOperator = 0;
//                }

//                string fieldName = conditionSplit[0].ToLower();
//                string value = conditionSplit[1];

//                SatisfiesCondition = (IFields item) =>
//                {
//                    if (!item.Fields().ContainsKey(fieldName))
//                    {
//                        return false;
//                    }

//                    Type t1 = item.Fields()[fieldName].Item2;
//                    if (t1 == typeof(int))
//                    {
//                        return Convert.ToInt32(item.Fields()[fieldName].Item1).CompareTo(Convert.ToInt32(value)) == conditionOperator;
//                    }
//                    return item.Fields()[fieldName].Item1.CompareTo(value) == conditionOperator;
//                };

//            }

//            switch (args[1].ToLower())
//            {
//                case "animal":
//                    Console.WriteLine(ICollection<Animal>.Find(animals, SatisfiesCondition).ToString());
//                    break;
//                case "species":
//                    Console.WriteLine(ICollection<Species>.Find(species, SatisfiesCondition).ToString());
//                    break;
//                case "employee":
//                    Console.WriteLine(ICollection<Employee>.Find(employees, SatisfiesCondition).ToString());
//                    break;
//                case "visitor":
//                    Console.WriteLine(ICollection<Visitor>.Find(visitors, SatisfiesCondition).ToString());
//                    break;
//                case "enclosure":
//                    Console.WriteLine(ICollection<Enclosure>.Find(enclosures, SatisfiesCondition).ToString());
//                    break;
//                default:
//                    return false;
//            }

//            return true;
//        }

//        public void Start()
//        {
//            string input;
//            string[] inputSplit;
//            bool result;
//            while ((input = GetCommandFromUser()) != "exit")
//            {
//                try
//                {
//                    inputSplit = input.Trim().Split(" ");
//                    result = commands[inputSplit[0]].Invoke(inputSplit);
//                    if (result == false)
//                    {
//                        throw new Exception();
//                    }
//                }
//                catch
//                {
//                    Console.WriteLine("Error! Cannot proceed given command. Please try again.");
//                }
//            }
//        }
//    }
//}


/*
namespace Project_1
{
    class CommandLoop 
    {
        private Dictionary<string, Func<string[], bool>> commands;
        private Dictionary<string, Action<Func<IFields, bool>>> printFunctions; // maps strings to actions that take a function of type Func<IFields, bool> and return void.
        private Dictionary<string, List<string>> availableFields;
        private DoublyLinkedList<Employee> employees;
        private DoublyLinkedList<Animal> animals;
        private DoublyLinkedList<Species> species;
        private DoublyLinkedList<Visitor> visitors;
        private DoublyLinkedList<Enclosure> enclosures;

        public CommandLoop() // constructor method that initializes these fields with various values
        {
            commands = new() // "commands" dictionary is initialized with three entries. The keys are the strings "list", "find", and "add",
            {
                ["list"] = List,
                ["find"] = Find,
                ["add"] = Add
            };

            printFunctions = new() // "printFunctions" dictionary is initialized with five entries. The keys are the strings "animal", "species", "visitor", "enclosure", and "employee"
            {
                // values are functions that take a Func<IFields, bool> as input and print the results of that function.

                ["animal"] = ListAnimals,
                ["species"] = ListSpecies,
                ["visitor"] = ListVisitors,
                ["enclosure"] = ListEnclosures,
                ["employee"] = ListEmployees
            };

            availableFields = new() // dictionary is initialized with five entries. The keys are the strings "animal", "species", "visitor", "enclosure", and "employee"
            {
                // the values are lists of strings that indicate the fields that are available for each type of object.
                ["animal"] = new() { "name", "age" },
                ["species"] = new() { "name" },
                ["visitor"] = new() { "name", "surname" },
                ["enclosure"] = new() { "name" },
                ["employee"] = new() { "name", "surname", "age" }
            };

            Employee emp1 = new("Ricardo", "Stallmano", 73);
            Employee emp2 = new("Steve", "Irvin", 43);

            Visitor vis1 = new("Tomas", "German");
            Visitor vis2 = new("Silvester", "Ileen");
            Visitor vis3 = new("Basil", "Bailey");
            Visitor vis4 = new("Ryker", "Polly");

            Species spec1 = new("Meerkat");
            Species spec2 = new("Kakapo");
            Species spec3 = new("Bengal Tiger");
            Species spec4 = new("Panda");
            Species spec5 = new("Python");
            Species spec6 = new("Dungeness Crab");
            Species spec7 = new("Gopher");
            Species spec8 = new("Cats");
            Species spec9 = new("Penguin");

            spec1.AddFavouriteFood(ref spec1);
            spec3.AddFavouriteFood(ref spec4);
            spec3.AddFavouriteFood(ref spec7);
            spec3.AddFavouriteFood(ref spec8);
            spec5.AddFavouriteFood(ref spec4);
            spec5.AddFavouriteFood(ref spec3);
            spec6.AddFavouriteFood(ref spec5);
            spec8.AddFavouriteFood(ref spec7);
            spec9.AddFavouriteFood(ref spec3);

            Animal anim1 = new("Harold", 2, ref spec1);
            Animal anim2 = new("Ryan", 1, ref spec1);
            Animal anim3 = new("Jenkins", 15, ref spec2);
            Animal anim4 = new("Kaka", 10, ref spec2);
            Animal anim5 = new("Ada", 13, ref spec3);
            Animal anim6 = new("Jett", 2, ref spec4);
            Animal anim7 = new("Conda", 4, ref spec5);
            Animal anim8 = new("Samuel", 2, ref spec5);
            Animal anim9 = new("Claire", 2, ref spec6);
            Animal anim10 = new("Andy", 3, ref spec7);
            Animal anim11 = new("Arrow", 5, ref spec8);
            Animal anim12 = new("Arch", 1, ref spec9);
            Animal anim13 = new("Ubuntu", 1, ref spec9);
            Animal anim14 = new("Fedora", 1, ref spec9);

            List<Animal> encl1Animals = new() { anim12, anim13, anim14, anim7, anim8, anim6 };
            Enclosure encl1 = new("311", ref encl1Animals, ref emp1);

            List<Animal> encl2Animals = new() { anim11, anim10, anim1, anim2 };
            Enclosure encl2 = new("Break", ref encl2Animals, ref emp2);

            List<Animal> encl3Animals = new() { anim3, anim4, anim5, anim9 };
            Enclosure encl3 = new("Jurasic Park", ref encl3Animals, ref emp2);

            vis1.Visit(ref encl1);
            vis1.Visit(ref encl2);
            vis2.Visit(ref encl3);
            vis3.Visit(ref encl1);
            vis3.Visit(ref encl3);
            vis4.Visit(ref encl2);

            employees = new();
            employees.Add(emp1);
            employees.Add(emp2);

            enclosures = new();
            enclosures.Add(encl1);
            enclosures.Add(encl2);
            enclosures.Add(encl3);

            visitors = new();
            visitors.Add(vis1);
            visitors.Add(vis2);
            visitors.Add(vis3);
            visitors.Add(vis4);

            species = new();
            species.Add(spec1);
            species.Add(spec2);
            species.Add(spec3);
            species.Add(spec4);
            species.Add(spec5);
            species.Add(spec6);
            species.Add(spec7);
            species.Add(spec8);
            species.Add(spec9);

            animals = new();
            animals.Add(anim1);
            animals.Add(anim2);
            animals.Add(anim3);
            animals.Add(anim4);
            animals.Add(anim5);
            animals.Add(anim6);
            animals.Add(anim7);
            animals.Add(anim8);
            animals.Add(anim9);
            animals.Add(anim10);
            animals.Add(anim11);
            animals.Add(anim12);
            animals.Add(anim13);
            animals.Add(anim14);
        }

        private static string? GetCommandFromUser() // getting command 
        {
            Console.Write(">> ");
            return Console.ReadLine();
        }

        private void ListAnimals(Func<IFields, bool> condition) // printing animal list 
        {
            Project_1.ICollection<Animal>.Print(animals, condition);
        }

        private void ListSpecies(Func<IFields, bool> condition) // printing species list 
        {
            Project_1.ICollection<Species>.Print(species, condition);
        }

        private void ListEmployees(Func<IFields, bool> condition) // printing employees list 
        {
            Project_1.ICollection<Employee>.Print(employees, condition);
        }

        private void ListVisitors(Func<IFields, bool> condition) // printing visitors list
        {
            Project_1.ICollection<Visitor>.Print(visitors, condition);
        }

        private void ListEnclosures(Func<IFields, bool> condition) // printing enclosures list 
        {
            Project_1.ICollection<Enclosure>.Print(enclosures, condition);
        }

        private bool List(string[] a) // implementing list command (taking array of strings)
        {
            if (a.Length < 2) // check if array has at least 2 elements 
            {
                return false;
            }

            Func<IFields, bool> SatisfiesCondition = (IFields item) => // if successful, creating delegates 
            {
                return true;
            };
            printFunctions[a[1].ToLower()].Invoke(SatisfiesCondition); // retrieves printFunctions dictionary object (contains a collection of print-related functions that can be invoked by the List command)

            return true; // returning bollean value indicating if the command was successful or not 
        }

        private bool Find(string[] a) // implementing find command 
        {
            if (a.Length < 2)
            {
                return false;
            }

            Func<IFields, bool> SatisfiesCondition = (IFields item) => // delegate called SatisfiesCondition is created and assigned to a lambda expression that always returns true. This is the default condition if no other condition is specified.
            {
                return true;
            };

            if (a.Length > 2) // checks what operator is used in the condition ("<", ">", or "=") and extracts the field name and value to compare
            {
                string condition = a[2];
                string[] conditionSplit = a[2].Split('<');
                int conditionOperator = -1;

                if (conditionSplit.Length == 1)
                {
                    conditionSplit = a[2].Split('>');
                    conditionOperator = 1;
                }

                if (conditionSplit.Length == 1)
                {
                    conditionSplit = a[2].Split('=');
                    conditionOperator = 0;
                }

                string fieldName = conditionSplit[0].ToLower(); //  field name is converted to lowercase and stored in the variable "fieldName", while the value to compare is stored in the variable "value"
                string value = conditionSplit[1];

                SatisfiesCondition = (IFields item) => // The SatisfiesCondition delegate is re-assigned to a new lambda expression that checks if the specified field exists in the record being evaluated
                {
                    if (!item.Fields().ContainsKey(fieldName))
                    {
                        return false;
                    }

                    Type t1 = item.Fields()[fieldName].Item2;
                    if (t1 == typeof(int))
                    {
                        return Convert.ToInt32(item.Fields()[fieldName].Item1).CompareTo(Convert.ToInt32(value)) == conditionOperator; // printFunctions dictionary is used to call the appropriate method to print the records that satisfy the specified condition.
                    }
                    return item.Fields()[fieldName].Item1.CompareTo(value) == conditionOperator;
                };
            }

            printFunctions[a[1].ToLower()].Invoke(SatisfiesCondition);

            return true;
        }

        private bool Add(string[] args) // implementing add command 
        {
            string objectClass = args[1].ToLower();
            if (!availableFields.ContainsKey(objectClass)) // checking if the object class specified by user exists in the list of available fields 
            {
                return false;
            }

            Console.Write("[Available fields: '"); // prints message about available fields (so user knows what information to provide)
            for (int fieldIndex = 0; fieldIndex < availableFields[objectClass].Count; fieldIndex++) // enter the loop prompting to enter the data for new object 
            {
                Console.Write(availableFields[objectClass][fieldIndex]);
                if (fieldIndex < availableFields[objectClass].Count - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.Write("']\n");

            Dictionary<string, string> fields = new();
            string input = "";
            while (input != "DONE" && input != "EXIT")
            {
                input = Console.ReadLine();
                if (input == "DONE") // DONE --> finish adding object
                {
                    CreateObject(objectClass, fields); // creates a new object of the specified class with the provided field values and adds it to a list of objects
                }
                else if (input == "EXIT") // EXIT --> abort creation process 
                {
                    Console.WriteLine($"[{objectClass} creation abandoned]");
                }
                else // checks if user enters a field data in the format "field=value", the code checks whether the specified field exists in the list of available fields
                {
                    string[] fieldData = input.Split('=');
                    if (availableFields[objectClass].Contains(fieldData[0]))
                    {
                        fields[fieldData[0]] = fieldData[1]; // if does, field data is added to a dictionary of fields 
                    }
                    else // if doesn't, prints appropriate message 
                    {
                        Console.WriteLine($"[{objectClass} doesn't take \"{fieldData[0]}\"]");
                    }
                }
            }

            return true;
        }

        private void CreateObject(string objectClass, Dictionary<string, string> fields) // definition of CreateObject method 
        {
            string name, surname;
            int age;

            switch (objectClass) // defne fields for each class 
            {
                case "animal":
                    name = fields.GetValueOrDefault("name") ?? "";
                    age = Convert.ToInt32(fields.GetValueOrDefault("age"));
                    Species emptySpecies = new("");
                    animals.Add(new(name, age, ref emptySpecies));
                    break;
                case "species":
                    name = fields.GetValueOrDefault("name") ?? "";
                    species.Add(new(name));
                    break;
                case "employee":
                    name = fields.GetValueOrDefault("name") ?? "";
                    surname = fields.GetValueOrDefault("surname") ?? "";
                    age = Convert.ToInt32(fields.GetValueOrDefault("age"));
                    employees.Add(new(name, surname, age));
                    break;
                case "visitor":
                    name = fields.GetValueOrDefault("name") ?? "";
                    surname = fields.GetValueOrDefault("surname") ?? "";
                    visitors.Add(new(name, surname));
                    break;
                case "enclosure":
                    name = fields.GetValueOrDefault("name") ?? "";
                    List<Animal> emptyList = new();
                    Employee emptyEmployee = new("", "", 0);
                    enclosures.Add(new(name, ref emptyList, ref emptyEmployee));
                    break;
            }
            Console.WriteLine($"[{objectClass} created]");
        }

        public void Start()
        {
            string input;
            string[] inputSplit; // to splitting separate words 
            bool result;
            while ((input = GetCommandFromUser()) != "exit") // reads user input untill exit command encountered 
            {
                try
                {
                    inputSplit = input.Trim().Split(" "); // splits into separate words 
                    result = commands[inputSplit[0]].Invoke(inputSplit); //  looks up the corresponding command in a dictionary of command functions 
                    if (result == false)
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    Console.WriteLine("Error! Cannot proceed given command. Please try again.");
                }
            }
        }
    }
}
*/


using Project1;
using Project2;
using System.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

/*
namespace Project3
{
    class CommandLoop
    {
        private Dictionary<string, Func<string[], bool>> commands;

        private Vector<Command> commandQueue;
        private Dictionary<string, Action<Func<IFields, bool>>> printFunctions;
        private Dictionary<string, List<string>> availableFields;
        private DoublyLinkedList<IEmployee> employees;
        private DoublyLinkedList<IAnimal> animals;
        private DoublyLinkedList<ISpecies> species;
        private DoublyLinkedList<IVisitor> visitors;
        private DoublyLinkedList<IEnclosure> enclosures;
        private bool exit = false;

        public CommandLoop()
        {
            commands = new()
            {
                ["list"] = List,
                ["find"] = Find,
                ["add"] = Add,
                ["queue"] = Queue,
                ["edit"] = Edit,
                ["delete"] = Delete,
                ["exit"] = Exit
            };

            commandQueue = new();

            printFunctions = new()
            {
                ["animal"] = ListAnimals,
                ["species"] = ListSpecies,
                ["visitor"] = ListVisitors,
                ["enclosure"] = ListEnclosures,
                ["employee"] = ListEmployees
            };

            availableFields = new()
            {
                ["animal"] = new() { "name", "age", "species" },
                ["species"] = new() { "name" },
                ["visitor"] = new() { "name", "surname" },
                ["enclosure"] = new() { "name" },
                ["employee"] = new() { "name", "surname", "age" }
            };

            Project1.Representation_0.Employee emp1 = new("Ricardo", "Stallmano", 73);
            Project1.Representation_0.Employee emp2 = new("Steve", "Irvin", 43);

            Project1.Representation_0.Visitor vis1 = new("Tomas", "German");
            Project1.Representation_0.Visitor vis2 = new("Silvester", "Ileen");
            Project1.Representation_0.Visitor vis3 = new("Basil", "Bailey");
            Project1.Representation_0.Visitor vis4 = new("Ryker", "Polly");

            Project1.Representation_0.Species spec1 = new("Meerkat");
            Project1.Representation_0.Species spec2 = new("Kakapo");
            Project1.Representation_0.Species spec3 = new("Bengal Tiger");
            Project1.Representation_0.Species spec4 = new("Panda");
            Project1.Representation_0.Species spec5 = new("Python");
            Project1.Representation_0.Species spec6 = new("Dungeness Crab");
            Project1.Representation_0.Species spec7 = new("Gopher");
            Project1.Representation_0.Species spec8 = new("Cats");
            Project1.Representation_0.Species spec9 = new("Penguin");

            spec1.AddFavouriteFood(ref spec1);
            spec3.AddFavouriteFood(ref spec4);
            spec3.AddFavouriteFood(ref spec7);
            spec3.AddFavouriteFood(ref spec8);
            spec5.AddFavouriteFood(ref spec4);
            spec5.AddFavouriteFood(ref spec3);
            spec6.AddFavouriteFood(ref spec5);
            spec8.AddFavouriteFood(ref spec7);
            spec9.AddFavouriteFood(ref spec3);

            Project1.Representation_0.Animal anim1 = new("Harold", 2, ref spec1);
            Project1.Representation_0.Animal anim2 = new("Ryan", 1, ref spec1);
            Project1.Representation_0.Animal anim3 = new("Jenkins", 15, ref spec2);
            Project1.Representation_0.Animal anim4 = new("Kaka", 10, ref spec2);
            Project1.Representation_0.Animal anim5 = new("Ada", 13, ref spec3);
            Project1.Representation_0.Animal anim6 = new("Jett", 2, ref spec4);
            Project1.Representation_0.Animal anim7 = new("Conda", 4, ref spec5);
            Project1.Representation_0.Animal anim8 = new("Samuel", 2, ref spec5);
            Project1.Representation_0.Animal anim9 = new("Claire", 2, ref spec6);
            Project1.Representation_0.Animal anim10 = new("Andy", 3, ref spec7);
            Project1.Representation_0.Animal anim11 = new("Arrow", 5, ref spec8);
            Project1.Representation_0.Animal anim12 = new("Arch", 1, ref spec9);
            Project1.Representation_0.Animal anim13 = new("Ubuntu", 1, ref spec9);
            Project1.Representation_0.Animal anim14 = new("Fedora", 1, ref spec9);

            List<Project1.Representation_0.Animal> encl1Animals = new() { anim12, anim13, anim14, anim7, anim8, anim6 };
            Project1.Representation_0.Enclosure encl1 = new("311", ref encl1Animals, ref emp1);

            List<Project1.Representation_0.Animal> encl2Animals = new() { anim11, anim10, anim1, anim2 };
            Project1.Representation_0.Enclosure encl2 = new("Break", ref encl2Animals, ref emp2);

            List<Project1.Representation_0.Animal> encl3Animals = new() { anim3, anim4, anim5, anim9 };
            Project1.Representation_0.Enclosure encl3 = new("Jurasic Park", ref encl3Animals, ref emp2);

            vis1.Visit(ref encl1);
            vis1.Visit(ref encl2);
            vis2.Visit(ref encl3);
            vis3.Visit(ref encl1);
            vis3.Visit(ref encl3);
            vis4.Visit(ref encl2);

            employees = new();
            employees.Add(emp1);
            employees.Add(emp2);

            enclosures = new();
            enclosures.Add(encl1);
            enclosures.Add(encl2);
            enclosures.Add(encl3);

            visitors = new();
            visitors.Add(vis1);
            visitors.Add(vis2);
            visitors.Add(vis3);
            visitors.Add(vis4);

            species = new();
            species.Add(spec1);
            species.Add(spec2);
            species.Add(spec3);
            species.Add(spec4);
            species.Add(spec5);
            species.Add(spec6);
            species.Add(spec7);
            species.Add(spec8);
            species.Add(spec9);

            animals = new();
            animals.Add(anim1);
            animals.Add(anim2);
            animals.Add(anim3);
            animals.Add(anim4);
            animals.Add(anim5);
            animals.Add(anim6);
            animals.Add(anim7);
            animals.Add(anim8);
            animals.Add(anim9);
            animals.Add(anim10);
            animals.Add(anim11);
            animals.Add(anim12);
            animals.Add(anim13);
            animals.Add(anim14);
        }

        private static string? GetCommandFromUser()
        {
            Console.Write(">> ");
            return Console.ReadLine();
        }

        private void ListAnimals(Func<IFields, bool> condition)
        {
            Project2.ICollection<IAnimal>.Print(animals, condition);
        }

        private void ListSpecies(Func<IFields, bool> condition)
        {
            Project2.ICollection<ISpecies>.Print(species, condition);
        }

        private void ListEmployees(Func<IFields, bool> condition)
        {
            Project2.ICollection<IEmployee>.Print(employees, condition);
        }

        private void ListVisitors(Func<IFields, bool> condition)
        {
            Project2.ICollection<IVisitor>.Print(visitors, condition);
        }

        private void ListEnclosures(Func<IFields, bool> condition)
        {
            Project2.ICollection<IEnclosure>.Print(enclosures, condition);
        }

        private bool List(string[] args)
        {
            if (args.Length < 2)
            {
                return false;
            }

            Func<IFields, bool> SatisfiesCondition = (IFields item) =>
            {
                return true;
            };
            printFunctions[args[1].ToLower()].Invoke(SatisfiesCondition);

            return true;
        }

        private bool Find(string[] args)
        {
            if (args.Length < 2)
            {
                return false;
            }

            Func<IFields, bool> SatisfiesCondition = (IFields item) =>
            {
                return true;
            };

            if (args.Length > 2)
            {
                string condition = args[2];
                string[] conditionSplit = args[2].Split('<');
                int conditionOperator = -1;

                if (conditionSplit.Length == 1)
                {
                    conditionSplit = args[2].Split('>');
                    conditionOperator = 1;
                }

                if (conditionSplit.Length == 1)
                {
                    conditionSplit = args[2].Split('=');
                    conditionOperator = 0;
                }

                string fieldName = conditionSplit[0].ToLower();
                string value = conditionSplit[1];

                SatisfiesCondition = (IFields item) =>
                {
                    if (!item.Fields().ContainsKey(fieldName))
                    {
                        return false;
                    }

                    Type t1 = item.Fields()[fieldName].Item2;
                    if (t1 == typeof(int))
                    {
                        return Convert.ToInt32(item.Fields()[fieldName].Item1).CompareTo(Convert.ToInt32(value)) == conditionOperator;
                    }
                    return item.Fields()[fieldName].Item1.CompareTo(value) == conditionOperator;
                };
            }

            printFunctions[args[1].ToLower()].Invoke(SatisfiesCondition);

            return true;
        }

        private bool Add(string[] args)
        {
            string objectClass = args[1].ToLower();
            bool isBaseRepresentation = true;
            if (args.Length > 2)
            {
                isBaseRepresentation = args[2].ToLower() == "base";
            }

            if (!availableFields.ContainsKey(objectClass))
            {
                return false;
            }

            Console.Write("[Available fields: '");
            for (int fieldIndex = 0; fieldIndex < availableFields[objectClass].Count; fieldIndex++)
            {
                Console.Write(availableFields[objectClass][fieldIndex]);
                if (fieldIndex < availableFields[objectClass].Count - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.Write("']\n");

            Dictionary<string, string> fields = new();
            string input = "";
            while (input != "DONE" && input != "EXIT")
            {
                input = Console.ReadLine();
                if (input == "DONE")
                {
                    CreateObject(objectClass, isBaseRepresentation, fields);
                }
                else if (input == "EXIT")
                {
                    Console.WriteLine($"[{objectClass} creation abandoned]");
                }
                else
                {
                    string[] fieldData = input.Split('=');
                    if (availableFields[objectClass].Contains(fieldData[0]))
                    {
                        fields[fieldData[0]] = fieldData[1];
                    }
                    else
                    {
                        Console.WriteLine($"[{objectClass} doesn't take \"{fieldData[0]}\"]");
                    }
                }
            }

            return true;
        }

        private void CreateObject(string objectClass, bool isBaseRepresentation, Dictionary<string, string> fields)
        {
            string name, surname, speciesName;
            int age;

            switch (objectClass)
            {
                case "animal":
                    name = fields.GetValueOrDefault("name") ?? "";
                    speciesName = fields.GetValueOrDefault("species") ?? "";
                    age = Convert.ToInt32(fields.GetValueOrDefault("age"));
                    Project1.Representation_0.Species emptySpecies = new(speciesName);
                    if (isBaseRepresentation)
                    {
                        animals.Add(new Project1.Representation_0.Animal(name, age, ref emptySpecies));
                    }
                    else
                    {
                        animals.Add(new Project1.Representation_1.Animal(name, age, speciesName));
                    }
                    break;
                case "species":
                    name = fields.GetValueOrDefault("name") ?? "";
                    if (isBaseRepresentation)
                    {
                        species.Add(new Project1.Representation_0.Species(name));
                    }
                    else
                    {
                        species.Add(new Project1.Representation_1.Species(name));
                    }
                    break;
                case "employee":
                    name = fields.GetValueOrDefault("name") ?? "";
                    surname = fields.GetValueOrDefault("surname") ?? "";
                    age = Convert.ToInt32(fields.GetValueOrDefault("age"));
                    if (isBaseRepresentation)
                    {
                        employees.Add(new Project1.Representation_0.Employee(name, surname, age));
                    }
                    else
                    {
                        employees.Add(new Project1.Representation_1.Employee(name, surname, age));
                    }
                    break;
                case "visitor":
                    name = fields.GetValueOrDefault("name") ?? "";
                    surname = fields.GetValueOrDefault("surname") ?? "";
                    if (isBaseRepresentation)
                    {
                        visitors.Add(new Project1.Representation_0.Visitor(name, surname));
                    }
                    else
                    {
                        visitors.Add(new Project1.Representation_1.Visitor(name, surname));
                    }
                    break;
                case "enclosure":
                    name = fields.GetValueOrDefault("name") ?? "";
                    List<Project1.Representation_0.Animal> emptyList = new();
                    Project1.Representation_0.Employee emptyEmployee = new("", "", 0);
                    if (isBaseRepresentation)
                    {
                        enclosures.Add(new Project1.Representation_0.Enclosure(name, ref emptyList, ref emptyEmployee));
                    }
                    else
                    {
                        enclosures.Add(new Project1.Representation_1.Enclosure(name, new(), ""));
                    }
                    break;
            }
            Console.WriteLine($"[{objectClass} created]");
        }

        private bool Queue(string[] args)
        {
            switch (args[1])
            {
                case "print":
                    return QueuePrint(args);
                case "commit":
                    return QueueCommit(args);
                case "export":
                    return QueueExport(args);
                case "dismiss":
                    return QueueDismiss(args);
                case "load":
                    return QueueLoad(args);
            }

            if (!commands.ContainsKey(args[1]))
            {
                return false;
            }

            commandQueue.Add(new(args[1], new(args.ToList().Skip(2))));

            return true;
        }

        private bool Edit(string[] args)
        {
            string objectClass = args[1].ToLower();

            Func<IFields, bool> SatisfiesCondition = (IFields item) =>
            {
                return true;
            };

            if (args.Length > 2)
            {
                string condition = args[2];
                string[] conditionSplit = args[2].Split('<');
                int conditionOperator = -1;

                if (conditionSplit.Length == 1)
                {
                    conditionSplit = args[2].Split('>');
                    conditionOperator = 1;
                }

                if (conditionSplit.Length == 1)
                {
                    conditionSplit = args[2].Split('=');
                    conditionOperator = 0;
                }

                string fieldName = conditionSplit[0].ToLower();
                string value = conditionSplit[1];

                SatisfiesCondition = (IFields item) =>
                {
                    if (!item.Fields().ContainsKey(fieldName))
                    {
                        return false;
                    }

                    Type t1 = item.Fields()[fieldName].Item2;
                    if (t1 == typeof(int))
                    {
                        return Convert.ToInt32(item.Fields()[fieldName].Item1).CompareTo(Convert.ToInt32(value)) == conditionOperator;
                    }
                    return item.Fields()[fieldName].Item1.CompareTo(value) == conditionOperator;
                };
            }

            if (!availableFields.ContainsKey(objectClass))
            {
                return false;
            }

            Console.Write("[Available fields: '");
            for (int fieldIndex = 0; fieldIndex < availableFields[objectClass].Count; fieldIndex++)
            {
                Console.Write(availableFields[objectClass][fieldIndex]);
                if (fieldIndex < availableFields[objectClass].Count - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.Write("']\n");

            Dictionary<string, string> fields = new();
            string input = "";
            while (input != "DONE" && input != "EXIT")
            {
                input = Console.ReadLine();
                if (input == "DONE")
                {
                    EditObject(objectClass, SatisfiesCondition, fields);
                }
                else if (input == "EXIT")
                {
                    Console.WriteLine($"[{objectClass} edition abandoned]");
                }
                else
                {
                    string[] fieldData = input.Split('=');
                    if (availableFields[objectClass].Contains(fieldData[0]))
                    {
                        fields[fieldData[0]] = fieldData[1];
                    }
                    else
                    {
                        Console.WriteLine($"[{objectClass} doesn't take \"{fieldData[0]}\"]");
                    }
                }
            }

            return true;
        }

        private bool QueueDismiss(string[] args)
        {
            commandQueue = new();
            return true;
        }

        private bool EditObject(string objectClass, Func<IFields, bool> condition, Dictionary<string, string> fields)
        {
            string name, surname;
            int age;

            switch (objectClass)
            {
                case "animal":
                    IAnimal foundAnimal = Project2.ICollection<IAnimal>.Find(animals, condition);
                    if (foundAnimal == null)
                    {
                        return false;
                    }

                    name = fields.GetValueOrDefault("name") ?? foundAnimal.Fields()["name"].Item1;
                    if (fields.ContainsKey("age"))
                    {
                        age = Convert.ToInt32(fields.GetValueOrDefault("age"));
                    }
                    else
                    {
                        age = Convert.ToInt32(foundAnimal.Fields()["age"].Item1);
                    }

                    foundAnimal.Edit(name, age);
                    break;
                case "species":
                    ISpecies foundSpecies = Project2.ICollection<ISpecies>.Find(species, condition);
                    if (foundSpecies == null)
                    {
                        return false;
                    }

                    name = fields.GetValueOrDefault("name") ?? foundSpecies.Fields()["name"].Item1;

                    foundSpecies.Edit(name);
                    break;
                case "employee":
                    IEmployee foundEmployee = Project2.ICollection<IEmployee>.Find(employees, condition);
                    if (foundEmployee == null)
                    {
                        return false;
                    }

                    name = fields.GetValueOrDefault("name") ?? foundEmployee.Fields()["name"].Item1;
                    surname = fields.GetValueOrDefault("surname") ?? foundEmployee.Fields()["surname"].Item1;
                    if (fields.ContainsKey("age"))
                    {
                        age = Convert.ToInt32(fields.GetValueOrDefault("age"));
                    }
                    else
                    {
                        age = Convert.ToInt32(foundEmployee.Fields()["age"].Item1);
                    }

                    foundEmployee.Edit(name, surname, age);
                    break;
                case "visitor":
                    IVisitor foundVisitor = Project2.ICollection<IVisitor>.Find(visitors, condition);
                    if (foundVisitor == null)
                    {
                        return false;
                    }

                    name = fields.GetValueOrDefault("name") ?? foundVisitor.Fields()["name"].Item1;
                    surname = fields.GetValueOrDefault("surname") ?? foundVisitor.Fields()["surname"].Item1;

                    foundVisitor.Edit(name, surname);
                    break;
                case "enclosure":
                    IEnclosure foundEnclosure = Project2.ICollection<IEnclosure>.Find(enclosures, condition);
                    if (foundEnclosure == null)
                    {
                        return false;
                    }

                    name = fields.GetValueOrDefault("name") ?? foundEnclosure.Fields()["name"].Item1;

                    foundEnclosure.Edit(name);
                    break;
            }
            Console.WriteLine($"[{objectClass} created]");
            return true;
        }

        private bool QueuePrint(string[] args)
        {
            foreach (Command command in commandQueue)
            {
                Console.WriteLine(command.ToString());
            }

            return true;
        }

        private bool QueueExport(string[] args)
        {
            string filename = args[2];
            string format = "xml";
            if (args.Length > 3)
            {
                format = args[3].ToLower();
            }

            if (format == "plaintext")
            {
                File.WriteAllLines(filename, commandQueue.Select(command => command.ToString()));
            }
            else
            {
                using XmlWriter writer = XmlWriter.Create(filename);
                writer.WriteStartElement("queue");
                foreach (Command command in commandQueue)
                {
                    writer.WriteStartElement("command");
                    writer.WriteElementString("name", command.Name);
                    writer.WriteStartElement("parameters");
                    foreach (string parameter in command.Parameters)
                    {
                        writer.WriteElementString("parameter", parameter);
                    }
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.Flush();
            }

            return true;
        }

        private bool QueueCommit(string[] args)
        {
            foreach (Command command in commandQueue)
            {
                ExecuteCommand(command);
            }

            commandQueue = new();

            return true;
        }

        private bool QueueLoad(string[] args)
        {
            string filePath = args[2];
            commandQueue = new();

            if (filePath.EndsWith(".xml"))
            {
                XmlDocument xmlDocument = new();
                xmlDocument.Load(filePath);
                foreach (XmlNode node in xmlDocument.DocumentElement.ChildNodes)
                {
                    List<string> commandSplit = new()
                    {
                        "queue",
                        node.SelectSingleNode("name").InnerText
                    };

                    XmlNode parametersNode = node.SelectSingleNode("parameters");
                    foreach (XmlNode parameterNode in parametersNode.ChildNodes)
                    {
                        commandSplit.Add(parameterNode.InnerText);
                    }

                    Queue(commandSplit.ToArray());
                }
            }
            else
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    List<string> lineSplit = new() { "queue" };
                    lineSplit.AddRange(line.Split(" "));
                    Queue(lineSplit.ToArray());
                }
            }

            return true;
        }

        private void ExecuteCommand(Command command)
        {
            command.Parameters.Insert(0, command.Name);
            commands[command.Name].Invoke(command.Parameters.ToArray());
        }

        private bool Delete(string[] args)
        {
            string objectClass = args[1];

            if (args.Length < 2)
            {
                return false;
            }

            Func<IFields, bool> SatisfiesCondition = (IFields item) =>
            {
                return true;
            };

            if (args.Length > 2)
            {
                string condition = args[2];
                string[] conditionSplit = args[2].Split('<');
                int conditionOperator = -1;

                if (conditionSplit.Length == 1)
                {
                    conditionSplit = args[2].Split('>');
                    conditionOperator = 1;
                }

                if (conditionSplit.Length == 1)
                {
                    conditionSplit = args[2].Split('=');
                    conditionOperator = 0;
                }

                string fieldName = conditionSplit[0].ToLower();
                string value = conditionSplit[1];

                SatisfiesCondition = (IFields item) =>
                {
                    if (!item.Fields().ContainsKey(fieldName))
                    {
                        return false;
                    }

                    Type t1 = item.Fields()[fieldName].Item2;
                    if (t1 == typeof(int))
                    {
                        return Convert.ToInt32(item.Fields()[fieldName].Item1).CompareTo(Convert.ToInt32(value)) == conditionOperator;
                    }
                    return item.Fields()[fieldName].Item1.CompareTo(value) == conditionOperator;
                };
            }

            switch (objectClass)
            {
                case "animal":
                    IAnimal foundAnimal = Project2.ICollection<IAnimal>.Find(animals, SatisfiesCondition);
                    if (foundAnimal == null)
                    {
                        return false;
                    }
                    animals.Remove(foundAnimal);
                    break;
                case "species":
                    ISpecies foundSpecies = Project2.ICollection<ISpecies>.Find(species, SatisfiesCondition);
                    if (foundSpecies == null)
                    {
                        return false;
                    }
                    species.Remove(foundSpecies);
                    break;
                case "employee":
                    IEmployee foundEmployee = Project2.ICollection<IEmployee>.Find(employees, SatisfiesCondition);
                    if (foundEmployee == null)
                    {
                        return false;
                    }
                    employees.Remove(foundEmployee);
                    break;
                case "visitor":
                    IVisitor foundVisitor = Project2.ICollection<IVisitor>.Find(visitors, SatisfiesCondition);
                    if (foundVisitor == null)
                    {
                        return false;
                    }
                    visitors.Remove(foundVisitor);
                    break;
                case "enclosure":
                    IEnclosure foundEnclosure = Project2.ICollection<IEnclosure>.Find(enclosures, SatisfiesCondition);
                    if (foundEnclosure == null)
                    {
                        return false;
                    }
                    enclosures.Remove(foundEnclosure);
                    break;
            }
            Console.WriteLine($"[{objectClass} deleted]");
            return true;
        }

        private bool Exit(string[] args)
        {
            exit = true;
            return true;
        }

        public void Start()
        {
            string input;
            string[] inputSplit;
            bool result;
            while (!exit && (input = GetCommandFromUser()) != "exit")
            {
                try
                {
                    inputSplit = input.Trim().Split(" ");
                    result = commands[inputSplit[0]].Invoke(inputSplit);
                    if (result == false)
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    Console.WriteLine("Error! Cannot proceed given command. Please try again.");
                }
            }
        }
    }
}
*/
using System;
using System.Collections.Generic;
using System.Linq;


namespace Project3
{
    class CommandLoop
    {
        private Dictionary<string, Func<string[], bool>> commands;
        private List<Command> commandQueue;
        private Stack<Command> commandHistory; // for history command 
        private Stack<Command> redoHistory; // for redo command 
        private Dictionary<string, Action<Func<IFields, bool>>> printFunctions;
        private Dictionary<string, List<string>> availableFields;
        private DoublyLinkedList<IEmployee> employees;
        private DoublyLinkedList<IAnimal> animals;
        private DoublyLinkedList<ISpecies> species;
        private DoublyLinkedList<IVisitor> visitors;
        private DoublyLinkedList<IEnclosure> enclosures;
        private bool exit = false;


        public CommandLoop()
        {
            commands = new Dictionary<string, Func<string[], bool>>()
            {
                ["list"] = List,
                ["find"] = Find,
                ["add"] = Add,
                ["queue"] = Queue,
                ["edit"] = Edit,
                ["delete"] = Delete,
                ["exit"] = Exit,
                ["history"] = History,
                ["undo"] = Undo,
                ["redo"] = Redo
            };

            commandQueue = new List<Command>();
            commandHistory = new Stack<Command>(); // initializing 
            redoHistory = new Stack<Command>(); // initializing

            printFunctions = new()
            {
                ["animal"] = ListAnimals,
                ["species"] = ListSpecies,
                ["visitor"] = ListVisitors,
                ["enclosure"] = ListEnclosures,
                ["employee"] = ListEmployees
            };


            availableFields = new()
            {
                ["animal"] = new() { "name", "age", "species" },
                ["species"] = new() { "name" },
                ["visitor"] = new() { "name", "surname" },
                ["enclosure"] = new() { "name" },
                ["employee"] = new() { "name", "surname", "age" }
            };

            Project1.Representation_0.Employee emp1 = new("Ricardo", "Stallmano", 73);
            Project1.Representation_0.Employee emp2 = new("Steve", "Irvin", 43);

            Project1.Representation_0.Visitor vis1 = new("Tomas", "German");
            Project1.Representation_0.Visitor vis2 = new("Silvester", "Ileen");
            Project1.Representation_0.Visitor vis3 = new("Basil", "Bailey");
            Project1.Representation_0.Visitor vis4 = new("Ryker", "Polly");

            Project1.Representation_0.Species spec1 = new("Meerkat");
            Project1.Representation_0.Species spec2 = new("Kakapo");
            Project1.Representation_0.Species spec3 = new("Bengal Tiger");
            Project1.Representation_0.Species spec4 = new("Panda");
            Project1.Representation_0.Species spec5 = new("Python");
            Project1.Representation_0.Species spec6 = new("Dungeness Crab");
            Project1.Representation_0.Species spec7 = new("Gopher");
            Project1.Representation_0.Species spec8 = new("Cats");
            Project1.Representation_0.Species spec9 = new("Penguin");

            spec1.AddFavouriteFood(ref spec1);
            spec3.AddFavouriteFood(ref spec4);
            spec3.AddFavouriteFood(ref spec7);
            spec3.AddFavouriteFood(ref spec8);
            spec5.AddFavouriteFood(ref spec4);
            spec5.AddFavouriteFood(ref spec3);
            spec6.AddFavouriteFood(ref spec5);
            spec8.AddFavouriteFood(ref spec7);
            spec9.AddFavouriteFood(ref spec3);

            Project1.Representation_0.Animal anim1 = new("Harold", 2, ref spec1);
            Project1.Representation_0.Animal anim2 = new("Ryan", 1, ref spec1);
            Project1.Representation_0.Animal anim3 = new("Jenkins", 15, ref spec2);
            Project1.Representation_0.Animal anim4 = new("Kaka", 10, ref spec2);
            Project1.Representation_0.Animal anim5 = new("Ada", 13, ref spec3);
            Project1.Representation_0.Animal anim6 = new("Jett", 2, ref spec4);
            Project1.Representation_0.Animal anim7 = new("Conda", 4, ref spec5);
            Project1.Representation_0.Animal anim8 = new("Samuel", 2, ref spec5);
            Project1.Representation_0.Animal anim9 = new("Claire", 2, ref spec6);
            Project1.Representation_0.Animal anim10 = new("Andy", 3, ref spec7);
            Project1.Representation_0.Animal anim11 = new("Arrow", 5, ref spec8);
            Project1.Representation_0.Animal anim12 = new("Arch", 1, ref spec9);
            Project1.Representation_0.Animal anim13 = new("Ubuntu", 1, ref spec9);
            Project1.Representation_0.Animal anim14 = new("Fedora", 1, ref spec9);

            List<Project1.Representation_0.Animal> encl1Animals = new() { anim12, anim13, anim14, anim7, anim8, anim6 };
            Project1.Representation_0.Enclosure encl1 = new("311", ref encl1Animals, ref emp1);

            List<Project1.Representation_0.Animal> encl2Animals = new() { anim11, anim10, anim1, anim2 };
            Project1.Representation_0.Enclosure encl2 = new("Break", ref encl2Animals, ref emp2);

            List<Project1.Representation_0.Animal> encl3Animals = new() { anim3, anim4, anim5, anim9 };
            Project1.Representation_0.Enclosure encl3 = new("Jurasic Park", ref encl3Animals, ref emp2);

            vis1.Visit(ref encl1);
            vis1.Visit(ref encl2);
            vis2.Visit(ref encl3);
            vis3.Visit(ref encl1);
            vis3.Visit(ref encl3);
            vis4.Visit(ref encl2);

            employees = new();
            employees.Add(emp1);
            employees.Add(emp2);

            enclosures = new();
            enclosures.Add(encl1);
            enclosures.Add(encl2);
            enclosures.Add(encl3);

            visitors = new();
            visitors.Add(vis1);
            visitors.Add(vis2);
            visitors.Add(vis3);
            visitors.Add(vis4);

            species = new();
            species.Add(spec1);
            species.Add(spec2);
            species.Add(spec3);
            species.Add(spec4);
            species.Add(spec5);
            species.Add(spec6);
            species.Add(spec7);
            species.Add(spec8);
            species.Add(spec9);

            animals = new();
            animals.Add(anim1);
            animals.Add(anim2);
            animals.Add(anim3);
            animals.Add(anim4);
            animals.Add(anim5);
            animals.Add(anim6);
            animals.Add(anim7);
            animals.Add(anim8);
            animals.Add(anim9);
            animals.Add(anim10);
            animals.Add(anim11);
            animals.Add(anim12);
            animals.Add(anim13);
            animals.Add(anim14);
        }

        private static string? GetCommandFromUser()
        {
            Console.Write(">> ");
            return Console.ReadLine();
        }

        private void ListAnimals(Func<IFields, bool> condition)
        {
            Project2.ICollection<IAnimal>.Print(animals, condition);
        }

        private void ListSpecies(Func<IFields, bool> condition)
        {
            Project2.ICollection<ISpecies>.Print(species, condition);
        }

        private void ListEmployees(Func<IFields, bool> condition)
        {
            Project2.ICollection<IEmployee>.Print(employees, condition);
        }

        private void ListVisitors(Func<IFields, bool> condition)
        {
            Project2.ICollection<IVisitor>.Print(visitors, condition);
        }

        private void ListEnclosures(Func<IFields, bool> condition)
        {
            Project2.ICollection<IEnclosure>.Print(enclosures, condition);
        }


        private bool List(string[] args)
        {
            if (args.Length < 2)
            {
                return false;
            }

            Func<IFields, bool> SatisfiesCondition = (IFields item) =>
            {
                return true;
            };
            printFunctions[args[1].ToLower()].Invoke(SatisfiesCondition);

            return true;
        }

        private bool Find(string[] args)
        {
            if (args.Length < 2)
            {
                return false;
            }

            Func<IFields, bool> SatisfiesCondition = (IFields item) =>
            {
                return true;
            };

            if (args.Length > 2)
            {
                string condition = args[2];
                string[] conditionSplit = args[2].Split('<');
                int conditionOperator = -1;

                if (conditionSplit.Length == 1)
                {
                    conditionSplit = args[2].Split('>');
                    conditionOperator = 1;
                }

                if (conditionSplit.Length == 1)
                {
                    conditionSplit = args[2].Split('=');
                    conditionOperator = 0;
                }

                string fieldName = conditionSplit[0].ToLower();
                string value = conditionSplit[1];

                SatisfiesCondition = (IFields item) =>
                {
                    if (!item.Fields().ContainsKey(fieldName))
                    {
                        return false;
                    }

                    Type t1 = item.Fields()[fieldName].Item2;
                    if (t1 == typeof(int))
                    {
                        return Convert.ToInt32(item.Fields()[fieldName].Item1).CompareTo(Convert.ToInt32(value)) == conditionOperator;
                    }
                    return item.Fields()[fieldName].Item1.CompareTo(value) == conditionOperator;
                };
            }

            printFunctions[args[1].ToLower()].Invoke(SatisfiesCondition);

            return true;
        }

        private bool Add(string[] args)
        {
            string objectClass = args[1].ToLower();
            bool isBaseRepresentation = true;
            if (args.Length > 2)
            {
                isBaseRepresentation = args[2].ToLower() == "base";
            }

            if (!availableFields.ContainsKey(objectClass))
            {
                return false;
            }

            Console.Write("[Available fields: '");
            for (int fieldIndex = 0; fieldIndex < availableFields[objectClass].Count; fieldIndex++)
            {
                Console.Write(availableFields[objectClass][fieldIndex]);
                if (fieldIndex < availableFields[objectClass].Count - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.Write("']\n");

            Dictionary<string, string> fields = new();
            string input = "";
            while (input != "DONE" && input != "EXIT")
            {
                input = Console.ReadLine();
                if (input == "DONE")
                {
                    CreateObject(objectClass, isBaseRepresentation, fields);
                }
                else if (input == "EXIT")
                {
                    Console.WriteLine($"[{objectClass} creation abandoned]");
                }
                else
                {
                    string[] fieldData = input.Split('=');
                    if (availableFields[objectClass].Contains(fieldData[0]))
                    {
                        fields[fieldData[0]] = fieldData[1];
                    }
                    else
                    {
                        Console.WriteLine($"[{objectClass} doesn't take \"{fieldData[0]}\"]");
                    }
                }
            }

            return true;
        }

        private void CreateObject(string objectClass, bool isBaseRepresentation, Dictionary<string, string> fields)
        {
            string name, surname, speciesName;
            int age;

            switch (objectClass)
            {
                case "animal":
                    name = fields.GetValueOrDefault("name") ?? "";
                    speciesName = fields.GetValueOrDefault("species") ?? "";
                    age = Convert.ToInt32(fields.GetValueOrDefault("age"));
                    Project1.Representation_0.Species emptySpecies = new(speciesName);
                    if (isBaseRepresentation)
                    {
                        animals.Add(new Project1.Representation_0.Animal(name, age, ref emptySpecies));
                    }
                    else
                    {
                        animals.Add(new Project1.Representation_1.Animal(name, age, speciesName));
                    }
                    break;
                case "species":
                    name = fields.GetValueOrDefault("name") ?? "";
                    if (isBaseRepresentation)
                    {
                        species.Add(new Project1.Representation_0.Species(name));
                    }
                    else
                    {
                        species.Add(new Project1.Representation_1.Species(name));
                    }
                    break;
                case "employee":
                    name = fields.GetValueOrDefault("name") ?? "";
                    surname = fields.GetValueOrDefault("surname") ?? "";
                    age = Convert.ToInt32(fields.GetValueOrDefault("age"));
                    if (isBaseRepresentation)
                    {
                        employees.Add(new Project1.Representation_0.Employee(name, surname, age));
                    }
                    else
                    {
                        employees.Add(new Project1.Representation_1.Employee(name, surname, age));
                    }
                    break;
                case "visitor":
                    name = fields.GetValueOrDefault("name") ?? "";
                    surname = fields.GetValueOrDefault("surname") ?? "";
                    if (isBaseRepresentation)
                    {
                        visitors.Add(new Project1.Representation_0.Visitor(name, surname));
                    }
                    else
                    {
                        visitors.Add(new Project1.Representation_1.Visitor(name, surname));
                    }
                    break;
                case "enclosure":
                    name = fields.GetValueOrDefault("name") ?? "";
                    List<Project1.Representation_0.Animal> emptyList = new();
                    Project1.Representation_0.Employee emptyEmployee = new("", "", 0);
                    if (isBaseRepresentation)
                    {
                        enclosures.Add(new Project1.Representation_0.Enclosure(name, ref emptyList, ref emptyEmployee));
                    }
                    else
                    {
                        enclosures.Add(new Project1.Representation_1.Enclosure(name, new(), ""));
                    }
                    break;
            }
            Console.WriteLine($"[{objectClass} created]");
        }

        private bool Queue(string[] args)
        {
            switch (args[1])
            {
                case "export":
                    return Export(args);
                case "load":
                    return Load(args);
            }

            if (!commands.ContainsKey(args[1]))
            {
                return false;
            }

            commandQueue.Add(new(args[1], new(args.ToList().Skip(2))));

            return true;
        }


        private bool Edit(string[] args)
        {
            string objectClass = args[1].ToLower();

            Func<IFields, bool> SatisfiesCondition = (IFields item) =>
            {
                return true;
            };

            if (args.Length > 2)
            {
                string condition = args[2];
                string[] conditionSplit = args[2].Split('<');
                int conditionOperator = -1;

                if (conditionSplit.Length == 1)
                {
                    conditionSplit = args[2].Split('>');
                    conditionOperator = 1;
                }

                if (conditionSplit.Length == 1)
                {
                    conditionSplit = args[2].Split('=');
                    conditionOperator = 0;
                }

                string fieldName = conditionSplit[0].ToLower();
                string value = conditionSplit[1];

                SatisfiesCondition = (IFields item) =>
                {
                    if (!item.Fields().ContainsKey(fieldName))
                    {
                        return false;
                    }

                    Type t1 = item.Fields()[fieldName].Item2;
                    if (t1 == typeof(int))
                    {
                        return Convert.ToInt32(item.Fields()[fieldName].Item1).CompareTo(Convert.ToInt32(value)) == conditionOperator;
                    }
                    return item.Fields()[fieldName].Item1.CompareTo(value) == conditionOperator;
                };
            }

            if (!availableFields.ContainsKey(objectClass))
            {
                return false;
            }

            Console.Write("[Available fields: '");
            for (int fieldIndex = 0; fieldIndex < availableFields[objectClass].Count; fieldIndex++)
            {
                Console.Write(availableFields[objectClass][fieldIndex]);
                if (fieldIndex < availableFields[objectClass].Count - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.Write("']\n");

            Dictionary<string, string> fields = new();
            string input = "";
            while (input != "DONE" && input != "EXIT")
            {
                input = Console.ReadLine();
                if (input == "DONE")
                {
                    EditObject(objectClass, SatisfiesCondition, fields);
                }
                else if (input == "EXIT")
                {
                    Console.WriteLine($"[{objectClass} edition abandoned]");
                }
                else
                {
                    string[] fieldData = input.Split('=');
                    if (availableFields[objectClass].Contains(fieldData[0]))
                    {
                        fields[fieldData[0]] = fieldData[1];
                    }
                    else
                    {
                        Console.WriteLine($"[{objectClass} doesn't take \"{fieldData[0]}\"]");
                    }
                }
            }

            return true;
        }

        private bool EditObject(string objectClass, Func<IFields, bool> condition, Dictionary<string, string> fields)
        {
            string name, surname;
            int age;

            switch (objectClass)
            {
                case "animal":
                    IAnimal foundAnimal = Project2.ICollection<IAnimal>.Find(animals, condition);
                    if (foundAnimal == null)
                    {
                        return false;
                    }

                    name = fields.GetValueOrDefault("name") ?? foundAnimal.Fields()["name"].Item1;
                    if (fields.ContainsKey("age"))
                    {
                        age = Convert.ToInt32(fields.GetValueOrDefault("age"));
                    }
                    else
                    {
                        age = Convert.ToInt32(foundAnimal.Fields()["age"].Item1);
                    }

                    foundAnimal.Edit(name, age);
                    break;
                case "species":
                    ISpecies foundSpecies = Project2.ICollection<ISpecies>.Find(species, condition);
                    if (foundSpecies == null)
                    {
                        return false;
                    }

                    name = fields.GetValueOrDefault("name") ?? foundSpecies.Fields()["name"].Item1;

                    foundSpecies.Edit(name);
                    break;
                case "employee":
                    IEmployee foundEmployee = Project2.ICollection<IEmployee>.Find(employees, condition);
                    if (foundEmployee == null)
                    {
                        return false;
                    }

                    name = fields.GetValueOrDefault("name") ?? foundEmployee.Fields()["name"].Item1;
                    surname = fields.GetValueOrDefault("surname") ?? foundEmployee.Fields()["surname"].Item1;
                    if (fields.ContainsKey("age"))
                    {
                        age = Convert.ToInt32(fields.GetValueOrDefault("age"));
                    }
                    else
                    {
                        age = Convert.ToInt32(foundEmployee.Fields()["age"].Item1);
                    }

                    foundEmployee.Edit(name, surname, age);
                    break;
                case "visitor":
                    IVisitor foundVisitor = Project2.ICollection<IVisitor>.Find(visitors, condition);
                    if (foundVisitor == null)
                    {
                        return false;
                    }

                    name = fields.GetValueOrDefault("name") ?? foundVisitor.Fields()["name"].Item1;
                    surname = fields.GetValueOrDefault("surname") ?? foundVisitor.Fields()["surname"].Item1;

                    foundVisitor.Edit(name, surname);
                    break;
                case "enclosure":
                    IEnclosure foundEnclosure = Project2.ICollection<IEnclosure>.Find(enclosures, condition);
                    if (foundEnclosure == null)
                    {
                        return false;
                    }

                    name = fields.GetValueOrDefault("name") ?? foundEnclosure.Fields()["name"].Item1;

                    foundEnclosure.Edit(name);
                    break;
            }
            Console.WriteLine($"[{objectClass} created]");
            return true;
        }

        private bool Export(string[] args)
        {
            string filename = args[2];
            string format = "xml";
            if (args.Length > 3)
            {
                format = args[3].ToLower();
            }

            if (format == "plaintext")
            {
                File.WriteAllLines(filename, commandQueue.Select(command => command.ToString()));
            }
            else
            {
                using XmlWriter writer = XmlWriter.Create(filename);
                writer.WriteStartElement("queue");
                foreach (Command command in commandQueue)
                {
                    writer.WriteStartElement("command");
                    writer.WriteElementString("name", command.Name);
                    writer.WriteStartElement("parameters");
                    foreach (string parameter in command.Parameters)
                    {
                        writer.WriteElementString("parameter", parameter);
                    }
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.Flush();
            }

            return true;
        }

        private bool Load(string[] args)
        {
            string filePath = args[2];
            commandQueue = new();

            if (filePath.EndsWith(".xml"))
            {
                XmlDocument xmlDocument = new();
                xmlDocument.Load(filePath);
                foreach (XmlNode node in xmlDocument.DocumentElement.ChildNodes)
                {
                    List<string> commandSplit = new()
                    {
                        "queue",
                        node.SelectSingleNode("name").InnerText
                    };

                    XmlNode parametersNode = node.SelectSingleNode("parameters");
                    foreach (XmlNode parameterNode in parametersNode.ChildNodes)
                    {
                        commandSplit.Add(parameterNode.InnerText);
                    }

                    Queue(commandSplit.ToArray());
                }
            }
            else
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    List<string> lineSplit = new() { "queue" };
                    lineSplit.AddRange(line.Split(" "));
                    Queue(lineSplit.ToArray());
                }
            }

            return true;
        }

        private void ExecuteCommand(Command command)
        {
            command.Parameters.Insert(0, command.Name);
            commands[command.Name].Invoke(command.Parameters.ToArray());
            
            // Add the executed command to the commandHistory
            commandHistory.Push(command);
        }

        private bool History(string[] args)
        {
            if (commandHistory.Count > 0)
            {
                Console.WriteLine("Command History:");
                int index = 1;
                foreach (Command command in commandHistory)
                {
                    Console.WriteLine($"{index++}. {command.ToString()}");
                }
            }
            else
            {
                Console.WriteLine("No commands executed.");
            }

            return true;
        }

        private bool Undo(string[] args)
        {
            if (commandHistory.Count > 0)
            {
                Command lastCommand = commandHistory.Pop();

                // Implement the logic to undo the specific command
                RevertCommand(lastCommand);

                // Add the undone command to the redoHistory stack
                redoHistory.Push(lastCommand);

                Console.WriteLine($"Undo command: {lastCommand.ToString()}");
                return true;
            }
            else
            {
                Console.WriteLine("No commands to undo.");
                return false;
            }
        }

        private bool Redo(string[] args)
        {
            if (redoHistory.Count > 0)
            {
                Command nextCommand = redoHistory.Pop();

                // Execute the next command to redo
                ExecuteCommand(nextCommand);

                // Add the redone command back to the commandHistory stack
                commandHistory.Push(nextCommand);

                Console.WriteLine($"Redo command: {nextCommand.ToString()}");
                return true;
            }
            else
            {
                Console.WriteLine("No commands to redo.");
                return false;
            }
        }

        private void RevertCommand(Command command)
        {
            // Implement the logic to revert the specific command
            switch (command.Name)
            {
                case "add":
                    UndoAddCommand(command);
                    break;
                // Add cases for other command types 
                case "list":
                    UndoListCommand(command);
                    break;
                case "find":
                    UndoFindCommand(command);
                    break;
                case "queue":
                    UndoQueueCommand(command);
                    break;
                case "edit":
                    UndoEditCommand(command);
                    break;
                case "delete":
                    UndoDeleteCommand(command);
                    break;
                default:
                    Console.WriteLine($"Cannot undo command: {command.Name}");
                    break;
            }
        }
        private void UndoAddCommand(Command command)
        {
            if (command.Parameters.Count > 0)
            {
                string itemName = command.Parameters[0];

                // Determine the object class based on the command name
                string objectClass = command.Name;

                switch (objectClass)
                {
                    case "animal":
                        // Remove the animal with the specified name from the animals list
                        IAnimal animalToRemove = animals.FirstOrDefault(animal => animal.Name == itemName);
                        if (animalToRemove != null)
                        {
                            animals.Remove(animalToRemove);
                            Console.WriteLine($"Undo 'add' command for animal: {itemName}");
                        }
                        else
                        {
                            Console.WriteLine($"Animal '{itemName}' not found to undo 'add' command.");
                        }
                        break;
                    case "species":
                        // Remove the species with the specified name from the species list
                        ISpecies speciesToRemove = species.FirstOrDefault(species => species.Name == itemName);
                        if (speciesToRemove != null)
                        {
                            species.Remove(speciesToRemove);
                            Console.WriteLine($"Undo 'add' command for species: {itemName}");
                        }
                        else
                        {
                            Console.WriteLine($"Species '{itemName}' not found to undo 'add' command.");
                        }
                        break;
                    case "employee":
                        // Remove the employee with the specified name from the employees list
                        IEmployee employeeToRemove = employees.FirstOrDefault(employee => employee.Name == itemName);
                        if (employeeToRemove != null)
                        {
                            employees.Remove(employeeToRemove);
                            Console.WriteLine($"Undo 'add' command for employee: {itemName}");
                        }
                        else
                        {
                            Console.WriteLine($"Employee '{itemName}' not found to undo 'add' command.");
                        }
                        break;
                    case "visitor":
                        // Remove the visitor with the specified name from the visitors list
                        IVisitor visitorToRemove = visitors.FirstOrDefault(visitor => visitor.Name == itemName);
                        if (visitorToRemove != null)
                        {
                            visitors.Remove(visitorToRemove);
                            Console.WriteLine($"Undo 'add' command for visitor: {itemName}");
                        }
                        else
                        {
                            Console.WriteLine($"Visitor '{itemName}' not found to undo 'add' command.");
                        }
                        break;
                    case "enclosure":
                        // Remove the enclosure with the specified name from the enclosures list
                        IEnclosure enclosureToRemove = enclosures.FirstOrDefault(enclosure => enclosure.Name == itemName);
                        if (enclosureToRemove != null)
                        {
                            enclosures.Remove(enclosureToRemove);
                            Console.WriteLine($"Undo 'add' command for enclosure: {itemName}");
                        }
                        else
                        {
                            Console.WriteLine($"Enclosure '{itemName}' not found to undo 'add' command.");
                        }
                        break;
                    default:
                        Console.WriteLine($"Cannot undo 'add' command for unknown object class: {objectClass}");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid 'add' command parameters.");
            }
        }

        private void UndoListCommand(Command command)
        {
            Console.WriteLine("Undo 'list' command.");
        }

        private void UndoFindCommand(Command command)
        {
            Console.WriteLine("Undo 'find' command.");
        }

        private void UndoQueueCommand(Command command)
        {
            Console.WriteLine("Undo 'queue' command.");
        }

        private void UndoEditCommand(Command command)
        {
            Console.WriteLine("Undo 'edit' command.");
        }

        private void UndoDeleteCommand(Command command)
        {
            Console.WriteLine("Undid 'delete' command.");
        }

        private bool Delete(string[] args)
        {
            string objectClass = args[1];

            if (args.Length < 2)
            {
                return false;
            }

            Func<IFields, bool> SatisfiesCondition = (IFields item) =>
            {
                return true;
            };

            if (args.Length > 2)
            {
                string condition = args[2];
                string[] conditionSplit = args[2].Split('<');
                int conditionOperator = -1;

                if (conditionSplit.Length == 1)
                {
                    conditionSplit = args[2].Split('>');
                    conditionOperator = 1;
                }

                if (conditionSplit.Length == 1)
                {
                    conditionSplit = args[2].Split('=');
                    conditionOperator = 0;
                }

                string fieldName = conditionSplit[0].ToLower();
                string value = conditionSplit[1];

                SatisfiesCondition = (IFields item) =>
                {
                    if (!item.Fields().ContainsKey(fieldName))
                    {
                        return false;
                    }

                    Type t1 = item.Fields()[fieldName].Item2;
                    if (t1 == typeof(int))
                    {
                        return Convert.ToInt32(item.Fields()[fieldName].Item1).CompareTo(Convert.ToInt32(value)) == conditionOperator;
                    }
                    return item.Fields()[fieldName].Item1.CompareTo(value) == conditionOperator;
                };
            }

            switch (objectClass)
            {
                case "animal":
                    IAnimal foundAnimal = Project2.ICollection<IAnimal>.Find(animals, SatisfiesCondition);
                    if (foundAnimal == null)
                    {
                        return false;
                    }
                    animals.Remove(foundAnimal);
                    break;
                case "species":
                    ISpecies foundSpecies = Project2.ICollection<ISpecies>.Find(species, SatisfiesCondition);
                    if (foundSpecies == null)
                    {
                        return false;
                    }
                    species.Remove(foundSpecies);
                    break;
                case "employee":
                    IEmployee foundEmployee = Project2.ICollection<IEmployee>.Find(employees, SatisfiesCondition);
                    if (foundEmployee == null)
                    {
                        return false;
                    }
                    employees.Remove(foundEmployee);
                    break;
                case "visitor":
                    IVisitor foundVisitor = Project2.ICollection<IVisitor>.Find(visitors, SatisfiesCondition);
                    if (foundVisitor == null)
                    {
                        return false;
                    }
                    visitors.Remove(foundVisitor);
                    break;
                case "enclosure":
                    IEnclosure foundEnclosure = Project2.ICollection<IEnclosure>.Find(enclosures, SatisfiesCondition);
                    if (foundEnclosure == null)
                    {
                        return false;
                    }
                    enclosures.Remove(foundEnclosure);
                    break;
            }
            Console.WriteLine($"[{objectClass} deleted]");
            return true;
        }

        private bool Exit(string[] args)
        {
            exit = true;
            return true;
        }


        List<Command> CommandHistory = new List<Command>();
        public void Start()
        {
            string input;
            string[] inputSplit;
            bool result;
            while (!exit && (input = GetCommandFromUser()) != "exit")
            {
                try
                {
                    inputSplit = input.Trim().Split(" ");
                    // dodać komendę do command history 
                    Command command = new Command(inputSplit[0], new List<string>());
                    CommandHistory.Add(command);
                    //for (int i = 1; i < inputSplit.Length; i++)
                    //{
                    //    command.Parameters.Add(inputSplit[i]);
                        
                    //}
                    //CommandHistory.Add(command);

                    result = commands[inputSplit[0]].Invoke(inputSplit);
                    if (result == false)
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    Console.WriteLine("Error! Cannot proceed given command. Please try again.");
                }
            }
        }
        }
    }






