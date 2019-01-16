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
    public bool peutBouger;
    public bool mainsLibres;
    public bool zoneLavabo;
    public bool zoneCuire;
    public bool zonePain;
    public bool zonePoulet;
    public bool zonePatate;
    public bool peutPrendre;
    public bool pain;
    public bool painCuit;
    public bool poulet;
    public bool pouletCuit;
    public bool patate;
    public bool patateCuit;
    //public bool assiette;
    public bool zoneAssiette;
    public GameObject assiette;

    //Use this for initialization
    void Start () {
        
	  //va chercher ce qu'on a besoin pour le début
		cuisinierAnim = GetComponent<Animator>();

      //va chercher ce qu'on a besoin pour le début
		cuisinierRigid = GetComponent<Rigidbody>();
		peutBouger = true;
 	 	mainsLibres = true;
		zoneLavabo = false;
 	 	zoneCuire = false;
 	 	zonePain = false;
		zonePoulet = false;
		zonePatate = false;
 	 	peutPrendre = true;
		pain = false;
		poulet = false;
		patate = false;
		//assiette = false;
		painCuit = false;
		pouletCuit = false;
		patateCuit = false;

	}
	
  //Update is called once per frame
	void Update () {}

    void FixedUpdate () {

		 cuisinierAnim.SetBool("marche", false);

		if(peutBouger == true){

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

	    if(Input.GetKeyDown("e")){

	    	if(zoneLavabo == true /*&& assiette == true*/){

	    		peutBouger = false;
	    		cuisinierAnim.SetTrigger("laver");
	    		Invoke ("bouger", 5f);
	    		}

	    	if(zoneCuire == true && mainsLibres == false){

	    		if(pain == true && painCuit == false){

	    			painCuit = true;
	    			peutBouger = false;
	    			cuisinierAnim.SetTrigger("prendre");
	    			Invoke ("bouger", 1f);
	    		}

	    		if(poulet == true && pouletCuit == false){

	    			pouletCuit = true;
	    			peutBouger = false;
	    			cuisinierAnim.SetTrigger("prendre");
	    			Invoke ("bouger", 1f);
	    		}

	    		if(patate == true && patateCuit == false){

	    			patateCuit = true;
	    			peutBouger = false;
	    			cuisinierAnim.SetTrigger("prendre");
	    			Invoke ("bouger", 1f);
	    		}

	    		}

	    	if(zonePain == true && mainsLibres == true){

	    		peutBouger = false;
	    		cuisinierAnim.SetTrigger("prendre");
	    		Invoke ("bouger", 1f);
	    		mainsLibres = false;
	    		pain = true;
	    		}

	    	if(zonePoulet == true && mainsLibres == true){

	    		peutBouger = false;
	    		cuisinierAnim.SetTrigger("prendre");
	    		Invoke ("bouger", 1f);
	    		mainsLibres = false;
	    		poulet = true;
	    		}

	    	if(zonePatate == true && mainsLibres == true){

	    		peutBouger = false;
	    		cuisinierAnim.SetTrigger("prendre");
	    		Invoke ("bouger", 1f);
	    		mainsLibres = false;
	    		patate = true;
	    		}

	    	if(zoneAssiette == true && mainsLibres == false){

	    		if(painCuit == true && assiette.GetComponent<assiette>().assietteVide == true){

	    			peutBouger = false;
	    			cuisinierAnim.SetTrigger("prendre");
	    			Invoke ("bouger", 1f);
	    			mainsLibres = true;
	    			pain = false;
	    			painCuit = false;
	    			assiette.GetComponent<assiette>().assietteVide = false;
	    			assiette.GetComponent<assiette>().pain = true;
	    		}

	    		if(pouletCuit == true && assiette.GetComponent<assiette>().assietteVide == true){

	    			peutBouger = false;
	    			cuisinierAnim.SetTrigger("prendre");
	    			Invoke ("bouger", 1f);
	    			mainsLibres = true;
	    			poulet = false;
	    			pouletCuit = false;
	    			assiette.GetComponent<assiette>().assietteVide = false;
	    			assiette.GetComponent<assiette>().poulet = true;
	    		}

	    		if(patateCuit == true && assiette.GetComponent<assiette>().assietteVide == true){

	    			peutBouger = false;
	    			cuisinierAnim.SetTrigger("prendre");
	    			Invoke ("bouger", 1f);
	    			mainsLibres = true;
	    			patate = false;
	    			patateCuit = false;
	    			assiette.GetComponent<assiette>().assietteVide = false;
	    			assiette.GetComponent<assiette>().patate = true;
	    		}
	   
	    		}


			}

		}//fin de la fonction bouger
		   
	}//fin de la fonction fixedUpdate

	void OnCollisionEnter (Collision infoCollision){}

    void OnTriggerEnter (Collider infoObject){

    }

    void OnTriggerStay (Collider infoObject){

    	if(infoObject.gameObject.tag == "laver" && transform.eulerAngles.y == 270){

    		zoneLavabo = true;

   		}

   		else{

   			zoneLavabo = false;

   			}

   		if(infoObject.gameObject.tag == "cuire" && transform.eulerAngles.y == 270){

    		zoneCuire = true;

   		}

   		else{

   			zoneCuire = false;

   			}

   		if(infoObject.gameObject.tag == "pain" && transform.eulerAngles.y == 270){

    		zonePain = true;

   		}

   		else{

   			zonePain = false;

   			}

   		if(infoObject.gameObject.tag == "poulet" && transform.eulerAngles.y == 0){

    		zonePoulet = true;

   		}

   		else{

   			zonePoulet = false;

   			}

   		if(infoObject.gameObject.tag == "patate" && transform.eulerAngles.y == 0){

    		zonePatate = true;

   		}

   		else{

   			zonePatate = false;

   			}

   		if(infoObject.gameObject.tag == "assiette" && transform.eulerAngles.y == 90){

    		zoneAssiette = true;

   		}

   		else{

   			zoneAssiette = false;

   			}

    }


    void OnTriggerExit (Collider infoObject){

    }

    void bouger(){peutBouger = true;}

}