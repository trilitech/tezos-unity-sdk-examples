using RMC.Core.Helpers;
using Cysharp.Threading.Tasks;
using RMC.Core.UI.DialogSystem;
using TezosSDKExamples.View;
using UnityEngine;
using System;
using TezosAPI;
using TezosSDKExamples.Scenes;

#pragma warning disable CS4014, CS1998
namespace TezosSDKExamples.Controllers
{
    /// <summary>
    /// Controller for <see cref="Example01_Authentication"/>
    /// </summary>
    public class Example01_Parent : MonoBehaviour
    {
        //  Events ----------------------------------------


        //  Properties ------------------------------------
        public Example01_View View { get { return _view; } }

        //  Fields ----------------------------------------
        [SerializeField] 
        private Example01_View _view;
        

        //  Unity Methods  --------------------------------
        protected virtual async void Start()
        {
   
            // Header
            _view.HeaderTextFieldUI.IsVisible = true;
            _view.HeaderTextFieldUI.Text.text = "Authentication";
            _view.AuthenticationButtonUI.IsVisible = true;
            _view.AuthenticationButtonUI.Button.onClick.AddListener(() => OnAuthenticateButtonClicked());
            
            // Body
            _view.MainTextPanelUI.BodyTextAreaUI.Text.text = "The <b>Tezos SDK For Unity</b> provides authentication.";
            _view.MainTextPanelUI.IsVisible = true;
            _view.DetailsTextPanelUI.IsVisible = true;
            
            // Footer
            
            // Refresh
            await RefreshUIAsync();
        }


        //  Methods ---------------------------------------
        protected virtual async UniTask RefreshUIAsync()
        {
            // Header
            _view.AuthenticationButtonUI.IsInteractable = true;
            
            // Tezos SDK For Unity
            // Usage: Determines if the user is authenticated
            ITezosAPI tezos = TezosSingleton.Instance;
            bool isAuthenticated = tezos.HasActiveWalletAddress();
            
            // Tezos SDK For Unity
            // Usage: Returns the address of the current active wallet
            string address = tezos.GetActiveWalletAddress();
            
            UIHelper.SetButtonText(
                _view.AuthenticationButtonUI.Button,
                isAuthenticated,
                $"Log Out",
                $"Log In"
            );
            
            // Body
            UIHelper.SetTextAreaUIText(
                _view.DetailsTextPanelUI.BodyTextAreaUI,
                isAuthenticated,
                
                $"You are authenticated with address <b>{address}</b>.\n\n" +
                $"You may click the <b>Log Out</b> button or load a different scene.",
                
                $"You are not authenticated.\n\nYou may click the <b>Log In</b> button."
            );

        }

        
        protected async UniTask ShowDialogAsync(Func<UniTask> transactionCall)
        {
            string dialogTitle = "Authentication";
            
            // Decorate text
            DialogData dialogData = TezosSDKExamplesConstants.CreateNewDialogData(dialogTitle);
            await _view.DialogSystem.ShowDialogAsync(
                dialogData,
                transactionCall,
                async () =>
                {
                    await RefreshUIAsync();
                });
        }

        
        //  Event Handlers --------------------------------
        protected virtual async UniTask OnAuthenticateButtonClicked()
        {
            TezosSDKExamplesHelper.PlayAudioClipClick01();
            await RefreshUIAsync();
        }
        
    }
}

