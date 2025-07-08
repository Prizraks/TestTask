// <copyright file="MeteoriteWebService.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Application.Web.Meteorites
{
    using System.Threading;
    using System.Threading.Tasks;

    using TestTask.Application.Meteorite;
    using TestTask.Application.Meteorite.Models;
    using TestTask.Application.Web.Meteorites.Models.Requests;
    using TestTask.Application.Web.Meteorites.Models.Response;

    /// <summary>
    /// Meteorite web service.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="MeteoriteWebService"/> class.
    /// </remarks>
    /// <param name="meteoriteReadOnlyRepository">Meteorite repository for read only.</param>
    /// <param name="cacheManager">Cache manager.</param>
    internal class MeteoriteWebService(
        IMeteoriteReadOnlyRepository meteoriteReadOnlyRepository,
        ICacheManager cacheManager) : IMeteoriteWebService
    {
        private readonly IMeteoriteReadOnlyRepository meteoriteReadOnlyRepository = meteoriteReadOnlyRepository;
        private readonly ICacheManager cacheManager = cacheManager;

        /// <inheritdoc />
        public async Task<MeteoritesLoadResponseModel> LazyLoadAsync(MeteoritesLoadRequestModel requestModel, CancellationToken token)
        {
            _ = requestModel ?? throw new ArgumentNullException(nameof(requestModel));

            requestModel.Validation();
            if (!requestModel.IsValid)
            {
                return new MeteoritesLoadResponseModel
                {
                    InvalidFields = requestModel.Errors,
                };
            }

            return await this.cacheManager.GetOrSetAsync(
                key: requestModel.GetKey(),
                fetchFunction: async () =>
                    {
                        var meteoriteParams = new MeteoriteParamsDto
                        {
                            YearFrom = requestModel.YearFrom,
                            YearTo = requestModel.YearTo,
                            Name = requestModel.Name,
                            RecClass = requestModel.RecClass,
                            SortField = requestModel.SortField,
                            SortOrder = requestModel.SortOrder,
                            PageNumber = requestModel.PageNumber,
                            PageSize = requestModel.PageSize,
                        };
                        var (records, totalRecords) = await this.meteoriteReadOnlyRepository.LazyLoadAsync(meteoriteParams, token);

                        return new MeteoritesLoadResponseModel
                        {
                            Data = records.Select(x => new MeteoriteViewModel(x)),
                            TotalRecords = totalRecords,
                        };
                    },
                cacheDuration: TimeSpan.FromMinutes(20));
        }
    }
}