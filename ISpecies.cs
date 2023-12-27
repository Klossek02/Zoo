namespace Project1
{
    interface ISpecies : IFields
    {
        string Name { get; } // added property Name
        public void Edit(string name);
        public void Print()
        {
            Console.Write(ToString());
        }
        public string ToString();
    }
}
