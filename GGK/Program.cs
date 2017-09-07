using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GGK
{
    class Program
    {
        static void Main(string[] args)
        {
            

            while (true)
            {
                Console.Write("1. Binary Search Tree\n2. Shortest Path Routing Algorithm\n3. Consecutive Prime Sum\n4. Sum of two Numbers\n5. ASCII Conversion\n6. Exit\nEnter your choice: ");
                int n = Convert.ToInt32(Console.ReadLine());

                switch (n)
                {
                    case 1:BinarySearchTree bst = new BinarySearchTree();
                        bst.ScanData();
                        bst.Search();
                        break;
                    case 2:ShortestPathRoutingAlgorithm spra = new ShortestPathRoutingAlgorithm();
                        spra.ScanData();
                        spra.FindPath();
                        break;
                    case 3:ConsecutivePrimeSum cps = new ConsecutivePrimeSum();
                        cps.ScanData();
                        cps.FindCPS();
                        break;
                    case 4:Sum s = new Sum();
                        s.ScanData();
                        s.FindSum();
                        break;
                    case 5:ASCIIConversion ac = new ASCIIConversion();
                        ac.ScanData();
                        ac.ASCIIConvert();
                        break;
                    case 6:Environment.Exit(0);
                        break;
                    default:Console.WriteLine("Please enter a valid input!!");
                        break;
                }
            }
        }
    }

    class BinarySearchTree
    {
        Node head;

        protected internal class Node
        {
            internal protected int data;
            internal protected Node left, right;

            internal protected Node(int data)
            {
                this.data = data;
                left = right = null;
            }
        }

        void addNode(int data)
        {
            Node n = new Node(data);

            if (head == null)
                head = n;
            else
            {
                Node temp = head;
                while(true)
                {
                    if (data > temp.data)
                    {
                        if(temp.right != null)
                            temp = temp.right;
                        else
                        {
                            temp.right = n;
                            break;
                        }
                    }
                    else if (data < temp.data)
                    {
                        if (temp.left != null)
                            temp = temp.left;
                        else
                        {
                            temp.left = n;
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Duplicate data: " + data);
                        return;
                    }
                }
            }
        }

        protected internal void ScanData()
        {
            Console.Write("Enter the data:");
            string[] str = Console.ReadLine().Trim().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            foreach(string s in str)
                addNode(Convert.ToInt32(s));
        }

        protected internal void PrintAscending(Node ptr)
        {
            if(ptr != null)
            {
                PrintAscending(ptr.left);
                Console.Write(ptr.data + " ");
                PrintAscending(ptr.right);
            }
        }

        protected internal void PrintDescending(Node ptr)
        {
            if (ptr != null)
            {
                PrintDescending(ptr.right);
                Console.Write(ptr.data + " ");
                PrintDescending(ptr.left);
            }
        }

        protected internal void Search()
        {
            while (true)
            {
                Console.Write("\n1.Ascending Order\n2.Descending Order\n3.Exit\nEnter your choice: ");
                int n = Convert.ToInt32(Console.ReadLine());

                switch (n)
                {
                    case 1:Console.Write("Data in Ascending order: ");
                        PrintAscending(head);
                        break;
                    case 2:Console.Write("Data in Descending order: ");
                        PrintDescending(head);
                        break;
                    case 3:return;
                    default:Console.WriteLine();
                        break;
                }
            }
        }
    }

    class ShortestPathRoutingAlgorithm
    {
        int n, start = 0, end = 0, dist = 0;

        protected internal class Node
        {
            protected internal int name;
            protected internal Dictionary<int, int> adjNode;
        }

        protected internal void ScanData()
        {
            Console.Write("Enter the data:");
            string[] str = Console.ReadLine().Trim().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < n; i++)
            {
                Node temp = new Node();
                Console.Write("Enter the node name: ");
                temp.name = int.Parse(Console.ReadLine());

                Console.Write("Enter Number of Connected Nodes: ");
                int num = int.Parse(Console.ReadLine());
                for (int j = 0; j < num; j++)
                {
                    Console.Write("Enter the Node name: ");
                    int name = int.Parse(Console.ReadLine());
                    Console.Write("Enter the Node distance: ");
                    int dist = int.Parse(Console.ReadLine());

                    temp.adjNode.Add(name, dist);
                }
            }

            Console.Write("Enter the starting node: ");
            start = int.Parse(Console.ReadLine());
            Console.Write("Enter the ending node: ");
            end = int.Parse(Console.ReadLine());
        }

        protected internal void FindPath()
        {
            int shortestDist = GetPath(start, end, dist);
        }

        protected internal int GetPath(int s, int e, int d)
        {
            return 1;
        }
    }

    class ConsecutivePrimeSum
    {
        long input;
        List<long> primeList = new List<long>();
        internal protected void PopulatePrimeList(long n)
        {
            primeList.Add(2);

            for(long i = 3; i <= n; i++)
            {
                bool isPrime = true;

                foreach(long p in primeList)
                {
                    if (i % p == 0)
                        isPrime = false;
                }

                if (isPrime)
                    primeList.Add(i);
            }

            primeList.Remove(2);
        }

        internal protected void ScanData()
        {
            Console.Write("Enter the Maximum Range Value: ");
            input = Convert.ToInt64(Console.ReadLine().Trim());

            if(input <= 3)
            {
                Console.WriteLine("Invalid Input !!");
                System.Environment.Exit(0);
            }
        }

        internal protected void FindCPS()
        {
            PopulatePrimeList(input);

            long count = 0, consecutiveSum = 2;
            foreach(long p in primeList)
            {
                consecutiveSum += p;

                if (primeList.Contains(consecutiveSum))
                    count++;
            }

            Console.WriteLine("Number of Consecutive prime number between 3 and " + input + " is: " + count);
        }
    }

    class Sum
    {
        string n1, n2;

        internal protected void ScanData()
        {
            Console.Write("Enter the first number: ");
            n1 = Console.ReadLine();
            Console.Write("Enter the second number: ");
            n2 = Console.ReadLine();
        }

        internal protected void FindSum()
        {
            int len = n1.Length > n2.Length ? n1.Length - 1: n2.Length - 1, carry = 0;
            string output = "";

            if (n1.Length > n2.Length)
                n2 = n2.PadLeft(n1.Length, '0');
            else
                n1 = n1.PadLeft(n2.Length, '0');

            while (len != -1)
            {
                int sum = int.Parse(n1[len].ToString()) + int.Parse(n2[len].ToString());

                sum += carry;

                if (sum >= 10)
                {
                    output += sum % 10;
                    carry = sum / 10;
                }
                else
                {
                    output += sum;
                    carry = 0;
                }
                len--;
            }

            if (carry >= 1)
                output += carry;

            char[] arr = output.ToCharArray();
            Array.Reverse(arr);
            output = new string(arr);

            Console.WriteLine("The sum of " + n1 + " and " + n2 + " is: " + output);
        }
    }

    class ASCIIConversion
    {
        string input;

        bool IsPrime(int num)
        {
            for (int i = 2; i <= Math.Sqrt(num); i++)
                if (num % i == 0)
                    return false;

            return true;
        }

        internal protected void ScanData()
        {
            Console.Write("Enter an input String: ");
            input = Console.ReadLine();
        }

        internal protected void ASCIIConvert(){
            byte[] asciiValues = Encoding.ASCII.GetBytes(input);

            Console.Write("The converted ASCII value is: ");

            for(int i = 1; i < asciiValues.Length; i++)
            {
                int val = (asciiValues[i - 1] + asciiValues[i]) / 2;

                if (!IsPrime(val))
                    Console.Write(Char.ConvertFromUtf32(val));
                else
                    Console.Write(Char.ConvertFromUtf32(val + 1));
            }
            Console.WriteLine();
        }
    }
}
