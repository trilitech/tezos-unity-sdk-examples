using Cysharp.Threading.Tasks;
using TezosAPI;
using TezosSDKExamples.Controllers;
using UnityEngine;

#pragma warning disable CS4014, CS1998, CS0219
namespace TezosSDKExamples.Scenes
{
    /// <summary>
    /// EXAMPLE: Demonstrates Authentication
    /// </summary>
    public class Example01_Authentication : Example01_Parent
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
            View.AuthenticationQr.IsVisible = false;
            
            // Tezos SDK For Unity
            // Usage: Store reference for convenience
            _tezos = TezosSingleton.Instance;
            
            // Tezos SDK For Unity
            // Usage: Observe events for Tezos Wallet
            _tezos.MessageReceiver.AccountConnected += Tezos_OnAccountConnected;
            _tezos.MessageReceiver.AccountDisconnected += Tezos_AccountDisconnected;
        }


        //  Event Handlers --------------------------------
        protected override async UniTask OnAuthenticateButtonClicked()
        {
            // Required: Render UI
            base.OnAuthenticateButtonClicked();
            base.ShowDialogAsync(async () =>
            {
                
                // Tezos SDK For Unity
                // Usage: Determines if the user is authenticated with Tezos
                if (!_tezos.HasActiveWalletAddress())
                {
                    
                    // Tezos SDK For Unity
                    // Usage: Connect To Wallet Using The Tezos SDK For Unity
                    View.AuthenticationQr.IsVisible = true;
                    View.AuthenticationQr.ShowQrCode();
                    _tezos.ConnectWallet();
                }
                else
                {
                    
                    // Tezos SDK For Unity
                    // Usage: Disconnect From Wallet Using The Tezos SDK For Unity
                    View.AuthenticationQr.IsVisible = true;
                    _tezos.DisconnectWallet();
                }
            });
        }
        
        
        private async void Tezos_OnAccountConnected(string address)
        {
            // Required: Render UI
            await RefreshUIAsync();
            View.AuthenticationQr.IsVisible = false;
            
            // Tezos SDK For Unity
            // Usage: Get the active wallet address
            string activeWalletAddress = _tezos.GetActiveWalletAddress();
            Debug.Log($"You are connected to a wallet with address <b>{activeWalletAddress}</b>.");
        }
        
        
        private async void Tezos_AccountDisconnected(string address)
        {
            // Required: Render UI
            await RefreshUIAsync();
            View.AuthenticationQr.IsVisible = false;
            
            // Optional: Add any custom code here
            Debug.Log($"You are not connected to a wallet.");
        }
    }
}

