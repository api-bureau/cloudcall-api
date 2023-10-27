using Microsoft.Extensions.Logging;

namespace ApiBureau.CloudCall.Api.Core;

public static class CloudCallSettingsValidator
{
    private const string MissingSettings = "Settings are missing";
    private const string MissingBaseUrl = "BaseUrl in settings is missing or empty";
    private const string MissingLoginUrl = "LoginUrl in settings is missing or empty";
    private const string MissingUserName = "UserName in settings is missing or empty";
    private const string MissingPassword = "Password in settings is missing or empty";
    private const string MissingLicenceKey = "LicenseKey in settings is missing or empty";

    public static void Validate(CloudCallSettings settings, ILogger logger)
    {
        if (settings is null)
        {
            logger.LogError(MissingSettings);
            throw new ArgumentNullException(nameof(settings), MissingSettings);
        }

        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(settings.BaseUrl))
        {
            errors.Add(MissingBaseUrl);
        }

        if (string.IsNullOrWhiteSpace(settings.LoginUrl))
        {
            errors.Add(MissingLoginUrl);
        }

        if (string.IsNullOrWhiteSpace(settings.UserName))
        {
            errors.Add(MissingUserName);
        }

        if (string.IsNullOrWhiteSpace(settings.Password))
        {
            errors.Add(MissingPassword);
        }

        if (string.IsNullOrWhiteSpace(settings.LicenseKey))
        {
            errors.Add(MissingLicenceKey);
        }

        if (errors.Any())
        {
            var errorMessage = string.Join("; ", errors);

            logger.LogError("Settings errors: {errors}", errorMessage);

            throw new ArgumentException(errorMessage, nameof(settings));
        }
    }
}