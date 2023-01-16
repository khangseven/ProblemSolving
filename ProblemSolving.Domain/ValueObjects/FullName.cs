using ProblemSolving.Domain.Primitives;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProblemSolving.Domain.ValueObjects
{
    public sealed class FullName : ValueObject
    {
        public string Value { get; }

        public const int MaxLenght = 25;

        public FullName(string value) {
            Value= value;
        }

        public FullName()
        {
        }

        public static FullName Create(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }
            if (name.Length > MaxLenght)
            {
                throw new Exception();
            }

            return new FullName(name);  
        }

        public override IEnumerable<object> GetAtomicValue()
        {
            yield return Value;
        }
    }
}
