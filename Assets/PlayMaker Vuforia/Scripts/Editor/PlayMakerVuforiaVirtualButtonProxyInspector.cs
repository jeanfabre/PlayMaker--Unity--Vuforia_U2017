using System;
using System.Collections;

using UnityEditor;
using UnityEngine;

using HutongGames.PlayMaker;
using HutongGames.PlayMakerEditor;


[CustomEditor(typeof(PlayMakerVuforiaVirtualButtonProxy))]
public class PlayMakerVuforiaVirtualButtonProxyInspector : UnityEditor.Editor {

	void OnEnable () {
		PlayMakerUtils.CreateIfNeededGlobalEvent(PlayMakerVuforiaVirtualButtonProxy.VirtualButtonPressedPlayMakerEventName);
		PlayMakerUtils.CreateIfNeededGlobalEvent(PlayMakerVuforiaVirtualButtonProxy.VirtualButtonReleasedPlayMakerEventName);
	}

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();	
	}
}