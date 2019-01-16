using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BarMan : MonoBehaviour {

  //référence a l'animator du hero
	Animator BarManAnim;
  //référence au rigidbody du hero
	Rigidbody BarManRigid;
  //ajuste la vitesse de marche
    public float vitesseMarche;
  //ajuste la vitesse latérale
    public float vitesseMarcheCoter;
  //ajuste la vitesse de la course
    public float vitesseCourse;
  //permet de faire tomber le personnage
    public float forceGravite;

    //Use this for initialization
    void Start () {
        
	  //va chercher ce qu'on a besoin pour le début
		BarManAnim = GetComponent<Animator>();

      //va chercher ce qu'on a besoin pour le début
		BarManRigid = GetComponent<Rigidbody>();

	}
	
  //Update is called once per frame
	void Update () {}

    void FixedUpdate () {

		 BarManAnim.SetBool("marche", false);

		if(Input.GetKey(KeyCode.DownArrow)){

			BarManAnim.SetBool("marche", true);
			transform.eulerAngles = new Vector3(0, 180, 0);
			
			if(Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow)){

				transform.eulerAngles = new Vector3(0, 135, 0);
			}

			if(Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow)){

				transform.eulerAngles = new Vector3(0, 225, 0);
				}
		}

		else if(Input.GetKey(KeyCode.UpArrow)){

			BarManAnim.SetBool("marche", true);
			transform.eulerAngles = new Vector3(0, 0, 0);

			if(Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow)){

				transform.eulerAngles = new Vector3(0, 45, 0);
			}

			if(Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow)){

				transform.eulerAngles = new Vector3(0, -45, 0);
				}
		}

		else if(Input.GetKey(KeyCode.LeftArrow)){

			BarManAnim.SetBool("marche", true);
			transform.eulerAngles = new Vector3(0, -90, 0);

			if(Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow)){

				transform.eulerAngles = new Vector3(0, -45, 0);
			}

			if(Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow)){

				transform.eulerAngles = new Vector3(0, -135, 0);
				}
		}

		else if(Input.GetKey(KeyCode.RightArrow)){

			BarManAnim.SetBool("marche", true);
			transform.eulerAngles = new Vector3(0, 90, 0);

			if(Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow)){

				transform.eulerAngles = new Vector3(0, 45, 0);
			}

			if(Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow)){

				transform.eulerAngles = new Vector3(0, 135, 0);
				}
		}

		if(BarManAnim.GetBool("marche") == true){

		   BarManRigid.AddRelativeForce(0, 0, vitesseMarche);
		   BarManRigid.AddForce(0, forceGravite, 0);

		}

		//si cette touche est maintenu, le perso va courrir
		if (Input.GetKey(KeyCode.LeftShift) && BarManAnim.GetBool("marche") == true /* || Input.GetAxis("LT") != 0*/){

            BarManAnim.SetBool("course", true);
			BarManRigid.AddRelativeForce(0, 0, vitesseCourse);}//fin du if

	  //sinon il arrêtte de courrir
		else{BarManAnim.SetBool("course", false);}//fin du else

	    if(Input.GetKeyDown(KeyCode.Keypad1)){BarManAnim.SetTrigger("prendre");}

	    if(Input.GetKeyDown(KeyCode.Keypad0)){BarManAnim.SetTrigger("laver");}
		   
	}//fin de la fonction fixedUpdate

	void OnCollisionEnter (Collision infoCollision){}

    void OnTriggerEnter (Collider infoObject){}


}