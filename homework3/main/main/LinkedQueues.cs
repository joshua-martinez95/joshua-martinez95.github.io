using hw3;
using hw3Ex;
using System;

public class LinkedQueues<T> : QueueInterface<T>
{
        private Node<T> front;
        private Node<T> rear;

        public LinkedQueues()
        {
            front = null;
            rear = null;

        }

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
