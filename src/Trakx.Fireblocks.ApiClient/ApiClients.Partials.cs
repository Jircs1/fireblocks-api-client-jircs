﻿namespace Trakx.Fireblocks.ApiClient
{
    internal partial class FireblocksClient
    {
        partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, string url)
        {
            CredentialProvider.AddCredentials(request);
        }
    }
}