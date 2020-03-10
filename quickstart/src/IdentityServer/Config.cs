// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            { 
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiResource> Apis =>
            new List<ApiResource>
            { 
                new ApiResource("api1", "My API")
            };
        
        public static IEnumerable<Client> Clients =>
            new List<Client> 
            { 
                new Client
                {
                    //think of this as the login name for the application.
                    ClientId = "client", 

                    //no interactive user, user the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication. Think of this as your applications password
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    //scopes that client has access to
                    AllowedScopes = { "api1"}


                    /*
                     You can think of the ClientId and the ClientSecret as the login and password for your application itself. 
                     
                     It identifies your application to the identity server so that it knows which application is trying to connect to it.

                     */
                },

                new Client
                {
                    ClientId = "mvc",
                    ClientSecrets = {new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,
                    RequireConsent = false,
                    RequirePkce = true,

                    RedirectUris = {"https://collegiate.site"},

                    PostLogoutRedirectUris = {"https://collegiate.site"},

                    AllowedScopes = new List<string>
                    {
                        IdentityServer4.IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServer4.IdentityServerConstants.StandardScopes.Profile

                    }
                }
            };
        
    }
}