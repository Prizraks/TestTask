// <copyright file="MeteoriteController.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Api.Controllers
{
    using System.Net;

    using Microsoft.AspNetCore.Mvc;

    using TestTask.Application.Web.Meteorites;
    using TestTask.Application.Web.Meteorites.Models.Requests;
    using TestTask.Application.Web.Meteorites.Models.Response;

    /// <summary>
    /// Meteorite controller.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="MeteoriteController"/> class.
    /// </remarks>
    /// <param name="meteoriteWebService">Meteorite web service.</param>
    [ApiController]
    [Route("[controller]")]
    public class MeteoriteController(IMeteoriteWebService meteoriteWebService) : ControllerBase
    {
        private readonly IMeteoriteWebService meteoriteWebService = meteoriteWebService;

        /// <summary>
        /// Gets meteorites.
        /// </summary>
        /// <param name="requestModel">Request model.</param>
        /// <param name="token">Operation cancellation token.</param>
        /// <returns>Meteorites.</returns>
        [HttpGet("get-meteorites")]
        [ProducesResponseType(typeof(MeteoritesLoadResponseModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetMeteoritesAsync([FromQuery] MeteoritesLoadRequestModel requestModel, CancellationToken token)
            => new JsonResult(await this.meteoriteWebService.LazyLoadAsync(requestModel, token));

        /// <summary>
        /// Get all classes.
        /// </summary>
        /// <param name="token">Operation cancellation token.</param>
        /// <returns>Asynchronous task instance, what return classes.</returns>
        [HttpGet("get-all-classes")]
        [ProducesResponseType(typeof(IEnumerable<string>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetAllClasses(CancellationToken token)
            => new JsonResult(await this.meteoriteWebService.GetAllClasses(token));

        /// <summary>
        /// Get years.
        /// </summary>
        /// <param name="token">Operation cancellation token.</param>
        /// <returns>Asynchronous task instance, what return years.</returns>
        [HttpGet("get-years")]
        [ProducesResponseType(typeof(IEnumerable<int>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetMinAndMaxYears(CancellationToken token)
            => new JsonResult(await this.meteoriteWebService.GetYears(token));
    }
}