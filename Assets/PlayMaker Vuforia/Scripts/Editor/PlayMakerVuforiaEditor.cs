// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.

using UnityEngine;
using UnityEditor;

using Vuforia;
using HutongGames.PlayMaker.Ecosystem.utils;

[InitializeOnLoad]
public class PlayMakerVuforiaEditor
{

    static PlayMakerVuforiaEditor()
    {
		CheckAndUpdateVersionIfNeeded ();
    }
		
	const string PLAYMAKER_VUFORIA_PRIOR_7_2 = "PLAYMAKER_VUFORIA_PRIOR_7_2";
	const string PLAYMAKER_VUFORIA_7_2_20_OR_NEWER = "PLAYMAKER_VUFORIA_7_2_20_OR_NEWER";

	/// <summary>
	/// mount or unmount a dedicated symbol for legacy vuforia support
	/// </summary>
	static void CheckAndUpdateVersionIfNeeded()
	{

		VersionInfo _version = new VersionInfo(VuforiaUnity.GetVuforiaLibraryVersion());
		VersionInfo _7_2_20_Version = new VersionInfo("7.2.20");

		#if PLAYMAKER_VUFORIA_7_2_20_OR_NEWER

			if (_version < _7_2_20_Version)
			{
				PlayMakerEditorUtils.UnMountScriptingDefineSymbolToAllTargets(PLAYMAKER_VUFORIA_7_2_20_OR_NEWER);
			}

		#else

			if (_version >= _7_2_20_Version)
			{
				PlayMakerEditorUtils.MountScriptingDefineSymbolToAllTargets(PLAYMAKER_VUFORIA_7_2_20_OR_NEWER);
			}
			

		#endif

		#if PLAYMAKER_VUFORIA_PRIOR_7_2

		if (_version >= _7_2_20_Version)
		{
			PlayMakerEditorUtils.UnMountScriptingDefineSymbolToAllTargets(PLAYMAKER_VUFORIA_PRIOR_7_2);
		}

		#else

		if (_version < _7_2_20_Version)
		{
			PlayMakerEditorUtils.MountScriptingDefineSymbolToAllTargets(PLAYMAKER_VUFORIA_PRIOR_7_2);
		}


		#endif


	}
}