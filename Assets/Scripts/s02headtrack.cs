using UnityEngine;
using System.Collections;
using System.IO;

public class s02headtrack : MonoBehaviour {
	public KinectInterop.JointType joint = KinectInterop.JointType.Head;
	public float OffsetX;
	public float OffsetY;
	public float OffsetZ;
	public float MultiplyX;
	public float MultiplyY;
	public float MultiplyZ;

	void Update () {
		
		KinectManager manager = KinectManager.Instance;


		
		if(manager && manager.IsInitialized())	
		{
			if(manager.IsUserDetected())
			{
			long userId = manager.GetPrimaryUserID();

					if(manager.IsJointTracked(userId, (int)joint))
					{
						Vector3 jointPos = manager.GetJointPosition(userId, (int)joint);
						float NewOffsetX = jointPos.x*MultiplyX + OffsetX; 
						float NewOffsetY = jointPos.y*MultiplyY + OffsetY;
						//float NewOffsetZ = jointPos.z*MultiplyZ + OffsetZ;
						float NewOffsetZ = OffsetZ;  // no tracking for Z

						transform.position = new Vector3 (NewOffsetX,NewOffsetY,NewOffsetZ);
					}
			}
		}
		
		
		

		/*
		if (manager && manager.IsInitialized())
		{
			if (manager.IsUserDetected())
			{
				long userId = manager.GetPrimaryUserID();

				if (manager.IsJointTracked(userId, (int)KinectInterop.JointType.Head))
				{
					Vector3 headPosition = manager.GetJointPosition(userId, (int)KinectInterop.JointType.Head);
					Quaternion neckRotation = manager.GetJointOrientation(userId, (int)KinectInterop.JointType.Neck, false);

					//Vector3 newPos = new Vector3(headPosition.x * 10, headPosition.y * 10, headPosition.z);

					// do something with the head position and neck orientation
					transform.position = headPosition;
				}
			}
		}
		*/
		
		

	}
}
