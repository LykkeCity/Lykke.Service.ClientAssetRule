﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lykke.Service.ClientAssetRule.Client.AutorestClient;
using Lykke.Service.ClientAssetRule.Client.AutorestClient.Models;
using Lykke.Service.ClientAssetRule.Client.Exceptions;
using RuleModel = Lykke.Service.ClientAssetRule.Client.Models.RuleModel;
using AssetConditionLayerRuleModel = Lykke.Service.ClientAssetRule.Client.Models.AssetConditionLayerRuleModel;

namespace Lykke.Service.ClientAssetRule.Client
{
    /// <summary>
    /// Contains methods for work with Lykke.Service.ClientAssetRule API.
    /// </summary>
    public class ClientAssetRuleClient : IClientAssetRuleClient, IDisposable
    {
        private ClientAssetRuleAPI _service;

        /// <summary>
        /// Initializes a new instance of <see cref="ClientAssetRuleClient"/>.
        /// </summary>
        /// <param name="serviceUrl">The client assest rules service URL.</param>
        public ClientAssetRuleClient(string serviceUrl)
        {
            _service = new ClientAssetRuleAPI(new Uri(serviceUrl));
        }

        /// <summary>
        /// Returns all rules.
        /// </summary>
        /// <returns>The list of rules.</returns>
        public async Task<IEnumerable<RuleModel>> GetRulesAsync()
        {
            IEnumerable<AutorestClient.Models.AssetGroupRuleModel> rules =
                await _service.AssetGroupRuleGetAsync();

            return rules.Select(AutorestClientMapper.ToModel);
        }

        /// <summary>
        /// Returns rule details by specified id.
        /// </summary>
        /// <param name="ruleId">The rule id.</param>
        /// <returns></returns>
        /// <exception cref="ErrorResponseException">Thrown if an error response received from service.</exception>
        public async Task<RuleModel> GetRuleByIdAsync(string ruleId)
        {
            object result = await _service.AssetGroupRuleGetByIdAsync(ruleId);

            if (result is AutorestClient.Models.AssetGroupRuleModel ruleModel)
                return ruleModel.ToModel();

            if (result is ErrorResponse errorResponse)
                throw new ErrorResponseException(errorResponse.ErrorMessage);

            throw new InvalidOperationException($"Unexpected response type: {result?.GetType()}");
        }

        /// <summary>
        /// Adds the rule.
        /// </summary>
        /// <param name="model">The model what describe a rule.</param>
        /// <exception cref="ErrorResponseException">Thrown if an error response received from service.</exception>
        public async Task AddRuleAsync(RuleModel model)
        {
            ErrorResponse errorResponse = await _service.AssetGroupRuleAddAsync(new NewAssetGroupRuleModel
            {
                Name = model.Name,
                RegulationId = model.RegulationId,
                AllowedAssetGroups = model.AllowedAssetGroups,
                DeclinedAssetGroups = model.DeclinedAssetGroups
            });

            if(errorResponse != null)
                throw new ErrorResponseException(errorResponse.ErrorMessage);
        }

        /// <summary>
        /// Updates the rule.
        /// </summary>
        /// <param name="model">The model what describe a rule.</param>
        /// <exception cref="ErrorResponseException">Thrown if an error response received from service.</exception>
        public async Task UpdateRuleAsync(RuleModel model)
        {
            ErrorResponse errorResponse = await _service.AssetGroupRuleUpdateAsync(new AutorestClient.Models.AssetGroupRuleModel
            {
                Id = model.Id,
                Name = model.Name,
                RegulationId = model.RegulationId,
                AllowedAssetGroups = model.AllowedAssetGroups,
                DeclinedAssetGroups = model.DeclinedAssetGroups
            });

            if (errorResponse != null)
                throw new ErrorResponseException(errorResponse.ErrorMessage);
        }

        /// <summary>
        /// Deletes the rule by specified id.
        /// </summary>
        /// <exception cref="ErrorResponseException">Thrown if an error response received from service.</exception>
        public async Task DeleteRuleAsync(string ruleId)
        {
            ErrorResponse errorResponse = await _service.AssetGroupRuleDeleteAsync(ruleId);

            if (errorResponse != null)
                throw new ErrorResponseException(errorResponse.ErrorMessage);
        }

        /// <summary>
        /// Returns all asset condition layer rules.
        /// </summary>
        /// <returns>The list of asset condition layer rules.</returns>
        public async Task<IEnumerable<AssetConditionLayerRuleModel>> GetAssetConditionLayerRulesAsync()
        {
            IEnumerable<AutorestClient.Models.AssetConditionLayerRuleModel> rules =
                await _service.AssetConditionLayerRuleGetAsync();

            return rules.Select(AutorestClientMapper.ToModel);
        }

        /// <summary>
        /// Adds the asset condition layer rule.
        /// </summary>
        /// <param name="model">The model that describe an asset condition layer rule.</param>
        /// <exception cref="ErrorResponseException">Thrown if an error response received from service.</exception>
        public async Task AddAssetConditionLayerRuleAsync(AssetConditionLayerRuleModel model)
        {
            ErrorResponse errorResponse = await _service.AssetConditionLayerRuleAddAsync(new AutorestClient.Models.AssetConditionLayerRuleModel
            {
                Name = model.Name,
                RegulationId = model.RegulationId,
                Layers = model.Layers
            });

            if (errorResponse != null)
                throw new ErrorResponseException(errorResponse.ErrorMessage);
        }

        /// <summary>
        /// Updates the asset condition layer rule.
        /// </summary>
        /// <param name="model">The model that describe an asset condition layer rule.</param>
        /// <exception cref="ErrorResponseException">Thrown if an error response received from service.</exception>
        public async Task UpdateAssetConditionLayerRuleAsync(AssetConditionLayerRuleModel model)
        {
            ErrorResponse errorResponse = await _service.AssetConditionLayerRuleUpdateAsync(new AutorestClient.Models.AssetConditionLayerRuleModel
            {
                Name = model.Name,
                RegulationId = model.RegulationId,
                Layers = model.Layers
            });

            if (errorResponse != null)
                throw new ErrorResponseException(errorResponse.ErrorMessage);
        }

        /// <summary>
        /// Deletes the asset condition layer rule for regulation.
        /// </summary>
        /// <param name="regulationId">The regulation.</param>
        /// <exception cref="ErrorResponseException">Thrown if an error response received from service.</exception>
        public async Task DeleteAssetConditionLayerRuleAsync(string regulationId)
        {
            ErrorResponse errorResponse = await _service.AssetConditionLayerRuleDeleteAsync(regulationId);

            if (errorResponse != null)
                throw new ErrorResponseException(errorResponse.ErrorMessage);
        }

        public void Dispose()
        {
            if (_service == null)
                return;

            _service.Dispose();
            _service = null;
        }
    }
}
