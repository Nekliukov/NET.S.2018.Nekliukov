using System;
using TimerLib;

namespace TimerTest
{
    /// <summary>
    /// First event listener
    /// </summary>
    public class Professor
    {
        private string name;

        #region Ctors                
        /// <summary>
        /// Initializes a new instance of the <see cref="Professor"/> class.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        public Professor(string userName) => Name = userName;

        /// <summary>
        /// Initializes a new instance of the <see cref="Professor"/> class.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="timerManager">The timer manager.</param>
        public Professor(string userName, TimerManager timerManager)
        {
            name = userName;
            timerManager.TimeIsUp += Reaction;
        }
        #endregion

        #region Public API        

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        /// <exception cref="ArgumentException">Name can't be empty</exception>
        /// <exception cref="ArgumentNullException">Null value of name was sent</exception>
        public string Name
        {
            get => name;
            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Name can't be empty");
                }

                if (value == null)
                {
                    throw new ArgumentNullException("Null value of name was sent");
                }

                name = value;
            }
        }
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
            => Console.WriteLine(Name + ": " + eventArgs.ProfessorMsg);
    }
}
