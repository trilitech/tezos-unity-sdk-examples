using RMC.Core.UI;
using TezosSDKExamples.Scenes;
using UnityEngine;

#pragma warning disable CS1998
namespace TezosSDKExamples.View
{
    /// <summary>
    /// UI for <see cref="Example02_NFTTokenGating"/>
    /// </summary>
    public class Example02_View : Scene_BaseView
    {
        //  Events ----------------------------------------

        //  Properties ------------------------------------

        public ButtonUI CheckForNft01ButtonUI { get { return _checkForNft01ButtonUI;} }
        public ButtonUI CheckForNft02ButtonUI { get { return _checkForNft02ButtonUI;} }
        public ButtonUI ListAllNftsButtonUI { get { return _listAllNftsButtonUI;} }
        
        //  Fields ----------------------------------------
        [Header("Child")]

        [SerializeField]
        private ButtonUI _checkForNft01ButtonUI;

        [SerializeField]
        private ButtonUI _checkForNft02ButtonUI;

        [SerializeField]
        private ButtonUI _listAllNftsButtonUI;

        //  Unity Methods  --------------------------------
        protected override async void Awake()
        {
            base.Awake();
        }
        
        protected override async void Start()
        {
            base.Start();
        }

        //  Methods ---------------------------------------

        //  Event Handlers --------------------------------
    }
}