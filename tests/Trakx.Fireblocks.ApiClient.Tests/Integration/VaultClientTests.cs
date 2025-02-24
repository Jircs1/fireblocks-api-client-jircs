using Microsoft.Extensions.DependencyInjection;
using Trakx.Fireblocks.ApiClient.Tests.Integration.Base;

namespace Trakx.Fireblocks.ApiClient.Tests.Integration;

public class VaultClientTests : FireblocksClientTestsBase
{
    private readonly IVaultsClient _vaultClient;

    public VaultClientTests(FireblocksApiFixture apiFixture, ITestOutputHelper output)
        : base(apiFixture, output)
    {
        _vaultClient = _serviceProvider.GetRequiredService<IVaultsClient>();
    }

    [Fact]
    public async Task GetVaultAccountsAsync_should_return_all_vault_accounts()
    {
        var response = await _vaultClient.GetPagedVaultAccountsAsync();
        response.Content.Should().NotBeNull();
        var accounts = response.Content.Accounts;
        accounts.Should().NotBeNullOrEmpty();
        accounts.Should().Contain(x => x.Assets.Any(x => x.Id == "BTC_TEST"));
    }

    [Fact]
    public async Task GetVaultAccountsAsync_is_case_insensitive()
    {
        var response = await _vaultClient.GetPagedVaultAccountsAsync(namePrefix: "exchange");
        response.Content.Should().NotBeNull();
        var accounts = response.Content.Accounts;
        accounts.Should().NotBeNullOrEmpty();
        accounts.Should().Contain(x => x.Name == "Exchange Warm Wallet");
    }
}