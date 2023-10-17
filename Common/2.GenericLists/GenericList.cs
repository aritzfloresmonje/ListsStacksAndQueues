using Common;

public class GenericListNode<T>
{
    public T Value;
    public GenericListNode<T> Next = null;
    public GenericListNode<T> Previous = null;

    public GenericListNode(T value)
    {
      Value = value;
    }

    public override string ToString()
    {
      return Value.ToString();
    }
}

public class GenericList<T> : IGenericList<T>
{
    GenericListNode<T> First = null;
    GenericListNode<T> Last = null;
    private int numElements = 0;

    public string AsString()
    {
      GenericListNode<T> node = First;
      string output = "[";

      while (node != null)
      {
        output += node.ToString() + ",";
        node = node.Next;
      }
      output = output.TrimEnd(',') + "] " + Count() + " elements";
      
      return output;
    }

    public void Add(T value)
    {
        //TODO #1: add a new element to the end of the list

        GenericListNode<T> newNode = new GenericListNode<T>(value);

        if (Last == null && First == null)
        {
            First = new GenericListNode<T>(value);
            Last = First;
            numElements++;
            return;
        }
        Last.Next = newNode;
        newNode.Previous = Last;
        Last = newNode;
        numElements++;
    }


    public GenericListNode<T> FindNode(int index)
    {
        //TODO #2: Return the element in position 'index'
        int nodeIndex = 0;
        GenericListNode<T> currentNode = First;
        while(currentNode != null && nodeIndex < index)
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

    public T Get(int index)
    {
        //TODO #3: return the element on the index-th position. YOU MUST USE GetNode(int). Return the default value for object class T if the position is out of bounds
        GenericListNode<T> node = FindNode(index);
        if(node == null)
        {
            return default(T);
        }
        return node.Value;
    }
    public int Count()
    {
        //TODO #4: return the number of elements on the list
        return numElements;
    }


    public void Remove(int index)
    {
        //TODO #5: remove the element on the index-th position. Do nothing if position is out of bounds
        GenericListNode<T> node = FindNode(index);

        if(node == null) return;
        if (node == Last)
        {
            Last = Last.Previous;
            Last.Next = null;
            numElements--;
            return;
        }

        if (node == First)
        {
            First = First.Next;
            First.Previous = null;
            numElements--;
            return;
        }

        node.Previous.Next = node.Next;
        node.Next.Previous = node.Previous;
        numElements--;
    }

    public void Clear()
    {
        //TODO #6: remove all the elements on the list
        First = null;
        numElements = 0;
    }
}