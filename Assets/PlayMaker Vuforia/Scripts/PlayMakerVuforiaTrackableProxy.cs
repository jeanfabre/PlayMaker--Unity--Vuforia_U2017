/*==============================================================================
            Copyright (c) 2010-2014 QUALCOMM Austria Research Center GmbH.
            All Rights Reserved.
            Qualcomm Confidential and Proprietary
==============================================================================*/

// (c) Copyright HutongGames, LLC 2010-2015. All rights reserved.

// original script: DefaultTrackableEventHandler
// modified to fire PlayMaker events.

using UnityEngine;
using HutongGames.PlayMaker;

using Vuforia;

using HutongGames.PlayMaker.Ecosystem.Utils;

/// <summary>
/// A custom handler that implements the ITrackableEventHandler interface to Fire PlayMaker Events.
/// </summary>
[RequireComponent (typeof(TrackableBehaviour))]
public class PlayMakerVuforiaTrackableProxy : MonoBehaviour, ITrackableEventHandler
{

	public static string TrackableFoundPlayMakerEventName = "VUFORIA / TRACKABLE FOUND";
	public static string TrackableLostPlayMakerEventName =  "VUFORIA / TRACKABLE LOST";

    private TrackableBehaviour mTrackableBehaviour;
    
	public PlayMakerEventTarget eventTarget;

	[EventTargetVariable("eventTarget")]
	public PlayMakerEvent trackableFoundEvent = new PlayMakerEvent(TrackableFoundPlayMakerEventName);

	[EventTargetVariable("eventTarget")]
	public PlayMakerEvent trackableLostEvent = new PlayMakerEvent(TrackableLostPlayMakerEventName);
	
	public bool debug;

    void OnEnable()
    {
		// set up global events if needed

        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }else{
			Debug.LogError("PlayMakerVuforiaTrackableProxy required a TrackableBehaviour component",this);
		}
    }
	
	void OnDisable()
	{
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.UnregisterTrackableEventHandler(this);
        }
	}


	/// <summary>
	/// Implementation of the ITrackableEventHandler function called when the
	/// tracking state changes.
	/// </summary>
	public void OnTrackableStateChanged(
		TrackableBehaviour.Status previousStatus,
		TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
		    newStatus == TrackableBehaviour.Status.TRACKED ||
		    newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
		{
			OnTrackingFound();
		}
		else
		{
			OnTrackingLost();
		}
	}


	private void OnTrackingFound()
	{
		if (debug) Debug.Log("sending  "+trackableFoundEvent.ToString()+" to "+eventTarget.ToString(),this);
		trackableFoundEvent.SendEvent(null,eventTarget);
	}
	
	
	private void OnTrackingLost()
	{
		if (debug) Debug.Log("sending  "+trackableLostEvent.ToString()+" to "+eventTarget.ToString(),this);
		trackableLostEvent.SendEvent(null,eventTarget);
	}


	/*
	[ContextMenu("Help")]
	public void help ()
	{
	    Application.OpenURL ("https://hutonggames.fogbugz.com/default.asp?Wxxx");
	}
	*/

}
