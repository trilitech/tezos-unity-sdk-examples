using System.Collections.Generic;
using RMC.Core.Components;
using RMC.Core.UI;
using RMC.Core.UI.DialogSystem;
using RMC.Core.UI.VisualTransitions;
using UnityEngine;
using System.Linq;
using RMC.Core.Interfaces;

#pragma warning disable CS1998
namespace TezosSDKExamples.View
{
    /// <summary>
    /// UI parent
    /// </summary>
    public class Scene_BaseView : MonoBehaviour
    {
        //  Events ----------------------------------------

        //  Properties ------------------------------------
        public TextFieldUI HeaderTextFieldUI { get { return _headerTextFieldUI;} }
        public ButtonUI AuthenticationButtonUI { get { return _authenticationButtonUI;} }
        public TextAreaPanelUI MainTextPanelUI { get { return _mainTextPanelUI;} }
        public TextAreaPanelUI DetailsTextPanelUI { get { return _detailsTextPanelUI;} }
        
        public DialogSystem DialogSystem { get { return _dialogSystem;} }
        public IVisualTransitionTarget SceneVisualTransitionTargetPrefab { get { return _sceneVisualTransitionTargetPrefab;} }
        public VisualTransition SceneVisualTransition { get { return _sceneVisualTransition;} }
        public SceneController SceneController { get { return _sceneController;} }
        
        //  Fields ----------------------------------------
        [Header("Base")]
        
        [SerializeField]
        private TextFieldUI _headerTextFieldUI;

        [SerializeField]
        private ButtonUI _authenticationButtonUI;

        [SerializeField]
        private TextAreaPanelUI _mainTextPanelUI;
        
        [SerializeField]
        private TextAreaPanelUI _detailsTextPanelUI;

        [SerializeField]
        private DialogSystem _dialogSystem;

        [SerializeReference]
        private VisualTransitionTarget _sceneVisualTransitionTargetPrefab;

        [SerializeField]
        private VisualTransition _sceneVisualTransition;
        private SceneController _sceneController = new SceneController();
        
        //  Unity Methods  --------------------------------
        protected virtual async void Awake()
        {
            // Turn UI elements invisible so we have less boilerplate.
            // Each scene must set visible as needed
            List<IIsVisible> components = gameObject.GetComponentsInChildren<Component>(true)
                .OfType<IIsVisible>().ToList();
            
            foreach (IIsVisible iIsVisible in components)
            {
                iIsVisible.IsVisible = false;  
            }
            
            // Set only the MOST common text values. Children can overwrite if desired.
            MainTextPanelUI.HeaderTextFieldUI.Text.text = "Main";
            DetailsTextPanelUI.HeaderTextFieldUI.Text.text = "Details";
            
        }

        
        protected virtual async void Start()
        {
            _sceneController.Initialize(_sceneVisualTransition, _sceneVisualTransitionTargetPrefab);
        }


        //  Methods ---------------------------------------

        //  Event Handlers --------------------------------
    }
}