// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;
using Vuforia;
using System;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Vuforia")]
	[Tooltip("Get the ExtendedTracking option for Target.")]

	#if PLAYMAKER_VUFORIA_7_2_20_OR_NEWER
	[Obsolete("ExtendedTracking is now replaced by 'Device Tracker'")]
	#endif
	public class VuforiaGetExtendedTracking : FsmStateAction
	{

		[Tooltip("The Target to check (must have IEditDataSetBehaviour interface")]
		public FsmOwnerDefault GameObject;

		[UIHint(UIHint.Variable)]
		[Tooltip("")]
		public FsmBool extendedTracking;

		public FsmEvent extendedTrackingEnabled;
		public FsmEvent extendedTrackingDisabled;

		public FsmEvent Error;

		GameObject _owner;
		GameObject _goTarget;

		#if !PLAYMAKER_VUFORIA_7_2_20_OR_NEWER
		IEditDataSetBehaviour _target;
		#endif

		int value = -1;

		public override void Reset()
		{
			GameObject = null;
			extendedTracking = null;
			extendedTrackingEnabled = null;
			extendedTrackingDisabled = null;
			Error = null;
		}
		
		public override void OnEnter()
		{

			ExecuteAction ();
		}

		public override void OnUpdate ()
		{
			ExecuteAction ();
		}
			
		void ExecuteAction()
		{
			#if !PLAYMAKER_VUFORIA_7_2_20_OR_NEWER
			_owner = Fsm.GetOwnerDefaultTarget (GameObject);

			if (_goTarget != _owner ) {
				_goTarget = _owner;
				if (_goTarget == null) {
					_target = null;
				} else{
					_target = _goTarget.GetComponent<IEditDataSetBehaviour> ();
				}

				if (_target == null) {
					Fsm.Event (Error);
				}

			}
				
			if (_target == null) {
				return;
			}

			if (!extendedTracking.IsNone) {
				extendedTracking.Value = _target.ExtendedTracking;
			}

			if (value == -1 || value == 1 != _target.ExtendedTracking) {
				value = _target.ExtendedTracking?1:0;
				if (value == 1) {
					Fsm.Event (extendedTrackingEnabled);
				}
				if (value == 0) {
					Fsm.Event (extendedTrackingDisabled);
				}
			}
			#endif
		}
		
		
	}
}