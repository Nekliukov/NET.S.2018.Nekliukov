using System;
using StatePatternSolution;

namespace StatePatternSolutionTest
{
    class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        static void Main()
        {
            TrafficLight tl = new TrafficLight();
            int loops = 3;

            /// <summary>
            /// Method for starting the traffic light
            /// </summary>
            void ImitateTrafficLight()
            {
                // startig light
                tl.State = new RedColorState();
                
                // tick = one state change. loop - all 3 color cahnges
                int numOfLoops = loops * 3;
                while ((numOfLoops)-- >= 0)
                {
                    Console.WriteLine(tl.ReportState());
                    tl.ChangeColor();
                }
            }

            ImitateTrafficLight();
        }
    }
}
