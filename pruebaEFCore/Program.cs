using System;
using System.Diagnostics;
using System.Threading;
using DataAccess;
using RDLC.EFCore.spDB;

namespace pruebaEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch _stopWatch = new Stopwatch();

            storedProceduresAccess sp = new storedProceduresAccess();
            CustomersList clist = new CustomersList();

            Console.WriteLine("Hello World!");
            Console.WriteLine("Notice that first query will be the longest fetch as EFCore validates " +
                                "the model that it is been requested");
            Console.WriteLine("Press any key to start the EFCore test");
            Console.ReadKey();
            Console.WriteLine();

            _stopWatch.Start();
            var f = sp.getCustomersList();
            _stopWatch.Stop();
            Console.WriteLine($"Cold Query List: {_stopWatch.ElapsedMilliseconds}, total records: {f.Count}");
            _stopWatch.Reset();

            Thread.Sleep(1000);

            _stopWatch.Start();
            sp.getCustomersList();
            _stopWatch.Stop();
            Console.WriteLine($"List: {_stopWatch.ElapsedMilliseconds}");
            _stopWatch.Reset();

            Thread.Sleep(1000);

            _stopWatch.Start();
            sp.getCustomersListNoTracking();
            _stopWatch.Stop();
            Console.WriteLine($"List as no tracking: {_stopWatch.ElapsedMilliseconds}");
            _stopWatch.Reset();

            Thread.Sleep(1000);

            _stopWatch.Start();
            sp.getCustomersIList();
            _stopWatch.Stop();
            Console.WriteLine($"IList: {_stopWatch.ElapsedMilliseconds}");
            _stopWatch.Reset();

            Thread.Sleep(1000);

            _stopWatch.Start();
            sp.getCustomersIListNoTracking();
            _stopWatch.Stop();
            Console.WriteLine($"IList as no tracking: {_stopWatch.ElapsedMilliseconds}");
            _stopWatch.Reset();

            Thread.Sleep(1000);

            _stopWatch.Start();
            sp.getCustomersIEnumerable();
            _stopWatch.Stop();
            Console.WriteLine($"IEnumerale: {_stopWatch.ElapsedMilliseconds}");
            _stopWatch.Reset();

            Thread.Sleep(1000);

            _stopWatch.Start();
            sp.getCustomersIEnumerableNoTracking();
            _stopWatch.Stop();
            Console.WriteLine($"IEnumerale as no tracking: {_stopWatch.ElapsedMilliseconds}");
            _stopWatch.Reset();

            Thread.Sleep(1000);

            _stopWatch.Start();
            sp.getAsyncCustomersIEnumerable();
            _stopWatch.Stop();
            Console.WriteLine($"Async IEnumerable: {_stopWatch.ElapsedMilliseconds}");
            _stopWatch.Reset();

            Thread.Sleep(1000);

            _stopWatch.Start();
            sp.getAsyncCustomersIEnumerableNoTracking();
            _stopWatch.Stop();
            Console.WriteLine($"Async IEnumerable as no tracking: {_stopWatch.ElapsedMilliseconds}");
            _stopWatch.Reset();

            Thread.Sleep(1000);

            _stopWatch.Start();
            sp.getCustomerFromSqlRaw();
            _stopWatch.Stop();
            Console.WriteLine($"Execute sp from EFCore: {_stopWatch.ElapsedMilliseconds}");

            Console.WriteLine("Now begin Store Procedure counterpart");
            Console.ReadKey();

            _stopWatch.Start();
            var cl = clist.getCustomersSP();
            _stopWatch.Stop();
            Console.WriteLine($"Stored Procedure round 1: {_stopWatch.ElapsedMilliseconds}, records: {cl.Rows.Count}");
            _stopWatch.Reset();

            Thread.Sleep(1000);

            _stopWatch.Start();
            clist.getCustomersSP();
            _stopWatch.Stop();
            Console.WriteLine($"Stored Procedure round 2: {_stopWatch.ElapsedMilliseconds}");
            _stopWatch.Reset();

            Thread.Sleep(1000);

            _stopWatch.Start();
            clist.getCustomersSP();
            _stopWatch.Stop();
            Console.WriteLine($"Stored Procedure round 3: {_stopWatch.ElapsedMilliseconds}");
            _stopWatch.Reset();

            Console.ReadKey();
        }
    }
}
