using Newtonsoft.Json;
using System.Collections.Generic;

namespace PokeApiNet
{
    /// <summary>
    /// Contest types are categories judges used to weigh
    /// a Pokémon's condition in Pokémon contests.
    /// </summary>
    public class ContestType : NamedApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "contest-type";

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// The berry flavor that correlates with this contest
        /// type.
        /// </summary>
        [JsonProperty("berry_flavor")]
        public NamedApiResource<BerryFlavor> BerryFlavor { get; set; }

        /// <summary>
        /// The name of this contest type listed in different
        /// languages.
        /// </summary>
        public List<ContestName> Names { get; set; }
    }

    /// <summary>
    /// The name of the context
    /// </summary>
    public class ContestName
    {
        /// <summary>
        /// The name for this contest.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The color associated with this contest's name.
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// The language that this name is in.
        /// </summary>
        public NamedApiResource<Language> Language { get; set; }
    }

    /// <summary>
    /// Contest effects refer to the effects of moves
    /// when used in contests.
    /// </summary>
    public class ContestEffect : ApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "contest-effect";

        /// <summary>
        /// The base number of hearts the user of this move
        /// gets.
        /// </summary>
        public int Appeal { get; set; }

        /// <summary>
        /// The base number of hearts the user's opponent
        /// loses.
        /// </summary>
        public int Jam { get; set; }

        /// <summary>
        /// The result of this contest effect listed in
        /// different languages.
        /// </summary>
        [JsonProperty("effect_entries")]
        public List<Effects> EffectEntries { get; set; }

        /// <summary>
        /// The flavor text of this contest effect listed in
        /// different languages.
        /// </summary>
        [JsonProperty("flavor_text_entries")]
        public List<FlavorTexts> FlavorTextEntries { get; set; }
    }

    /// <summary>
    /// Super contest effects refer to the effects of moves
    /// when used in super contests.
    /// </summary>
    public class SuperContestEffect : ApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "super-contest-effect";

        /// <summary>
        /// The level of appeal this super contest effect has.
        /// </summary>
        public int Appeal { get; set; }

        /// <summary>
        /// The flavor text of this super contest effect listed
        /// in different languages.
        /// </summary>
        [JsonProperty("flavor_text_entries")]
        public List<FlavorTexts> FlavorTextEntries { get; set; }

        /// <summary>
        /// A list of moves that have the effect when used in
        /// super contests.
        /// </summary>
        public List<NamedApiResource<Move>> Moves { get; set; }
    }
}
