namespace async_await_task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Sample4();
            Task task1 = Task1a();
            task1.Wait();
            Task task2 = Task2a();
            Task task3 = Task3a();
            DoSomething(5, "main", ConsoleColor.Blue);
            Console.WriteLine("Hello world");
            Console.ReadKey();
        }
        public static void DoSomething(int count, string msg, ConsoleColor color)
        {
            lock (Console.Out)
            {
                Console.ForegroundColor = color;
                Console.WriteLine($"{msg,10} start");
                Console.ResetColor();
            }
            for (int i = 0; i < count; i++)
            {
                lock (Console.Out)
                {
                    Console.ForegroundColor = color;
                    Console.WriteLine($"{msg,10} {i,2}");
                    Console.ResetColor();
                }
                Thread.Sleep(1000);
            }
            lock (Console.Out)
            {
                Console.ForegroundColor = color;
                Console.WriteLine($"{msg,10} end");
                Console.ResetColor();
            }
        }


        public static void Sample1()
        {
            Task t1 = new Task(() =>
            {
                DoSomething(5, "1", ConsoleColor.Red);
            });
            Task t2 = new Task(() =>
            {
                DoSomething(7, "2", ConsoleColor.Green);
            });
            Task t3 = new Task(() =>
            {
                DoSomething(9, "3", ConsoleColor.Yellow);
            });
            t1.Start();
            t2.Start();
            t3.Start();
        }

        public static void Sample2()
        {
            Task t1 = new Task((object o) =>
            {
                DoSomething(5, (string)o, ConsoleColor.Red);
            }, "1");
            Task t2 = new Task((object o) =>
            {
                DoSomething(7, (string)o, ConsoleColor.Green);
            }, "2");
            Task t3 = new Task((object o) =>
            {
                DoSomething(9, (string)o, ConsoleColor.Yellow);
            }, "3");
            t1.Start();
            t2.Start();
            t3.Start();
        }
        public static void Sample3()
        {
            Task t1 = new Task(() =>
            {
                DoSomething(5, "1", ConsoleColor.Red);
            });
            Task t2 = new Task(() =>
            {
                DoSomething(7, "2", ConsoleColor.Green);
            });
            Task t3 = new Task(() =>
            {
                DoSomething(9, "3", ConsoleColor.Yellow);
            });
            t1.Start();
            t1.Wait();//t1 xong mới đi tiếp
            t2.Start();
            t2.Wait();//t2 xong mới đi tiếp
            t3.Start();
            t3.Wait();//t3 xong mới đi tiếp
        }
        public static void Sample4()
        {
            Task t1 = new Task(() =>
            {
                DoSomething(5, "1", ConsoleColor.Red);
            });
            Task t2 = new Task(() =>
            {
                DoSomething(7, "2", ConsoleColor.Green);
            });
            Task t3 = new Task(() =>
            {
                DoSomething(9, "3", ConsoleColor.Yellow);
            });
            t1.Start();
            t2.Start();
            Task.WaitAll(t1, t2);
            t3.Start();
            //t3.Wait();
            Console.WriteLine("Hehe");
        }
        public static Task Task1()
        {
            Task t1 = new Task(() =>
            {
                DoSomething(5, "1", ConsoleColor.Red);
            });
            t1.Start();
            t1.Wait();
            Console.WriteLine("task 1 xong nè");
            return t1;
        }
        public static Task Task2()
        {
            Task t2 = new Task(() =>
            {
                DoSomething(7, "2", ConsoleColor.Green);
            });
            t2.Start();
            return t2;
        }
        public static Task Task3()
        {
            Task t3 = new Task(() =>
            {
                DoSomething(9, "3", ConsoleColor.Yellow);
            });
            t3.Start();
            return t3;
        }
        public static async Task Task1a()
        {
            Task t1 = new Task(() =>
            {
                DoSomething(5, "1", ConsoleColor.Red);
            });
            t1.Start();
            //t1.Wait();
            await t1;//khác t1.Wait() là khi await thì trả task luôn
            Console.WriteLine("task 1 xong nè");
            //return t1;
        }
        public static async Task Task2a()
        {
            Task t2 = new Task(() =>
            {
                DoSomething(7, "2", ConsoleColor.Green);
            });
            t2.Start();
            //t2.Wait();
            await t2;
            Console.WriteLine("task 2 xong nè");
            //return t2;
        }
        public static async Task Task3a()
        {
            Task t3 = new Task(() =>
            {
                DoSomething(9, "3", ConsoleColor.Yellow);
            });
            t3.Start();
            //t3.Wait();
            await t3;
            Console.WriteLine("task 3 xong nè");
            //return t3;
        }
    }
}