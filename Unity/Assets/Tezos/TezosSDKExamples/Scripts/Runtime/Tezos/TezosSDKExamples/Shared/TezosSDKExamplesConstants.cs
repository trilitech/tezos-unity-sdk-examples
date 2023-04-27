
using RMC.Core.UI.DialogSystem;

namespace TezosSDKExamples
{
    /// <summary>
    /// Constant values
    /// </summary>
    public static class TezosSDKExamplesConstants
    {
        public const string PathMenuItemAssetsCompanyProject = "Assets/" + CompanyName + "/" + ProjectName;
        public const string PathMenuItemWindowCompanyProject = "Window/" + CompanyName + "/" + ProjectName;
        public const string CompanyName = "Tezos";
        public const string ProjectName = "TezosSDKExamples";
        public const int PriorityMenuItem_Examples = 1;

        public const string PleaseVisitAuthenticationSceneMessage =
            "Authentication required. Please visit the <b>Example01_Authentication</b> scene and return here to try again.";

        public static DialogData CreateNewDialogData(string dialogTitle)
        {
            float delaySecondsSending = 0.7f;
            float delaySecondsSent = 0.0f;
            float delaySecondsAwaiting = 0.7f;
                
            return  new DialogData(
                $"~ <b>{dialogTitle}</b> ~\nSending...",
                   $"~ <b>{dialogTitle}</b> ~\nSent...",
                $"~ <b>{dialogTitle}</b> ~\nAwaiting...", 
                delaySecondsSending, 
                delaySecondsSent, 
                delaySecondsAwaiting
            );
        }

    }
}