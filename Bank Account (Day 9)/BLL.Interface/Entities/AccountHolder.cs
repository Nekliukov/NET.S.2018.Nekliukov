using System;

namespace BLL.Interface.Entities
{
    public class AccountHolder
    {
        #region Constants        

        /// <summary>
        /// The maximum name or surname length
        /// </summary>
        private const int MAX_NAME_LEN = 30;

        #endregion

        #region Private fields

        private string firstName;
        private string secondName;
        private string email;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountHolder"/> class.
        /// </summary>
        /// <param name="holderName">Name of the holder.</param>
        /// <param name="holderSurname">The holder surname.</param>
        /// <param name="holderEmail">The holder email.</param>
        public AccountHolder(string holderName, string holderSurname, string holderEmail)
        {
            FirstName = holderName;
            SecondName = holderSurname;
            Email = holderEmail;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the first name. Values setted only in this type
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        /// <exception cref="System.ArgumentException">Wrong name format</exception>
        /// <exception cref="System.ArgumentException">Not starts from uppercase</exception>
        /// <exception cref="System.ArgumentException">Empty value was sent</exception>
        /// <exception cref="System.ArgumentNullException">Null value was sent</exception>
        public string FirstName
        {
            get => firstName;
            private set
            {
                CheckIsNullOrEmpty(value);
                value = value.Trim();
                ValidateNamePart(value);
                firstName = value;
            }
        }

        /// <summary>
        /// Gets the second name. Values setted only in this type
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        /// <exception cref="System.ArgumentException">Wrong second name format</exception>
        /// <exception cref="System.ArgumentException">Not starts from uppercase</exception>
        /// <exception cref="System.ArgumentException">Empty value was sent</exception>
        /// <exception cref="System.ArgumentNullException">Null value was sent</exception>
        public string SecondName
        {
            get => secondName;
            private set
            {
                CheckIsNullOrEmpty(value);
                value = value.Trim();
                ValidateNamePart(value);
                secondName = value;
            }
        }

        /// <summary>
        /// Gets the email. Values setted only in this type
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        /// <exception cref="System.ArgumentException">Wrong format</exception>
        /// <exception cref="System.ArgumentException">Empty value was sent</exception>
        /// <exception cref="System.ArgumentNullException">Null value was sent</exception>
        public string Email
        {
            get => email;
            private set
            {
                CheckIsNullOrEmpty(value);
                value = value.Trim();
                ValidateEmail(value);
                email = value;
            }
        }

        #endregion

        #region Private Validation

        private void CheckIsNullOrEmpty(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException($"Null {nameof(value)} was sent!");
            }

            if (value == string.Empty)
            {
                throw new ArgumentException($"Empty {nameof(value)} was sent!");
            }
        }

        private void ValidateNamePart(string name)
        {
            if (name.Length > MAX_NAME_LEN)
            {
                throw new ArgumentException($"Wrong name format. {name} is" +
                    $" too long (limit - {MAX_NAME_LEN} symbols).");
            }

            if (char.IsLower(name[0]))
            {
                throw new ArgumentException($"Name {name} must starts from the " +
                    $"uppercase letter");
            }

            for (int i = 0; i < name.Length; i++)
            {
                if (!char.IsLetter(name[i]) && name[i] != '-')
                {
                    throw new ArgumentException($"Wrong name format. {name} must" +
                        $" consist of letters only.");
                }
            }
        }

        private void ValidateEmail(string value)
        {
            try
            {
                System.Net.Mail.MailAddress ma = new System.Net.Mail.MailAddress(value);
            }
            catch (FormatException)
            {
                throw new ArgumentException($"Wrong email {value} format!");
            }
        }
        #endregion
    }
}
