using Cysharp.Threading.Tasks;
using Scripts.Tezos;
using Scripts.Tezos.Wallet;
using TezosSDKExamples.Controllers;
using TezosSDKExamples.Shared.Tezos;
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
        // Usage: Store reference for convenience
        private ITezos _tezos;
        
        
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
            _tezos.Wallet.MessageReceiver.HandshakeReceived += OnHandshakeReceived;
            _tezos.Wallet.MessageReceiver.AccountConnected += OnAccountConnected;
            _tezos.Wallet.MessageReceiver.AccountDisconnected += AccountDisconnected;
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
                    _tezos.Wallet.Connect(WalletProviderType.kukai);
                }
                else
                {
                    
                    // Tezos SDK For Unity
                    // Usage: Disconnect From Wallet Using The Tezos SDK For Unity
                    View.AuthenticationQr.IsVisible = true;
                    _tezos.Wallet.Disconnect();
                }
            });
        }
        
        
        private async void OnAccountConnected(string address)
        {
            // Required: Render UI
            await RefreshUIAsync();
            View.AuthenticationQr.IsVisible = false;
                    
            // Tezos SDK For Unity
            // Usage: Get the active wallet address
            string activeWalletAddress = _tezos.Wallet.GetActiveAddress();
            Debug.Log($"You are connected to a wallet with address <b>{activeWalletAddress}</b>.");
        }
        
        
        private async void AccountDisconnected(string address)
        {
            // Required: Render UI
            await RefreshUIAsync();
            View.AuthenticationQr.IsVisible = false;
            
            // Optional: Add any custom code here
            Debug.Log($"You are not connected to a wallet.");
        }
        
        private async void OnHandshakeReceived(string handshake)
        {

        }
    }
}

