using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChargementJouer : MonoBehaviour 
{
	public void ChargementParIndex(int sceneIndex)
	{
		SceneManager.LoadScene (sceneIndex, LoadSceneMode.Single);
	}
}