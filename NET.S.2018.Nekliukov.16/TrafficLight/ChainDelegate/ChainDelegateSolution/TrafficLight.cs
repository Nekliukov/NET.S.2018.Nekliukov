using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace ChainDelegateSolution
{
    /// <summary>
    /// Traffic light with 3 colors. Conditions:
    /// Red -> Green
    /// Green -> Yellow
    /// Yellow -> Red etc.
    /// </summary>
    public class TrafficLight
    {
        #region Constants

        private const int COLORS_NUMBER =  3;

        private const int RED_TIMEOUT_MS = 6000;
        private const int YELLOW_TIMEOUT_MS = 3000;
        private const int GREEN_TIMEOUT_MS = 6000;

        #endregion

        #region Private fields

        private readonly Dictionary<Color, int> _trafficLightStructure
            = new Dictionary<Color, int>(COLORS_NUMBER)
            {
                {Color.Red,    RED_TIMEOUT_MS},
                {Color.Yellow, YELLOW_TIMEOUT_MS},
                {Color.Green,  GREEN_TIMEOUT_MS}
            };

        private delegate void ColorStateHandler();
        private Color _currentColor;

        #endregion

        #region Public API

        /// <summary>
        /// Starts the specified loops.
        /// </summary>
        /// <param name="loops">The loops.</param>
        /// <exception cref="System.ArgumentException">
        /// Number of loops must be grater than 0</exception>
        public void Start(int loops)
        {
            if (loops <= 0)
            {
                throw new ArgumentException("Number of loops must be grater than 0");
            }

            ColorStateHandler csh = StartRedColor;
            csh += StartGreenColor;
            csh += StartYellowColor;
            while (loops-- >= 0)
            {
                csh.Invoke();
            }
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Starts the red color.
        /// </summary>
        private void StartRedColor()
        {
            _currentColor = Color.Red;
            ShowCurrentColor();
            Thread.Sleep(_trafficLightStructure[Color.Red]);
        }

        private void StartYellowColor()
        {
            _currentColor = Color.Yellow;
            ShowCurrentColor();
            Thread.Sleep(_trafficLightStructure[Color.Yellow]);
        }

        private void StartGreenColor()
        {
            _currentColor = Color.Green;
            ShowCurrentColor();
            Thread.Sleep(_trafficLightStructure[Color.Green]);

        }

        /// <summary>
        /// Shows the color of the current on console.
        /// </summary>
        private void ShowCurrentColor()
        {
            string curColor = _currentColor.ToString();
            curColor = curColor.Replace("[", "");
            curColor = curColor.Replace("]", "");
            Console.WriteLine(curColor);
        }
        #endregion
    }
}
