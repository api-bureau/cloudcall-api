namespace ApiBureau.CloudCall.Api.Dtos;

public class CallDetailDto
{
    public string SessionId { get; set; } = default!;
    public string ContactName { get; set; } = default!;
    public string ContactCompany { get; set; } = default!;
    public string CategoryDescription { get; set; } = default!;
    public string Subject { get; set; } = default!;
    public DateTime LastUpdated { get; set; }
    public string Note { get; set; } = default!;
    //public object Custom1 { get; set; }
    //public object Custom2 { get; set; }
    //public string AccountName { get; set; }
    //public object HandledBy { get; set; }
    //public object ClickDevice { get; set; }
    //public object Voicemail { get; set; }
    //public object IsDynamicIdentity { get; set; }
}