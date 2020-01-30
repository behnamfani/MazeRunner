using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotatecoin : MonoBehaviour {
    public GameObject coin;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        coin.transform.Rotate(0,0, 140 * Time.deltaTime);
	}
}
