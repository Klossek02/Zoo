namespace Project3
{
    public class Command
    {
        public string Name { get; set; }
        public List<string> Parameters { get; set; }

        public Command(string name, List<string> parameters)
        {
            Name = name;
            Parameters = parameters;

        }

        public override string ToString()
        {
            return $"{Name} {string.Join(" ", Parameters)}";
        }
    }
}
