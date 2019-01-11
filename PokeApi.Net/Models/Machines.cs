using System;
using System.Collections.Generic;
using System.Text;

namespace PokeApi.Net.Models
{
    class Machine
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
        public NamedApiResource VersionGroup { get; set; }
    }
}
