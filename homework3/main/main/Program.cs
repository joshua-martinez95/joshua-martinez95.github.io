using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mainProgram
{   
    /// <summary>
    /// this class holds the main function
    /// </summary>
    class binaryTree
    {
        /// <summary>
        ///     /**
        ///* Print the binary representation of all numbers from 1 up to n.
        ///* This is accomplished by using a FIFO queue to perform a level
        ///* order(i.e.BFS) traversal of a virtual binary tree that
        ///* looks like this:
        ///*                 1
        ///*             /       \
        /// *            10       11
        ///*           /  \     /  \
        ///*         100  101  110  111
        ///*          etc.
        ///* and then storing each "value" in a list as it is "visited".
        ///*/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
    static LinkedList<string> generateBinaryRepresentationList(int n)
        {
            /// create an empty queue of strings with which to perform the traversal
            LinkedQueues<StringBuilder> q = new LinkedQueues<StringBuilder>();
            /// a list for returning the binary values
            LinkedList<string> output = new LinkedList<string>();

            if (n < 1)
            {
                /// binary representatin of negative values is ot supported
                /// return an empty list
                return output;
            }

            ///Enqueue the first binary number. Use a dynamic string to avoid string concat
            q.push(new StringBuilder("1"));

            /// BFS
            while(n > 0)
            {
                /// printthe front of the queue
                StringBuilder sb = q.pop();
                output.AddLast(sb.ToString());

                /// make a copy
                StringBuilder sbc = new StringBuilder(sb.ToString());
                /// left child
                sb.Append('0');
                q.push(sb);
                /// right child
                sbc.Append('1');
                q.push(sbc);
                n--;
            }
            return output;
        }
        /// <summary>
        /// driver program to test above function
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            int n = 10;
            if(args.Length < 1)
            {
                Console.Write("Please invoke with the max value to print binary up to, like this:");
                Console.Write("\tMain 12");
                return;
            }
            try
            {
                n = Int32.Parse(args[0]);
            }
            catch (NotFiniteNumberException e)
            {
                Console.Write("I'm sorry, I can't understand the number: " + args[0]);
                return;
            }

            LinkedList<string> output = generateBinaryRepresentationList(n);
            int maxLength = output.Last().Length;
            foreach (string s in output)
            {
                for(int i = 0; i < maxLength - s.Length; ++i)
                {
                    Console.Write(" ");
                }
                Console.Write(s+"\n");
            }
        }
    }
}
