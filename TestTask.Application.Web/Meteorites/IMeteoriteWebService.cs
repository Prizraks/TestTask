// <copyright file="IMeteoriteWebService.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Application.Web.Meteorites
{
    using System.Threading.Tasks;

    using TestTask.Application.Meteorite.Models;
    using TestTask.Application.Web.Meteorites.Models.Requests;
    using TestTask.Application.Web.Meteorites.Models.Response;

    /// <summary>
    /// Interface meteorite web service.
    /// </summary>
    public interface IMeteoriteWebService
    {
        /// <summary>
        /// Lazy load.
        /// </summary>
        /// <param name="requestModel">Request model.</param>
        /// <param name="token">Operation cancellation token.</param>
        /// <returns>Asynchronous task instance.</returns>
        Task<MeteoritesLoadResponseModel> LazyLoadAsync(MeteoritesLoadRequestModel requestModel, CancellationToken token);

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