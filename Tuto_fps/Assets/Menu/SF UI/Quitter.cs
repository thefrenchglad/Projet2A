using System.Collections;
using UnityEngine;

public class Quitter : MonoBehaviour
{
	public void quit()
	{
		#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
		#else
			Application.Quit ();
		#endif
	}
}
