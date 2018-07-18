// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;
using Vuforia;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Vuforia")]
	[Tooltip("Enable or Disable the PersistExtendeTracking option for ObjectTracker.")]
	public class VuforiaSetPersistExtendedTracking : FsmStateAction
	{

		[RequiredField]
		public FsmBool persistExtendedTracking;

		
		public override void Reset()
		{
			persistExtendedTracking = true;
		}
		
		public override void OnEnter()
		{

			ObjectTracker tracker = TrackerManager.Instance.GetTracker<ObjectTracker>();

			if (tracker!=null)
			{
				tracker.PersistExtendedTracking ( persistExtendedTracking.Value );
			}

			Finish();	

		}

		
		
		
	}
}