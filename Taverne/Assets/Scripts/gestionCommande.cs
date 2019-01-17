using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
////////////////////////////////////////////
//Ce script gère la génération des commandes
////////////////////////////////////////////

public class gestionCommande : MonoBehaviour {

	//La quantité maximal de commande qu'il peut avoir à la fois
	private int NbsCommandeMax = 10;
	private int NbsCommandeGen = 0;

	//Le délai qu'il y a entre 2 commandes
	public int delaiEntreCommande;
	public int IDCommande;

	//Si le tuto est terminer
	public bool tutoFin;

	//Tableaux des sprites des boissons et nourriture
	public Sprite[] ArrayMenu;
	public Sprite oeufPaque;

	//Array qui va contenir les commandes actuelles
	public GameObject[] ArrayCommande;

	//Array des GameObjects 
	public GameObject[] ArrayComptoir;


	// Use this for initialization
	void Start () {
        //Start la fonction répétante pour générer
        genereCommandeTuto();

    }
	
	// Update is called once per frame
	void Update () {

		if(tutoFin == true)
		{
			//Start la fonction répétante pour générer
			InvokeRepeating("genereCommande", 3, delaiEntreCommande);
			tutoFin = false;
		}

		if(Input.GetKeyUp("s"))
		{
			supprimeCommande();
		}

		if(Input.GetKeyUp("p"))
		{
			//Random la chance de pogner un oeuf de pâque
				int chanceOeuf = Random.Range(0,20);
				print("L'oeuf est " + chanceOeuf);
		}

		//Start la fonction répétante pour générer
		//InvokeRepeating("genereCommande", 3, delaiEntreCommande);

	}//fin update

	public void genereCommande(){



		//Regarde si il y a de la place dans le tableau/ une commande en attente
		if(NbsCommandeGen < NbsCommandeMax){

			//Choisi aleatoirement la commande
			int comptoirInt = Random.Range(0, 10);
			while(ArrayComptoir[comptoirInt].transform.GetChild(0).GetComponent<papierScript>().commandeGenerer == true){
				comptoirInt = Random.Range(0, 10);
			}//fin while
			IDCommande++;
			//Change la bool en true
			ArrayComptoir[comptoirInt].transform.GetChild(0).GetComponent<papierScript>().commandeGenerer = true;

			//Fait apparaitre le papier(Renderder)
			ArrayComptoir[comptoirInt].transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;


			//*************** Random la chance de pogner un oeuf de pâque *******************************/
			int chanceOeuf = Random.Range(0,2);
			print("L'oeuf est " + chanceOeuf);
			if(chanceOeuf == 0){
				print("Oeuf a été pogner");
				//Donne la commande au papier
				//Choisi aleatoirement la commande

				//donne le nom de la commande
				ArrayComptoir[comptoirInt].transform.GetChild(0).GetComponent<papierScript>().commande = oeufPaque.name;
				//Donne le numero de la commande
				ArrayComptoir[comptoirInt].transform.GetChild(0).GetComponent<papierScript>().NoCommande = IDCommande;
			}else{

			}//fin if else oeuf
			//*************** Si on pogne pas un oeuf *******************************/

			//Donne la commande au papier
			//Choisi aleatoirement la commande
			var commandeSprite = ArrayMenu[Random.Range(0, 5)];
			//donne le nom de la commande
			ArrayComptoir[comptoirInt].transform.GetChild(0).GetComponent<papierScript>().commande = commandeSprite.name;
			//Donne le numero de la commande
			ArrayComptoir[comptoirInt].transform.GetChild(0).GetComponent<papierScript>().NoCommande = IDCommande;

		}//fin if NbsCommande


	}//fin function


	public void genereCommandeTuto(){
		
			//Choisi aleatoirement le comptoir
			int comptoirInt = Random.Range(0, 9);

			IDCommande++;

			//Change la bool en true
			ArrayComptoir[comptoirInt].transform.GetChild(0).GetComponent<papierScript>().commandeGenerer = true;

			//Fait apparaitre le papier(Renderder)
			ArrayComptoir[comptoirInt].transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;

			//Donne la commande au papier
			//Choisi aleatoirement la commande
			var commandeSprite = ArrayMenu[1];
			//donne le nom de la commande
			ArrayComptoir[comptoirInt].transform.GetChild(0).GetComponent<papierScript>().commande = commandeSprite.name;
			//Donne le numero de la commande
			ArrayComptoir[comptoirInt].transform.GetChild(0).GetComponent<papierScript>().NoCommande = IDCommande;

		//Mets la commande sur un comptoir aléatoirement
		//ajouteArray(commande);

	}//fin fonction

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

		
	}//fin fonction


	public void supprimeCommande(){
		var aleatoire = Random.Range(0, 10);

		ArrayCommande[aleatoire].transform.GetChild(1).GetComponent<Image>().sprite = null;
		ArrayCommande[aleatoire].transform.GetChild(0).GetComponent<Text>().text = "No";
	}//fin fonction


}
