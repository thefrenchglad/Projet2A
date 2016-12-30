using UnityEngine;
using System.Collections;

public class ScreenSize : MonoBehaviour {

	[SerializeField] private int height;
	[SerializeField] private int width;
	// Use this for initialization
	void Update () {
		height = Screen.height;
		width = Screen.width;

		gameObject.GetComponent<RectTransform> ().sizeDelta = new Vector2(width,height);

	}
	

}
