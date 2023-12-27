namespace Project1
{
    interface IAnimal : IFields
    {
        string Name { get; } // added property Name
        public void Edit(string name, int age);
        public void Print()
        {
            Console.WriteLine(ToString());
        }
        public string ToString();
    }
}