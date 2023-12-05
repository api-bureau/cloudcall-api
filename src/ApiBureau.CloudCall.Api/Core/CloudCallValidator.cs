using Microsoft.Extensions.Logging;
using System.Text;

namespace ApiBureau.CloudCall.Api.Core;

/// <summary>
/// Provides validation methods for CloudCall settings and access tokens.
/// This static class contains methods to ensure that necessary configuration settings
/// and access tokens are present and valid for CloudCall operations.
/// </summary>
public static class CloudCallValidator
{
    private const string MissingSettings = "Settings are missing in the appsettings.json or secret.json";
    private const string MissingBaseUrl = "Base Url in settings is missing or empty";
    private const string MissingLoginUrl = "Login Url in settings is missing or empty";
    private const string MissingUserName = "Username in settings is missing or empty";
    private const string MissingPassword = "Password in settings is missing or empty";
    private const string MissingLicenceKey = "License key in settings is missing or empty";
    private const string MissingAccessToken = "Access token is missing or invalid";

    /// <summary>
    /// Validates the provided CloudCall settings.
    /// </summary>
    /// <param name="settings">The CloudCallSettings object to validate.</param>
    /// <param name="logger">The logger to log any validation errors.</param>
    /// <exception cref="ArgumentNullException">Thrown if settings are null.</exception>
    /// <exception cref="ArgumentException">Thrown if any of the settings properties are invalid.</exception>
    public static void ValidateSettings(CloudCallSettings settings, ILogger logger)
    {
        if (settings is null)
        {
            logger.LogError(MissingSettings);
            throw new ArgumentNullException(nameof(settings), MissingSettings);
        }

        var errors = new StringBuilder();

        if (string.IsNullOrWhiteSpace(settings.BaseUrl))
        {
            errors.AppendLine(MissingBaseUrl);
        }

        if (string.IsNullOrWhiteSpace(settings.LoginUrl))
        {
            errors.AppendLine(MissingLoginUrl);
        }

        if (string.IsNullOrWhiteSpace(settings.UserName))
        {
            errors.AppendLine(MissingUserName);
        }

        if (string.IsNullOrWhiteSpace(settings.Password))
        {
            errors.AppendLine(MissingPassword);
        }

        if (string.IsNullOrWhiteSpace(settings.LicenseKey))
        {
            errors.AppendLine(MissingLicenceKey);
        }

        if (errors.Length > 0)
        {
            var errorMessage = errors.ToString().TrimEnd();

            logger.LogError("Settings validation errors: {errors}", errorMessage);
            throw new ArgumentException(errorMessage, nameof(settings));
        }
    }

    /// <summary>
    /// Validates the access token.
    /// </summary>
    /// <param name="token">The access token to validate.</param>
    /// <param name="logger">The logger to log any validation errors.</param>
    /// <exception cref="InvalidOperationException">Thrown if the access token is invalid.</exception>
    public static void ValidateAccessToken(string? token, ILogger logger)
    {
        if (!string.IsNullOrWhiteSpace(token)) return;

        logger.LogError("Access Token error: {error}", MissingAccessToken);
        throw new InvalidOperationException(MissingAccessToken);
    }
}