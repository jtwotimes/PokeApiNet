using PokeApiNet.Directives;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokeApiNet.Models
{
    /// <summary>
    /// Methods by which the player might can encounter Pokémon
    /// in the wild, e.g., walking in tall grass.
    /// </summary>
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

    /// <summary>
    /// Conditions which affect what pokemon might appear in the
    /// wild, e.g., day or night.
    /// </summary>
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

    /// <summary>
    /// Encounter condition values are the various states that an encounter
    /// condition can have, i.e., time of day can be either day or night.
    /// </summary>
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
