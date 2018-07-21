using System;
using TimerLib;

namespace TimerTest
{
    class Ring
    {
        #region Ctors        
        /// <summary>
        /// Initializes a new instance of the <see cref="Ring"/> class.
        /// </summary>
        public Ring(){ }

        /// <summary>
        /// Initializes a new instance of the <see cref="Ring"/> class.
        /// </summary>
        /// <param name="timerManager">The timer manager.</param>
        public Ring(TimerManager timerManager) => timerManager.TimeIsUp += Reaction;
        #endregion

        #region Public API
        /// <summary>
        /// Registers the specified time manager.
        /// </summary>
        /// <param name="timeManager">The time manager.</param>
        public void Register(TimerManager timeManager) => timeManager.TimeIsUp += Reaction;

        /// <summary>
        /// Unregisters the specified time manager.
        /// </summary>
        /// <param name="timeManager">The time manager.</param>
        public void Unregister(TimerManager timeManager) => timeManager.TimeIsUp -= Reaction;
        #endregion

        /// <summary>
        /// Reaction on some event from this type
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The <see cref="ElapsedTimeEventArgs"/> instance containing the event data.</param>
        private void Reaction(object sender, ElapsedTimeEventArgs eventArgs)
            => Console.WriteLine(eventArgs.RingMsg);
    }
}
