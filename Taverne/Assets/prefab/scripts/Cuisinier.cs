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
    public bool zoneAssiette1;
    public bool zoneAssiette2;
    public bool zoneAssiette3;
    public bool zoneAssiette4;
    public bool zoneAssiette5;
    public GameObject assiette1;
    public GameObject assiette2;
    public GameObject assiette3;
    public GameObject assiette4;
    public GameObject assiette5;
    public bool zonePoubelle;
    public bool assietteSale;
    public GameObject painObj;
    public GameObject pouletObj;
    public GameObject patateObj;



    //Use this for initialization
    void Start () {
        
	  //va chercher ce qu'on a besoin pour le début
		cuisinierAnim = GetComponent<Animator>();

      //va chercher ce qu'on a besoin pour le début
		cuisinierRigid = GetComponent<Rigidbody>();
		peutBouger = true;
 	 	mainsLibres = true;
 	 	peutPrendre = true;
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

	    	if(zonePoubelle == true && mainsLibres == false){

	    		peutBouger = false;
	    	    cuisinierAnim.SetTrigger("prendre");
	    		Invoke ("bouger", 1f);
	    		Invoke ("disparaitre", 0.5f);
	    		mainsLibres = true;
	    		pain = false;
	    		poulet = false;
	    		patate = false;
	    		painCuit = false;
	    		pouletCuit = false;
	    		patateCuit = false;

	    	}

	    	if(zoneLavabo == true && assietteSale == true){

	    		assietteSale = false;
	    		peutBouger = false;
	    		cuisinierAnim.SetTrigger("laver");
	    		Invoke ("bouger", 5f);
	    		}

	    	if(zoneCuire == true && mainsLibres == false){

	    		if(pain == true && painCuit == false){

	    			painCuit = true;
	    			peutBouger = false;
	    			cuisinierAnim.SetTrigger("prendre");
	    			Invoke ("disparaitre", 0.5f);
	    			Invoke ("prendreObjet", 1.5f);
	    			Invoke ("apparaitre", 2.1f);
	    			Invoke ("bouger", 2.6f);
	    		}

	    		if(poulet == true && pouletCuit == false){

	    			pouletCuit = true;
	    			peutBouger = false;
	    			cuisinierAnim.SetTrigger("prendre");
	    			Invoke ("disparaitre", 0.5f);
	    			Invoke ("prendreObjet", 1.5f);
	    			Invoke ("apparaitre", 2.1f);
	    			Invoke ("bouger", 2.6f);

	    		}

	    		if(patate == true && patateCuit == false){

	    			patateCuit = true;
	    			peutBouger = false;
	    			cuisinierAnim.SetTrigger("prendre");
	    			Invoke ("disparaitre", 0.5f);
	    			Invoke ("prendreObjet", 1.5f);
	    			Invoke ("apparaitre", 2.1f);
	    			Invoke ("bouger", 2.6f);
	    		}

	    		}

	    	if(zonePain == true && mainsLibres == true){

	    		peutBouger = false;
	    		cuisinierAnim.SetTrigger("prendre");
	    		Invoke ("bouger", 1f);
	    		Invoke ("apparaitre", 0.5f);
	    		mainsLibres = false;
	    		pain = true;
	    		}

	    	if(zonePoulet == true && mainsLibres == true){

	    		peutBouger = false;
	    		cuisinierAnim.SetTrigger("prendre");
	    		Invoke ("bouger", 1f);
	    		Invoke ("apparaitre", 0.5f);
	    		mainsLibres = false;
	    		poulet = true;
	    		}

	    	if(zonePatate == true && mainsLibres == true){

	    		peutBouger = false;
	    		cuisinierAnim.SetTrigger("prendre");
	    		Invoke ("bouger", 1f);
	    		Invoke ("apparaitre", 0.5f);
	    		mainsLibres = false;
	    		patate = true;
	    		}

	    		////////////////////////assiette 1/////////////////////////////////////

	    	if(zoneAssiette1 == true && mainsLibres == false && assiette1.GetComponent<assiette>().assietteVide == true){

	    		if(painCuit == true){

	    			peutBouger = false;
	    			cuisinierAnim.SetTrigger("prendre");
	    			Invoke ("bouger", 1f);
	    			Invoke ("disparaitre", 0.5f);
	    			mainsLibres = true;
	    			pain = false;
	    			painCuit = false;
	    			assiette1.GetComponent<assiette>().assietteVide = false;
	    			assiette1.GetComponent<assiette>().pain = true;
	    			assiette1.GetComponent<assiette>().callApparaitre();

	    		}

	    		if(pouletCuit == true){

	    			peutBouger = false;
	    			cuisinierAnim.SetTrigger("prendre");
	    			Invoke ("bouger", 1f);
	    			Invoke ("disparaitre", 0.5f);
	    			mainsLibres = true;
	    			poulet = false;
	    			pouletCuit = false;
	    			assiette1.GetComponent<assiette>().assietteVide = false;
	    			assiette1.GetComponent<assiette>().poulet = true;
	    			assiette1.GetComponent<assiette>().callApparaitre();
	    		}

	    		if(patateCuit == true){

	    			peutBouger = false;
	    			cuisinierAnim.SetTrigger("prendre");
	    			Invoke ("bouger", 1f);
	    			Invoke ("disparaitre", 0.5f);
	    			mainsLibres = true;
	    			patate = false;
	    			patateCuit = false;
	    			assiette1.GetComponent<assiette>().assietteVide = false;
	    			assiette1.GetComponent<assiette>().patate = true;
	    			assiette1.GetComponent<assiette>().callApparaitre();
	    		}

	    	}

	    		////////////////////////assiette 2/////////////////////////////////////

	    	if(zoneAssiette2 == true && mainsLibres == false && assiette2.GetComponent<assiette>().assietteVide == true){

	    		if(painCuit == true){

	    			peutBouger = false;
	    			cuisinierAnim.SetTrigger("prendre");
	    			Invoke ("bouger", 1f);
	    			Invoke ("disparaitre", 0.5f);
	    			mainsLibres = true;
	    			pain = false;
	    			painCuit = false;
	    			assiette2.GetComponent<assiette>().assietteVide = false;
	    			assiette2.GetComponent<assiette>().pain = true;
	    			assiette2.GetComponent<assiette>().callApparaitre();
	    		}

	    		if(pouletCuit == true){

	    			peutBouger = false;
	    			cuisinierAnim.SetTrigger("prendre");
	    			Invoke ("bouger", 1f);
	    			Invoke ("disparaitre", 0.5f);
	    			mainsLibres = true;
	    			poulet = false;
	    			pouletCuit = false;
	    			assiette2.GetComponent<assiette>().assietteVide = false;
	    			assiette2.GetComponent<assiette>().poulet = true;
	    			assiette2.GetComponent<assiette>().callApparaitre();
	    		}

	    		if(patateCuit == true){

	    			peutBouger = false;
	    			cuisinierAnim.SetTrigger("prendre");
	    			Invoke ("bouger", 1f);
	    			Invoke ("disparaitre", 0.5f);
	    			mainsLibres = true;
	    			patate = false;
	    			patateCuit = false;
	    			assiette2.GetComponent<assiette>().assietteVide = false;
	    			assiette2.GetComponent<assiette>().patate = true;
	    			assiette2.GetComponent<assiette>().callApparaitre();
	    		}
	    	}

	    		////////////////////////assiette 3/////////////////////////////////////

	    	if(zoneAssiette3 == true && mainsLibres == false && assiette3.GetComponent<assiette>().assietteVide == true){

	    		if(painCuit == true){

	    			peutBouger = false;
	    			cuisinierAnim.SetTrigger("prendre");
	    			Invoke ("bouger", 1f);
	    			Invoke ("disparaitre", 0.5f);
	    			mainsLibres = true;
	    			pain = false;
	    			painCuit = false;
	    			assiette3.GetComponent<assiette>().assietteVide = false;
	    			assiette3.GetComponent<assiette>().pain = true;
	    			assiette3.GetComponent<assiette>().callApparaitre();
	    		}

	    		if(pouletCuit == true){

	    			peutBouger = false;
	    			cuisinierAnim.SetTrigger("prendre");
	    			Invoke ("bouger", 1f);
	    			Invoke ("disparaitre", 0.5f);
	    			mainsLibres = true;
	    			poulet = false;
	    			pouletCuit = false;
	    			assiette3.GetComponent<assiette>().assietteVide = false;
	    			assiette3.GetComponent<assiette>().poulet = true;
	    			assiette3.GetComponent<assiette>().callApparaitre();
	    		}

	    		if(patateCuit == true){

	    			peutBouger = false;
	    			cuisinierAnim.SetTrigger("prendre");
	    			Invoke ("bouger", 1f);
	    			Invoke ("disparaitre", 0.5f);
	    			mainsLibres = true;
	    			patate = false;
	    			patateCuit = false;
	    			assiette3.GetComponent<assiette>().assietteVide = false;
	    			assiette3.GetComponent<assiette>().patate = true;
	    			assiette3.GetComponent<assiette>().callApparaitre();
	    		}
	    	}

	    		////////////////////////assiette 4/////////////////////////////////////

	    	if(zoneAssiette4 == true && mainsLibres == false && assiette4.GetComponent<assiette>().assietteVide == true){

	    		if(painCuit == true){

	    			peutBouger = false;
	    			cuisinierAnim.SetTrigger("prendre");
	    			Invoke ("bouger", 1f);
	    			Invoke ("disparaitre", 0.5f);
	    			mainsLibres = true;
	    			pain = false;
	    			painCuit = false;
	    			assiette4.GetComponent<assiette>().assietteVide = false;
	    			assiette4.GetComponent<assiette>().pain = true;
	    			assiette4.GetComponent<assiette>().callApparaitre();
	    		}

	    		if(pouletCuit == true){

	    			peutBouger = false;
	    			cuisinierAnim.SetTrigger("prendre");
	    			Invoke ("bouger", 1f);
	    			Invoke ("disparaitre", 0.5f);
	    			mainsLibres = true;
	    			poulet = false;
	    			pouletCuit = false;
	    			assiette4.GetComponent<assiette>().assietteVide = false;
	    			assiette4.GetComponent<assiette>().poulet = true;
	    			assiette4.GetComponent<assiette>().callApparaitre();
	    		}

	    		if(patateCuit == true){

	    			peutBouger = false;
	    			cuisinierAnim.SetTrigger("prendre");
	    			Invoke ("bouger", 1f);
	    			Invoke ("disparaitre", 0.5f);
	    			mainsLibres = true;
	    			patate = false;
	    			patateCuit = false;
	    			assiette4.GetComponent<assiette>().assietteVide = false;
	    			assiette4.GetComponent<assiette>().patate = true;
	    			assiette4.GetComponent<assiette>().callApparaitre();
	    		}

	    	}
	    		////////////////////////assiette 5/////////////////////////////////////

	    	if(zoneAssiette5 == true && mainsLibres == false && assiette5.GetComponent<assiette>().assietteVide == true){

	    		if(painCuit == true){

	    			peutBouger = false;
	    			cuisinierAnim.SetTrigger("prendre");
	    			Invoke ("bouger", 1f);
	    			Invoke ("disparaitre", 0.5f);
	    			mainsLibres = true;
	    			pain = false;
	    			painCuit = false;
	    			assiette5.GetComponent<assiette>().assietteVide = false;
	    			assiette5.GetComponent<assiette>().pain = true;
	    			assiette5.GetComponent<assiette>().callApparaitre();
	    		}

	    		if(pouletCuit == true){

	    			peutBouger = false;
	    			cuisinierAnim.SetTrigger("prendre");
	    			Invoke ("bouger", 1f);
	    			Invoke ("disparaitre", 0.5f);
	    			mainsLibres = true;
	    			poulet = false;
	    			pouletCuit = false;
	    			assiette5.GetComponent<assiette>().assietteVide = false;
	    			assiette5.GetComponent<assiette>().poulet = true;
	    			assiette5.GetComponent<assiette>().callApparaitre();
	    		}

	    		if(patateCuit == true){

	    			peutBouger = false;
	    			cuisinierAnim.SetTrigger("prendre");
	    			Invoke ("bouger", 1f);
	    			Invoke ("disparaitre", 0.5f);
	    			mainsLibres = true;
	    			patate = false;
	    			patateCuit = false;
	    			assiette5.GetComponent<assiette>().assietteVide = false;
	    			assiette5.GetComponent<assiette>().patate = true;
	    			assiette5.GetComponent<assiette>().callApparaitre();
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

   		if(infoObject.gameObject.tag == "pain" && transform.eulerAngles.y == 180){

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

   		if(infoObject.gameObject.tag == "assiette1" && transform.eulerAngles.y == 90){

    		zoneAssiette1 = true;

   		}

   		else{

   			zoneAssiette1 = false;

   			}

   		if(infoObject.gameObject.tag == "assiette2" && transform.eulerAngles.y == 90){

    		zoneAssiette2 = true;

   		}

   		else{

   			zoneAssiette2 = false;

   			}

   		if(infoObject.gameObject.tag == "assiette3" && transform.eulerAngles.y == 90){

    		zoneAssiette3 = true;

   		}

   		else{

   			zoneAssiette3 = false;

   			}

   		if(infoObject.gameObject.tag == "assiette4" && transform.eulerAngles.y == 90){

    		zoneAssiette4 = true;

   		}

   		else{

   			zoneAssiette4 = false;

   			}

   		if(infoObject.gameObject.tag == "assiette5" && transform.eulerAngles.y == 90){

    		zoneAssiette5 = true;

   		}

   		else{

   			zoneAssiette5 = false;

   			}

   		if(infoObject.gameObject.tag == "poubelle" && transform.eulerAngles.y == 270){

    		zonePoubelle = true;

   		}

   		else{

   			zonePoubelle = false;

   			}

    }


    void OnTriggerExit (Collider infoObject){

    }

    void bouger(){peutBouger = true;}

    void prendreObjet(){cuisinierAnim.SetTrigger("prendre");}

    void disparaitre(){

    	if(painObj.activeSelf == true){painObj.SetActive(false);}

    	if(pouletObj.activeSelf == true){pouletObj.SetActive(false);}

    	if(patateObj.activeSelf == true){patateObj.SetActive(false);}

    }

    void apparaitre(){

    	if(pain == true){painObj.SetActive(true);}

    	if(poulet == true){pouletObj.SetActive(true);}

    	if(patate == true){patateObj.SetActive(true);}
    }

}