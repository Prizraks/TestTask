// <copyright file="MeteoriteApiModel.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Application.GitHub.Models
{
    using System;

    /// <summary>
    ///  Meteorite api model.
    /// </summary>
    public class MeteoriteApiModel
    {
        /// <summary>
        /// Gets id.
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// Gets name.
        /// </summary>
        public string Name { get; init; } = string.Empty;

        /// <summary>
        /// Gets name type.
        /// </summary>
        public string NameType { get; init; } = string.Empty;

        /// <summary>
        /// Gets recClass.
        /// </summary>
        public string RecClass { get; init; } = string.Empty;

        /// <summary>
        /// Gets mass.
        /// </summary>
        public double Mass { get; init; }

        /// <summary>
        /// Gets fall.
        /// </summary>
        public string Fall { get; init; } = string.Empty;

        /// <summary>
        /// Gets year.
        /// </summary>
        public DateTime Year { get; init; }

        /// <summary>
        /// Gets reclat.
        /// </summary>
        public double Reclat { get; init; }

        /// <summary>
        /// Gets longitude.
        /// </summary>
        public double Reclong { get; init; }
    }
}