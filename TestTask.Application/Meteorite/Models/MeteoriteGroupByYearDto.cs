// <copyright file="MeteoriteGroupByYearDto.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Application.Meteorite.Models
{
    /// <summary>
    /// Meteorite Dto.
    /// </summary>
    public class MeteoriteGroupByYearDto
    {
        /// <summary>
        /// Gets mass sum.
        /// </summary>
        public double MassSum { get; init; }

        /// <summary>
        /// Gets count.
        /// </summary>
        public int Count { get; init; }

        /// <summary>
        /// Gets year.
        /// </summary>
        public int Year { get; init; }
    }
}