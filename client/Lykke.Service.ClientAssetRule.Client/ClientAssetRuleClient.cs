﻿using System;
using Common.Log;

namespace Lykke.Service.ClientAssetRule.Client
{
    public class ClientAssetRuleClient : IClientAssetRuleClient, IDisposable
    {
        private readonly ILog _log;

        public ClientAssetRuleClient(string serviceUrl, ILog log)
        {
            _log = log;
        }

        public void Dispose()
        {
            //if (_service == null)
            //    return;
            //_service.Dispose();
            //_service = null;
        }
    }
}
