using System.Text;

namespace Sorschia.Convention
{
    public sealed class InformalFullNameBuilder : IInformalFullNameBuilder
    {
        private const char SPACE = ' ';
        
        public string Build(string firstName, string middleInitials, string lastName, string nameExtension)
        {
            var hasFirstName = !string.IsNullOrWhiteSpace(firstName);
            var hasMiddleInitials = !string.IsNullOrWhiteSpace(middleInitials);
            var hasLastName = !string.IsNullOrWhiteSpace(lastName);
            var hasNameExtension = !string.IsNullOrWhiteSpace(nameExtension);

            if (hasFirstName || hasMiddleInitials || hasLastName || hasNameExtension)
            {
                var builder = new StringBuilder();

                TryAppendFirstName(firstName, hasFirstName, hasMiddleInitials, hasLastName, hasNameExtension, builder);
                TryAppendMiddleInitials(middleInitials, hasMiddleInitials, hasLastName, hasNameExtension, builder);
                TryAppendLastName(lastName, hasLastName, hasNameExtension, builder);
                TryAppendNameExtension(nameExtension, hasNameExtension, builder);

                return builder.ToString();
            }
            else
            {
                return null;
            }
        }

        private void TryAppendFirstName(string firstName, bool hasFirstName, bool hasMiddleInitials, bool hasLastName, bool hasNameExtension, StringBuilder builder)
        {
            if (hasFirstName)
            {
                builder.Append(firstName.Trim());

                if (hasMiddleInitials || hasLastName || hasNameExtension)
                {
                    builder.Append(SPACE);
                }
            }
        }

        private void TryAppendMiddleInitials(string middleInitials, bool hasMiddleInitials, bool hasLastName, bool hasNameExtension, StringBuilder builder)
        {
            if (hasMiddleInitials)
            {
                builder.Append(middleInitials.Trim());

                if (hasLastName || hasNameExtension)
                {
                    builder.Append(SPACE);
                }
            }
        }

        private void TryAppendLastName(string lastName, bool hasLastName, bool hasNameExtension, StringBuilder builder)
        {
            if (hasLastName)
            {
                builder.Append(lastName.Trim());

                if (hasNameExtension)
                {
                    builder.Append(SPACE);
                }
            }
        }

        private void TryAppendNameExtension(string nameExtension, bool hasNameExtension, StringBuilder builder)
        {
            if (hasNameExtension)
            {
                builder.Append(nameExtension.Trim());
            }
        }
    }
}
