using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cuisinier : MonoBehaviour {

  //référence a l'animator du hero
	Animator cuisinierAnim;
  //référence au rigidbody du hero
	Rigidbody cuisinierRigid;
  //ajuste la vitesse de marche
    public float vitesseMarche;
  //ajuste la vitesse de la course
    public float vitesseCourse;
  //permet de faire tomber le personnage
    public float forceGravite;

    //Use this for initialization
    void Start () {
        
	  //va chercher ce qu'on a besoin pour le début
		cuisinierAnim = GetComponent<Animator>();

      //va chercher ce qu'on a besoin pour le début
		cuisinierRigid = GetComponent<Rigidbody>();

	}
	
  //Update is called once per frame
	void Update () {}

    void FixedUpdate () {

		 cuisinierAnim.SetBool("marche", false);

		if(Input.GetKey("s")){

			cuisinierAnim.SetBool("marche", true);
			transform.eulerAngles = new Vector3(0, 180, 0);
			
			if(Input.GetKey("s") && Input.GetKey("d")){

				transform.eulerAngles = new Vector3(0, 135, 0);
			}

			if(Input.GetKey("s") && Input.GetKey("a")){

				transform.eulerAngles = new Vector3(0, 225, 0);
				}
		}

		else if(Input.GetKey("w")){

			cuisinierAnim.SetBool("marche", true);
			transform.eulerAngles = new Vector3(0, 0, 0);

			if(Input.GetKey("w") && Input.GetKey("d")){

				transform.eulerAngles = new Vector3(0, 45, 0);
			}

			if(Input.GetKey("w") && Input.GetKey("a")){

				transform.eulerAngles = new Vector3(0, -45, 0);
				}
		}

		else if(Input.GetKey("a")){

			cuisinierAnim.SetBool("marche", true);
			transform.eulerAngles = new Vector3(0, -90, 0);

			if(Input.GetKey("a") && Input.GetKey("w")){

				transform.eulerAngles = new Vector3(0, -45, 0);
			}

			if(Input.GetKey("a") && Input.GetKey("s")){

				transform.eulerAngles = new Vector3(0, -135, 0);
				}
		}

		else if(Input.GetKey("d")){

			cuisinierAnim.SetBool("marche", true);
			transform.eulerAngles = new Vector3(0, 90, 0);

			if(Input.GetKey("d") && Input.GetKey("w")){

				transform.eulerAngles = new Vector3(0, 45, 0);
			}

			if(Input.GetKey("d") && Input.GetKey("s")){

				transform.eulerAngles = new Vector3(0, 135, 0);
				}
		}

		if(cuisinierAnim.GetBool("marche") == true){

		   cuisinierRigid.AddRelativeForce(0, 0, vitesseMarche);
		   cuisinierRigid.AddForce(0, forceGravite, 0);

		}

		//si cette touche est maintenu, le perso va courrir
		if (Input.GetKey(KeyCode.LeftShift) && cuisinierAnim.GetBool("marche") == true /* || Input.GetAxis("LT") != 0*/){

            cuisinierAnim.SetBool("course", true);
			cuisinierRigid.AddRelativeForce(0, 0, vitesseCourse);}//fin du if

	  //sinon il arrêtte de courrir
		else{cuisinierAnim.SetBool("course", false);}//fin du else

	    if(Input.GetKeyDown("e")){cuisinierAnim.SetTrigger("prendre");}

	    if(Input.GetKeyDown("r")){cuisinierAnim.SetTrigger("laver");}
		   
	}//fin de la fonction fixedUpdate

	void OnCollisionEnter (Collision infoCollision){}

    void OnTriggerEnter (Collider infoObject){}


}