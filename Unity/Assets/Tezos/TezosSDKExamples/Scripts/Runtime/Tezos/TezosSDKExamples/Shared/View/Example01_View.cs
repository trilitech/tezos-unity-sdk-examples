
using TezosSDKExamples.Scenes;
using TezosSDKExamples.Shared;
using UnityEngine;

#pragma warning disable CS1998
namespace TezosSDKExamples.View
{
    /// <summary>
    /// UI for <see cref="Example01_Authentication"/>
    /// </summary>
    public class Example01_View : Scene_BaseView
    {
        //  Events ----------------------------------------

        //  Properties ------------------------------------
        public AuthenticationQr AuthenticationQr { get { return _authenticationQr;} }
        
        //  Fields ----------------------------------------
        [Header("Tezos SDK For Unity")]
        [SerializeField]
        private AuthenticationQr _authenticationQr;

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