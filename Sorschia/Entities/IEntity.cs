﻿namespace Sorschia.Entities
{
    public interface IEntity<TIdentifier>
    {
        TIdentifier Id { get; }
    }
}