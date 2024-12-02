using Microsoft.Identity.Client;
using System.Diagnostics;
#if __IOS__
using UIKit;
#endif
#if __ANDROID__
using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;
#endif
namespace AzureB2C;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
    }
#if __IOS__
    private UIViewController GetCurrentViewController()
    {
        var window = UIApplication.SharedApplication.KeyWindow;
        var rootController = window.RootViewController;
        while (rootController.PresentedViewController != null)
        {
            rootController = rootController.PresentedViewController;
        }
        return rootController;
    }

    private async void LoginIntoAzureB2C(object sender, EventArgs e)
    {
        string[] scopes = Constants.Scopes;
#if __ANDROID__
        // Load your auth config
     var androidBuilder = PublicClientApplicationBuilder
    .Create(Constants.ClientID)
    .WithB2CAuthority(Constants.AuthoritySignIn)//"https://siinfrab2cdev.b2clogin.com/tfp/siinfrab2cdev.onmicrosoft.com/B2C_1_mobile_signin"
    .WithRedirectUri(Constants.RedirectUrl)//$"msalfcefe273-17f6-4bf6-ad87-90c5a61b3dc3://auth"
    //.WithIosKeychainSecurityGroup(Constants.IoKeyChainSecurityGroup)
    .Build();
    AuthenticationResult result;

    try
    {
    var accounts = await androidBuilder.GetAccountsAsync();
    var account = accounts.FirstOrDefault();
    //  if(account == null)
    //     return;
   result = await androidBuilder
        .AcquireTokenInteractive(scopes)
        .WithParentActivityOrWindow(Platform.CurrentActivity) // This line is crucial on Android
        .ExecuteAsync().ConfigureAwait(false);
     Console.WriteLine(result.AccessToken);

    }
        catch (MsalException ex)
        {
            Debug.WriteLine($"Error Acquiring Token: {ex.Message}");
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"General error: {ex.Message}");
        }
#endif

#if __IOS__


        try
        {
            var iOSBuilder = PublicClientApplicationBuilder
       .Create(Constants.ClientID)
       .WithB2CAuthority(Constants.AuthoritySignIn)
       .WithIosKeychainSecurityGroup(Constants.IoKeyChainSecurityGroup) // Correct keychain security group
       .WithRedirectUri(Constants.iOSRedirectUrl)
       .Build();

            var accounts = await iOSBuilder.GetAccountsAsync();
            var account = accounts.FirstOrDefault();

            var result = await iOSBuilder
         .AcquireTokenInteractive(scopes)
         .WithParentActivityOrWindow(GetCurrentViewController()) // Provide the current UIViewController on iOS
         .ExecuteAsync()
         .ConfigureAwait(false);

          Console.WriteLine(result.AccessToken);
        }
        catch (MsalException ex)
        {
            Debug.WriteLine($"Error Acquiring Token: {ex.Message}");
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"General error: {ex.Message}");
        }

#endif
    }
#endif
}


