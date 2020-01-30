using System.Collections; 
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour {
    public  AudioSource audio;
    public Text coins;
    int collisionNumber ;
    public static bool win = false;
    void Start()
    {
        audio = GetComponent<AudioSource> ();
        collisionNumber = 1;
    }
    void OnTriggerEnter(Collider other)
    {
        if (timer.lose)
            return;

        if (other.gameObject.tag == "Coin")
        {
            coins.text = collisionNumber.ToString();
            Destroy(other.gameObject);
            audio.Play();
            if (collisionNumber == MazeLoader.NumberOfcoins)
                win = true;

            collisionNumber = collisionNumber + 1;
            
        }
            
    }
}
