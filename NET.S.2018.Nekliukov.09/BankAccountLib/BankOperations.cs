using System;

namespace BankAccountLib
{
    /// <summary>
    /// Class that performs banks operations over holder's account
    /// </summary>
    public class BankOperations
    {
        #region Public API
        /// <summary>
        /// Makes the deposit.
        /// </summary>
        /// <param name="holder">The holder.</param>
        /// <param name="enteredPin">The entered pin.</param>
        /// <param name="deposit">The deposit.</param>
        /// <exception cref="System.ArgumentNullException">Null card holder value
        /// </exception>
        /// <exception cref="System.ArgumentNullException">Null pin was sent
        /// </exception>
        /// <exception cref="System.ArgumentException">Empty pin was sent
        /// </exception>
        /// <exception cref="System.ArgumentException">Wrong pin
        /// </exception>
        /// <exception cref="System.ArgumentException">Bank cannot perform depoist
        /// </exception>
        public void MakeDeposit(CardHolder holder, string enteredPin, decimal deposit)
        {
            if (holder == null)
            {
                throw new ArgumentNullException($"Null car holder value was sent");
            }

            if (deposit <= 0)
            {
                throw new ArgumentException($"Bank cannot perform your depoist with value {deposit}");
            }
            
            holder.CheckIsNullOrEmpty(enteredPin, "pin");

            if (enteredPin != holder.Pin)
            {
                throw new ArgumentException($"Wrong pin, try again.");
            }

            holder.Balance += deposit;

            // Bonus points equals to 3% of deposit multipled on card type multiplier
            // (silver - x1, gold - x2, platinum - x3)
            holder.BonusPoints += GetBonusMultiplier(holder) * (int)(deposit * 3 / 100);
            holder.ShowMessage($"Deposit succesfully performed.\n" +
                $"Current balance = {holder.Balance}\nBonus points = {holder.BonusPoints}\n");
        }

        /// <summary>
        /// Makes the withdraw.
        /// </summary>
        /// <param name="holder">The holder.</param>
        /// <param name="enteredPin">The entered pin.</param>
        /// <param name="withdraw">The withdraw.</param>
        /// <exception cref="System.ArgumentNullException">Null card holder value
        /// </exception>
        /// <exception cref="System.ArgumentNullException">Null pin was sent
        /// </exception>
        /// <exception cref="System.ArgumentException">Empty pin was sent
        /// </exception>
        /// <exception cref="System.ArgumentException">Wrong pin </exception>
        /// <exception cref="System.ArgumentNullException">Balance is not enough
        /// to perform withdraw</exception>
        public void MakeWithdraw(CardHolder holder, string enteredPin, decimal withdraw)
        {
            if (holder == null)
            {
                throw new ArgumentNullException($"Null car holder value was sent");
            }

            holder.CheckIsNullOrEmpty(enteredPin, "pin");

            if (enteredPin != holder.Pin)
            {
                throw new ArgumentException($"Wrong pin, operation cancelled.");
            }

            if (withdraw <= 0)
            {
                throw new ArgumentException($"Bank cannot perform your withdraw with value {withdraw}");
            }

            if (withdraw > holder.Balance)
            {
                throw new ArgumentException($"Your balance is not enough to perform withdraw.\n" +
                    $"Balance - {holder.Balance}, Withdraw - {withdraw}");
            }

            holder.Balance -= withdraw;

            // Bonus points are reset to zero if you withdraws all your money
            if (holder.Balance == 0)
            {
                holder.BonusPoints = 0;
            }

            holder.ShowMessage($"Withdraw succesfully performed.\nCurrent balance" +
                $" = {holder.Balance}\nBonus points = {holder.BonusPoints}\n");
        }
        #endregion

        #region Private API
        /// <summary>
        /// Gets the bonus multiplier.
        /// </summary>
        /// <param name="holder">The holder.</param>
        /// <returns>Bonus multiplier, according to card's type</returns>
        private int GetBonusMultiplier(CardHolder holder)
        {
            for (int i = 0; i < holder.CardTypes.Length; i++)
            {
                if (holder.CardType.ToLower() == holder.CardTypes[i])
                {
                    return i + 1;
                }
            }

            return -1;
        }
        #endregion
    }
}
