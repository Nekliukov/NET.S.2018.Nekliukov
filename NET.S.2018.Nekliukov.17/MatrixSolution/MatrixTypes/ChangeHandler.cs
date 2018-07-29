using System.Windows.Forms;

namespace MatrixTypes
{
    /// <summary>
    /// Class for notifying about index of matrix cahnging
    /// </summary>
    internal sealed class ChangeHandler
    {
        /// <summary>
        /// Generates the message.
        /// </summary>
        /// <param name="indexI">The index i.</param>
        /// <param name="indexJ">The index j.</param>
        internal void GenerateMessage(int indexI, int indexJ)
            => MessageBox.Show($"Matrix was changed on index [{indexI}, {indexJ}]");
    }
}
