using RMC.Core.Helpers;
using Cysharp.Threading.Tasks;
using RMC.Core.UI.DialogSystem;
using TezosSDKExamples.View;
using UnityEngine;
using System;
using TezosSDKExamples.Scenes;
using TezosSDKExamples.Shared.Tezos;
using Scripts.Tezos;

#pragma warning disable CS4014, CS1998, CS0219
namespace TezosSDKExamples.Controllers
{
    /// <summary>
    /// Controller for <see cref="Example02_NFTTokenGating"/>
    /// </summary>
    public class Example02_Parent : MonoBehaviour
    {
        //  Events ----------------------------------------


        //  Properties ------------------------------------
        protected Example02_View View { get { return _view;}}

        
        //  Fields ----------------------------------------
        [SerializeField] 
        private Example02_View _view;
        

        //  Unity Methods  --------------------------------
        protected virtual async void Start()
        {
            // Header
            _view.HeaderTextFieldUI.IsVisible = true;
            _view.HeaderTextFieldUI.Text.text = "NFT Token Gating";
            
            // Body
            _view.MainTextPanelUI.IsVisible = true;
            _view.DetailsTextPanelUI.BodyTextAreaUI.Text.text = "Click any button below.";
            
            // Footer
            _view.CheckForNft01ButtonUI.Text.text = "Check For NFT\n<size=30>(Current User)</size>";
            _view.CheckForNft02ButtonUI.Text.text = "Check For NFT\n<size=30>(Demo User)</size>";
            _view.ListAllNftsButtonUI.Text.text = "List All NFTs\n<size=30>(Demo User)</size>";
            _view.CheckForNft01ButtonUI.Button.onClick.AddListener(() => OnCheckForNft01ButtonClicked());
            _view.CheckForNft02ButtonUI.Button.onClick.AddListener(() => OnCheckForNft02ButtonClicked());
            _view.ListAllNftsButtonUI.Button.onClick.AddListener( () => OnListAllNftsButtonClicked());
                
            await RefreshUIAsync();
        }


        //  Methods ---------------------------------------
        protected virtual async UniTask RefreshUIAsync()
        {
            // Tezos SDK For Unity
            // Usage: Determines if the user is authenticated
            ITezos tezos = TezosSingleton.Instance;
            bool isAuthenticated = tezos.HasActiveWalletAddress();
            
            
            // Body
            if (isAuthenticated)
            {
                _view.MainTextPanelUI.BodyTextAreaUI.Text.text = "The <b>Tezos SDK For Unity</b> provides NFT functionality.";
            }
            else
            {
                _view.MainTextPanelUI.BodyTextAreaUI.Text.text =
                    TezosSDKExamplesConstants.PleaseVisitAuthenticationSceneMessage;
            }
            

            // Footer
            _view.DetailsTextPanelUI.IsVisible = isAuthenticated;
            _view.CheckForNft01ButtonUI.IsVisible = isAuthenticated;
            _view.CheckForNft02ButtonUI.IsVisible = isAuthenticated;
            _view.ListAllNftsButtonUI.IsVisible = isAuthenticated;
            _view.CheckForNft01ButtonUI.IsInteractable = isAuthenticated;
            _view.DetailsTextPanelUI.BodyTextAreaUI.IsVisible = isAuthenticated;
            _view.ListAllNftsButtonUI.IsInteractable = isAuthenticated;
        }

        protected async UniTask ShowDialogAsync(string dialogTitle, Func<UniTask> transactionCall)
        {
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

        
        protected virtual async UniTask OnCheckForNft01ButtonClicked()
        {
            // Required: Render UI
            TezosSDKExamplesHelper.PlayAudioClipClick01();
            View.DetailsTextPanelUI.BodyTextAreaUI.Text.text = "";
            await RefreshUIAsync();
        }
        
        protected virtual async UniTask OnCheckForNft02ButtonClicked()
        {
            // Required: Render UI
            TezosSDKExamplesHelper.PlayAudioClipClick01();
            View.DetailsTextPanelUI.BodyTextAreaUI.Text.text = "";
            await RefreshUIAsync();
        }
        
        protected virtual async UniTask OnListAllNftsButtonClicked()
        {
            // Required: Render UI
            TezosSDKExamplesHelper.PlayAudioClipClick01();
            View.DetailsTextPanelUI.BodyTextAreaUI.Text.text = "";
            await RefreshUIAsync();
        }
    }
}

