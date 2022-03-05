using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp4
{

    class Route
    {
        private List<Router> listOfRouters = new List<Router>();
        public static int routesCounter = 0;

        public Route()
        {
            Console.WriteLine($"Route {routesCounter+1} has created successfully.\n");
            routesCounter++;
        }

        public Route AddNewRouter(Router router)
        {
            listOfRouters.Add(router);
            Console.WriteLine("Router has been added successfully.\n ");
            return this;
        }

        public List<Router> GetListOfRouters()
        {
            return listOfRouters;
        }


    }

    class Router
    {
        private int routerTime;
        public Router()
        {
            Console.WriteLine("Router has been created successfully.\n ");
        }

        public void SetRouterTime(int routerTime_)
        {
            routerTime = routerTime_;
        }

        public int GetRouterTime()
        {
            return routerTime;
        }
     
    }

    class Implementation
    {
        private List<Route> listOfRoutes = new List<Route>();

        public void ImplementationMain()
        {
            
            Console.WriteLine("\n List of available operations for you in below :) ");
            Console.WriteLine(".............................................\n");
            Console.WriteLine("1. Create a new route .");
            Console.WriteLine("2. Add a router to given route .");
            Console.WriteLine("\n............................................\n");

            Console.Write("Enter your choice plz : ");
            int choice = Convert.ToInt32(Console.ReadLine());

            while (choice != -1){
                switch (choice)
                            {
                                case 1:
                                    Route route = new Route();
                                    listOfRoutes.Add(route);
                                    break;
                                case 2:
                                    AddRouterToRoute();
                                    break;
                                default:
                                    Console.WriteLine("No match founded\n");
                                    break;
                            }
                Console.Write("Enter your choice plz . PS: enter -1 to end the operation : ");
                choice = Convert.ToInt32(Console.ReadLine());
            }
            
        }

        public void AddRouterToRoute()
        {
            if (listOfRoutes.Count() == 0)
            {
                Console.WriteLine("List of routes is empty : ");
                return;
            }
            Console.Write("Plz enter the route number you want add the router to it : ");
            int routeNumber = Convert.ToInt32(Console.ReadLine());
            while (routeNumber <=0 || routeNumber > listOfRoutes.Count())
            {
                Console.Write("The Route number witch you have entered is out of range :( \nPlz enter the route number you want add the router to it again : ");
                routeNumber = int.Parse(Console.ReadLine());
            }

            Router router = new Router();
            Console.Write("Plz enter the router time : ");
            int routerTime = Convert.ToInt32(Console.ReadLine());
            router.SetRouterTime(routerTime);
            listOfRoutes[routeNumber-1].AddNewRouter(router);

        }


        public List<Route> GetListOfRoutes()
        {
            return listOfRoutes;
        }
        
    }

    class BestRoute
    {
        Implementation Implementation_ = new Implementation();

        public int GetBestRoutSync(List<Route> listOfRoutes)
        {

            int sumTime = 0 , bestRout_ = int.MaxValue , numberOfBestRoute=0;
            for (int i = 0; i < listOfRoutes.Count(); i++)
            {

                sumTime = SumTime(listOfRoutes[i]);
                if (sumTime < bestRout_)
                {
                    bestRout_ = sumTime;
                    numberOfBestRoute = i + 1;
                }
 
            }

            return numberOfBestRoute;
        }

        public int SumTime(Route route)
         {
            int sumTime = 0;
            for (int j = 0; j < route.GetListOfRouters().Count(); j++)
            {
                sumTime += route.GetListOfRouters()[j].GetRouterTime();         
            }

            return sumTime;
         }

        public int  GetBestRoutAsync(List<Route> listOfRoutes)
        {

            int bestRout_ = int.MaxValue, numberOfBestRoute = 0;
            for (int i = 0; i < listOfRoutes.Count(); i++)
            {
                var sumTime = SumTimeAsync(listOfRoutes[i]);
                if (sumTime.GetAwaiter().GetResult() < bestRout_)
                {
                    bestRout_ = sumTime.GetAwaiter().GetResult();
                    numberOfBestRoute = i + 1;
                }
            }

            return numberOfBestRoute;
        }

        public async Task<int> SumTimeAsync(Route route)
        {
            var task = Task.Run(() =>
            {
                int sumTime = 0;
                for (int j = 0; j < route.GetListOfRouters().Count(); j++)
                {
                    sumTime += route.GetListOfRouters()[j].GetRouterTime();
                }
 
                return sumTime;
            });

            await task;
            return task.GetAwaiter().GetResult();
        }

    }

    class Program
    {
        static async Task Main(string[] args)
        {

            int numberOfBestRoute1 = 0 , numberOfBestRoute2 = 0;
            Implementation Implementation_ = new Implementation();
            BestRoute bestRoute = new BestRoute();

            Implementation_.ImplementationMain();
            List<Route> listOfRoutes = Implementation_.GetListOfRoutes();

            numberOfBestRoute1 = bestRoute.GetBestRoutSync(listOfRoutes);
            numberOfBestRoute2 = bestRoute.GetBestRoutAsync(listOfRoutes);


            Console.WriteLine("\nThe best total time between all routes from synchronous methode = " + numberOfBestRoute1);
            Console.WriteLine("The best total time between all routes from asynchronous methode = " + numberOfBestRoute2);

            //The max number of allowed parallel threads is 4 :

            /* 
               int result = 0 ; 
               Parallel.ForEach(listOfRoutes, new ParallelOptions { MaxDegreeOfParallelism = 4 }, async msg =>
                {
                        result = bestRoute.GetBestRoutAsync(listOfRoutes);
                 });
            */

            Console.ReadKey();

        }


    }
}
