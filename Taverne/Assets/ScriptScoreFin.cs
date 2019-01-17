using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptScoreFin : MonoBehaviour {

    public gestionCommande gererCommande;

    public GameObject ballounes;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Text>().text = gererCommande.score + "";
	}
}
