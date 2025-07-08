// <copyright file="MeteoritesLoadResponseModel.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Application.Web.Meteorites.Models.Response
{
    using TestTask.Application.Common;

    /// <summary>
    /// Meteorites load response model.
    /// </summary>
    public class MeteoritesLoadResponseModel : LazyLoadResponseModel<MeteoriteViewModel>, IValidationResult
    {
        /// <inheritdoc />
        public Dictionary<string, string> InvalidFields { get; init; } = new Dictionary<string, string>();
    }
}