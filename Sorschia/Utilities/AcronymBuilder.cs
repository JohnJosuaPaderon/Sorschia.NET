using System.Text;

namespace Sorschia.Utilities
{
    public sealed class AcronymBuilder : IAcronymBuilder
    {
        private const char SEPARATOR = ' ';
        private const string DOUBLE_SEPARATOR = "  ";
        
        public string Build(string text)
        {
            if (!string.IsNullOrWhiteSpace(text))
            {
                var builder = new StringBuilder();
                text = RemoveMultipleSeparator(text);
                var splitItems = Split(text);

                if (splitItems.Length > 0)
                {
                    foreach (var item in splitItems)
                    {
                        AppendChar(builder, item);
                    }
                }
                else
                {
                    throw SorschiaException.EmptyCollection(nameof(splitItems));
                }

                return builder.ToString();
            }
            else
            {
                return null;
            }
        }

        private void AppendChar(StringBuilder builder, string text)
        {
            if (!string.IsNullOrWhiteSpace(text) && text.Length > 0)
            {
                var c = text[0];

                if (char.IsLetter(c))
                {
                    builder.Append(c);
                }
            }
        }

        private string RemoveMultipleSeparator(string text)
        {
            while (text.Contains(DOUBLE_SEPARATOR))
            {
                text = text.Replace(DOUBLE_SEPARATOR, string.Empty);
            }

            return text;
        }

        private string[] Split(string text)
        {
            return text.Split(SEPARATOR);
        }
    }
}
