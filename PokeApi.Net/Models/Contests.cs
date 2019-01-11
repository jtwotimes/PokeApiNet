using System;
using System.Collections.Generic;
using System.Text;

namespace PokeApi.Net.Models
{
    class ContestType : Resource
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
        /// The berry flavor that correlates with this contest
        /// type.
        /// </summary>
        public NamedApiResource BerryFlavor { get; set; }

        /// <summary>
        /// The name of this contest type listed in different
        /// languages.
        /// </summary>
        public List<ContestName> Names { get; set; }

        public override string ApiEndpoint => "contest-type";
    }

    class ContestName
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
        public NamedApiResource Language { get; set; }
    }

    class ContestEffect : Resource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public int Id { get; set; }

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
        public List<Effects> EffectEntries { get; set; }

        /// <summary>
        /// The flavor text of this contest effect listed in
        /// different languages.
        /// </summary>
        public List<FlavorTexts> FlavorTextEntries { get; set; }

        public override string ApiEndpoint => "contest-effect";
    }

    class SuperContestEffect : Resource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The level of appeal this super contest effect has.
        /// </summary>
        public int Appeal { get; set; }

        /// <summary>
        /// The flavor text of this super contest effect listed
        /// in different languages.
        /// </summary>
        public List<FlavorTexts> FlavorTextEntries { get; set; }

        /// <summary>
        /// A list of moves that have the effect when used in
        /// super contests.
        /// </summary>
        public List<NamedApiResource> Moves { get; set; }

        public override string ApiEndpoint => "super-contest-effect";
    }
}
