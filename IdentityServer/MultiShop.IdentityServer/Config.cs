// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace MultiShop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("Resource_Catalog")
            {
                Scopes={"CatalogFullPermission","CatalogReadPermission"},
            },
            new ApiResource("Resource_Discount")
            {
                Scopes={"DiscountFullPermission"},
            },
            new ApiResource("Resource_Order")
            {
                Scopes={"OrderFullPermission"},
            },
            new ApiResource("Resource_Cargo")
            {
                Scopes={"CargoFullPermission"},
            },
            new ApiResource("Resource_Basket")
            {
                Scopes={"BasketFullPermission"},
            },
             new ApiResource("Resource_Comment")
            {
                Scopes={"CommentFullPermission"},
            },
            new ApiResource("Resource_Ocelot")
            {
                Scopes={"OcelotFullPermission"},
            },
             new ApiResource("Resource_Message")
            {
                Scopes={"MessageFullPermission"},
            },
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile(),
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission","Full_Permission_For_Catalog_Operations"),
            new ApiScope("CatalogReadPermission","Reading_Permission_For_Catalog_Operations"),
            new ApiScope("DiscountFullPermission","Full_Operations_For_Discount"),
            new ApiScope("OrderFullPermission","Full_Operations_For_Order"),
            new ApiScope("CargoFullPermission","Full_Operations_For_Cargo"),
            new ApiScope("BasketFullPermission","Full_Operations_For_Basket"),
            new ApiScope("CommentFullPermission","Full_Operations_For_Comment"),
            new ApiScope("OcelotFullPermission","Full_Operations_For_Ocelot"),
            new ApiScope("MessageFullPermission","Full_Operations_Message"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            #region Visitor
            new Client
            {
                ClientId="MultiShopVisitorId",
                ClientName="Multi Shop Visitor User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = {
                    new Secret("multishopsecret".Sha256())
                },
                AllowedScopes = {
                  "CatalogReadPermission","CatalogFullPermission","DiscountFullPermission","OcelotFullPermission","CommentFullPermission", IdentityServerConstants.LocalApi.ScopeName,
                },
           
            },
            #endregion

            #region Manager
            new Client
            {
                ClientId="MultiShopManagerId",
                ClientName="Multi Shop Manager User",
                AllowedGrantTypes= GrantTypes.ResourceOwnerPassword,
                ClientSecrets = {
                    new Secret("multishopsecret".Sha256())
                },
                 AllowedScopes = {
                    "CatalogFullPermission","CatalogReadPermission","CargoFullPermission","OrderFullPermission","MessageFullPermission","DiscountFullPermission","BasketFullPermission","OcelotFullPermission" ,"CommentFullPermission"  , IdentityServerConstants.LocalApi.ScopeName,
                 IdentityServerConstants.StandardScopes.Email,
                 IdentityServerConstants.StandardScopes.OpenId,
                 IdentityServerConstants.StandardScopes.Profile,
                }

            },
            #endregion


             #region Admin
            new Client
            {
                ClientId="MultiShopAdminId",
                ClientName="Multi Shop Admin User",
                AllowedGrantTypes= GrantTypes.ResourceOwnerPassword,
                ClientSecrets = {
                    new Secret("multishopsecret".Sha256())
                },
                 AllowedScopes = {
                    "CatalogFullPermission","CatalogReadPermission","CargoFullPermission","CommentFullPermission","DiscountFullPermission","OrderFullPermission","CargoFullPermission","BasketFullPermission","OcelotFullPermission",
                 IdentityServerConstants.LocalApi.ScopeName,
                 IdentityServerConstants.StandardScopes.Email,
                 IdentityServerConstants.StandardScopes.OpenId,
                 IdentityServerConstants.StandardScopes.Profile,
                 },
                 AccessTokenLifetime=600,

            }
            #endregion
        };
    }
}