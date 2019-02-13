using UnityEngine;
using System.Collections;

public class MoveObject : MonoBehaviour
{
    public float speed; //Speed of the barricade
    private float x; //x coordinate of the barricade
    public GameObject Player;
    private bool record; //To be able to get point of the player

    //This function is called when the current scene starts to operate
	void Start ()
    {
        Player = GameObject.Find("Player") as GameObject;
	}

    //This function runs per frame (fps-frame per second is changable according to different computers/CPUs)
	void Update ()
    {
        x = transform.position.x; //Assign x as current position
        x = x + speed * Time.deltaTime; //Increase x by speed and per time (per frame)
        transform.position = new Vector3(x, transform.position.y, transform.position.z); //Finalize the position

        if (x <= -7.5) //If the barricade comes out of the sight
        {
            Destroy(transform.gameObject); //Destruct the barricade
        }

        if (x < Player.transform.position.x && record == false) //If the player pass the barricade successfully
        {
            record = true;
            PlayerController.score = PlayerController.score + 10; //Increase the score
        }

        //Increase the speed of the barricades in each 500 points to make the game hard
        if (PlayerController.score >= 250)
        {
            speed = speed + speed * 0.005f;
        }
        if (PlayerController.score >= 500)
        {
            speed = speed + speed * 0.009f;
        }
        if (PlayerController.score >= 750)
        {
            speed = speed + speed * 0.01f;
        }
        if (PlayerController.score >= 1000)
        {
            speed = speed + speed * 0.02f;
        }
        if (PlayerController.score >= 1250)
        {
            speed = speed + speed * 0.04f;
        }
        if (PlayerController.score >= 1500)
        {
            speed = speed + speed * 0.08f;
        }
        if (PlayerController.score >= 1750)
        {
            speed = speed + speed * 0.1f;
        }
        if (PlayerController.score >= 2000)
        {
            speed = speed + speed * 0.15f;
        }
	}
}
