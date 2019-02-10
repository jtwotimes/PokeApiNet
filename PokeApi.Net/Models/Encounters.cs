using PokeApi.Net.Directives;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokeApi.Net.Models
{
    [ApiEndpoint("encounter-method")]
    public class EncounterMethod : ICanBeCached
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A good value for sorting.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// The name of this resource listed in different
        /// languages.
        /// </summary>
        public List<Names> Names { get; set; }
    }

    [ApiEndpoint("encounter-condition")]
    public class EncounterCondition : ICanBeCached
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The name of this resource listed in different
        /// languages.
        /// </summary>
        public List<Names> Names { get; set; }

        /// <summary>
        /// A list of possible values for this encounter condition.
        /// </summary>
        public List<NamedApiResource> Values { get; set; }
    }

    [ApiEndpoint("encounter-condition-value")]
    public class EncounterConditionValue : ICanBeCached
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The condition this encounter condition value pertains
        /// to.
        /// </summary>
        public NamedApiResource Condition { get; set; }

        /// <summary>
        /// The name of this resource listed in different
        /// languages.
        /// </summary>
        public List<Names> Names { get; set; }
    }
}
