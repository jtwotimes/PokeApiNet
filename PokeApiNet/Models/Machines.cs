using Newtonsoft.Json;

namespace PokeApiNet
{
    /// <summary>
    /// Machines are the representation of items that teach moves
    /// to Pokémon. They vary from version to version, so it is
    /// not certain that one specific TM or HM corresponds to a
    /// single Machine.
    /// </summary>
    public class Machine : ApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "machine";

        /// <summary>
        /// The TM or HM item that corresponds to this machine.
        /// </summary>
        public NamedApiResource<Item> Item { get; set; }

        /// <summary>
        /// The move that is taught by this machine.
        /// </summary>
        public NamedApiResource<Move> Move { get; set; }

        /// <summary>
        /// The version group that this machine applies to.
        /// </summary>
        [JsonProperty("version_group")]
        public NamedApiResource<VersionGroup> VersionGroup { get; set; }
    }
}
