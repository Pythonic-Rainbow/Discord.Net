using Discord.Entities.Messages.Embeds;
using Discord.Gateway.Cache;
using Discord.Rest;

namespace Discord.Gateway
{
    /// <summary>
    ///     Represents a generic WebSocket-based channel that can send and receive messages.
    /// </summary>
    public interface IGatewayMessageChannel : IMessageChannel, ICacheableEntity<ulong, IChannelModel>
    {
        /// <summary>
        ///     Gets all messages in this channel's cache.
        /// </summary>
        MessagesCacheable CachedMessages { get; }

        /// <inheritdoc cref="IMessageChannel.SendMessageAsync(string, bool, Embed, RequestOptions, AllowedMentions, MessageReference, MessageComponent, ISticker[], Embed[], MessageFlags)"/>
        new Task<RestUserMessage> SendMessageAsync(string? text = null, bool isTTS = false, Embed? embed = null,
            RequestOptions? options = null, AllowedMentions? allowedMentions = null, MessageReference? messageReference = null,
            MessageComponent? components = null, ISticker[]? stickers = null, Embed[]? embeds = null, MessageFlags flags = MessageFlags.None);

        /// <inheritdoc cref="IMessageChannel.SendFileAsync(string, string, bool, Embed, RequestOptions, bool, AllowedMentions, MessageReference, MessageComponent, ISticker[], Embed[], MessageFlags)"/>
        new Task<RestUserMessage> SendFileAsync(string filePath, string? text = null, bool isTTS = false, Embed? embed = null,
            RequestOptions? options = null, bool isSpoiler = false, AllowedMentions? allowedMentions = null,
            MessageReference? messageReference = null, MessageComponent? components = null, ISticker[]? stickers = null,
            Embed[]? embeds = null, MessageFlags flags = MessageFlags.None);

        /// <inheritdoc cref="IMessageChannel.SendFileAsync(Stream, string, string, bool, Embed, RequestOptions, bool, AllowedMentions, MessageReference, MessageComponent, ISticker[], Embed[], MessageFlags)"/>
        new Task<RestUserMessage> SendFileAsync(Stream stream, string filename, string? text = null, bool isTTS = false,
            Embed? embed = null, RequestOptions? options = null, bool isSpoiler = false, AllowedMentions? allowedMentions = null,
            MessageReference? messageReference = null, MessageComponent? components = null, ISticker[]? stickers = null,
            Embed[]? embeds = null, MessageFlags flags = MessageFlags.None);

        /// <inheritdoc cref="IMessageChannel.SendFileAsync(FileAttachment, string, bool, Embed, RequestOptions, AllowedMentions, MessageReference, MessageComponent, ISticker[], Embed[], MessageFlags)"/>
        new Task<RestUserMessage> SendFileAsync(FileAttachment attachment, string? text = null, bool isTTS = false,
            Embed? embed = null, RequestOptions? options = null, AllowedMentions? allowedMentions = null,
            MessageReference? messageReference = null, MessageComponent? components = null, ISticker[]? stickers = null,
            Embed[]? embeds = null, MessageFlags flags = MessageFlags.None);

        /// <inheritdoc cref="IMessageChannel.SendFilesAsync(IEnumerable{FileAttachment}, string, bool, Embed, RequestOptions, AllowedMentions, MessageReference, MessageComponent, ISticker[], Embed[], MessageFlags)"/>
        new Task<RestUserMessage> SendFilesAsync(IEnumerable<FileAttachment> attachments, string? text = null,
            bool isTTS = false, Embed? embed = null, RequestOptions? options = null,
            AllowedMentions? allowedMentions = null, MessageReference? messageReference = null,
            MessageComponent? components = null, ISticker[]? stickers = null, Embed[]? embeds = null,
            MessageFlags flags = MessageFlags.None);

