using hw3;
using hw3Ex;
using System;

public class LinkedQueues<T> : QueueInterface<T>
{
        /// <summary>
        /// dtermines what's in front or behind the node
        /// </summary>
        private Node<T> front;
        private Node<T> rear;
        /// <summary>
        /// Linked nodes
        /// </summary>
        public LinkedQueues()
        {
            front = null;
            rear = null;

        }
        /// <summary>
        /// actual push method
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public T push(T element)
        {
            if (element == null)
            {
                throw new NullReferenceException();
            }
            if (isEmpty())
            {
                Node<T> tmp = new Node<T>(element, null);
                rear = front = tmp;
            }
            else
            {
                //General case
                Node<T> tmp = new Node<T>(element, null);
                rear.next = tmp;
                rear = tmp;
            }
            return element;
        }
        /// <summary>
        /// actual pop method. returns the top node
        /// </summary>
        /// <returns></returns>
        public T pop()
        {
            T tmp = default(T);
            if ( isEmpty() )
            {
                throw new QueueUnderflowException("The queue was empty when pop was invoked.");
            }
            else if (front == rear)
            {
                // one item in queue
                tmp = front.stuff;
                front = null;
                rear = null;
            }
            else
            {
                // general case
                tmp = front.stuff;
                front = front.next;
            }
            return tmp;
        }
        /// <summary>
        /// if empty, do this
        /// </summary>
        /// <returns></returns>
        public bool isEmpty()
        {
            if ( front == null && rear == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

	
}
