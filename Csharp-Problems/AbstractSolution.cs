using System.Collections.Generic;

namespace Algorithms
{
    public abstract class AbstractSolution
    {
        public abstract void Test();
        
        public void Swap(IList<int> arr, int i, int j)
        {
            var buf = arr[i];
            arr[i] = arr[j];
            arr[j] = buf;
        }
    }
}
