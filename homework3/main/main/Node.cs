using System;

namespace hw3
{
    public class Node<T>
    {
        public T stuff;

        public Node<T> next;

        public Node(T stuff, Node<T> next)
        {
            this.stuff = stuff;
            this.next = next;
        }
    }
}
