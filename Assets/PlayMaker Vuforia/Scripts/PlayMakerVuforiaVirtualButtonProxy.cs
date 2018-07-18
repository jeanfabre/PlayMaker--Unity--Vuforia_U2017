/*==============================================================================
            Copyright (c) 2010-2014 QUALCOMM Austria Research Center GmbH.
            All Rights Reserved.
            Qualcomm Confidential and Proprietary
==============================================================================*/

// (c) Copyright HutongGames, LLC 2010-2015. All rights reserved.


using UnityEngine;
using HutongGames.PlayMaker;

using Vuforia;

using HutongGames.PlayMaker.Ecosystem.Utils;

[RequireComponent (typeof(VirtualButtonBehaviour))]
public class PlayMakerVuforiaVirtualButtonProxy : MonoBehaviour, IVirtualButtonEventHandler {


	private VirtualButtonBehaviour mVirtualButtonBehavior;

	public static string VirtualButtonPressedPlayMakerEventName = "VUFORIA / VIRTUAL BUTTON PRESSED";
	public static string VirtualButtonReleasedPlayMakerEventName =  "VUFORIA / VIRTUAL BUTTON RELEASED";

	
	public PlayMakerEventTarget eventTarget;
	
	[EventTargetVariable("eventTarget")]
	public PlayMakerEvent virtualButtonPressed = new PlayMakerEvent(VirtualButtonPressedPlayMakerEventName);
	
	[EventTargetVariable("eventTarget")]
	public PlayMakerEvent virtualButtonReleased = new PlayMakerEvent(VirtualButtonReleasedPlayMakerEventName);
	
	public bool debug;

	// Use this for initialization
	void OnEnable () {
	
		mVirtualButtonBehavior = this.GetComponent<VirtualButtonBehaviour>();

		if (mVirtualButtonBehavior!=null)
		{
			mVirtualButtonBehavior.RegisterEventHandler(this);
		}

	}

	void OnDisabled()
	{
		mVirtualButtonBehavior = this.GetComponent<VirtualButtonBehaviour>();
		
		if (mVirtualButtonBehavior!=null)
		{
			mVirtualButtonBehavior.UnregisterEventHandler(this);
		}
	}


	public void OnButtonPressed (VirtualButtonBehaviour vb)
	{
		if (debug) Debug.Log("OnButtonPressed ("+vb.VirtualButtonName+") "+virtualButtonPressed.ToString()+" to "+eventTarget.ToString(),this);

		Fsm.EventData.StringData = vb.VirtualButtonName;
		virtualButtonPressed.SendEvent(null,eventTarget);
	}

	public void OnButtonReleased (VirtualButtonBehaviour vb)
	{
		if (debug) Debug.Log("OnButtonPressed ("+vb.VirtualButtonName+") "+virtualButtonReleased.ToString()+" to "+eventTarget.ToString(),this);
		
		Fsm.EventData.StringData = vb.VirtualButtonName;
		virtualButtonReleased.SendEvent(null,eventTarget);
	}
		
}
