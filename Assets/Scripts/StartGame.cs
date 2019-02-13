using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour 
{
    //This function runs per frame (fps-frame per second is changable according to different computers/CPUs)
	void Update () 
    {
        if (Input.GetMouseButtonDown(0)) //Start the game play scene by using the left button of the mouse
        {
            Application.LoadLevel("MiniCurso"); //Load the scene called MiniCurso.unity
        }
	}
}
