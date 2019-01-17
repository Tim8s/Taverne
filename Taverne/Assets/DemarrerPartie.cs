using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemarrerPartie : MonoBehaviour {

	public gestionCommande gererCommande;

	public GameObject lumAmbi;
	public GameObject soleil;

	// Use this for initialization
	void Start () {

        gererCommande.ArrayCommande[0].transform.GetChild(1).GetComponent<Image>().sprite = null;
        gererCommande.ArrayCommande[0].transform.GetChild(0).GetComponent<Text>().text = "No";
        gererCommande.NbsCommandeGen = 0;
        gererCommande.IDCommande = 0;

        gererCommande.txtTuto1.SetActive(false);
        gererCommande.txtTuto2.SetActive(false);
        gererCommande.txtTuto3.SetActive(false);
        gererCommande.txtTuto4.SetActive(false);
        gererCommande.txtTuto5.SetActive(false);
        gererCommande.txtTuto6.SetActive(false);

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
