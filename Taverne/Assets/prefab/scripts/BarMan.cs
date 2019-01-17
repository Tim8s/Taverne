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
  //ajuste la vitesse de la course
    public float vitesseCourse;
  //permet de faire tomber le personnage
    public float forceGravite;
    public bool peutBouger;
    public bool mainsLibres;
    public bool bierre;
    public bool vin;
    public bool pain;
    public bool poulet;
    public bool patate;
    public bool zoneBierre;
    public bool zoneVin;
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

    //Use this for initialization
    void Start () {
        
	  //va chercher ce qu'on a besoin pour le début
		BarManAnim = GetComponent<Animator>();

      //va chercher ce qu'on a besoin pour le début
		BarManRigid = GetComponent<Rigidbody>();

		peutBouger = true;
 	 	mainsLibres = true;

	}
	
  //Update is called once per frame
	void Update () {}

    void FixedUpdate () {

		BarManAnim.SetBool("marche", false);

		if(peutBouger == true){

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
		if (Input.GetKey(KeyCode.RightControl) && BarManAnim.GetBool("marche") == true /* || Input.GetAxis("LT") != 0*/){

            BarManAnim.SetBool("course", true);
			BarManRigid.AddRelativeForce(0, 0, vitesseCourse);}//fin du if

	  //sinon il arrêtte de courrir
		else{BarManAnim.SetBool("course", false);}//fin du else

		if(Input.GetKeyDown(KeyCode.Keypad0)){


			if(zonePoubelle == true && mainsLibres == false){

	    		peutBouger = false;
	    	    BarManAnim.SetTrigger("prendre");
	    		Invoke ("bouger", 1f);
	    		mainsLibres = true;
	    		pain = false;
	    		poulet = false;
	    		patate = false;
	    		bierre = false;
	    		vin = false;

	    	}

			if(zoneBierre == true && mainsLibres == true){

	    		peutBouger = false;
	    		BarManAnim.SetTrigger("prendre");
	    		Invoke ("bouger", 1f);
	    		mainsLibres = false;
	    		bierre = true;
	    		}

	    	if(zoneVin == true && mainsLibres == true){

	    		peutBouger = false;
	    		BarManAnim.SetTrigger("prendre");
	    		Invoke ("bouger", 1f);
	    		mainsLibres = false;
	    		vin = true;
	    		}

			////////////////////assiette 1//////////////////////////

	    	if(zoneAssiette1 == true && mainsLibres == true){

	    		if(assiette1.GetComponent<assiette>().assietteVide == false){

	    			if(assiette1.GetComponent<assiette>().pain == true){

	    				peutBouger = false;
	    				BarManAnim.SetTrigger("prendre");
	    				Invoke ("bouger", 1f);
	    				mainsLibres = false;
	    				assiette1.GetComponent<assiette>().assietteVide = true;
	    				assiette1.GetComponent<assiette>().pain = false;
	    				pain = true;
	    			}

	    			if(assiette1.GetComponent<assiette>().poulet == true){

	    				peutBouger = false;
	    				BarManAnim.SetTrigger("prendre");
	    				Invoke ("bouger", 1f);
	    				mainsLibres = false;
	    				assiette1.GetComponent<assiette>().assietteVide = true;
	    				assiette1.GetComponent<assiette>().poulet = false;
	    				poulet = true;
	    			}

	    			if(assiette1.GetComponent<assiette>().patate == true){

	    				peutBouger = false;
	    				BarManAnim.SetTrigger("prendre");
	    				Invoke ("bouger", 1f);
	    				mainsLibres = false;
	    				assiette1.GetComponent<assiette>().assietteVide = true;
	    				assiette1.GetComponent<assiette>().patate = false;
	    				patate = true;
	    				}
	    			
	    			}

	    		}

	    		////////////////////assiette 2//////////////////////////

	    	if(zoneAssiette2 == true && mainsLibres == true){

	    		if(assiette2.GetComponent<assiette>().assietteVide == false){

	    			if(assiette2.GetComponent<assiette>().pain == true){

	    				peutBouger = false;
	    				BarManAnim.SetTrigger("prendre");
	    				Invoke ("bouger", 1f);
	    				mainsLibres = false;
	    				assiette2.GetComponent<assiette>().assietteVide = true;
	    				assiette2.GetComponent<assiette>().pain = false;
	    				pain = true;
	    			}

	    			if(assiette2.GetComponent<assiette>().poulet == true){

	    				peutBouger = false;
	    				BarManAnim.SetTrigger("prendre");
	    				Invoke ("bouger", 1f);
	    				mainsLibres = false;
	    				assiette2.GetComponent<assiette>().assietteVide = true;
	    				assiette2.GetComponent<assiette>().poulet = false;
	    				poulet = true;
	    			}

	    			if(assiette2.GetComponent<assiette>().patate == true){

	    				peutBouger = false;
	    				BarManAnim.SetTrigger("prendre");
	    				Invoke ("bouger", 1f);
	    				mainsLibres = false;
	    				assiette2.GetComponent<assiette>().assietteVide = true;
	    				assiette2.GetComponent<assiette>().patate = false;
	    				patate = true;
	    				}
	    			
	    			}

	    		}

	    		////////////////////assiette 3//////////////////////////

	    	if(zoneAssiette3 == true && mainsLibres == true){

	    		if(assiette3.GetComponent<assiette>().assietteVide == false){

	    			if(assiette3.GetComponent<assiette>().pain == true){

	    				peutBouger = false;
	    				BarManAnim.SetTrigger("prendre");
	    				Invoke ("bouger", 1f);
	    				mainsLibres = false;
	    				assiette3.GetComponent<assiette>().assietteVide = true;
	    				assiette3.GetComponent<assiette>().pain = false;
	    				pain = true;
	    			}

	    			if(assiette3.GetComponent<assiette>().poulet == true){

	    				peutBouger = false;
	    				BarManAnim.SetTrigger("prendre");
	    				Invoke ("bouger", 1f);
	    				mainsLibres = false;
	    				assiette3.GetComponent<assiette>().assietteVide = true;
	    				assiette3.GetComponent<assiette>().poulet = false;
	    				poulet = true;
	    			}

	    			if(assiette3.GetComponent<assiette>().patate == true){

	    				peutBouger = false;
	    				BarManAnim.SetTrigger("prendre");
	    				Invoke ("bouger", 1f);
	    				mainsLibres = false;
	    				assiette3.GetComponent<assiette>().assietteVide = true;
	    				assiette3.GetComponent<assiette>().patate = false;
	    				patate = true;
	    				}
	    			
	    			}

	    		}

	    		////////////////////assiette 4//////////////////////////

	    	if(zoneAssiette4 == true && mainsLibres == true){

	    		if(assiette4.GetComponent<assiette>().assietteVide == false){

	    			if(assiette4.GetComponent<assiette>().pain == true){

	    				peutBouger = false;
	    				BarManAnim.SetTrigger("prendre");
	    				Invoke ("bouger", 1f);
	    				mainsLibres = false;
	    				assiette4.GetComponent<assiette>().assietteVide = true;
	    				assiette4.GetComponent<assiette>().pain = false;
	    				pain = true;
	    			}

	    			if(assiette4.GetComponent<assiette>().poulet == true){

	    				peutBouger = false;
	    				BarManAnim.SetTrigger("prendre");
	    				Invoke ("bouger", 1f);
	    				mainsLibres = false;
	    				assiette4.GetComponent<assiette>().assietteVide = true;
	    				assiette4.GetComponent<assiette>().poulet = false;
	    				poulet = true;
	    			}

	    			if(assiette4.GetComponent<assiette>().patate == true){

	    				peutBouger = false;
	    				BarManAnim.SetTrigger("prendre");
	    				Invoke ("bouger", 1f);
	    				mainsLibres = false;
	    				assiette4.GetComponent<assiette>().assietteVide = true;
	    				assiette4.GetComponent<assiette>().patate = false;
	    				patate = true;
	    				}
	    			
	    			}

	    		}

	    		////////////////////assiette 5//////////////////////////

	    	if(zoneAssiette5 == true && mainsLibres == true){

	    		if(assiette5.GetComponent<assiette>().assietteVide == false){

	    			if(assiette5.GetComponent<assiette>().pain == true){

	    				peutBouger = false;
	    				BarManAnim.SetTrigger("prendre");
	    				Invoke ("bouger", 1f);
	    				mainsLibres = false;
	    				assiette5.GetComponent<assiette>().assietteVide = true;
	    				assiette5.GetComponent<assiette>().pain = false;
	    				pain = true;
	    			}

	    			if(assiette5.GetComponent<assiette>().poulet == true){

	    				peutBouger = false;
	    				BarManAnim.SetTrigger("prendre");
	    				Invoke ("bouger", 1f);
	    				mainsLibres = false;
	    				assiette5.GetComponent<assiette>().assietteVide = true;
	    				assiette5.GetComponent<assiette>().poulet = false;
	    				poulet = true;
	    			}

	    			if(assiette5.GetComponent<assiette>().patate == true){

	    				peutBouger = false;
	    				BarManAnim.SetTrigger("prendre");
	    				Invoke ("bouger", 1f);
	    				mainsLibres = false;
	    				assiette5.GetComponent<assiette>().assietteVide = true;
	    				assiette5.GetComponent<assiette>().patate = false;
	    				patate = true;
	    				}
	    			
	    			}

	    		}	

			}

	}//fin de la fonction bouger
		   
	}//fin de la fonction fixedUpdate

	void OnCollisionEnter(Collision infoCollision){}

    void OnTriggerEnter(Collider infoObject){}

    void OnTriggerStay(Collider infoObject){

    	if(infoObject.gameObject.tag == "bierre" && transform.eulerAngles.y == 0){

    		zoneBierre = true;

   		}

   		else{

   			zoneBierre = false;

   			}

   		if(infoObject.gameObject.tag == "vin" && transform.eulerAngles.y == 0){

    		zoneVin = true;

   		}

   		else{

   			zoneVin = false;

   			}
   
   		 if(infoObject.gameObject.tag == "assiette1" && transform.eulerAngles.y == 270){

    		zoneAssiette1 = true;

   		}

   		else{

   			zoneAssiette1 = false;

   			}

   		if(infoObject.gameObject.tag == "assiette2" && transform.eulerAngles.y == 270){

    		zoneAssiette2 = true;

   		}

   		else{

   			zoneAssiette2 = false;

   			}

   		if(infoObject.gameObject.tag == "assiette3" && transform.eulerAngles.y == 270){

    		zoneAssiette3 = true;

   		}

   		else{

   			zoneAssiette3 = false;

   			}

   		if(infoObject.gameObject.tag == "assiette4" && transform.eulerAngles.y == 270){

    		zoneAssiette4 = true;

   		}

   		else{

   			zoneAssiette4 = false;

   			}

   		if(infoObject.gameObject.tag == "assiette5" && transform.eulerAngles.y == 270){

    		zoneAssiette5 = true;

   		}

   		else{

   			zoneAssiette5 = false;

   			}

   		if(infoObject.gameObject.tag == "poubelle" && transform.eulerAngles.y == 0){

    		zonePoubelle = true;

   		}

   		else{

   			zonePoubelle = false;

   			}

   		}
   	void bouger(){peutBouger = true;}
}