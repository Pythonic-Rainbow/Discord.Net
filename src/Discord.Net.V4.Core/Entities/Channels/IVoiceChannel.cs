namespace Discord;

public interface IVoiceChannel : ITextChannel, IAudioChannel, IModifyable<VoiceChannelProperties>
{
    /// <summary>
    ///     Gets the bit-rate that the clients in this voice channel are requested to use.
    /// </summary>
    /// <returns>
    ///     An <see cref="int"/> representing the bit-rate (bps) that this voice channel defines and requests the
    ///     client(s) to use.
    /// </returns>
    int Bitrate { get; }
    /// <summary>
    ///     Gets the max number of users allowed to be connected to this channel at once.
    /// </summary>
    /// <returns>
    ///     An <see cref="int"/> representing the maximum number of users that are allowed to be connected to this
    ///     channel at once; <see langword="null" /> if a limit is not set.
    /// </returns>
    int? UserLimit { get; }

    /// <summary>
    ///     Gets the video quality mode for this channel.
    /// </summary>
    VideoQualityMode VideoQualityMode { get; }
}