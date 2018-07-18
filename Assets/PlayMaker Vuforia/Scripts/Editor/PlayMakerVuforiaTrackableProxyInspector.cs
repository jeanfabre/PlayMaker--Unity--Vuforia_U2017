using System;
using System.Collections;

using UnityEditor;
using UnityEngine;

using HutongGames.PlayMaker;
using HutongGames.PlayMakerEditor;


[CustomEditor(typeof(PlayMakerVuforiaTrackableProxy))]
public class PlayMakerVuforiaTrackableProxyInspector : UnityEditor.Editor {

	void OnEnable () {
		PlayMakerUtils.CreateIfNeededGlobalEvent(PlayMakerVuforiaTrackableProxy.TrackableFoundPlayMakerEventName);
		PlayMakerUtils.CreateIfNeededGlobalEvent(PlayMakerVuforiaTrackableProxy.TrackableLostPlayMakerEventName);
	}

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();	
	}
}
