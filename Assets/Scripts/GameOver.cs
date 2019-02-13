using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOver : MonoBehaviour
{
    public Text score; //Score of the player
    public Text record; //The high score

	//This function is called when the current scene starts to operate
	void Start ()
    {
        score.text = PlayerPrefs.GetInt("score").ToString(); //Assign the score when the game over
        record.text = PlayerPrefs.GetInt("record").ToString(); //Assign the high score when the game over
	}
	
}
