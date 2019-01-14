using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IEnumerableSamples
{
    public class InfinityNumbersList : IEnumerable<int>
    {
        private readonly InfinityNumbersListEnumerator _enumerator;
        
        public InfinityNumbersList()
        {
            _enumerator = new InfinityNumbersListEnumerator();
        }
        public IEnumerator<int> GetEnumerator()
        => _enumerator;

        IEnumerator IEnumerable.GetEnumerator()
        => _enumerator;
    }

    public class InfinityNumbersListEnumerator : IEnumerator<int>
    {
        private int _current = -1;
        public int Current => _current;

        object IEnumerator.Current => _current;
        public bool MoveNext()
        {
            _current++;
            return true;
        }

        public void Reset()
        {
            _current = -1;
        }

        public void Dispose()
        {
            Reset();
        }
    }
}
