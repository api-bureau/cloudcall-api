namespace ApiBureau.CloudCall.Api.Dtos;

public class ContactDto
{
    public int ContactId { get; set; }
    public string Name { get; set; } = null!;
    //public string FirstName { get; set; } = default!;
    //public string LastName { get; set; } = default!;
    //public string? Number { get; set; }
    //public string? Mobile { get; set; }
    //public string Home { get; set; } = default!;
    //public string Ddi { get; set; } = default!;
    //public int ContactTypeId { get; set; }
    public string Company { get; set; } = default!;
    //public string AccountId { get; set; } = default!;
    //public string Fax { get; set; }
    //public string ImageType { get; set; }
    //public string ContactType { get; set; } = default!;
    //public string Image { get; set; }
    //public int i_customer { get; set; }
    //public string Email { get; set; }
    //public string Email1 { get; set; }
    //public string Email1Description { get; set; }
    //public string Number1 { get; set; }
    //public string Number1Description { get; set; }
    //public string Number2 { get; set; }
    //public string Number2Description { get; set; }
    //public string Number3 { get; set; }
    //public string Number3Description { get; set; }
    //public string Number4 { get; set; }
    //public string Number4Description { get; set; }
    //public bool Deleted { get; set; }
    //public object LastUpdated { get; set; }
    //public object LinkedInUrl { get; set; }
    //public object FacebookUrl { get; set; }
    //public object GooglePlusUrl { get; set; }
    //public object TwitterHandle { get; set; }
    //public object OtherUrl { get; set; }
    public string? DeepLinkUrl { get; set; }
    //public bool ReadOnly { get; set; }
    public string? CrmObjectInstanceId { get; set; }
    public int CrmEntityMappingId { get; set; }
    public string? CrmEntityName { get; set; }
    public string? CrmProductName { get; set; }
}