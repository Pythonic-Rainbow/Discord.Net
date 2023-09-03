using System.Text.Json.Serialization;

namespace Discord.API.Rest;

internal class ModifyGuildParams
{
    [JsonPropertyName("name")]
    public Optional<string> Name { get; set; }

    [JsonPropertyName("region")]
    public Optional<string?> RegionId { get; set; }

    [JsonPropertyName("verification_level")]
    public Optional<VerificationLevel?> VerificationLevel { get; set; }

    [JsonPropertyName("default_message_notifications")]
    public Optional<DefaultMessageNotifications?> DefaultMessageNotifications { get; set; }

    [JsonPropertyName("explicit_content_filter")]
    public Optional<ExplicitContentFilterLevel?> ExplicitContentFilter { get; set; }

    [JsonPropertyName("afk_channel_id")]
    public Optional<ulong?> AfkChannelId { get; set; }

    [JsonPropertyName("afk_timeout")]
    public Optional<AfkTimeout> AfkTimeout { get; set; }

    [JsonPropertyName("icon")]
    public Optional<Image?> Icon { get; set; }

    [JsonPropertyName("owner_id")]
    public Optional<ulong> OwnerId { get; set; }

    [JsonPropertyName("splash")]
    public Optional<Image?> Splash { get; set; }

    [JsonPropertyName("discovery_splash")]
    public Optional<Image?> DiscoverySplash { get; set; }

    [JsonPropertyName("banner")]
    public Optional<Image?> Banner { get; set; }

    [JsonPropertyName("system_channel_id")]
    public Optional<ulong?> SystemChannelId { get; set; }

    [JsonPropertyName("system_channel_flags")]
    public Optional<SystemChannelMessageDeny> SystemChannelFlags { get; set; }

    [JsonPropertyName("rules_channel_id")]
    public Optional<ulong> RulesChannelId { get; set; }
    
    [JsonPropertyName("public_updates_channel_id")]
    public Optional<ulong?> PublicUpdatesChannelId { get; set; }

    [JsonPropertyName("preferred_locale")]
    public Optional<string?> PreferredLocale { get; set; }

    [JsonPropertyName("features")]
    public Optional<GuildFeatures> GuildFeatures { get; set; }

    [JsonPropertyName("description")]
    public Optional<string?> Description { get; set; }

    [JsonPropertyName("premium_progress_bar_enabled")]
    public Optional<bool> IsBoostProgressBarEnabled { get; set; }

    [JsonPropertyName("safety_alerts_channel_id")]
    public Optional<ulong?> SafetyAlertsChannelId { get; set; }
}