using System;
using System.Collections.Generic;

class Visitor
{
    public string Name { get; set; }
    public bool Reservation { get; }

    public Visitor(string name, bool reservation)
    {
        Name = name;
        Reservation = reservation;
    }
}

class CafeQueue
{
    private Queue<Visitor> waitingQueue = new();
    private List<Visitor> reservedVisitors = new();
    public int Tables { get; set; }

    public CafeQueue(int tables)
    {
        Tables = tables;
    }

    public void Added(string name, bool reservation)
    {
        var visitor = new Visitor(name, reservation);
        if (reservation)
        {
            reservedVisitors.Add(visitor);
            Console.WriteLine($"{name} has reserved a table;");
        }
        else
        {
            waitingQueue.Enqueue(visitor);
            Console.WriteLine($"{name} is added to the queue");
        }
    }

    public void Serve()
    {
        if (Tables > 0)
        {
            if (reservedVisitors.Count > 0)
            {
                var visitor = reservedVisitors[0];
                reservedVisitors.RemoveAt(0);
                Console.WriteLine($"{visitor.Name} with reservation is seated.");
            }
            else if (waitingQueue.Count > 0)
            {
                var visitor = waitingQueue.Dequeue();
                Console.WriteLine($"{visitor.Name} from the queue is seated.");
            }
            else
            {
                Console.WriteLine("No visitors waiting.");
                return;
            }
            Tables--;
        }
        else
        {
            Console.WriteLine("No available tables.");
        }
    }
}

class Program
{
    static void Main()
    {
        CafeQueue queue = new CafeQueue(3);

        queue.Added("Amanda", false);
        queue.Serve();
        queue.Added("Sam", true);
        queue.Serve();
        queue.Added("Avadakedabra", true);
        queue.Serve();
        queue.Added("Bob", true);
        queue.Serve();
    }
}
