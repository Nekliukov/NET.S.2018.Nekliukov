using System;
using System.Threading;

namespace StatePatternSolution
{
    /// <inheritdoc />
    /// <summary>
    /// Red color state
    /// </summary>
    /// <seealso cref="T:StatePatternSolution.ILightState" />
    public class RedColorState : ILightState
    {

        #region Private field(s)
        /// <summary>
        /// How long does red color stays
        /// </summary>
        private const int TIMER_MILISEC = 3000;
        #endregion

        #region Public API (ILightState realistaion)
        /// <inheritdoc />
        /// <summary>
        /// Changes the color.
        /// </summary>
        /// <param name="trafficLight">The traffic light.</param>
        public void ChangeColor(TrafficLight trafficLight)
        {
            Thread.Sleep(TIMER_MILISEC);
            trafficLight.State = new GreenColorState();
        }

        /// <inheritdoc />
        /// <summary>
        /// Reports the state.
        /// </summary>
        /// <returns></returns>
        public string ReportState() => "Current color: RED";
        #endregion

    }
}
