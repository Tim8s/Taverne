using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    public GameObject painObj;
    public GameObject pouletObj;
    public GameObject patateObj;
    public GameObject bouteilleVin;
    public GameObject MugBierre;

    public gestionCommande gererCommande;

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
		if (Input.GetKey(KeyCode.Keypad0) && BarManAnim.GetBool("marche") == true /* || Input.GetAxis("LT") != 0*/){

            BarManAnim.SetBool("course", true);
			BarManRigid.AddRelativeForce(0, 0, vitesseCourse);}//fin du if

	  //sinon il arrêtte de courrir
		else{BarManAnim.SetBool("course", false);}//fin du else

		if(Input.GetKeyDown(KeyCode.KeypadPeriod)){


			if(zonePoubelle == true && mainsLibres == false){

	    		peutBouger = false;
	    	    BarManAnim.SetTrigger("prendre");
	    		Invoke ("bouger", 1f);
	    		Invoke ("disparaitre", 0.5f);
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
	    		Invoke ("apparaitre", 0.5f);
	    		mainsLibres = false;
	    		bierre = true;
	    		}

	    	if(zoneVin == true && mainsLibres == true){

	    		peutBouger = false;
	    		BarManAnim.SetTrigger("prendre");
	    		Invoke ("bouger", 1f);
	    		Invoke ("apparaitre", 0.5f);
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
	    				Invoke ("apparaitre", 0.5f);
	    				mainsLibres = false;
	    				assiette1.GetComponent<assiette>().assietteVide = true;
	    				assiette1.GetComponent<assiette>().pain = false;
	    				assiette1.GetComponent<assiette>().callDisparaitre();
	    				pain = true;
	    			}

	    			if(assiette1.GetComponent<assiette>().poulet == true){

	    				peutBouger = false;
	    				BarManAnim.SetTrigger("prendre");
	    				Invoke ("bouger", 1f);
	    				Invoke ("apparaitre", 0.5f);
	    				mainsLibres = false;
	    				assiette1.GetComponent<assiette>().assietteVide = true;
	    				assiette1.GetComponent<assiette>().poulet = false;
	    				assiette1.GetComponent<assiette>().callDisparaitre();
	    				poulet = true;
	    			}

	    			if(assiette1.GetComponent<assiette>().patate == true){

	    				peutBouger = false;
	    				BarManAnim.SetTrigger("prendre");
	    				Invoke ("bouger", 1f);
	    				Invoke ("apparaitre", 0.5f);
	    				mainsLibres = false;
	    				assiette1.GetComponent<assiette>().assietteVide = true;
	    				assiette1.GetComponent<assiette>().patate = false;
	    				assiette1.GetComponent<assiette>().callDisparaitre();
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
	    				Invoke ("apparaitre", 0.5f);
	    				mainsLibres = false;
	    				assiette2.GetComponent<assiette>().assietteVide = true;
	    				assiette2.GetComponent<assiette>().pain = false;
	    				assiette2.GetComponent<assiette>().callDisparaitre();
	    				pain = true;
	    			}

	    			if(assiette2.GetComponent<assiette>().poulet == true){

	    				peutBouger = false;
	    				BarManAnim.SetTrigger("prendre");
	    				Invoke ("bouger", 1f);
	    				Invoke ("apparaitre", 0.5f);
	    				mainsLibres = false;
	    				assiette2.GetComponent<assiette>().assietteVide = true;
	    				assiette2.GetComponent<assiette>().poulet = false;
	    				assiette2.GetComponent<assiette>().callDisparaitre();
	    				poulet = true;
	    			}

	    			if(assiette2.GetComponent<assiette>().patate == true){

	    				peutBouger = false;
	    				BarManAnim.SetTrigger("prendre");
	    				Invoke ("bouger", 1f);
	    				Invoke ("apparaitre", 0.5f);
	    				mainsLibres = false;
	    				assiette2.GetComponent<assiette>().assietteVide = true;
	    				assiette2.GetComponent<assiette>().patate = false;
	    				assiette2.GetComponent<assiette>().callDisparaitre();
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
	    				Invoke ("apparaitre", 0.5f);
	    				mainsLibres = false;
	    				assiette3.GetComponent<assiette>().assietteVide = true;
	    				assiette3.GetComponent<assiette>().pain = false;
	    				assiette3.GetComponent<assiette>().callDisparaitre();
	    				pain = true;
	    			}

	    			if(assiette3.GetComponent<assiette>().poulet == true){

	    				peutBouger = false;
	    				BarManAnim.SetTrigger("prendre");
	    				Invoke ("bouger", 1f);
	    				Invoke ("apparaitre", 0.5f);
	    				mainsLibres = false;
	    				assiette3.GetComponent<assiette>().assietteVide = true;
	    				assiette3.GetComponent<assiette>().poulet = false;
	    				assiette3.GetComponent<assiette>().callDisparaitre();
	    				poulet = true;
	    			}

	    			if(assiette3.GetComponent<assiette>().patate == true){

	    				peutBouger = false;
	    				BarManAnim.SetTrigger("prendre");
	    				Invoke ("bouger", 1f);
	    				Invoke ("apparaitre", 0.5f);
	    				mainsLibres = false;
	    				assiette3.GetComponent<assiette>().assietteVide = true;
	    				assiette3.GetComponent<assiette>().patate = false;
	    				assiette3.GetComponent<assiette>().callDisparaitre();
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
	    				Invoke ("apparaitre", 0.5f);
	    				mainsLibres = false;
	    				assiette4.GetComponent<assiette>().assietteVide = true;
	    				assiette4.GetComponent<assiette>().pain = false;
	    				assiette4.GetComponent<assiette>().callDisparaitre();
	    				pain = true;
	    			}

	    			if(assiette4.GetComponent<assiette>().poulet == true){

	    				peutBouger = false;
	    				BarManAnim.SetTrigger("prendre");
	    				Invoke ("bouger", 1f);
	    				Invoke ("apparaitre", 0.5f);
	    				mainsLibres = false;
	    				assiette4.GetComponent<assiette>().assietteVide = true;
	    				assiette4.GetComponent<assiette>().poulet = false;
	    				assiette4.GetComponent<assiette>().callDisparaitre();
	    				poulet = true;
	    			}

	    			if(assiette4.GetComponent<assiette>().patate == true){

	    				peutBouger = false;
	    				BarManAnim.SetTrigger("prendre");
	    				Invoke ("bouger", 1f);
	    				Invoke ("apparaitre", 0.5f);
	    				mainsLibres = false;
	    				assiette4.GetComponent<assiette>().assietteVide = true;
	    				assiette4.GetComponent<assiette>().patate = false;
	    				assiette4.GetComponent<assiette>().callDisparaitre();
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
	    				Invoke ("apparaitre", 0.5f);
	    				mainsLibres = false;
	    				assiette5.GetComponent<assiette>().assietteVide = true;
	    				assiette5.GetComponent<assiette>().pain = false;
	    				assiette5.GetComponent<assiette>().callDisparaitre();
	    				pain = true;
	    			}

	    			if(assiette5.GetComponent<assiette>().poulet == true){

	    				peutBouger = false;
	    				BarManAnim.SetTrigger("prendre");
	    				Invoke ("bouger", 1f);
	    				Invoke ("apparaitre", 0.5f);
	    				mainsLibres = false;
	    				assiette5.GetComponent<assiette>().assietteVide = true;
	    				assiette5.GetComponent<assiette>().poulet = false;
	    				assiette5.GetComponent<assiette>().callDisparaitre();
	    				poulet = true;
	    			}

	    			if(assiette5.GetComponent<assiette>().patate == true){

	    				peutBouger = false;
	    				BarManAnim.SetTrigger("prendre");
	    				Invoke ("bouger", 1f);
	    				Invoke ("apparaitre", 0.5f);
	    				mainsLibres = false;
	    				assiette5.GetComponent<assiette>().assietteVide = true;
	    				assiette5.GetComponent<assiette>().patate = false;
	    				assiette5.GetComponent<assiette>().callDisparaitre();
	    				patate = true;
	    				}
	    			
	    			}

	    		}	

			}

	}//fin de la fonction bouger
		   
	}//fin de la fonction fixedUpdate

	void OnCollisionEnter(Collision infoCollision){}

    void OnTriggerEnter(Collider infoObject){

    }

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

        if (infoObject.gameObject.tag == "comptoir" && infoObject.gameObject.transform.GetChild(0).GetComponent<papierScript>().commandeGenerer == true && infoObject.gameObject.transform.GetChild(0).GetComponent<papierScript>().commandePris == false && Input.GetKeyDown(KeyCode.KeypadPeriod))
        {
            infoObject.gameObject.transform.GetChild(0).GetComponent<papierScript>().commandePris = true;
            infoObject.gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;

            gererCommande.ajouteArray(infoObject.gameObject.transform.GetChild(0).GetComponent<papierScript>().commande, infoObject.gameObject.transform.GetChild(0));
        }
        else if (infoObject.gameObject.tag == "comptoir" && infoObject.gameObject.transform.GetChild(0).GetComponent<papierScript>().commandeGenerer == true && infoObject.gameObject.transform.GetChild(0).GetComponent<papierScript>().commandePris == true && Input.GetKeyDown(KeyCode.KeypadPeriod))
        {
            if (infoObject.gameObject.transform.GetChild(0).GetComponent<papierScript>().commande.name == "pain" && pain == true)
            {
                gererCommande.supprimeCommande(infoObject.gameObject.transform.GetChild(0).GetComponent<papierScript>().NoCommande, 20);
                infoObject.gameObject.transform.GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(false);
                infoObject.gameObject.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetComponent<Image>().fillAmount = 0;
                pain = false;
                mainsLibres = true;
                BarManAnim.SetTrigger("prendre");
                Invoke ("disparaitre", 0.5f);
                print("SUCCES");
            }
            else if (infoObject.gameObject.transform.GetChild(0).GetComponent<papierScript>().commande.name == "patate" && patate == true)
            {
                gererCommande.supprimeCommande(infoObject.gameObject.transform.GetChild(0).GetComponent<papierScript>().NoCommande, 20);
                infoObject.gameObject.transform.GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(false);
                infoObject.gameObject.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetComponent<Image>().fillAmount = 0;
                patate = false;
                mainsLibres = true;
                BarManAnim.SetTrigger("prendre");
                Invoke ("disparaitre", 0.5f);
                print("SUCCES");
            }
            else if (infoObject.gameObject.transform.GetChild(0).GetComponent<papierScript>().commande.name == "poulet" && poulet == true)
            {
                gererCommande.supprimeCommande(infoObject.gameObject.transform.GetChild(0).GetComponent<papierScript>().NoCommande, 20);
                infoObject.gameObject.transform.GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(false);
                infoObject.gameObject.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetComponent<Image>().fillAmount = 0;
                poulet = false;
                mainsLibres = true;
                BarManAnim.SetTrigger("prendre");
                Invoke ("disparaitre", 0.5f);
                print("SUCCES");
            }
            else if (infoObject.gameObject.transform.GetChild(0).GetComponent<papierScript>().commande.name == "vin" && vin == true)
            {
                gererCommande.supprimeCommande(infoObject.gameObject.transform.GetChild(0).GetComponent<papierScript>().NoCommande, 20);
                infoObject.gameObject.transform.GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(false);
                infoObject.gameObject.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetComponent<Image>().fillAmount = 0;
                vin = false;
                mainsLibres = true;
                BarManAnim.SetTrigger("prendre");
                Invoke ("disparaitre", 0.5f);
                print("SUCCES");
            }
            else if (infoObject.gameObject.transform.GetChild(0).GetComponent<papierScript>().commande.name == "biere" && bierre == true)
            {
                gererCommande.supprimeCommande(infoObject.gameObject.transform.GetChild(0).GetComponent<papierScript>().NoCommande, 20);
                infoObject.gameObject.transform.GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(false);
                infoObject.gameObject.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetComponent<Image>().fillAmount = 0;
                bierre = false;
                mainsLibres = true;
                BarManAnim.SetTrigger("prendre");
                Invoke ("disparaitre", 0.5f);
                print("SUCCES");
            }
        }

   	}
   	void bouger(){peutBouger = true;}

   	void prendreObjet(){BarManAnim.SetTrigger("prendre");}

    void disparaitre(){

    	if(painObj.activeSelf == true){painObj.SetActive(false);}

    	if(pouletObj.activeSelf == true){pouletObj.SetActive(false);}

    	if(patateObj.activeSelf == true){patateObj.SetActive(false);}

    	if(bouteilleVin.activeSelf == true){bouteilleVin.SetActive(false);}

    	if(MugBierre.activeSelf == true){MugBierre.SetActive(false);}

    }

    void apparaitre(){

    	if(pain == true){painObj.SetActive(true);}

    	if(poulet == true){pouletObj.SetActive(true);}

    	if(patate == true){patateObj.SetActive(true);}

    	if(vin == true){bouteilleVin.SetActive(true);}

    	if(bierre == true){MugBierre.SetActive(true);}
    }
}