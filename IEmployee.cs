namespace Project1
{
    interface IEmployee : IFields
    {
        string Name { get; } // added property Name
        public void Edit(string name, string surnname, int age);
        public void Print()
        {
            Console.WriteLine(ToString());
        }
        public string ToString();
    }
}