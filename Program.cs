using System;

namespace DnetDelegates
{
    class Program
    {
        public delegate void WorkPerformedHandler(int hours); // custom delegate

        static void Main(string[] args)
        {
            Console.WriteLine("Delegates and Lambdas");

            //WorkPerformedHandler delegate1 = new WorkPerformedHandler(WorkPerformed1);
            //WorkPerformedHandler delegate2 = new WorkPerformedHandler(WorkPerformed2);
            //WorkPerformedHandler delegate3 = new WorkPerformedHandler(WorkPerformed3);

            //delegate3 += delegate1 + delegate2; // Invocation List
            //delegate3(15); // Will call all 3 delegates

            var worker = new Worker();
            worker.WorkPerformed += new EventHandler<WorkPerformedEventArgs>(WPHandler);
            worker.WorkCompleted += new EventHandler(WCHandler);
            worker.DoWork(8);
            //Hours WorkPerformed 8
            //Work Completed

            // Above can be rewrote as follows:
            //worker.WorkPerformed += WPHandler; // delegate inference
            //worker.WorkCompleted += WCHandler; // delegate inference

            // Anonymous Function
            //worker.WorkPerformed += delegate (object sender, WorkPerformedEventArgs e) {
            //    Console.WriteLine($"Hours WorkPerformed {e.Hours}");
            //};

            // Lambdas
            var worker2 = new Worker();
            worker2.WorkPerformed += (s, e) =>
            {
                Console.WriteLine("Work Performed " + e.Hours);
            };
            worker2.WorkCompleted += (s, e) => Console.WriteLine("Work Completed");
            worker2.DoWork(5);
        }

        static void WPHandler(object sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine($"Hours WorkPerformed {e.Hours}");
        }
        static void WCHandler(object sender, EventArgs e)
        {
            Console.WriteLine($"Work Completed");
        }

        static void WorkPerformed1(int hours)
        {
            Console.WriteLine($"Worked Performed 1 for {hours}");
        }
        static void WorkPerformed2(int hours)
        {
            Console.WriteLine($"Worked Performed 2 for {hours}");
        }
        static void WorkPerformed3(int hours)
        {
            Console.WriteLine($"Worked Performed 3 for {hours}");
        }
    }
}
