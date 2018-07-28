using System.Threading;

namespace StatePatternSolution
{
    /// <inheritdoc />
    /// <summary>
    /// Green color state
    /// </summary>
    /// <seealso cref="T:StatePatternSolution.ILightState" />
    public class GreenColorState : ILightState
    {
        #region Private field(s)
        /// <summary>
        /// How long does green color stays
        /// </summary>
        private const int TIMER_MILISEC = 5000;
        #endregion

        #region Public API (ILightState realistaion)

        /// <inheritdoc />
        /// <summary>
        /// Changes the color to next one
        /// </summary>
        /// <param name="trafficLight">The traffic light.</param>
        public void ChangeColor(TrafficLight trafficLight)
        {
            Thread.Sleep(TIMER_MILISEC);
            trafficLight.State = new YellowColorState();
        }

        /// <inheritdoc />
        /// <summary>
        /// Reports the state.
        /// </summary>
        /// <returns></returns>
        public string ReportState() => "Current color: GREEN";

        #endregion

    }
}
