using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
////////////////////////////////////////////
//Ce script gère la génération des commandes
////////////////////////////////////////////

public class gestionCommande : MonoBehaviour {

	//La quantité maximal de commande qu'il peut avoir à la fois
	public int NbsCommandeMax;

	//Le délai qu'il y a entre 2 commandes
	public int delaiEntreCommande;
	public int IDCommande = 0;

	//Tableaux des sprites des boissons et nourriture
	public Sprite[] ArrayMenu;

	//Array qui va contenir les commandes actuelles
	public GameObject[] ArrayCommande;

	//Array des GameObjects 
	public GameObject[] ArrayComptoir;

	//Array les positions/*Faculcatif*/
	//public Sprite[] ArrayPosition;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyUp("a"))
		{
			genereCommande();
		}

		if(Input.GetKeyUp("s"))
		{
			supprimeCommande();
		}

	}

	public void genereCommande(){

		//Change le numero de commande
		//IDCommande++;

		//Regarde si il y a de la place dans le tableau/ une commande en attente
		for(int i = 0; i < 10; i++){
			print(ArrayComptoir[i].transform.GetChild(0).GetComponent<papierScript>().commandeEnAttente);
			/*if(ArrayComptoir[i].transform.GetChild(0).GetComponent<papierScript>().commandeEnAttente == false){
				
			}//fin if*/
		}//fin for

		//Choisi aleatoirement la commande
		var commande = ArrayMenu[Random.Range(0, 4)];

		

		//Mets la commande sur un comptoir aléatoirement

		print(commande);
		ajouteArray(commande);

	}

	public void ajouteArray(Sprite commande){

		//Pour mettre la commande dans l'affichage
		for(int i = 0; i < 10; i++){

			if(ArrayCommande[i].transform.GetChild(1).GetComponent<Image>().sprite == null){
				//Ajoute l'image
				ArrayCommande[i].transform.GetChild(1).GetComponent<Image>().sprite = commande;

				//Ajoute le numéro de commande
				ArrayCommande[i].transform.GetChild(0).GetComponent<Text>().text = "No. " + IDCommande.ToString();
				break;
			}//fin if

		}//fin for

		
	}


	public void supprimeCommande(){
		var aleatoire = Random.Range(0, 9);

		ArrayCommande[aleatoire].transform.GetChild(1).GetComponent<Image>().sprite = null;
		ArrayCommande[aleatoire].transform.GetChild(0).GetComponent<Text>().text = "No";
	}


}
