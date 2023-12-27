namespace Project1
{
    interface IVisitor : IFields
    {
        string Name { get; } // added property Name
        public void Edit(string name, string surname);
        public void Print()
        {
            Console.WriteLine(ToString());
        }
        public string ToString();
    }
}
