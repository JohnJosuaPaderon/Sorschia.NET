﻿using Newtonsoft.Json.Linq;
using Sorschia.Extensions;
using System;
using System.Collections.Generic;
using System.IO;

namespace Sorschia.Configurations
{
    public sealed class JsonConnectionStringSource : ConnectionStringSource, IConnectionStringSource
    {
        public JsonConnectionStringSource(JsonConnectionStringSourceProvider provider)
        {
            _Provider = provider;
        }

        private readonly JsonConnectionStringSourceProvider _Provider;
        private const string CONNECTION_STRINGS = "connectionStrings";
        private const string CONNECTION_STRING_KEY = "key";

        protected override void Initialize()
        {
            var getData = SelectDataGetter();

            if (getData == null)
            {
                throw new SorschiaException(SorschiaExceptionType.UnknownOperation);
            }
            else
            {
                Initialize(getData());
            }
        }

        private Func<IDictionary<string, string>> SelectDataGetter()
        {
            switch (_Provider.Mode)
            {
                case JsonConnectionStringSourceMode.DirectObject: return GetFromDirectObject;
                case JsonConnectionStringSourceMode.FromFile: return GetFromFile;
                default:
                    throw new SorschiaException($"The selected mode of getting connection string is currently not supported.{Environment.NewLine}Mode: {_Provider.Mode}", SorschiaExceptionType.FeatureNotSupported);
            }
        }

        private IDictionary<string, string> GetFromJObject(JObject source)
        {
            if (source == null)
            {
                throw new SorschiaException("JSON connection string source.", SorschiaExceptionType.UnexpectedNull);
            }
            else
            {
                if (source[CONNECTION_STRINGS] is JArray connectionStrings)
                {
                    return Extract(connectionStrings);
                }
                else
                {
                    throw new SorschiaException(CONNECTION_STRINGS, SorschiaExceptionType.ValueRequired);
                }
            }
        }

        private static IDictionary<string, string> Extract(JArray connectionStrings)
        {
            var result = new Dictionary<string, string>();

            foreach (var jToken in connectionStrings)
            {
                if (jToken is JObject connectionString)
                {
                    var key = connectionString.GetString(CONNECTION_STRING_KEY);
                }
            }

            return result;
        }

        private IDictionary<string, string> GetFromDirectObject()
        {
            return GetFromJObject(_Provider.Source);
        }

        private IDictionary<string, string> GetFromFile()
        {
            if (File.Exists(_Provider.FilePath))
            {
                try
                {
                    var jObject = JObject.Parse(File.ReadAllText(_Provider.FilePath));

                    if (jObject != null)
                    {
                        return GetFromJObject(jObject);
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }
    }
}