        /// <summary>
        ///     Gets a cached message from this channel.
        /// </summary>
        /// <remarks>
        ///     <note type="warning">
        ///         This method requires the use of cache, which is not enabled by default; if caching is not enabled,
        ///         this method will always return <see langword="null" />. Please refer to
        ///         <see cref="Discord.WebSocket.DiscordSocketConfig.MessageCacheSize" /> for more details.
        ///     </note>
        ///     <para>
        ///         This method retrieves the message from the local WebSocket cache and does not send any additional
        ///         request to Discord. This message may be a message that has been deleted.
        ///     </para>
        /// </remarks>
        /// <param name="id">The snowflake identifier of the message.</param>
        /// <returns>
        ///     A WebSocket-based message object; <see langword="null" /> if it does not exist in the cache or if caching is not
        ///     enabled.
        /// </returns>
        MessageCacheable GetCachedMessage(ulong id);
        /// <summary>
        ///     Gets the last N cached messages from this message channel.
        /// </summary>
        /// <remarks>
        ///     <note type="warning">
        ///         This method requires the use of cache, which is not enabled by default; if caching is not enabled,
        ///         this method will always return an empty collection. Please refer to
        ///         <see cref="Discord.WebSocket.DiscordSocketConfig.MessageCacheSize" /> for more details.
        ///     </note>
        ///     <para>
        ///         This method retrieves the message(s) from the local WebSocket cache and does not send any additional
        ///         request to Discord. This read-only collection may include messages that have been deleted. The
        ///         maximum number of messages that can be retrieved from this method depends on the
        ///         <see cref="Discord.WebSocket.DiscordSocketConfig.MessageCacheSize" /> set.
        ///     </para>
        /// </remarks>
        /// <param name="limit">The number of messages to get.</param>
        /// <returns>
        ///     A read-only collection of WebSocket-based messages.
        /// </returns>
        MessagesCacheable GetCachedMessages(int limit = DiscordConfig.MaxMessagesPerBatch);

        /// <summary>
        ///     Gets the last N cached messages starting from a certain message in this message channel.
        /// </summary>
        /// <remarks>
        ///     <note type="warning">
        ///         This method requires the use of cache, which is not enabled by default; if caching is not enabled,
        ///         this method will always return an empty collection. Please refer to
        ///         <see cref="Discord.WebSocket.DiscordSocketConfig.MessageCacheSize" /> for more details.
        ///     </note>
        ///     <para>
        ///         This method retrieves the message(s) from the local WebSocket cache and does not send any additional
        ///         request to Discord. This read-only collection may include messages that have been deleted. The
        ///         maximum number of messages that can be retrieved from this method depends on the
        ///         <see cref="Discord.WebSocket.DiscordSocketConfig.MessageCacheSize" /> set.
        ///     </para>
        /// </remarks>
        /// <param name="fromMessageId">The message ID to start the fetching from.</param>
        /// <param name="dir">The direction of which the message should be gotten from.</param>
        /// <param name="limit">The number of messages to get.</param>
        /// <returns>
        ///     A read-only collection of WebSocket-based messages.
        /// </returns>
        MessagesCacheable GetCachedMessages(ulong fromMessageId, Direction dir, int limit = DiscordConfig.MaxMessagesPerBatch);
        /// <summary>
        ///     Gets the last N cached messages starting from a certain message in this message channel.
        /// </summary>
        /// <remarks>
        ///     <note type="warning">
        ///         This method requires the use of cache, which is not enabled by default; if caching is not enabled,
        ///         this method will always return an empty collection. Please refer to
        ///         <see cref="Discord.WebSocket.DiscordSocketConfig.MessageCacheSize" /> for more details.
        ///     </note>
        ///     <para>
        ///         This method retrieves the message(s) from the local WebSocket cache and does not send any additional
        ///         request to Discord. This read-only collection may include messages that have been deleted. The
        ///         maximum number of messages that can be retrieved from this method depends on the
        ///         <see cref="Discord.WebSocket.DiscordSocketConfig.MessageCacheSize" /> set.
        ///     </para>
        /// </remarks>
        /// <param name="fromMessage">The message to start the fetching from.</param>
        /// <param name="dir">The direction of which the message should be gotten from.</param>
        /// <param name="limit">The number of messages to get.</param>
        /// <returns>
        ///     A read-only collection of WebSocket-based messages.
        /// </returns>
        MessagesCacheable GetCachedMessages(IMessage fromMessage, Direction dir, int limit = DiscordConfig.MaxMessagesPerBatch);
        /// <summary>
        ///     Gets a read-only collection of pinned messages in this channel.
        /// </summary>
        /// <remarks>
        ///     This method follows the same behavior as described in <see cref="IMessageChannel.GetPinnedMessagesAsync"/>.
        ///     Please visit its documentation for more details on this method.
        /// </remarks>
        /// <param name="options">The options to be used when sending the request.</param>
        /// <returns>
        ///     A task that represents the asynchronous get operation for retrieving pinned messages in this channel.
        ///     The task result contains a read-only collection of messages found in the pinned messages.
        /// </returns>
        new Task<IReadOnlyCollection<RestMessage>> GetPinnedMessagesAsync(RequestOptions? options = null);
    }
}