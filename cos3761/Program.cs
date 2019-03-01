using System;
using System.Collections.Generic;

namespace COS3761
{
    class Program
    {
        static List<Literal> Literals { get; set; }
        static void Main(string[] args)
        {
            Literal p = new Literal("p");
            Literal q = new Literal("q");
            Literal r = new Literal("r");
            Literals = new List<Literal>() { p, q, r };
            PrintTruthTable(new Disjunction(new Conjunction(p,q), new Negation(r)));
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }

        static void PrintTruthTable(Literal literal)
        {
            Console.WriteLine($"{string.Join("  |  ", Literals.ConvertAll(lits => lits.Name))}  | {literal.Name}");

        }

        public class Literal
        {
            static int global_count;
            public string Name { get; set; }
            public bool Value { get; set; }

            public Literal()
            {
                Name = $"p{global_count++}";
                Value = true;
            }

            public Literal(string name)
            {
                Name = name;
                Value = true;
            }

            public Literal(bool atom)
            {
                Name = $"p{global_count++}";
                Value = atom;
            }

            public Literal(string name, bool atom)
            {
                Name = name;
                Value = atom;
            }
        }

        public class Negation : Literal
        {
            Literal Literal { get; set; }

            public Negation(Literal literal)
            {
                Literal = literal;
                Name = $" !({literal.Name}) ";
                Value = !literal.Value;
            }
        }

        public abstract class BooleanCollective : Literal
        { 
            public Literal Left_Literal { get; set; }

            public Literal Right_Literal { get; set; }

            protected abstract Func<bool, bool, bool> EvaluateAs { get; }

            protected abstract Func<string, string, string> NameFormat { get; }

            protected BooleanCollective(Literal left_literal, Literal right_literal)
            {
                Left_Literal = left_literal;
                Right_Literal = right_literal;
                Name = NameFormat(left_literal.Name, right_literal.Name);
            }
        }

        public class Disjunction : BooleanCollective
        {
            protected override Func<bool, bool, bool> EvaluateAs =>
                (value_1, value_2) => value_1 || value_2;

            protected override Func<string, string, string> NameFormat =>
                (name_1, name_2) => $" ({name_1} || {name_2}) ";

            public Disjunction(Literal left_literal, Literal right_literal) : base(left_literal, right_literal) { }
        }

        public class Conjunction : BooleanCollective
        {
            protected override Func<bool, bool, bool> EvaluateAs => (value_1, value_2) => value_1 && value_2;

            protected override Func<string, string, string> NameFormat => (name_1, name_2) => $" ({name_1} && {name_2}) ";

            public Conjunction(Literal left_literal, Literal right_literal) : base(left_literal, right_literal) { }
        }
    }
}
