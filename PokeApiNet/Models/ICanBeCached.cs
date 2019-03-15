namespace PokeApiNet.Models
{
    /// <summary>
    /// Contract for PokeApi resource classes that can be cached
    /// </summary>
    public interface ICanBeCached
    {
        /// <summary>
        /// Id of the resource
        /// </summary>
        int Id { get; set; }
    }
}
