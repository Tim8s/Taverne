using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CuisinierMenu : MonoBehaviour {

    Scene scene;

	// Use this for initialization
	void Start () {
        scene = SceneManager.GetActiveScene();

    }
	
	// Update is called once per frame
	void Update () {
        if (scene.name == "Scene Menu")
        {
            print("YAY");
        }
	}
}
