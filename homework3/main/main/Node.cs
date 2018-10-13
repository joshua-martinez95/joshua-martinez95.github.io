using System;

namespace hw3
{   
    /// <summary>
    /// singly linked node class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Node<T>
    {
        /// <summary>
        /// stores data
        /// </summary>
        public T stuff;

        /// <summary>
        /// what node is next
        /// </summary>
        public Node<T> next;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="stuff"></param>
        /// <param name="next"></param>
        public Node(T stuff, Node<T> next)
        {
            this.stuff = stuff;
            this.next = next;
        }
    }
}
