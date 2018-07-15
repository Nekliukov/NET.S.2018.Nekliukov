using System;
using System.Linq;

namespace BankAccountLib
{
    /// <summary>
    /// Class that creates instances of card holders in a bank
    /// </summary>
    public class CardHolder
    {
        #region Constants & readonly        
        /// <summary>
        /// The card types
        /// </summary>
        internal readonly string[] CardTypes = { "silver", "gold", "platinum" };
        private const int MAX_NAME_LEN = 30;
        private const int MAX_PIN_LEN = 4;
        #endregion

        #region Private fields
        private string cardType;
        private decimal balance;
        private string name;
        private string pin;
        #endregion

        #region Properties        
        /// <summary>
        /// Gets the name. Values set only in this type
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        /// <exception cref="System.ArgumentException">Wrong name format</exception>
        /// <exception cref="System.ArgumentException">Empty value was sent</exception>
        /// <exception cref="System.ArgumentNullException">Null value was sent</exception>
        public string Name
        {
            get
            {
                return name;
            }

            private set
            {
                CheckIsNullOrEmpty(value, "name");
                value = value.Trim();

                if (!ValidateName(value))
                {
                    throw new ArgumentException($"Wrong name format. {value} must" +
                        $" consist of letters only.");
                }

                if (value.Length > MAX_NAME_LEN)
                {
                    throw new ArgumentException($"Wrong name format. {value} is" +
                        $" too long (limit - {MAX_NAME_LEN} symbols).");
                }

                name = value;
            }
        }

        /// <summary>
        /// Gets the balance. Values set only in this or other types
        /// in current assemply (f.e in Bank's operations)
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        /// <exception cref="System.ArgumentException">Negative balance's
        /// value was sent</exception>
        public decimal Balance
        {
            get
            {
                return balance;
            }

            internal set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Value {value} can't be negative" +
                        $" to set the balance");
                }

                balance = value;
            }
        }

        /// <summary>
        /// Gets the type of the card. Values set only in this type
        /// </summary>
        /// <value>
        /// The type of the card.
        /// </value>
        /// <exception cref="System.ArgumentException">There is no such
        /// card's type in the bank</exception>
        public string CardType
        {
            get
            {
                return cardType;
            }

            private set
            {
                CheckIsNullOrEmpty(value, "card type");
                if (!CardTypes.Contains(value.ToLower()))
                {
                    throw new ArgumentException($"Our banks do not provides {value} card's type");
                }

                cardType = value;
            }
        }

        /// <summary>
        /// Gets the bonus points. Values set only in this or other types
        /// in current assemply (f.e in Bank's operations)
        /// </summary>
        /// <value>
        /// The bonus points.
        /// </value>
        public int BonusPoints { get; internal set; }

        /// <summary>
        /// Gets pin in a visibility of an assemply. Sets the pin only in this type
        /// in time of account creating 
        /// </summary>
        /// <value>
        /// The pin.
        /// </value>
        /// <exception cref="System.ArgumentException">Wrong pin format</exception>
        /// <exception cref="System.ArgumentException">Empty pin was sent</exception>
        /// <exception cref="System.ArgumentNullException">Null pin's value was sent</exception>
        internal string Pin
        {
            get
            {
                return pin;
            }

            private set
            {
                CheckIsNullOrEmpty(value, "pin");
                value = value.Trim();

                if (!ValidatePin(value))
                {
                    throw new ArgumentException($"Wrong pin format. {value} must" +
                        $" consist of digits only.");
                }

                if (value.Length != MAX_PIN_LEN)
                {
                    throw new ArgumentException($"Wrong pin format! The pin" +
                        $" must have {MAX_PIN_LEN} digits");
                }

                pin = value;
            }
        }
        #endregion

        #region Public API        
        /// <summary>
        /// Initializes a new instance of the <see cref="CardHolder"/> class.
        /// </summary>
        /// <param name="UserCardType">Type of the user card.</param>
        /// <param name="UserName">Name of the user.</param>
        /// <param name="UserPin">The user pin.</param>
        /// <param name="UserBalance">The user balance.</param>
        public CardHolder(string UserCardType, string UserName, string UserPin,
            decimal UserBalance = 0)
        {
            CardType = UserCardType;
            Name = UserName;
            Pin = UserPin;
            Balance = UserBalance;
            ShowMessage($"Dear, {name}, account has been succesfully created.\n" +
                $"Balance = {Balance}\n");
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
            => $"Account holder: {Name}\nCard type: {CardType}\n" +
               $"Current balance: {Balance} $\nBonusPoints: {BonusPoints}";
        #endregion

        #region Internal API        
        /// <summary>
        /// Checks input value on null or empty.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="subject">The subject.</param>
        /// <exception cref="System.ArgumentNullException">Null subject was sent
        /// </exception>
        /// <exception cref="System.ArgumentException">Empty subject was sent
        /// </exception>
        internal void CheckIsNullOrEmpty(string value, string subject)
        {
            if (value == null)
            {
                throw new ArgumentNullException($"Null {subject} was sent!");
            }

            if (value == string.Empty)
            {
                throw new ArgumentException($"Empty {subject} was sent!");
            }
        }

        /// <summary>
        /// Shows the message. Current realisation allow to show messages
        /// in colsole applications
        /// </summary>
        /// <param name="msg">The message.</param>
        internal void ShowMessage(string msg) => Console.WriteLine(msg);
        #endregion

        #region Private API
        private bool ValidateName(string name)
        {
            for (int i = 0; i < name.Length; i++)
            {
                if (!char.IsLetter(name[i]) &&
                    !char.IsWhiteSpace(name[i]) &&
                    name[i]!='-')
                {
                    return false;
                }
            }

            return true;
        }

        private bool ValidatePin(string pin)
        {
            for (int i = 0; i < pin.Length; i++)
            {
                if (!char.IsDigit(pin[i]))
                {
                    return false;
                }
            }

            return true;
        }
        #endregion
    }
}
