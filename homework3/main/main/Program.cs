using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mainProgram
{
    class binaryTree
    {

        static LinkedList<string> generateBinaryRepresentationList(int n)
        {
            LinkedQueues<StringBuilder> q = new LinkedQueues<StringBuilder>();

            LinkedList<string> output = new LinkedList<string>();

            if (n < 1)
            {
                return output;
            }
            q.push(new StringBuilder("1"));

            /// BFS
            while(n > 0)
            {
                /// printthe front of the queue
                StringBuilder sb = q.pop();
                output.AddLast(sb.ToString());


                StringBuilder sbc = new StringBuilder(sb.ToString());

                sb.Append('0');
                q.push(sb);

                sbc.Append('1');
                q.push(sbc);
                n--;
            }
            return output;
        }

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
