using ChainDelegateSolution;

namespace ChainDelegateTest
{
    class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        static void Main()
        {
            TrafficLight trafficLight = new TrafficLight();
            trafficLight.Start(3);
        }
    }
}
