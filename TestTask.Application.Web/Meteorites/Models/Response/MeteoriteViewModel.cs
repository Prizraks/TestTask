// <copyright file="MeteoriteViewModel.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Application.Web.Meteorites.Models.Response
{
    using TestTask.Application.Meteorite.Models;

    /// <summary>
    /// Meteorite view model.
    /// </summary>
    public class MeteoriteViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MeteoriteViewModel"/> class.
        /// </summary>
        /// <param name="dto">Dto.</param>
        public MeteoriteViewModel(MeteoriteGroupByYearDto dto)
        {
            this.Year = dto.Year;
            this.Count = dto.Count;
            this.MassSum = dto.MassSum;
        }

        /// <summary>
        /// Gets year.
        /// </summary>
        public int Year { get; init; }

        /// <summary>
        /// Gets count.
        /// </summary>
        public int Count { get; init; }

        /// <summary>
        /// Gets mass sum.
        /// </summary>
        public double MassSum { get; init; }
    }
}