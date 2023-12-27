namespace Project1.Representation_0
{
    class Enclosure : IEnclosure
    {
        public string Name { get; private set; }
        public List<Animal> Animals { get; private set; }
        public Employee Employee { get; private set; }

        public Enclosure(string name, ref List<Animal> animals, ref Employee employee)
        {
            Name = name;
            Animals = animals;
            Employee = employee;
            var me = this;
            employee.AddEnclosure(ref me);
        }

        public void Edit(string name)
        {
            Name = name;
        }

        public void Print()
        {
            Console.Write(Name + ", [");
            for (int animalIndex = 0; animalIndex < Animals.Count; animalIndex++)
            {
                Console.Write(Animals[animalIndex].Name);
                if (animalIndex < Animals.Count - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.Write("], " + Employee.Name + " " + Employee.Surname + "\n");
        }

        public override string ToString()
        {
            string str = Name + ", [";
            for (int animalIndex = 0; animalIndex < Animals.Count; animalIndex++)
            {
                str += Animals[animalIndex].Name;
                if (animalIndex < Animals.Count - 1)
                {
                    str += ", ";
                }
            }
            str += "], " + Employee.Name + " " + Employee.Surname;
            return str;
        }

        public Dictionary<string, Tuple<string, Type>> Fields() => new()
        {
            { "name", new(Name, typeof(string))},
            { "animals", new(Animals.ToString(), typeof(List<Animal>)) },
            { "employee", new(Employee.ToString(), typeof(Employee)) }
        };
    }
}
