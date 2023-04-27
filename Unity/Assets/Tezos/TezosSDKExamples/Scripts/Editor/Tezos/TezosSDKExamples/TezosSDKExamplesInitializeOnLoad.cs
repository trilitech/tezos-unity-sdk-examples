using RMC.Core.ReadMe;
using UnityEditor;

namespace TezosSDKExamples
{
	/// <summary>
	/// Automatically Load <see cref="ReadMe"/> when Unity opens
	/// </summary>
	
	[InitializeOnLoad]
	public static class TezosSDKExamplesInitializeOnLoad
	{
		//  Properties ------------------------------------

		
		//  Fields ----------------------------------------
		private static readonly string HasShownReadMe = "TezosSDKExamples.HasShownReadMe";
		
		//  Other Methods ---------------------------------
		static TezosSDKExamplesInitializeOnLoad()
		{
			if (!SessionState.GetBool(HasShownReadMe, false))
			{
				EditorApplication.update += WaitOneFrame;
			}
		}
		

		private static void WaitOneFrame()
		{
			EditorApplication.update -= WaitOneFrame;
			ReadMeHelper.SelectReadmes();
			SessionState.SetBool(HasShownReadMe, true);
		}
	}
}
