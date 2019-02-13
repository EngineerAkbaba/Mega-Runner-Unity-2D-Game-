using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour
{
    public GameObject barrieraPrefab; //The barricade game object
    public float rateSpawn; //the appearance frequency of the barricades
    private float currentTime;
    private int position; //The position generation of the barricade
    private float y; //y position of the barricade
    public float posA; //Down position of the baricade
    public float posB; //Up position of the baricade

    //This function is called when the current scene starts to operate
	void Start ()
    {
        currentTime = 0;
	}

    //This function runs per frame (fps-frame per second is changable according to different computers/CPUs)
	void Update ()
    {
        currentTime = currentTime + Time.deltaTime;
        //Generate baricade randommly
        if (currentTime >= rateSpawn)
        {
            currentTime = 0;
            position = Random.Range(1, 100);
            if (position > 50)
            {
                y = posA;
            }
            else
            {
                y = posB;
            }
            GameObject tempPrefab = Instantiate(barrieraPrefab) as GameObject;
            tempPrefab.transform.position = new Vector3(transform.position.x, y, tempPrefab.transform.position.z);
        }
	}
}
