# Azure AD Configuration Setup

## Required Steps

### 1. Configure Client Secret (CRITICAL)

Your application needs a **Client Secret** to properly authenticate with Azure AD. Follow these steps:

#### Option A: Using User Secrets (Recommended for Local Development)

1. Open PowerShell or Command Prompt in your project directory
2. Run the following commands:

```powershell
# Initialize user secrets if not already done
dotnet user-secrets init

# Add your Client Secret (replace VALUE with your actual secret from Azure)
dotnet user-secrets set "AzureAd:ClientSecret" "VALUE"
```

#### Option B: Using appsettings.json (NOT recommended for production)

Add to `appsettings.json` in the `AzureAd` section:
```json
"ClientSecret": "your-client-secret-value"
```

### 2. Get Your Client Secret from Azure Portal

1. Navigate to [Azure Portal](https://portal.azure.com)
2. Go to **Azure Active Directory** → **App registrations**
3. Search for your app: `9f14b307-1dba-4101-ae1d-fd52e3250d1f`
4. Click **Certificates & secrets** in the left sidebar
5. Under **Client secrets**, click **New client secret**
6. Add a description and set expiration
7. Click **Add**
8. Copy the **Value** (not the ID) - this is your ClientSecret
9. Store this value securely using one of the methods above

### 3. Verify Session State

Ensure session state is properly configured:
- The application uses `AddSessionTokenCaches()` which requires sessions to work
- Sessions are configured to expire after 20 minutes of inactivity
- Session cookies are marked as essential for authentication flows

### 4. Error Handling

The updated `Program.cs` now includes:
- Middleware to catch `MicrosoftIdentityWebChallengeUserException`
- Automatic redirect to sign-in when incremental consent is needed
- Fallback exception handling in the controller

### 5. Testing

1. Clean your browser cookies/session cache
2. Run the application
3. You should be redirected to Microsoft login
4. After successful login, you'll be prompted for consent to access your profile
5. You should be able to view your display name on the home page

## Troubleshooting

### Issue: "No account or login hint was passed to the AcquireTokenSilent call"

**Solution**: This error occurs when:
- ClientSecret is missing → Add it using steps above
- Session is not persisting → Check browser session/cookie settings
- User is not fully authenticated → Clear cookies and re-login

### Issue: Still getting authentication errors

1. Check the browser console for more details
2. Enable Debug logging by reviewing `appsettings.json` (already configured with Debug level)
3. Review the Visual Studio debug output window for detailed error messages
4. Verify all configuration values match your Azure app registration

## Configuration Reference

| Setting | Value | Source |
|---------|-------|--------|
| Instance | `https://login.microsoftonline.com/` | AzureAd section |
| Domain | `hiwadrashad1hotmail.onmicrosoft.com` | AzureAd section |
| TenantId | `a8bea8c5-704f-49f3-83ea-8a3432770e96` | AzureAd section |
| ClientId | `9f14b307-1dba-4101-ae1d-fd52e3250d1f` | AzureAd section |
| ClientSecret | *(from Azure Portal)* | User secrets or appsettings |
| Scopes | `user.read` | MicrosoftGraph section |
