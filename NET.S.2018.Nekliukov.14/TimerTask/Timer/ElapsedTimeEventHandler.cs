using System;

namespace TimerLib
{
    /// <summary>
    /// Type for stoaring info, which sends to recivieces in case of
    /// event notification
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class ElapsedTimeEventArgs : EventArgs
    {
        public string ProfessorMsg { get; } = "Time is up! Collect all test blanks!";
        public string StudentMsg { get; } = "Oh, please, give us 5 extra minutes!";
        public string RingMsg { get; } = "Ring, ring, ring!!!!!!!!!!!!!!!!!!!!!!!";
    }
}
