namespace Project1.Representation_1
{
    class Employee : IEmployee
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public int Age { get; private set; }
        public List<Enclosure> Enclosures { get; private set; }

        public Employee(string name, string surnname, int age, ref List<Enclosure> enclosures)
        {
            Name = name;
            Surname = surnname;
            Age = age;
            Enclosures = enclosures;
        }

        public Employee(string name, string surnname, int age)
        {
            Name = name;
            Surname = surnname;
            Age = age;
            Enclosures = new();
        }

        public void AddEnclosure(ref Enclosure enclosure)
        {
            Enclosures.Add(enclosure);
        }

        public void Edit(string name, string surnname, int age)
        {
            Name = name;
            Surname = surnname;
            Age = age;
        }

        public void Print()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            string str = Name + ", " + Surname + ", [";
            for (int enclosureIndex = 0; enclosureIndex < Enclosures.Count; enclosureIndex++)
            {
                str += Enclosures[enclosureIndex].Name;
                if (enclosureIndex < Enclosures.Count - 1)
                {
                    str += ", ";
                }
            }
            str += "]";
            return str;
        }

        public Dictionary<string, Tuple<string, Type>> Fields() => new()
        {
            { "name", new(Name, typeof(string))},
            { "surname", new(Surname, typeof(string)) },
            { "age", new(Age.ToString(), typeof(int)) },
            { "enclosures", new(Enclosures.ToString(), typeof(List<string>)) }
        };
    }
}