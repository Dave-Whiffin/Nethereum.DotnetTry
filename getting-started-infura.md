# Getting started using Infura with Nethereum

This sample will take you through the steps of connecting to [Infura](https://www.infura.io), retrieving the balance of an account from the mainnet (live Ethereum) and checking on the chain ID and latest block number.


INFURA runs ethereum nodes and provides access to them via api, eliminating the need to run and update your own infrastructure.

The first step to use INFURA is to [sign up](https://infura.io/register) and get an API key. The next step is to choose which Ethereum network to connect to, either mainnet, Kovan, Goerli, Rinkeby, or Ropsten test networks. The name of the network will be used in the url, which  format looks like this:`https://<network>.infura.io/v3/YOUR-PROJECT-ID`.

For this sample, we’ll use a special API key `7238211010344719ad14a89db874158c`, but for your own project you’ll need your own key.

The required assembly is `Nethereum.Web3`
```cs
using Nethereum.Web3;
```
Let’s create an instance of Web3 using the privateKey of an Ethereum account and the infura url for mainnet, then, using the Eth API (in the form of Web3) we can execute the `GetBalance` request asynchronously, for any account. In this scenario the chosen account belongs to the Ethereum Foundation: `0xde0b295669a9fd93d5f28d9ec85e40f4cb697bae`:
```cs --source-file ./NethereumDotnetTry/Program.cs --project ./NethereumDotnetTry/NethereumDotnetTry.csproj --region get-balance
```
The amount returned above is in wei(not that human-friendly), the lowest unit of value. We can convert this to ether using the convertion utility:
```cs --source-file ./NethereumDotnetTry/Program.cs --project ./NethereumDotnetTry/NethereumDotnetTry.csproj --region convert-balance
```

Using the Net API, we can call and find out which network we’re connected to. This will change depending on which network we chose to connect to previously. For example, Kovan will return `42` and mainnet would be `1`.

```cs --source-file ./NethereumDotnetTry/Program.cs --project ./NethereumDotnetTry/NethereumDotnetTry.csproj --region get-networkId
```

Next, using the Eth API, we’ll call to get the latest block number that has been mined in this network.

```cs --source-file ./NethereumDotnetTry/Program.cs --project ./NethereumDotnetTry/NethereumDotnetTry.csproj --region get-latestBlockNumber
```

That’s a quick demo of using Nethereum with INFURA. One important thing to know when using hosted infrastructure like Infura is it doesn’t store any private keys, so any signing must be done locally and then the raw transaction passed on to the service. Nethereum makes this easy with the `Account` object. See the [Using account objects](https://docs.nethereum.com/en/latest/Nethereum.Workbooks/docs/nethereum-using-account-objects/#sending-a-transaction) for more details.

Note: some communication errors can occur with INFURA if INFURA's API and your app can't agree on what version of TLS to use. .Net 4.5 and earlier will default to TLS v1, with TLS v1.2 deactivated if it's included in the framework. (In .Net 4.6.*, v1.2 is the default.)
To enable v1.2 in 4.5.2 you can use:
`System.Net.ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;` Notice the use of |= to turn on 1.2 without affecting other protocols (that way you remain able to take advantage of future TLS versions that may become the default values in future updates to .NET).
