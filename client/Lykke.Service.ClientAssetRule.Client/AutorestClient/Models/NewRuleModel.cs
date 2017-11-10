// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Lykke.Service.ClientAssetRule.Client.AutorestClient.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public partial class NewRuleModel
    {
        /// <summary>
        /// Initializes a new instance of the NewRuleModel class.
        /// </summary>
        public NewRuleModel()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the NewRuleModel class.
        /// </summary>
        public NewRuleModel(string name = default(string), string regulationId = default(string), IList<string> allowedAssetGroups = default(IList<string>), IList<string> declinedAssetGroups = default(IList<string>))
        {
            Name = name;
            RegulationId = regulationId;
            AllowedAssetGroups = allowedAssetGroups;
            DeclinedAssetGroups = declinedAssetGroups;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "RegulationId")]
        public string RegulationId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "AllowedAssetGroups")]
        public IList<string> AllowedAssetGroups { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "DeclinedAssetGroups")]
        public IList<string> DeclinedAssetGroups { get; set; }

    }
}