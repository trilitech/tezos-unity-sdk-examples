using RMC.Core.ReadMe;
using UnityEditor;

namespace TezosSDKExamples
{
	public static class TezosSDKExamplesMenuItems
	{
		//  Properties ------------------------------------

        
		//  Fields ----------------------------------------
		
		[MenuItem( TezosSDKExamplesConstants.PathMenuItemWindowCompanyProject + "/" + "Open ReadMe", 
			false,
						TezosSDKExamplesConstants.PriorityMenuItem_Examples)]
		public static void SelectReadmes()
		{
			ReadMeHelper.SelectReadmes();
		}
		
	}
}
