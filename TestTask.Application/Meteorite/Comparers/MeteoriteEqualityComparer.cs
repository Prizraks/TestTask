// <copyright file="MeteoriteEqualityComparer.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Application.Meteorite.Comparers
{
    using System.Collections.Generic;

    using TestTask.Domain.Meteorite;

    /// <summary>
    /// Meteorite equality comparer.
    /// </summary>
    public class MeteoriteEqualityComparer : IEqualityComparer<Meteorite>
    {
        /// <inheritdoc />
        public bool Equals(Meteorite? x, Meteorite? y)
        {
            if (object.ReferenceEquals(x, y))
            {
                return true;
            }

            if (x is null || y is null)
            {
                return false;
            }

            return x.Name == y.Name
                   && x.RecClass == y.RecClass
                   && x.Mass.Equals(y.Mass)
                   && x.Year.Equals(y.Year);
        }

        /// <inheritdoc />
        public int GetHashCode(Meteorite obj)
        {
            return obj.Name.GetHashCode()
                ^ obj.RecClass.GetHashCode()
                ^ obj.Mass.GetHashCode()
                ^ obj.Year.GetHashCode();
        }
    }
}