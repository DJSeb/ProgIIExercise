using System;
using System.Collections.Generic;

namespace PhonebookForIntegers
{
    class Node
    {
        private Node next;
        private int value;

        public int Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public Node Next
        {
            get { return next; }
            set { this.next = value; }
        }

        public Node(int value, Node next = null)
        {
            Next = next;
            Value = value;
        }
    }

    class LinkedList
    {
        private Node root;
        private Node tail;

        public LinkedList(Node root = null)
        {
            Root = root;
            Tail = root;
        }

        public LinkedList(int value)
        {
            Node root = new Node(value);
            Root = root;
            Tail = root;
        }

        public Node Root
        { 
            get { return root; }
            set { root = value; }
        }

        public Node Tail
        {
            get { return tail; }
            set { tail = value; }
        }

        public void Add(int value)
        {
            if(Root == null)
            {
                Root = new Node(value);
                Tail = Root;
                return;
            }
            Tail.Next = new Node(value);
            Tail = Tail.Next;
            return;
        }

        public void Remove(int value)
        {
            Node current = root;

            if(current == null)
            {
                return;
            }

            while(current.Next != null && current.Next.Value != value)
            {
                current = current.Next;
            }

            if(current.Next == null)
            {
                return;
            }

            if(current.Next == Tail)
            {
                tail = current;
            }

            current.Next = current.Next.Next;
            return;
        }

        public void Sort()
        {
            List<int> list = this.getList();
            list.Sort(); 
            Root = new Node(list[0]);
            Tail = Root;
            list.RemoveAt(0);

            foreach(int value in list)
            {
                Tail.Next = new Node(value);
                Tail = Tail.Next;
            }

            return;
        }

        public void Print()
        {
            Console.WriteLine();
            Node current = Root;

            while(current != null)
            {
                Console.WriteLine(current.Value.ToString());
                current = current.Next;
            }

            Console.WriteLine();
            return;
        }

        private List<int> getList()
        {
            List<int> to_return = new List<int>();
            Node current = root;
            while(current != null)
            {
                to_return.Add(current.Value);
                current = current.Next;
            }

            return to_return;
        }
    }

    class PhoneBook
    {
        private LinkedList book;
        bool end = false;

        public PhoneBook()
        {
            book = new LinkedList();
        }

        public void Instruction(int code, int parameter = 0)
        {
            switch(code)
            {
                case 1:
                    book.Add(parameter);
                    break;
                case 2:
                    book.Remove(parameter);
                    break;
                case 4:
                    book.Sort();
                    break;
                case 5:
                    book.Print();
                    break;
                case 6:
                    end = true;
                    break;
                default:
                    Console.WriteLine("Unknown instruction");
                    break;

            }
        }

        public void Execute()
        {
            while(!end)
            {
                string[] input = Console.ReadLine().Split();
                int instruction = int.Parse(input[0]);
                int parameter = -1;
                if(input.Length > 1)
                    parameter = int.Parse(input[1]);
                this.Instruction(instruction, parameter);
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            PhoneBook phonebook = new PhoneBook();
            phonebook.Execute();
        }
    }
}
