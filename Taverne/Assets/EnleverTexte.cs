using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnleverTexte : MonoBehaviour {

	public GameObject txtTuto7;

	// Use this for initialization
	void Start () {
		StartCoroutine (Detruire ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Detruire(){
		yield return new WaitForSeconds (5);
		gameObject.SetActive (false);
		txtTuto7.SetActive (true);
	}
}
