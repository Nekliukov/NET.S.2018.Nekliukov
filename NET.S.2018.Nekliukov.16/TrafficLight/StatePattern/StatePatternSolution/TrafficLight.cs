using System;

namespace StatePatternSolution
{
    /// <summary>
    /// Traffic light with 3 colors. Conditions:
    /// Red -> Green
    /// Green -> Yellow
    /// Yellow -> Red etc.
    /// </summary>
    public class TrafficLight
    {
        #region Private field(s)
        /// <summary>
        /// The state
        /// </summary>
        private ILightState _state;

        #endregion

        #region Public API

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        /// <exception cref="System.ArgumentNullException">value</exception>
        public ILightState State
        {
            get => _state;
            set => _state = value ??
                throw new ArgumentNullException($"Null {nameof(value)} was sent");
        }

        /// <summary>
        /// Changes the color.
        /// </summary>
        public void ChangeColor()
            => State.ChangeColor(this);

        /// <summary>
        /// Reports the state.
        /// </summary>
        /// <returns></returns>
        public string ReportState()
            => State.ReportState();

        #endregion

    }
}
