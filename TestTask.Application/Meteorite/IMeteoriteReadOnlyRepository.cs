// <copyright file="IMeteoriteReadOnlyRepository.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Application.Meteorite
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using TestTask.Application.Meteorite.Models;

    /// <summary>
    /// Interface meteorite repository for read only.
    /// </summary>
    public interface IMeteoriteReadOnlyRepository
    {
        /// <summary>
        /// Lazy load.
        /// </summary>
        /// <param name="requestModel">Request model.</param>
        /// <param name="token">Operation cancellation token.</param>
        /// <returns>Asynchronous task instance.</returns>
        Task<(IReadOnlyCollection<MeteoriteGroupByYearDto> Records, int TotalRecords)> LazyLoadAsync(MeteoriteParamsDto requestModel, CancellationToken token);

        /// <summary>
        /// Get all classes.
        /// </summary>
        /// <param name="token">Operation cancellation token.</param>
        /// <returns>Asynchronous task instance, what return classes.</returns>
        Task<IEnumerable<string>> GetAllClasses(CancellationToken token);

        /// <summary>
        /// Get years.
        /// </summary>
        /// <param name="token">Operation cancellation token.</param>
        /// <returns>Asynchronous task instance, what return years.</returns>
        Task<IEnumerable<int>> GetYears(CancellationToken token);
    }
}