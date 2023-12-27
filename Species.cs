namespace Project1.Representation_1
{
    class Species : ISpecies
    {

        public string Name { get; private set; }
        public List<string> FavouriteFoods { get; private set; }

        public Species(string name, List<string> favouriteFoods)
        {
            Name = name;
            FavouriteFoods = favouriteFoods;
        }

        public Species(string name)
        {
            Name = name;
            FavouriteFoods = new();
        }

        public void AddFavouriteFood(Species species)
        {
            FavouriteFoods.Add(species.Name);
        }

        public void Edit(string name)
        {
            Name = name;
        }

        public void Print()
        {
            Console.Write(ToString());
        }

        public override string ToString()
        {
            string str = Name + ", [";
            for (int foodIndex = 0; foodIndex < FavouriteFoods.Count; foodIndex++)
            {
                str += FavouriteFoods[foodIndex];
                if (foodIndex < FavouriteFoods.Count - 1)
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
            { "favouriteFoods", new(FavouriteFoods.ToString(), typeof(List<string>)) }
        };
    }
}