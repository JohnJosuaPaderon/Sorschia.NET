using System.Collections;
using System.Collections.Generic;

namespace Sorschia.Data
{
    public abstract class DbQueryParameterCollectionBase : IDbQueryParameterCollection
    {
        public DbQueryParameterCollectionBase(IDbQueryParameterCollectionValidator validator, IDbQueryParameterCollectionMessageComposer messageComposer)
        {
            _Source = new Dictionary<string, IDbQueryParameter>();
            _Validator = validator;
            _MessageComposer = messageComposer;
        }

        private readonly Dictionary<string, IDbQueryParameter> _Source;
        private readonly IDbQueryParameterCollectionValidator _Validator;
        private readonly IDbQueryParameterCollectionMessageComposer _MessageComposer;

        public IDbQueryParameter this[string parameterName]
        {
            get
            {
                _Validator.ValidateParameterName(parameterName);

                if (_Source.ContainsKey(parameterName))
                {
                    return _Source[parameterName];
                }
                else
                {
                    throw SorschiaException.CollectionItemNotExists(_MessageComposer.ComposeParameterNotFound(parameterName));
                }
            }
        }

        public void Add(IDbQueryParameter parameter)
        {
            _Validator.ValidateParameter(parameter);
            _Validator.ValidateParameterName(parameter.Name);

            if (_Source.ContainsKey(parameter.Name))
            {
                throw SorschiaException.CollectionItemDuplication(_MessageComposer.ComposeParameterNameExists(parameter.Name));
            }
            else
            {
                _Source.Add(parameter.Name, parameter);
            }
        }

        public void Clear()
        {
            _Source.Clear();
        }

        public IEnumerator<IDbQueryParameter> GetEnumerator()
        {
            return _Source.Values.GetEnumerator();
        }

        public void Remove(IDbQueryParameter parameter)
        {
            _Validator.ValidateParameter(parameter);
            Remove(parameter.Name);
        }

        public void Remove(string parameterName)
        {
            _Validator.ValidateParameterName(parameterName);

            if (_Source.ContainsKey(parameterName))
            {
                _Source.Remove(parameterName);
            }
            else
            {
                throw SorschiaException.CollectionItemNotExists(_MessageComposer.ComposeParameterNotFound(parameterName));
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
