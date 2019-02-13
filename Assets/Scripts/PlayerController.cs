using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public Animator anime; //To attacah the animations to do animator
    public Rigidbody2D playerRigidbody; //Basic physics rules of the player
    public int forceJump; //The force to jump the player from the ground
    public bool slide; //Is the player sliding or not
    public bool grounded; //Is the player on the ground or not
    public LayerMask whatIsGround; //Control the ground
    public Transform GroundCheck; //Check the ground

    //Slide
    public float slideTemp;
    public float timeTemp;

    public Transform colisor; //Collider component of the eplayer

    //Audio components
    public AudioSource audio;
    public AudioClip audioJump;
    public AudioClip audioSlide;

    public static int score; //Score of the player
    public Text txtScore; //The UI component of the score

    //This function is called when the current scene starts to operate
	void Start ()
    {
        score = 0;
        PlayerPrefs.SetInt("score", score);
        
	}

    //This function runs per frame (fps-frame per second is changable according to different computers/CPUs)
	void Update ()
    {
        txtScore.text = score.ToString();
        grounded = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, whatIsGround); //Check if it is on the ground by using Physics component

        if (Input.GetMouseButtonDown(0) && grounded == true) //Use left button of the mouse for jumping
        {
            playerRigidbody.AddForce(new Vector2(0, forceJump)); //Don't go towards x, but go toward y as much as forceJump
            audio.PlayOneShot(audioJump); //Play a different sound for jumping
            audio.volume = 1; //Set the volume of the audio source

            if (slide == true) //If the player is sliding, then bounce (jump) it immediatelly
            {
                colisor.position = new Vector3(colisor.position.x, colisor.position.y + 0.3f, colisor.position.z);
                slide = false;
            }
            
        }
        if (Input.GetMouseButtonDown(1) && grounded == true && slide == false) //Use right button of the mouse for sliding
        {
            audio.PlayOneShot(audioSlide); //Play a different sound for sliding
            audio.volume = 0.5f; //Set the volue of the audio source
            colisor.position = new Vector3(colisor.position.x, colisor.position.y - 0.3f, colisor.position.z);
            slide = true;
            timeTemp = 0;
        }

        if (slide == true) //If the player is sliding, the do increase the time of the sliding 
        {
            timeTemp = timeTemp + Time.deltaTime;
            if (timeTemp >= slideTemp)
            {
                colisor.position = new Vector3(colisor.position.x, colisor.position.y + 0.3f, colisor.position.z);
                slide = false;
            }
        }

        anime.SetBool("jump", !grounded); //Set the jump animation on the animator tab
        anime.SetBool("slide", slide); //Set the slide animation on the animator tab
	}

    void OnTriggerEnter2D() //If the player crash to any barricade 
    {
        PlayerPrefs.SetInt("score", score);
        if (score > PlayerPrefs.GetInt("record")) //If the score of the player is greater than the high score
        {
            PlayerPrefs.SetInt("record", score); //Reassign the high score
        }
        Application.LoadLevel("GameOver"); //Finish the game playing scene and load the GameOver scene
    }
}
