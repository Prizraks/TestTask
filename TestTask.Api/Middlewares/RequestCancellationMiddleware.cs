// <copyright file="RequestCancellationMiddleware.cs" company="V.Muryn Company">
// Copyright (c) V.Muryn Company. All rights reserved.
// </copyright>

namespace TestTask.Api.Middlewares
{
    /// <summary>
    /// Request cancellation middleware.
    /// </summary>
    public class RequestCancellationMiddleware
    {
        private readonly int clientClosedRequestHttpCode = 499;

        private readonly RequestDelegate next;
        private readonly ILogger<RequestCancellationMiddleware> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestCancellationMiddleware"/> class.
        /// </summary>
        /// <param name="next">HTTP request handling delegate.</param>
        /// <param name="logger">Logger.</param>
        public RequestCancellationMiddleware(
            RequestDelegate next,
            ILogger<RequestCancellationMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        /// <summary>
        /// Run handle exception.
        /// </summary>
        /// <param name="context">HTTP context.</param>
        /// <returns>Asynchronous task instance.</returns>
        public async Task InvokeAsync(HttpContext context)
        {
            using var cts = CancellationTokenSource.CreateLinkedTokenSource(context.RequestAborted);

            try
            {
                await this.next(context);
            }
            catch (OperationCanceledException) when (context.RequestAborted.IsCancellationRequested)
            {
                this.LogCancellation(context);
                context.Response.StatusCode = this.clientClosedRequestHttpCode;
            }
        }

        private void LogCancellation(HttpContext context)
        {
            var request = context.Request;

            this.logger.LogWarning(
                "Request was cancelled by the client. " +
                "Path: {Path}, Method: {Method}, Client IP: {ClientIp}",
                request.Path,
                request.Method,
                context.Connection.RemoteIpAddress?.ToString());
        }
    }
}