using System;

namespace Common
{
    public class IntListNode
    {
        public int Value;
        public IntListNode Next = null;

        public IntListNode(int value)
        {
            Value = value;
        }
    }

    public class IntList : IList
    {
        IntListNode First = null;
        private int numElements = 0;
        IntListNode Last = null;

        //This method returns all the elements on the list as a string
        //Use it as an example on how to access all the elements on the list
        public string AsString()
        {
            IntListNode node = First;
            string output = "[";

            while (node != null)
            {
                output += node.Value + ",";
                node = node.Next;
            }
            output = output.TrimEnd(',') + "] " + Count() + " elements";

            return output;
        }

        
        public void Add(int value)
        {
            //TODO #1: add a new integer to the end of the list
            // When adding a new element to a linked list, we need to create a new list node and add a reference of it to the previous last item

            // Create a new node
            IntListNode newNode = new IntListNode(value);
            // If the new node is the first element to be added to the list, then add a reference of it to First. If not, search for a null reference to a node
            if (Last == null && First == null)
            {
                First = newNode;
                Last = First;
                numElements++;
                return;
            }

            Last.Next = newNode;
            Last = newNode;
            numElements++;
        }

        private IntListNode GetNode(int index)
        {
            //TODO #2: Return the element in position 'index'
            int nodeIndex = 0;
            IntListNode currentNode = First;
            while(nodeIndex != index && currentNode != null)
            {
                currentNode = currentNode.Next;
                nodeIndex++;
            }
            
            if(nodeIndex == index)
            {
                return currentNode;
            }
            return null;
        }

        
        public int Get(int index)
        {
            //TODO #3: return the element on the index-th position. YOU MUST USE GetNode(int). O if the position is out of bounds
            if(GetNode(index) == null)
            {
                return 0; // the index is out of the range of the list
            }
            return GetNode(index).Value;
        }

        
        public int Count()
        {
            //TODO #4: return the number of elements on the list
            return numElements;
        }
        
        public void Remove(int index)
        {
            //TODO #5: remove the element on the index-th position. Do nothing if position is out of bounds
            IntListNode node = GetNode(index);
            if(node == null)
            {
                return;
            }
            
            if(node == Last)
            {
                // The previous node becomes the last node
                IntListNode newLastNode = GetNode(index - 1);
                Last = newLastNode;
                numElements--;
                return;
            }

            if(node == First)
            {
                // The next node becomes the first node
                First = First.Next;
                numElements--;
                return;
            }

            // Link the previous node's "Next" property to the node's next node
            IntListNode previousNode = GetNode(index - 1);
            previousNode.Next = node.Next;
        }


        public void Clear()
        {
            //TODO #6: remove all the elements on the list
            // Unlink the whole list
            First = null;
            numElements = 0;
        }
    }
}