namespace Project1.Representation_0
{
    class Visitor : IVisitor
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public List<Enclosure> VisitedEnclosures { get; private set; }

        public Visitor(string name, string surname, ref List<Enclosure> visitedEnclosures)
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

        public void Visit(ref Enclosure enclosure)
        {
            VisitedEnclosures.Add(enclosure);
        }

        public void Edit(string name, string surname)
        {
            Name = name;
            Surname = surname;
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
                str += VisitedEnclosures[enclosureIndex].Name;
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
            { "visitedEnclosures", new(VisitedEnclosures.ToString(), typeof(List<Enclosure>))}
        };
    }
}