using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using TezosAPI;
using TezosSDKExamples.Controllers;
using UnityEngine;

#pragma warning disable CS4014, CS1998, CS0219
namespace TezosSDKExamples.Scenes
{
    /// <summary>
    /// EXAMPLE: Demonstrates NFT Token Gating 
    /// </summary>
    public class Example02_NFTTokenGating : Example02_Parent
    {
        //  Fields ----------------------------------------
        
        // Tezos SDK For Unity
        // Usage: Store reference to Tezos SDK For Unity
        private ITezosAPI _tezos;
        
        //  Methods ---------------------------------------
        
        protected override async void Start()
        {
            // Required: Render UI
            base.Start();
            
            // Tezos SDK For Unity
            // Usage: Store reference for convenience
            _tezos = TezosSingleton.Instance;
            
            // Tezos SDK For Unity
            // Usage: Observe events for Tezos Wallet
            _tezos.MessageReceiver.AccountConnected += Tezos_OnAccountConnected;
            _tezos.MessageReceiver.AccountDisconnected += Tezos_AccountDisconnected;
        }


        //  Event Handlers --------------------------------
        
        private async void Tezos_OnAccountConnected(string address)
        {
            // Required: Render UI
            await RefreshUIAsync();
            
            // Tezos SDK For Unity
            // Usage: Get the active wallet address
            string activeWalletAddress = _tezos.GetActiveWalletAddress();
            Debug.Log($"You are connected to a wallet with address '{activeWalletAddress}'.");
        }
        
        
        private async void Tezos_AccountDisconnected(string address)
        {
            // Required: Render UI
            await RefreshUIAsync();
            
            // Optional: Add any custom code here
            Debug.Log($"You are not connected to a wallet.");
        }
        
        protected override async UniTask OnCheckForNft01ButtonClicked()
        { 
            // Required: Render UI
            base.OnCheckForNft01ButtonClicked();
            
            // Setup
            string activeWalletAddress = _tezos.GetActiveWalletAddress();
            string demoNFTAddress = "KT1BRADdqGk2eLmMqvyWzqVmPQ1RCBCbW5dY";
            int demoTokenId = 1;
            
            // Display Dialog
            bool hasTheNft = false;
            await ShowDialogAsync("Check For NFT", async () =>
            {
                
                // Tezos SDK For Unity
                // Usage: Determines if the user account owns a given Nft
                hasTheNft = await _tezos.IsOwnerOfToken(
                    activeWalletAddress, 
                    demoNFTAddress, 
                    demoTokenId);
                
            });
        
            // Display Result
            string result = "";
            if (hasTheNft)
            {
                result = $"The wallet address <b>{activeWalletAddress}</b> has " +
                         $"the NFT with address <b>{demoNFTAddress}</b> and tokenId <b>{demoTokenId}</b>.\n\n";
            }
            else
            {
                result = $"The wallet address <b>{activeWalletAddress}</b> does NOT have " +
                         $"the NFT with address <b>{demoNFTAddress}</b> and tokenId <b>{demoTokenId}</b>.\n\n";
            }

            // Required: Render UI
            View.DetailsTextPanelUI.BodyTextAreaUI.Text.text = result;
            base.RefreshUIAsync();
        }

        protected override async UniTask OnCheckForNft02ButtonClicked()
        { 
            // Required: Render UI
            base.OnCheckForNft02ButtonClicked();
            
            // Setup
            string demoWalletAddress = "tz1TiZ74DtsT74VyWfbAuSis5KcncH1WvNB9";
            string demoNFTAddress = "KT1BRADdqGk2eLmMqvyWzqVmPQ1RCBCbW5dY";
            int demoTokenId = 1;
            
            // Display Dialog
            bool hasTheNft = false;
            await ShowDialogAsync("Check For NFT", async () =>
            {
                
                // Tezos SDK For Unity
                // Usage: Determines if the user account owns a given Nft
                hasTheNft = await _tezos.IsOwnerOfToken(
                    demoWalletAddress, 
                    demoNFTAddress, 
                    demoTokenId);
                
            });
        
            // Display Result
            string result = "";
            if (hasTheNft)
            {
                result = $"The wallet address <b>{demoWalletAddress}</b> has " +
                         $"the NFT with address <b>{demoNFTAddress}</b> and tokenId <b>{demoTokenId}</b>.\n\n";
            }
            else
            {
                result = $"The wallet address <b>{demoWalletAddress}</b> does NOT have " +
                         $"the NFT with address <b>{demoNFTAddress}</b> and tokenId <b>{demoTokenId}</b>.\n\n";
            }

            // Required: Render UI
            View.DetailsTextPanelUI.BodyTextAreaUI.Text.text = result;
            base.RefreshUIAsync();
        }
        
        protected override async UniTask OnListAllNftsButtonClicked()
        {
            // Required: Render UI
            base.OnListAllNftsButtonClicked();
            
            // Setup
            string demoWalletAddress = "tz2U7C8cf4W5Qw6onYjF8QLhnh5hMRbrrDon";
            
            // Display Dialog
            List<TokenBalance> tokenBalances = new List<TokenBalance>();
            await ShowDialogAsync("List All NFTs", async () =>
            {
                
                // Tezos SDK For Unity
                // Usage: Gets all tokens owned by the authenticated user account
                tokenBalances = await _tezos.GetAllTokensForOwner(demoWalletAddress);
                
            });
        
            // Display Result
            string result = $"The wallet address <b>{demoWalletAddress}</b> has {tokenBalances.Count} NFTs.\n\n";

            foreach (TokenBalance tokenBalance in tokenBalances)
            {
                // Tezos SDK For Unity
                // Usage: Fetch rich data within each tokenBalance object
                result += $" • tokenId = {tokenBalance.tokenId}, balance = {tokenBalance.balance}\n";
            }

            // Required: Render UI
            View.DetailsTextPanelUI.BodyTextAreaUI.Text.text = result;
            base.RefreshUIAsync();
        }
    }
}

