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
                   && x.NameType == y.NameType
                   && x.RecClass == y.RecClass
                   && x.Mass.Equals(y.Mass)
                   && x.Fall == y.Fall
                   && x.Latitude.Equals(y.Latitude)
                   && x.Longitude.Equals(y.Longitude)
                   && x.Year.Equals(y.Year);
        }

        /// <inheritdoc />
        public int GetHashCode(Meteorite obj)
        {
            return obj.Name.GetHashCode()
                ^ obj.NameType.GetHashCode()
                ^ obj.RecClass.GetHashCode()
                ^ obj.Mass.GetHashCode()
                ^ obj.Fall.GetHashCode()
                ^ obj.Latitude.GetHashCode()
                ^ obj.Longitude.GetHashCode()
                ^ obj.Year.GetHashCode();
        }
    }
}