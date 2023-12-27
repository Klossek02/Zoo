namespace Project1
{
    interface IEnclosure : IFields
    {
        string Name { get; } // added property Name
        public void Edit(string name);
        public void Print();
        public string ToString();
    }
}
