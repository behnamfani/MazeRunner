using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class timer : MonoBehaviour {

    public Text time , time1 , text2;
    public float starttime ,Nowtime;
    public static bool lose = false;
    public int x = 0;


	// Use this for initialization
	void Start () {
        starttime = Time.time;

    }
	
	// Update is called once per frame
	void Update () {

        if (MazeLoader.timeBycoins < 5) x = 3;
        else x = 4;

        Nowtime = Time.time - starttime;
        time1.text = "0:"+(MazeLoader.timeBycoins * x).ToString() + ":00";

        if (PlayerCollision.win && (int)Nowtime <= (MazeLoader.timeBycoins * x))
        {
            text2.color = Color.green;
            text2.text = "YOU WIN !!!";
            return;
        }
            
;
        if ((int)Nowtime == (MazeLoader.timeBycoins * x) && !(PlayerCollision.win))
            finished();

        else if((int)Nowtime <= (MazeLoader.timeBycoins * x))
        {
            string minutes = ((int)Nowtime / 60).ToString();
            string seconds = (Nowtime % 60).ToString("f2");

            time.text = minutes + ":" + seconds;
        }
	}

    private void finished()
    {
        time.color = Color.yellow;
        time.text = "0:" + (MazeLoader.timeBycoins * x).ToString() + ":00";
        text2.color = Color.black;
        text2.text = "YOU LOSE !!!";
        lose = true;
    }
}
