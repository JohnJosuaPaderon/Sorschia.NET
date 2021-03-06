﻿using System.IO;

namespace Sorschia.Utilities
{
    public static class DirectoryResolver
    {
        public static void ResolveExistence(string directory)
        {
            if (string.IsNullOrWhiteSpace(directory))
            {
                throw SorschiaException.ParameterRequired(nameof(directory));
            }
            Directory.CreateDirectory(directory);
        }
    }
}
