using System;

namespace Common
{
    public class IntArrayList : IList
    {
        int[] Values;
        int NumElements = 0;

        public IntArrayList(int n)
        {
            Values = new int[n];
        }
        public string AsString()
        {
            string output = "[";

            for (int i = 0; i < Count(); i++)
                output += Values[i] + ",";
            output = output.TrimEnd(',') + "] " + Count() + " elements";

            return output;
        }

        
        public void Add(int value)
        {
            // Adds the element to the end of the list
            Values[NumElements] = value;
            NumElements++;
        }

        public int Get(int index)
        {
            if (index >= NumElements) return 0;
            return Values[index];
        }


        
        public int Count()
        {
            return Values.Length;
        }


       
        public void Remove(int index)
        {
            // Move every element on the right side of the index-th element to its left side, then decrease NumElements so it is not considered
            if (index >= NumElements) return;
            for(int i = index; i < NumElements; i++)
            {
                // Swap the current element with the one to its right
                int aux = Values[i];
                Values[i] = Values[i + 1];
                Values[i + 1] = aux;
            }
            NumElements--;
        }


        public void Clear()
        {
            NumElements = 0;
        }
    }
}