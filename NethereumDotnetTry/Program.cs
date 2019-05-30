using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using Nethereum.Web3;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts.CQS;
using Nethereum.Util;
using Nethereum.Web3.Accounts;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Contracts;
using Nethereum.Contracts.Extensions;
using System.Numerics;
using System;
using System.Collections.Generic;
using System.Linq;
namespace NethereumTry
{
    class Program
    {
        static void Main(string region = null,
            string session = null,
            string package = null,
            string project = null,
            string[] args = null)
        {
            switch(region)
            {
                case "get-balance":
                    CheckBalance().Wait();
                    break;
                case "convert-balance":
                    ConvertBalance().Wait();
                    break;
                case "get-networkId":
                    GetNetworkId().Wait();
                    break;
                case "get-latestBlockNumber":
                    GetlatestBlockNumber().Wait();
                    break;
            }
        }
        public static async Task<System.Numerics.BigInteger> CheckBalance()
        {
            #region get-balance
            // Instantiate an account using its private key
            var account = new Account("0xb5b1870957d373ef0eeffecc6e4812c0fd08f554b37b233526acc331bf1544f7");

            // Instantiate a Web3 object, using our Ethereum account and the Infura endpoint 
            var web3 = new Web3(account, "https://mainnet.infura.io/v3/7238211010344719ad14a89db874158c");

            // Query the account balance of the Ethereum Foundation  
            var balance = await web3.Eth.GetBalance.SendRequestAsync("0xde0b295669a9fd93d5f28d9ec85e40f4cb697bae");
            
            // Print account balance in Wei
            Console.WriteLine($"Balance of account: {balance.Value}");
            #endregion
            return balance;
        }
        public static async Task<System.Numerics.BigInteger> ConvertBalance()
        {
            var account = new Account("0xb5b1870957d373ef0eeffecc6e4812c0fd08f554b37b233526acc331bf1544f7");
            var web3 = new Web3(account, "https://mainnet.infura.io/v3/7238211010344719ad14a89db874158c");
            var balance = await web3.Eth.GetBalance.SendRequestAsync("0xde0b295669a9fd93d5f28d9ec85e40f4cb697bae");
            // Print account balance in Wei
            #region convert-balance
            Console.WriteLine($"Balance of account: {Web3.Convert.FromWei(balance.Value)}");
            #endregion
            return balance;
        }
        public static async Task GetNetworkId()
        {
            var account = new Account("0xb5b1870957d373ef0eeffecc6e4812c0fd08f554b37b233526acc331bf1544f7");
            var web3 = new Web3(account, "https://mainnet.infura.io/v3/7238211010344719ad14a89db874158c");
            #region get-networkId
            var networkId = await web3.Net.Version.SendRequestAsync();
            #endregion
            Console.WriteLine($"NetworkId is: {networkId}");
        }
        public static async Task<System.Numerics.BigInteger> GetlatestBlockNumber()
        {
            var account = new Account("0xb5b1870957d373ef0eeffecc6e4812c0fd08f554b37b233526acc331bf1544f7");
            var web3 = new Web3(account, "https://mainnet.infura.io/v3/7238211010344719ad14a89db874158c");
            #region get-latestBlockNumber
            var latestBlockNumber = await web3.Eth.Blocks.GetBlockNumber.SendRequestAsync();
            #endregion
            Console.WriteLine($"Latest Block Number is: {latestBlockNumber.Value}");
            return latestBlockNumber;
        }
    }
}
