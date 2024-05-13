using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainme : MonoBehaviour
{
    public void PlayGame()
	{
		SceneManager. LoadSceneAsync("World");
	}
}

