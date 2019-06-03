﻿// <copyright file="IAuthenticationService.cs" company="Yetisoftworks LLC">
// Copyright (c) Yetisoftworks LLC. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MeshyDB.SDK.Models;

namespace MeshyDB.SDK.Services
{
    /// <summary>
    /// Defines method of Authentication.
    /// </summary>
    internal interface IAuthenticationService
    {
        /// <summary>
        /// Log in anonymously to authenticate with client.
        /// </summary>
        /// <param name="username">Specify known username for anonymous user.</param>
        /// <returns>Authentication id upon success.</returns>
        Task<string> LoginAnonymouslyAsync(string username = null);

        /// <summary>
        /// Log in with provided user name and password.
        /// </summary>
        /// <param name="username">User name provided for login.</param>
        /// <param name="password">Password provided for login.</param>
        /// <returns>Authentication id upon success.</returns>
        Task<string> LoginWithPasswordAsync(string username, string password);

        /// <summary>
        /// Log in with persistance token provided from a previous session.
        /// </summary>
        /// <param name="persistanceToken">Persistance token from a previous session.</param>
        /// <returns>Authentication id upon success.</returns>
        Task<string> LoginWithPersistanceAsync(string persistanceToken);

        /// <summary>
        /// Retrieves persistance token so a user can log in at a later time without requiring credentials.
        /// </summary>
        /// <param name="authenticationId">Internal identifier provided from login process.</param>
        /// <returns>Persistance token used for persistance login at a later time.</returns>
        Task<string> RetrievePersistanceTokenAsync(string authenticationId);

        /// <summary>
        /// Forgot Password for user.
        /// </summary>
        /// <param name="username">User name to request a reset.</param>
        /// <returns>Hash object to verify parity in requests.</returns>
        Task<UserVerificationHash> ForgotPasswordAsync(string username);

        /// <summary>
        /// Reset password for user parity hash object.
        /// </summary>
        /// <param name="resetPassword">Hash object with parity information.</param>
        /// <returns>Task indicating when operation is complete.</returns>
        Task ResetPasswordAsync(ResetPassword resetPassword);

        /// <summary>
        /// Updates the password of the requesting user.
        /// </summary>
        /// <param name="previousPassword">Previous password of user.</param>
        /// <param name="newPassword">New password for user.</param>
        /// <returns>Task indicating when operation is complete.</returns>
        Task UpdatePasswordAsync(string previousPassword, string newPassword);

        /// <summary>
        /// Register user.
        /// </summary>
        /// <param name="user">User definition with password for login.</param>
        /// <returns>Resulting user based on save.</returns>
        Task<UserVerificationHash> RegisterAsync(RegisterUser user);

        /// <summary>
        /// Signout the targeted user based on authentication id.
        /// </summary>
        /// <param name="authenticationId">Internal identifier provided from login process.</param>
        /// <returns>Task indicating when operation is complete.</returns>
        Task SignoutAsync(string authenticationId);

        /// <summary>
        /// Verify user to allow login after establishing identity.
        /// </summary>
        /// <param name="userVerificationCheck">User verification check object to establish authorization.</param>
        /// <returns>Task indicating when operation is complete.</returns>
        Task VerifyAsync(UserVerificationCheck userVerificationCheck);

        /// <summary>
        /// Check hash to ensure established identity.
        /// </summary>
        /// <param name="userVerificationCheck">User verification check object to establish authorization.</param>
        /// <returns>Whether or not the check was successful.</returns>
        Task<bool> CheckHashAsync(UserVerificationCheck userVerificationCheck);
    }
}
