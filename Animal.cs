namespace Project1.Representation_0
{
    class Animal : IAnimal
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public Species Species { get; private set; }

        public Animal(string name, int age, ref Species species)
        {
            Name = name;
            Age = age;
            Species = species;
        }
        public void Edit(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void Print()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return Name + ", " + Age + ", " + Species.Name;
        }

        public Dictionary<string, Tuple<string, Type>> Fields() => new()
        {
            { "name", new(Name, typeof(string))},
            { "age", new(Age.ToString(), typeof(int)) },
            { "species", new(Species.ToString(), typeof(Species))}
        };
    }
}