using Project1.Representation_0;

namespace Project1
{
    class Representation8
    {
        public static Tuple<int, Stack<string>> GetTuple(Enclosure enclosure, int id)
        {
            Stack<string> stack = new();
            stack.Push(enclosure.Employee.Name + " " + enclosure.Employee.Surname);
            stack.Push("Employee");

            string animalsListString = "[";
            for (int animalIndex = 0; animalIndex < enclosure.Animals.Count; animalIndex++)
            {
                animalsListString += enclosure.Animals[animalIndex].Name;
                if (animalIndex <= enclosure.Animals.Count - 1)
                {
                    animalsListString += ",";
                }
            }
            animalsListString += "]";

            stack.Push(animalsListString);
            stack.Push("Animals");

            stack.Push(enclosure.Name);
            stack.Push("Name");

            return new Tuple<int, Stack<string>>(id, stack);
        }

        public static Enclosure GetEnclosure(Tuple<int, Stack<string>> enclosure, List<Animal> animals, List<Employee> employees)
        {
            string value;
            string name = "";
            List<Animal> enclosureAnimals = new();
            Employee enclosureEmployee;

            while (enclosure.Item2.Count > 0)
            {
                value = enclosure.Item2.Pop();

                if (value == "Name")
                {
                    name = enclosure.Item2.Pop();
                }
                else if (value == "Animals")
                {
                    foreach (string animalName in enclosure.Item2.Pop().Split(","))
                    {
                        foreach (Animal animal in animals)
                        {
                            if (animal.Name == animalName)
                            {
                                enclosureAnimals.Add(animal);
                                break;
                            }
                        }
                    }
                }
                else if (value == "Employee")
                {
                    string[] employeeName = enclosure.Item2.Pop().Split(" ");
                    foreach (Employee employee in employees)
                    {
                        if (employee.Name == employeeName[0] && employee.Surname == employeeName[1])
                        {
                            enclosureEmployee = employee;
                            return new Enclosure(name, ref enclosureAnimals, ref enclosureEmployee);
                        }
                    }
                }
            }
            return null;
        }
    }
}
