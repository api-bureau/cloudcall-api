namespace ApiBureau.CloudCall.Api.Interfaces;

public interface ICloudCallClient
{
    AccountEndpoint Accounts { get; }
    CallEndpoint Calls { get; }
}