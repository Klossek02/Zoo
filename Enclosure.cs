namespace Project1.Representation_1
{
    class Enclosure : IEnclosure
    {
        public string Name { get; private set; }
        public List<string> Animals { get; private set; }
        public string Employee { get; private set; }

        public Enclosure(string name, List<string> animals, string employee)
        {
            Name = name;
            Animals = animals;
            Employee = employee;
            var me = this;
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
                Console.Write(Animals[animalIndex]);
                if (animalIndex < Animals.Count - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.Write("], " + Employee + " " + Employee + "\n");
        }

        public override string ToString()
        {
            string str = Name + ", [";
            for (int animalIndex = 0; animalIndex < Animals.Count; animalIndex++)
            {
                str += Animals[animalIndex];
                if (animalIndex < Animals.Count - 1)
                {
                    str += ", ";
                }
            }
            str += "], " + Employee + " " + Employee;
            return str;
        }

        public Dictionary<string, Tuple<string, Type>> Fields() => new()
        {
            { "name", new(Name, typeof(string))},
            { "animals", new(Animals.ToString(), typeof(List<string>)) },
            { "employee", new(Employee.ToString(), typeof(string)) }
        };
    }
}
