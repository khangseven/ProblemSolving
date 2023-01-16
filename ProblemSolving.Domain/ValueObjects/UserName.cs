using ProblemSolving.Domain.Primitives;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProblemSolving.Domain.ValueObjects
{
    public sealed class UserName : ValueObject
    {

        public string Value { get; }

        public const int MaxLenght = 100;
        public const int MinLenght = 5;

        public UserName(string value) { Value = value; }

        public UserName()
        {
        }

        public static UserName Create(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }
            if(name.Length > MaxLenght || name.Length < MinLenght)
            {
                throw new ArgumentNullException("name");
            }
            return new UserName(name);
        }

        public override IEnumerable<object> GetAtomicValue()
        {
            yield return Value;
        }
    }
}
