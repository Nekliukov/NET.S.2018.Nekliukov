namespace StatePatternSolution
{
    /// <summary>
    /// Declares methods for each color state
    /// </summary>
    public interface ILightState
    {
        /// <summary>
        /// Changes the color.
        /// </summary>
        /// <param name="trafficLight">The traffic light.</param>
        void ChangeColor(TrafficLight trafficLight);

        /// <summary>
        /// Reports the state.
        /// </summary>
        /// <returns></returns>
        string ReportState();
    }
}
