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
		
		pain = false;
		poulet = false;
		patate = false;
		assietteVide = true;
	}
	
	// Update is called once per frame
	void Update () {

		if(pain == true){

			lePain.SetActive (true);

		}else if(poulet == true){

				lePoulet.SetActive (true);

		}else if(patate == true){

				laPatate.SetActive (true);

		}

		if(pain == false){

			lePain.SetActive (false);

		}else if(poulet == false){

				lePoulet.SetActive (false);

		}else if(patate == false){

				laPatate.SetActive (false);

		}


		
	}
}
