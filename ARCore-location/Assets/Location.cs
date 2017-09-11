using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Location : MonoBehaviour {

	// aktuelle Position, 2D Winkelkoordinaten
	public static float latitude;
	public static float longitude;

	// Use this for initialization
	IEnumerator Start () {

		if (!Input.location.isEnabledByUser) {
	 		print ("LocationService not available, aborting!");
			yield break;
		}

		// Start service before querying location
		Input.location.Start();
		// Wait until service initializes
		int waitTime = 20;
		while (Input.location.status == LocationServiceStatus.Initializing && waitTime > 0) {
			yield return new WaitForSeconds(1);
			waitTime--;
		}
		// Service didn't initialize in 20 seconds
		if (waitTime < 1) {
			print("LocationService timed out!");
			yield break;
		}
		// Connection has failed
		if (Input.location.status == LocationServiceStatus.Failed) {
			print("Unable to determine device location");
			yield break;
		} else {
			// Access granted and location value could be retrieved
			longitude = Input.location.lastData.longitude;
			latitude = Input.location.lastData.latitude;
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.location.status == LocationServiceStatus.Running) {
			longitude = Input.location.lastData.longitude;
			latitude = Input.location.lastData.latitude;
		}
	}

	IEnumerator OnApplicationPause(bool pauseState){
		if (pauseState) {
			Input.location.Stop ();
		} else {
			// Start service before querying location
			Input.location.Start();
			// Wait until service initializes
			int waitTime = 20;
			while (Input.location.status == LocationServiceStatus.Initializing && waitTime > 0) {
				yield return new WaitForSeconds(1);
				waitTime--;
			}
			// Service didn't initialize in 20 seconds
			if (waitTime < 1) {
				print("LocationService timed out!");
				yield break;
			}
			// Connection has failed
			if (Input.location.status == LocationServiceStatus.Failed) {
				print("Unable to determine device location");
				yield break;
			} else {
				// Access granted and location value could be retrieved
				longitude = Input.location.lastData.longitude;
				latitude = Input.location.lastData.latitude;
			}
		}
	}
} 
