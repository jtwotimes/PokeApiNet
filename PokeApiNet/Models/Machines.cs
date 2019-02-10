using Newtonsoft.Json;
using PokeApiNet.Directives;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokeApiNet.Models
{
    /// <summary>
    /// Machines are the representation of items that teach moves
    /// to Pokémon. They vary from version to version, so it is
    /// not certain that one specific TM or HM corresponds to a
    /// single Machine.
    /// </summary>
    [ApiEndpoint("machine")]
    public class Machine : ICanBeCached
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The TM or HM item that corresponds to this machine.
        /// </summary>
        public NamedApiResource Item { get; set; }

        /// <summary>
        /// The move that is taught by this machine.
        /// </summary>
        public NamedApiResource Move { get; set; }

        /// <summary>
        /// The version group that this machine applies to.
        /// </summary>
        [JsonProperty("version_group")]
        public NamedApiResource VersionGroup { get; set; }
    }
}
