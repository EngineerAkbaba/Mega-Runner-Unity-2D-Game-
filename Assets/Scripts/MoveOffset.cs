using UnityEngine;
using System.Collections;

public class MoveOffset : MonoBehaviour
{
    public float speed; //The speed of the background and the floor
    private float offSet; //The balance of background and the floor on the screen
    private Renderer rend; //Renderer component of the background and the floor
    //(The Mesh Renderer takes the geometry from the Mesh Filter and renders it at the position defined by the object’s Transform component.)

    //This function is called when the current scene starts to operate
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    //This function runs per frame (fps-frame per second is changable according to different computers/CPUs)
    void Update()
    {
        offSet += speed * Time.deltaTime; //Update the offSet
        rend.material.mainTextureOffset = new Vector2(offSet, 0); //Vector2 generates a new vector including x and y components
    }
}