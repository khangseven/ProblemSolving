using ProblemSolving.Domain.Primitives; 

namespace ProblemSolving.Domain.ValueObjects
{
    public sealed class Content : ValueObject
    {
        public string Value { get;  }


        public Content(string value) { Value = value; }

        public Content()
        {
        }

        public static Content Create(string name)
        {
            if(string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
            return new Content(name);
        }

        public override IEnumerable<object> GetAtomicValue()
        {
            yield return Value;
        }

    }
}
