namespace ApiBureau.CloudCall.Api.Dtos;

public class CallDto
{
    /// <summary>
    /// Unique identifier of the call
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Unique identifier of the account that the call is assigned to
    /// </summary>
    [JsonPropertyName("i_account")]
    public int IAccount { get; set; }

    /// <summary>
    /// This is linked to AccountNumber in AccountDto
    /// </summary>
    public string AccountId { get; set; } = null!;

    //public bool CallRecordingDeleted { get; set; }
    public bool CallRecordingAvailable { get; set; }
    public bool Mp3RecordingAvailable { get; set; }

    /// <summary>
    /// Indicates whether the call came from an anonymous number
    /// </summary>
    public bool Withheld { get; set; }

    /// <summary>
    /// Indicates whether the call is transferred or not
    /// </summary>
    public bool Transfered { get; set; }
    public bool FailedClickCall { get; set; }

    /// <summary>
    /// Outbound Identifier of the call, Destination Number
    /// </summary>
    public string Cld { get; set; } = null!;

    /// <summary>
    /// Inbound identifier of the call, can be the AccountId or the Default Click device
    /// </summary>
    public string Cli { get; set; } = null!;

    public string? Note { get; set; }

    //public string call_id { get; set; }
    public string SessionId { get; set; } = null!;
    public string Direction { get; set; } = null!;
    //public string LastCallStatus { get; set; } = default!;

    /// <summary>
    /// Contains the URL that gives the Call recording. The default format will be MP3. The URL has got an Expiry time of 30 days
    /// </summary>
    public string? CallRecordingUrl { get; set; }

    /// <summary>
    /// Time the call was connected
    /// </summary>
    public DateTime ConnectTime { get; set; }

    /// <summary>
    /// Time the call got disconnected
    /// </summary>
    public DateTime DisconnectTime { get; set; }
    public DateTime? LastUpdated { get; set; }

    /// <summary>
    /// Expiry Time of the call recording
    /// </summary>
    public DateTime ExpiryTime { get; set; }
    public DateTime? TransferTime { get; set; }
    //public double ChargedAmount { get; set; }
    //public int ChargedTime { get; set; }
    //public int? CategoryId { get; set; }
    public int? ContactId { get; set; }
    public int? Leg { get; set; }
    //public object Category { get; set; }
    public ContactDto? Contact { get; set; }
    public CallDetailDto? CallDetail { get; set; } = new CallDetailDto();

    public int Duration => (int)(DisconnectTime - ConnectTime).TotalSeconds;

    public int GetNumericCrmId()
    {
        if (Contact is null) return 0;

        _ = int.TryParse(Contact.CrmObjectInstanceId, out var crmId);

        return crmId;
    }

    //public List<string> CallRecordingUrLs { get; set; } = new List<string>();
}