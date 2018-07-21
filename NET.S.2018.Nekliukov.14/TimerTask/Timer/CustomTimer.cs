using System;
using System.Threading;

namespace TimerLib
{
    /// <summary>
    /// Main class for actions and event managment with timer
    /// </summary>
    public class TimerManager
    {
        #region Private fields
        private int initSeconds;
        #endregion

        #region Public fields
        /// <summary>
        /// Occurs when time is up.
        /// </summary>
        public event EventHandler<ElapsedTimeEventArgs> TimeIsUp = delegate { };
        #endregion

        #region Ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="TimerManager"/> class.
        /// </summary>
        /// <param name="StartSeconds">The start seconds.</param>
        public TimerManager(int StartSeconds) => InitSeconds = StartSeconds;
        #endregion

        #region Public API
        /// <summary>
        /// Gets or sets the initialize seconds.
        /// </summary>
        /// <value>
        /// The initialize seconds.
        /// </value>
        /// <exception cref="ArgumentException">Seconds can't be negative</exception>
        public int InitSeconds {
            get => initSeconds;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Seconds can't be negative");
                }

                initSeconds = value;
            }
        }

        /// <summary>
        /// Starts the timer.
        /// </summary>
        public void StartTimer()
        {
            for (int leftSeconds = initSeconds; leftSeconds >= 0; leftSeconds--)
            {
                Thread.Sleep(1000);
                Console.Clear();
                Console.WriteLine("==== Examination started ==== ");
                Console.WriteLine($"Time left: {leftSeconds} seconds");
            }

            SimulateOutOfTime();
        }
        #endregion

        #region Notification method
        /// <summary>
        /// Raises the <see cref="E:OutOfTime" /> event.
        /// </summary>
        /// <param name="e">The <see cref="ElapsedTimeEventArgs"/> instance containing the event data.</param>
        protected virtual void OnOutOfTime(ElapsedTimeEventArgs e)
        {
            EventHandler<ElapsedTimeEventArgs> temp = TimeIsUp;
            temp?.Invoke(this, e);
        }
        #endregion

        /// <summary>
        /// Simulates the out of time.
        /// </summary>
        private void SimulateOutOfTime() => OnOutOfTime(new ElapsedTimeEventArgs());
    }

    #region Listeners
    
    #endregion
}
