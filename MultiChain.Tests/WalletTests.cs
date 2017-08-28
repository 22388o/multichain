﻿/*=====================================================================
Authors: Lucid Ocean PTY (LTD)
Copyright © 2017 Lucid Ocean PTY (LTD). All Rights Reserved.

License: Dual MIT / Lucid Ocean Wave Business License v1.0
Please refer to http://www.lucidocean.co.za/wbl-license.html for restrictions and freedoms.
The full license will also be found on the root of the main source-code directory.
=====================================================================*/
using LucidOcean.MultiChain;
using LucidOcean.MultiChain.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace BlockChainAPITester
{
    [TestClass]
    public class WalletTests
    {
        
        private MultiChainClient _Client = null;

        [TestInitialize]
        public void Init()
        {
            _Client = new MultiChainClient(TestSettings.Connection);
        }

        //addmultisigaddress

        [TestMethod]
        public void GetNewAddressAsync()
        {
            JsonRpcResponse<string> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Wallet.GetNewAddressAsync();
            }).GetAwaiter().GetResult();
        }

        [TestMethod]
        public void GetNewAddress()
        {
            JsonRpcResponse<string> response = null;
            response = _Client.Wallet.GetNewAddress();
        }

        [TestMethod]
        public JsonRpcResponse<List<string>> GetAddressesAsync()
        {
            JsonRpcResponse<List<string>> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Wallet.GetAddressesAsync();
            }).GetAwaiter().GetResult();

            ResponseLogger<List<string>>.Log(response);

            return response;
        }


        [TestMethod]
        public void GetAddressesVerboseAsync()
        {
            JsonRpcResponse<List<AddressResponse>> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Wallet.GetAddressesVerboseAsync();
            }).GetAwaiter().GetResult();

            ResponseLogger<List<AddressResponse>>.Log(response);
        }


        


        [TestMethod]
        public void ImportAddressAsync()
        {
            JsonRpcResponse<List<string>> address = GetAddressesAsync();

            JsonRpcResponse<string> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Wallet.ImportAddressAsync(address.Result[0]);
            }).GetAwaiter().GetResult();

            ResponseLogger<string>.Log(response);
        }


        //[TestMethod]
        //public void ListAddressGroupingsAsync()
        //{
        //    JsonRpcResponse<List<List<List<object>>>> response = null;
        //    Task.Run(async () =>
        //    {
        //        response = await _Client.Wallet.ListAddressGroupingsAsync();
        //    }).GetAwaiter().GetResult();

        //    ResponseLogger<List<List<List<object>>>>.Log(response);

        //}


        //CombineUnspent

        [TestMethod]
        public void ListLockUnspentAsync()
        {
            JsonRpcResponse<List<string>> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Wallet.ListLockUnspentAsync();
            }).GetAwaiter().GetResult();

            ResponseLogger<List<string>>.Log(response);
        }


        [TestMethod]
        public void ListUnspentAsync()
        {
            JsonRpcResponse<List<UnspentResponse>> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Wallet.ListUnspentAsync();
            }).GetAwaiter().GetResult();

            ResponseLogger<List<UnspentResponse>>.Log(response);
        }

        //lockunspent


        [TestMethod]
        public void BackupWalletAsync()
        {
            JsonRpcResponse<string> response = null;
            var path = Path.GetTempFileName();
            Task.Run(async () =>
            {
                response = await _Client.Wallet.BackupWalletAsync(path);
            }).GetAwaiter().GetResult();

            ResponseLogger<string>.Log(response);
        }


        //DumpPrivKeyAsync

        [TestMethod]
        public void DumpWalletAsync()
        {
            JsonRpcResponse<string> response = null;
            var path = Path.GetTempFileName();
            Task.Run(async () =>
            {
                response = await _Client.Wallet.DumpWalletAsync(path);
            }).GetAwaiter().GetResult();

            ResponseLogger<string>.Log(response);
        }

        //EncryptWalletAsync

        [TestMethod]
        public void GetWalletInfoAsync()
        {
            JsonRpcResponse<WalletInfoResponse> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Wallet.GetWalletInfoAsync();
            }).GetAwaiter().GetResult();

            ResponseLogger<WalletInfoResponse>.Log(response);
        }

        //importprivkey

        //importwallet

        //not implemented
        //walletlock

        //not implemented
        //walletpassphrase

        //not implemented
        //walletpassphrasechange

        /// <summary>
        /// this test requires the  GetAccountAddressAsync result and wont work until that test is resolved.
        /// </summary>
        [TestMethod]
        public void GetAddressBalancesAsync(string address)
        {
            JsonRpcResponse<List<AssetBalanceResponse>> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Wallet.GetAddressBalancesAsync(address);
            }).GetAwaiter().GetResult();

            ResponseLogger<List<AssetBalanceResponse>>.Log(response);

            throw new Exception();
        }
        

        [TestMethod]
        public void GetTotalBalancesAsync()
        {
            JsonRpcResponse<List<AssetBalanceResponse>> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Wallet.GetTotalBalancesAsync();
            }).GetAwaiter().GetResult();

            ResponseLogger<List<AssetBalanceResponse>>.Log(response);
        }

        //getwallettransaction

        [TestMethod]
        public void ListAddressTransactionsAsync()
        {
            
            JsonRpcResponse<List<AddressTransactionResponse>> response = null;
            Task.Run(async () =>
            {
                response = await _Client.Wallet.ListAddressTransactionsAsync("1DpvKsVyF37NMGhwowenKKrRT8Hi92HZZT8t9J",10,0,true);
            }).GetAwaiter().GetResult();

            ResponseLogger<List<AddressTransactionResponse>>.Log(response);
        }


       
        //listaddresstransactions
        //listwallettransactions

    }
}