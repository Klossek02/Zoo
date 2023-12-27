namespace Project1.Representation_1
{
    class Visitor : IVisitor
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public List<string> VisitedEnclosures { get; private set; }

        public Visitor(string name, string surname, ref List<string> visitedEnclosures)
        {
            Name = name;
            Surname = surname;
            VisitedEnclosures = visitedEnclosures;
        }

        public Visitor(string name, string surname)
        {
            Name = name;
            Surname = surname;
            VisitedEnclosures = new();
        }

        public void Edit(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public void Visit(string enclosure)
        {
            VisitedEnclosures.Add(enclosure);
        }

        public void Print()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            string str = Name + ", " + Surname + ", [";
            for (int enclosureIndex = 0; enclosureIndex < VisitedEnclosures.Count; enclosureIndex++)
            {
                str += VisitedEnclosures[enclosureIndex];
                if (enclosureIndex < VisitedEnclosures.Count - 1)
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
            { "visitedEnclosures", new(VisitedEnclosures.ToString(), typeof(List<string>))}
        };
    }
}