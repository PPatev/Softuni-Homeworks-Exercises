namespace P07_ImmutableList
{
    using System.Collections.Generic;
    
    public class ImmutableList
    {
        public List<int> collection;

        public ImmutableList(List<int> collection)
        {
            this.collection = collection;
        }

        public ImmutableList GetImmutableList()
        {
            List<int> newCollection = new List<int>(this.collection);
            return new ImmutableList(newCollection);
        }
    }
}