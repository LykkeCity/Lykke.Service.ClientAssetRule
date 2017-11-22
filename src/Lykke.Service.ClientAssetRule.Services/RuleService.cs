﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lykke.Service.ClientAssetRule.Core.Domain;
using Lykke.Service.ClientAssetRule.Core.Repositories;
using Lykke.Service.ClientAssetRule.Core.Services;

namespace Lykke.Service.ClientAssetRule.Services
{
    public class RuleService : IRuleService
    {
        private readonly IRuleRepository _ruleRepository;

        public RuleService(IRuleRepository ruleRepository)
        {
            _ruleRepository = ruleRepository;
        }

        public Task<IEnumerable<IRule>> GetAllAsync()
        {
            return _ruleRepository.GetAllAsync();
        }

        public async Task<IAssetGroups> GetAssetGroupsAsync(IEnumerable<IClientRegulation> clientRegulations)
        {
            var allowed = new List<string>();
            var declined = new List<string>();

            foreach (IClientRegulation clientRegulation in clientRegulations)
            {
                IEnumerable<IRule> rules = await _ruleRepository.GetByRegulationIdAsync(clientRegulation.RegulationId);

                foreach (IRule rule in rules)
                {
                    allowed.AddRange(rule.AllowedAssetGroups);
                    declined.AddRange(rule.DeclinedAssetGroups);
                }
            }

            declined = declined.Distinct()
                .ToList();

            allowed = allowed.Distinct()
                .Except(declined)
                .ToList();

            return new AssetGroups
            {
                Allowed = allowed,
                Declined = declined
            };
        }

        public  Task<IRule> GetByIdAsync(string id)
        {
            return _ruleRepository.GetByIdAsync(id);
        }

        public async Task InsertAsync(IRule rule)
        {
            IEnumerable<IRule> rules = await _ruleRepository.GetByRegulationIdAsync(rule.RegulationId);

            if(rules.Any())
                throw new InvalidOperationException("Rule for specified regulation already exist");

            await _ruleRepository.InsertAsync(rule);
        }

        public Task UpdateAsync(IRule rule)
        {
            return _ruleRepository.UpdateAsync(rule);
        }

        public Task DeleteAsync(string id)
        {
            return _ruleRepository.DeleteAsync(id);
        }
    }
}
