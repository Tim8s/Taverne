using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemarrerPartie : MonoBehaviour {

	public gestionCommande gererCommande;

	public GameObject lumAmbi;
	public GameObject soleil;

	// Use this for initialization
	void Start () {
		gererCommande.isTuto = false;
		lumAmbi.GetComponent<ScriptLumiereAmbiance> ().enabled = true;
		soleil.GetComponent<ScriptLumiereJour> ().enabled = true;
		StartCoroutine (Destroy ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Destroy(){
		yield return new WaitForSeconds (3);
		gameObject.SetActive (false);
	}
}
