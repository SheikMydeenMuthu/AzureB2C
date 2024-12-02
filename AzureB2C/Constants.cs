using System;

namespace AzureB2C;

public static class Constants
{
 public static readonly string ClientID = "fcefe273-17f6-4bf6-ad87-90c5a61b3dc3";//"2af39e4d-e5f1-451c-b0a4-f6930c4e584f";
 public static readonly string[] Scopes = {"openid", "offline_access", ClientID};
 public static readonly string TenantName = "siinfrab2cdev";
 public static readonly string TenantID = "45b78219-559c-45ec-abeb-83b0b19be577";
 public static readonly string SignInPolicy = "B2C_1_mobile_signin";
  public static readonly string AuthorityBase = $"https://{TenantName}.b2clogin.com/tfp/{TenantID}/";
 public static readonly string AuthoritySignIn = $"{AuthorityBase}{SignInPolicy}";
 public static readonly string IoKeyChainSecurityGroup = "com.sisystems.Sisystems";
 public static readonly string RedirectUrl = $"msal{ClientID}://auth";
 public static readonly string iOSRedirectUrl = "msauth.com.sisystems.Sisystems://auth";



}
