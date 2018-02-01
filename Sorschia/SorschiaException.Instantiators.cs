using System;

namespace Sorschia
{
    partial class SorschiaException
    {
        public static SorschiaException PropertyRequired(string propertyName)
        {
            return new SorschiaException($"Value for '{propertyName}' is required and cannot be set to null or default.", SorschiaExceptionType.PropertyRequired);
        }

        public static SorschiaException ParameterRequired(string parameterName)
        {
            return ParameterRequired(parameterName, string.Empty);
        }

        public static SorschiaException ParameterRequired(string parameterName, string additionalMessage)
        {
            return new SorschiaException($"Value of parameter '{parameterName}' is required and cannot be set to null or default.{(string.IsNullOrWhiteSpace(additionalMessage) ? string.Empty : Environment.NewLine)}{additionalMessage}", SorschiaExceptionType.ParameterRequired);
        }

        public static SorschiaException InvalidConnectionString()
        {
            return new SorschiaException("Connection string is invalid.", SorschiaExceptionType.InvalidConnectionString);
        }

        public static SorschiaException InvalidValue(string variableName, string additionalMessage)
        {
            return new SorschiaException($"Value for variable '{variableName}' is required and cannot be set to null or default.{(string.IsNullOrWhiteSpace(additionalMessage) ? string.Empty : Environment.NewLine)}{additionalMessage}", SorschiaExceptionType.InvalidValue);
        }

        public static SorschiaException ValidationFailed(string message)
        {
            return new SorschiaException(message, SorschiaExceptionType.ValidationFailed);
        }

        public static SorschiaException EmptyCollection(string collectionName)
        {
            return EmptyCollection(collectionName, string.Empty);
        }

        public static SorschiaException EmptyCollection(string collectionName, string additionalMessage)
        {
            return new SorschiaException($"The collection '{collectionName}' is empty.{(string.IsNullOrWhiteSpace(additionalMessage) ? string.Empty : Environment.NewLine)}{additionalMessage}", SorschiaExceptionType.EmptyCollection);
        }

        public static SorschiaException ParseError(string message)
        {
            return new SorschiaException(message, SorschiaExceptionType.ParseError);
        }

        public static SorschiaException ParseError(Exception inner)
        {
            return new SorschiaException("Failed to parse.", inner, SorschiaExceptionType.ParseError);
        }

        public static SorschiaException InvalidOperation(string message)
        {
            return new SorschiaException(message, SorschiaExceptionType.InvalidOperation);
        }

        public static SorschiaException CollectionItemDuplication(string message)
        {
            return new SorschiaException(message, SorschiaExceptionType.CollectionItemDuplication);
        }

        public static SorschiaException CollectionItemNotExists(string message)
        {
            return new SorschiaException(message, SorschiaExceptionType.CollectionItemNotExists);
        }

        public static SorschiaException FileNotFound(string filePath)
        {
            return new SorschiaException($"The file '{filePath}' doesn't exists.", SorschiaExceptionType.FileNotFound);
        }

        public static SorschiaException AppFailure(string message)
        {
            return new SorschiaException(message, SorschiaExceptionType.AppFailure);
        }

        public static SorschiaException FieldRequired(string fieldName)
        {
            return new SorschiaException($"Value for the field '{fieldName}' is required and cannot be set to it's default value.", SorschiaExceptionType.FieldRequired);
        }
    }
}
