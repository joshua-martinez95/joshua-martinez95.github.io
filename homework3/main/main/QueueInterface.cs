using System;

public class hw3
{
    /// <summary>
    /// a FIFO queu interface. For a singly linked queue
    /// </summary>
    /// <typeparam name="T"></typeparam>
	public interface QueueInterface<T>
	{
        ///Add an element to the end of the queue
        ///
        /// return the elemtn that was enqueued
        ///
        
        T push(T element);

        /// removes and returns the front element
        /// 
        /// throws Thrown if the queue is empty

        
        T pop();

        bool isEmpty();
	}
}
