// <copyright file="Meteorite.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Domain.Meteorite
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Meteorite.
    /// </summary>
    public class Meteorite : RootEntity<int>
    {
        /// <summary>
        /// Gets name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets name type.
        /// </summary>
        public NameType NameType { get; private set; }

        /// <summary>
        /// Gets class.
        /// </summary>
        public string Class { get; private set; }

        /// <summary>
        /// Gets mass.
        /// </summary>
        public double Mass { get; private set; }
    }
}
