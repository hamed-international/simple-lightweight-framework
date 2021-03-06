﻿using Domain.Model._App;
using Domain.Model.Collections;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Application.Services
{
    public class HttpLogService : IHttpLogService
    {
        #region Constructor
        private readonly MongoDBContext _mongoDBContext;
        private readonly IExceptionService _exceptionService;

        public HttpLogService(MongoDBContext mongoDBContext, IExceptionService exceptionService)
        {
            _mongoDBContext = mongoDBContext;
            _exceptionService = exceptionService;
        }
        #endregion

        public async Task<int> InsertAsync(HttpLog model, int timeoutMS)
        {
            var startTime = DateTime.UtcNow;
            try
            {
                using (var timeoutCancellationTokenSource = new CancellationTokenSource(TimeSpan.FromMilliseconds(timeoutMS)))
                {
                    await _mongoDBContext.HttpLogs.InsertOneAsync(model, cancellationToken: timeoutCancellationTokenSource.Token);
                }
                return 1;
            }
            catch (OperationCanceledException ex)
            {
                await _exceptionService.InsertAsync(ex, "Domain.Application.ServicesHttpLogService.Insert", "");
                var elapsed = DateTime.UtcNow - startTime;
                return 0;
            }
        }
    }
}
