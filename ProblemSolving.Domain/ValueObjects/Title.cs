using ProblemSolving.Domain.Primitives; 

namespace ProblemSolving.Domain.ValueObjects
{
    public sealed class Title : ValueObject
    {
        public string Value { get; }

        public const int MaxLenght = 16;
        public const int MinLenght = 5;

        public Title(string value) { Value = value; }

        public Title()
        {
        }

        public static Title Create(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }
            if (name.Length > MaxLenght || name.Length < MinLenght)
            {
                throw new ArgumentNullException("name");
            }
            return new Title(name);
        }

        public override IEnumerable<object> GetAtomicValue()
        {
            yield return Value;
        }

    }
}
