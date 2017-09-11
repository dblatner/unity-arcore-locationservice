using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowLocation : MonoBehaviour {

	public GameObject latText;
	public GameObject longText;

	// Update is called once per frame
	void Update () {
		if (Input.location.status == LocationServiceStatus.Running) {
			latText.GetComponent<Text>().text = Input.location.lastData.latitude.ToString();
			longText.GetComponent<Text>().text = Input.location.lastData.longitude.ToString();
		}
	}
}
