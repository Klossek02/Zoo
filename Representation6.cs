using Project1.Representation_0;

namespace Project1
{
    class Representation6
    {
        public static void AddEnclosureToMap(Dictionary<string, string> zoo, Enclosure enclosure)
        {
            int enclosureIndex = 1;
            while (zoo.ContainsKey($"{enclosureIndex}.name"))
            {
                enclosureIndex++;
            }

            // Employee
            zoo[$"{enclosureIndex}.name"] = enclosure.Name;
            zoo[$"{enclosureIndex}.employee.name"] = enclosure.Employee.Name;
            zoo[$"{enclosureIndex}.employee.surname"] = enclosure.Employee.Surname;
            zoo[$"{enclosureIndex}.employee.age"] = enclosure.Employee.Age.ToString();

            // Animals
            zoo[$"{enclosureIndex}.animals_count"] = enclosure.Animals.Count.ToString();
            for (int animalIndex = 0; animalIndex < enclosure.Animals.Count; animalIndex++)
            {
                zoo[$"{enclosureIndex}.animals[{animalIndex}].name"] = enclosure.Animals[animalIndex].Name;
            }
        }

        public static List<Enclosure> GetEnclosures(Dictionary<string, string> zoo, List<Animal> animals, List<Employee> employees)
        {
            List<Enclosure> enclosures = new();

            int enclosureIndex = 1;
            while (zoo.ContainsKey($"{enclosureIndex}.name"))
            {
                string name = zoo[$"{enclosureIndex}.name"];
                List<Animal> enclosureAnimals = new();
                for (int animalIndex = 0; animalIndex < Convert.ToInt32(zoo[$"{enclosureIndex}.animals_count"]); animalIndex++)
                {
                    string animalName = zoo[$"{enclosureIndex}.animals[{animalIndex}].name"];
                    foreach (Animal animal in animals)
                    {
                        if (animal.Name == animalName)
                        {
                            enclosureAnimals.Add(animal);
                            break;
                        }
                    }
                }

                string employeeName = zoo[$"{enclosureIndex}.employee.name"];
                string employeeSurmame = zoo[$"{enclosureIndex}.employee.surname"];
                Employee enclosureEmployee;
                foreach (Employee employee in employees)
                {
                    if (employee.Name == employeeName && employee.Surname == employeeSurmame)
                    {
                        enclosureEmployee = employee;
                        enclosures.Add(new(name, ref enclosureAnimals, ref enclosureEmployee));
                        break;
                    }
                }

                enclosureIndex++;
            }

            return enclosures;
        }
    }
}
