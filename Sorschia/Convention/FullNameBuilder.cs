using System.Text;

namespace Sorschia.Convention
{
    public sealed class FullNameBuilder : IFullNameBuilder
    {
        private const char SPACE = ' ';
        private const string COMMA_SPACE = ", ";
        
        public string Build(string lastName, string firstName, string nameExtension, string middleName)
        {
            var hasFirstName = !string.IsNullOrWhiteSpace(firstName);
            var hasMiddleName = !string.IsNullOrWhiteSpace(middleName);
            var hasLastName = !string.IsNullOrWhiteSpace(lastName);
            var hasNameExtension = !string.IsNullOrWhiteSpace(nameExtension);

            if (hasFirstName || hasMiddleName || hasLastName || hasNameExtension)
            {
                var builder = new StringBuilder();

                TryAppendLastName(lastName, hasLastName, hasFirstName, hasNameExtension, hasMiddleName, builder);
                TryAppendFirstName(firstName, hasFirstName, hasNameExtension, hasMiddleName, builder);
                TryAppendNameExtension(nameExtension, hasNameExtension, hasMiddleName, builder);
                TryAppendMiddleName(middleName, hasMiddleName, builder);

                return builder.ToString();
            }
            else
            {
                return null;
            }
        }

        private void TryAppendLastName(string lastName, bool hasLastName, bool hasFirstName, bool hasNameExtension, bool hasMiddleName, StringBuilder builder)
        {
            if (hasLastName)
            {
                builder.Append(lastName.Trim());

                if (hasFirstName || hasMiddleName || hasNameExtension)
                {
                    builder.Append(COMMA_SPACE);
                }
            }
        }

        private void TryAppendFirstName(string firstName, bool hasFirstName, bool hasNameExtension, bool hasMiddleName, StringBuilder builder)
        {
            if (hasFirstName)
            {
                builder.Append(firstName.Trim());

                if (hasMiddleName || hasNameExtension)
                {
                    builder.Append(SPACE);
                }
            }
        }

        private void TryAppendNameExtension(string nameExtension, bool hasNameExtension, bool hasMiddleName, StringBuilder builder)
        {
            if (hasNameExtension)
            {
                builder.Append(nameExtension.Trim());

                if (hasMiddleName)
                {
                    builder.Append(SPACE);
                }
            }
        }

        private void TryAppendMiddleName(string middleName, bool hasMiddleName, StringBuilder builder)
        {
            if (hasMiddleName)
            {
                builder.Append(middleName.Trim());
            }
        }
    }
}
