using System.Data;

namespace Discord;

/// <summary>
///     Provides properties that are used to modify an <see cref="IGuildEmote" /> with the specified changes.
/// </summary>
public class EmoteProperties
{
    /// <summary>
    ///     Gets or sets the name of the <see cref="Emote"/>.
    /// </summary>
    public Optional<string> Name { get; set; }

    /// <summary>
    ///     Gets or sets the roles that can access this <see cref="Emote"/>.
    /// </summary>
    public Optional<IEnumerable<IRole>> Roles { get; set; }

    /// <summary>
    ///     Gets or sets the roles that can access this <see cref="Emote"/>.
    /// </summary>
    public Optional<IEnumerable<ulong>> RoleIds { get; set; }
}