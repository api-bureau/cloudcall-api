namespace ApiBureau.CloudCall.Api.Dtos;

public class AccountDto
{
    public string AccountNumber { get; set; } = null!;
    public bool? AutoForwardToDefaultDevice { get; set; }
    public bool CanDownloadAllRecordings { get; set; }
    public bool CanDownloadRecordings { get; set; }
    public bool CanPauseAndResumeRecording { get; set; }
    //public bool DynamicIdentityAllowed { get; set; }
    //public bool DynamicIdentityEnabled { get; set; }
    public string Firstname { get; set; } = default!;
    //public string HideOutboundIdentityPrefix { get; set; } = default!;

    /// <summary>
    /// Unique identifier of the account that the call is assigned to
    /// </summary>
    [JsonPropertyName("i_account")]
    public int IAccount { get; set; }

    [JsonPropertyName("i_customer")]
    public int CustomerId { get; set; }

    //public int i_master_account { get; set; }
    public string Login { get; set; } = default!;
    public string? CurrentOutboundIdentity { get; set; }

    //public string NotificationToken { get; set; } = default!;
    //public bool OutboundIdentityHidden { get; set; }
    //public bool OverrideCampaignIdentity { get; set; }
    //public string Password { get; set; } = default!;
    //public string? ProductDescription { get; set; };
    //public int ProductId { get; set; }
    //public string? ProductName { get; set; }
    public string Surname { get; set; } = null!;
    //public bool UnifyModeEnabled { get; set; }
    //public int VoiceCodec { get; set; }
    //public IList<object> VoicemailDropFiles { get; set; }

    public string? FullName => $"{Firstname ?? ""} {Surname ?? ""}".Trim();
}