namespace Project1.Representation_0
{
    class Species : ISpecies
    {
        public string Name { get; private set; }
        public List<Species> FavouriteFoods { get; private set; }

        public Species(string name, ref List<Species> favouriteFoods)
        {
            Name = name;
            FavouriteFoods = favouriteFoods;
        }

        public Species(string name)
        {
            Name = name;
            FavouriteFoods = new();
        }

        public void AddFavouriteFood(ref Species species)
        {
            FavouriteFoods.Add(species);
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
                str += FavouriteFoods[foodIndex].Name;
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
            { "favouriteFoods", new(FavouriteFoods.ToString(), typeof(List<Species>)) }
        };
    }
}