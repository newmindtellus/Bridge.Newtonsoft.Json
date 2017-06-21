using System;

namespace Newtonsoft.Json
{
    /// <summary>
    /// Specifies type name handling options for the <see cref="JsonConvert"/>.
    /// </summary>
    [Flags]
    public enum TypeNameHandling
    {
        /// <summary>
        /// Do not include the .NET type name when serializing types.
        /// </summary>
        None = 0,

        /// <summary>
        /// Include the .NET type name when serializing into a JSON object structure.
        /// </summary>
        Objects = 1,
    }
}