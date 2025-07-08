// <copyright file="MeteoriteReadOnlyRepository.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Infrastructure.Data.Repositories.Meteorite
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using TestTask.Application.Common;
    using TestTask.Application.Meteorite;
    using TestTask.Application.Meteorite.Models;

    /// <summary>
    /// Meteorite repository for read only.
    /// </summary>
    internal class MeteoriteReadOnlyRepository : IMeteoriteReadOnlyRepository
    {
        private readonly IApplicationContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="MeteoriteReadOnlyRepository"/> class.
        /// </summary>
        /// <param name="context">Application context.</param>
        public MeteoriteReadOnlyRepository(IApplicationContext context)
        {
            this.context = context;
        }

        /// <inheritdoc />
        public async Task<(IReadOnlyCollection<MeteoriteGroupByYearDto> Records, int TotalRecords)> LazyLoadAsync(MeteoriteParamsDto requestModel, CancellationToken token)
        {
            var query = this.context.Meteorites
                .AsNoTracking()

                .Where(x =>
                    (!requestModel.YearFrom.HasValue || requestModel.YearFrom <= default(int) || x.Year >= requestModel.YearFrom)
                    && (!requestModel.YearTo.HasValue || requestModel.YearTo <= default(int) || x.Year <= requestModel.YearTo)
                    && (string.IsNullOrWhiteSpace(requestModel.Name) || EF.Functions.Like(x.Name, $"%{requestModel.Name}%"))
                    && (string.IsNullOrWhiteSpace(requestModel.RecClass) || x.RecClass == requestModel.RecClass))

                .GroupBy(x => x.Year)

                .Select(x => new MeteoriteGroupByYearDto { Year = x.Key, Count = x.Count(), Mass = x.Sum(s => s.Mass) });

            if (!string.IsNullOrWhiteSpace(requestModel.SortField) && requestModel.SortOrder.HasValue)
            {
                query = requestModel.SortOrder == SortOrderType.OrderByAsk
                    ? query.OrderBy(x => $"x.{requestModel.SortField}")
                    : query.OrderByDescending(x => $"x.{requestModel.SortField}");
            }

            var totalRecords = await query.CountAsync(token);

            var records = (await query
                .Skip(requestModel.PageNumber)
                .Take(requestModel.PageSize)
                .ToListAsync(token))
                .AsReadOnly();

            return (Records: records, TotalRecords: totalRecords);
        }
    }
}