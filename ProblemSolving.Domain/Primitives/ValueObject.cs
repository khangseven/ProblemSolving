using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolving.Domain.Primitives
{
    public abstract class ValueObject
    {
        public abstract IEnumerable<object> GetAtomicValue();

        private bool AreEquals(ValueObject other)
        {
            return GetAtomicValue().SequenceEqual(other.GetAtomicValue());
        }
        public override bool Equals(object? obj)
        {
            return obj is ValueObject valueObject && AreEquals(valueObject);
        }

        public bool Equals(ValueObject? other)
        {
            return other is not null && AreEquals(other);
        }
        public override int GetHashCode()
        {
            return GetAtomicValue().Aggregate(default(int), HashCode.Combine);
        }


        
    }
}
