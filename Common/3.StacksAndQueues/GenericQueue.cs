namespace Common
{

    public class GenericQueue<T> : IPushPop<T>
    {
        //TODO #1: Declare a List inside this object class to store the objects. Choose the most appropriate object class
        private GenericList<T> objects;

        public GenericQueue()
        {
            objects = new GenericList<T>();
        }

        public string AsString()
        {
            //TODO #2: Return the list as a string. Use the method already implemented in your list
            return objects.AsString();
        }

        public int Count()
        {
            //TODO #3: Return the number of objects
            return objects.Count();
        }

        public void Clear()
        {
            //TODO #4: Remove all objects stored
            objects.Clear();
        }

        public void Push(T value)
        {
            //TODO #5: Add a new object to the list (at the end of it)
            objects.Add(value);
        }

        public T Pop()
        {
            //TODO #6: Remove the first object of the list and return it
            T value = objects.Get(0);
            objects.Remove(0);
            return value;
        }
    }
}