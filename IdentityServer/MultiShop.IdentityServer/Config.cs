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
                    "DiscountFullPermission"
                }
            },
            #endregion

            #region Manager
            new Client
            {
                ClientId="MultiShopManagerId",
                ClientName="Multi Shop Manager User",
                AllowedGrantTypes= GrantTypes.ClientCredentials,
                ClientSecrets = {
                    new Secret("multishopsecret".Sha256())
                },
                 AllowedScopes = {
                    "CatalogFullPermission","CatalogReadPermission"
                }

            },
            #endregion


             #region Admin
            new Client
            {
                ClientId="MultiShopAdminId",
                ClientName="Multi Shop Admin User",
                AllowedGrantTypes= GrantTypes.ClientCredentials,
                ClientSecrets = {
                    new Secret("multishopsecret".Sha256())
                },
                 AllowedScopes = {
                    "CatalogFullPermission","CatalogReadPermission","DiscountFullPermission","OrderFullPermission","CargoFullPermission","BasketFullPermission",
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