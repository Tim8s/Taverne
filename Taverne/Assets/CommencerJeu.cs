using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CommencerJeu : MonoBehaviour {
	public GameObject camera;
	public GameObject camera1;
	public GameObject camera2;
	public GameObject Texte;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Commencer(){
		StartCoroutine (DebutCine ());
	}
	void fadeOutText(){
		Texte.GetComponent<Button> ().enabled = false;
		Texte.GetComponent<Text> ().CrossFadeAlpha (0, 0.2f, true);
	}

	IEnumerator DebutCine()
	{
		fadeOutText ();
		Destroy (camera2);
		camera1.SetActive (true);
		yield return new WaitForSeconds(5);
		Destroy (camera1);
		camera.SetActive (true);

        yield return new WaitForSeconds(2.65f);

        SceneManager.LoadScene(1);
	}
}
