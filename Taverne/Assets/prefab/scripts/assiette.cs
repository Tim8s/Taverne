using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class assiette : MonoBehaviour {

	public bool pain;
	public bool poulet;
	public bool patate;
	public bool assietteVide;
	public GameObject lePain;
	public GameObject lePoulet;
	public GameObject laPatate;

	// Use this for initialization
	void Start () {
		
		assietteVide = true;
	}
	
	// Update is called once per frame
	void Update () {}

	public void callDisparaitre(){Invoke ("disparaitre", 0.5f);}

	public void callApparaitre(){Invoke ("apparaitre", 0.5f);}

	void disparaitre(){

    	if(pain == false){lePain.SetActive(false);}

    	if(poulet == false){lePoulet.SetActive(false);}

    	if(patate == false){laPatate.SetActive(false);}

    }

    void apparaitre(){

    	if(pain == true){lePain.SetActive(true);}

    	if(poulet == true){lePoulet.SetActive(true);}

    	if(patate == true){laPatate.SetActive(true);}
    }


}
