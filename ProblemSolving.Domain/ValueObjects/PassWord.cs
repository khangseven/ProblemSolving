using ProblemSolving.Domain.Primitives;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProblemSolving.Domain.ValueObjects
{
    public sealed class PassWord : ValueObject
    {

        public string Value { get; }

        public const int MaxLenght = 16;
        public const int MinLenght = 8;

        public PassWord(string value)
        {
            Value = value;
        }

        public PassWord()
        {
        }

        public static PassWord Create(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("password");
            }
            if(password.Length > MaxLenght || password.Length < MinLenght)
            {
                throw new ArgumentException("out of lenght");
            }
            return new PassWord(password);
        }

        public override IEnumerable<object> GetAtomicValue()
        {
            yield return Value;
        }
    }
}
