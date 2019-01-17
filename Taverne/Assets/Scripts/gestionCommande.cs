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
	public int NbsCommandeGen = 0;

	//Le délai qu'il y a entre 2 commandes
	public int delaiEntreCommande;
	public int IDCommande;

	//Si le tuto est terminer
	public bool tutoFin = false;
	public bool isTuto = true;

	//Tableaux des sprites des boissons et nourriture
	public Sprite[] ArrayMenu;
	public Sprite oeufPaque;

	//Array qui va contenir les commandes actuelles
	public GameObject[] ArrayCommande;

	//Array des GameObjects 
	public GameObject[] ArrayComptoir;

    public Sprite commandeSprite;

    public float score;

    public Text txtScore;

    public Image fillScore;
    public Image fondScore;

	public GameObject txtTuto1;
	public GameObject txtTuto2;
	public GameObject txtTuto3;
	public GameObject txtTuto4;
	public GameObject txtTuto5;
	public GameObject txtTuto6;
	public GameObject txtTuto7;

	public GameObject lumPoule;

	// Use this for initialization
	void Start () {
        //Start la fonction répétante pour générer
        genereCommandeTuto();
    }
	
	// Update is called once per frame
	void Update () {

		if(isTuto == false)
		{
			print ("AYAYAY");
			//Start la fonction répétante pour générer
			InvokeRepeating("genereCommande", 5, delaiEntreCommande);
			tutoFin = true;
			isTuto = true;
		}

		/*if(Input.GetKeyUp("s"))
		{
			supprimeCommande();
		}*/

		if(Input.GetKeyUp("p"))
		{
			//Random la chance de pogner un oeuf de pâque
				int chanceOeuf = Random.Range(0,20);
				//print("L'oeuf est " + chanceOeuf);
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

            //Fait apparaitre son timer
            ArrayComptoir[comptoirInt].transform.GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(true);
            ArrayComptoir[comptoirInt].transform.GetChild(0).GetChild(0).GetChild(1).GetChild(0).gameObject.GetComponent<Cadran>().Initialize();
            ArrayComptoir[comptoirInt].transform.GetChild(0).GetChild(0).GetChild(1).GetChild(2).GetComponent<Text>().text = IDCommande + "";

            NbsCommandeGen++;
            print(NbsCommandeGen);

            //*************** Random la chance de pogner un oeuf de pâque *******************************/
            int chanceOeuf = Random.Range(0,2);
			//print("L'oeuf est " + chanceOeuf);
			if(chanceOeuf == 0){
				//print("Oeuf a été pogner");
				//Donne la commande au papier
				//Choisi aleatoirement la commande

				//donne le nom de la commande
				ArrayComptoir[comptoirInt].transform.GetChild(0).GetComponent<papierScript>().commande = oeufPaque;
				//Donne le numero de la commande
				ArrayComptoir[comptoirInt].transform.GetChild(0).GetComponent<papierScript>().NoCommande = IDCommande;
			}else{

			}//fin if else oeuf
			//*************** Si on pogne pas un oeuf *******************************/

			//Donne la commande au papier
			//Choisi aleatoirement la commande
			commandeSprite = ArrayMenu[Random.Range(0, 5)];
			//donne le nom de la commande
			ArrayComptoir[comptoirInt].transform.GetChild(0).GetComponent<papierScript>().commande = commandeSprite;
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
			//Choisi aleatoirement la commande POULET
			var commandeSprite = ArrayMenu[1];
			//donne le nom de la commande
			ArrayComptoir[comptoirInt].transform.GetChild(0).GetComponent<papierScript>().commande = commandeSprite;
			//Donne le numero de la commande
			ArrayComptoir[comptoirInt].transform.GetChild(0).GetComponent<papierScript>().NoCommande = IDCommande;

		//Mets la commande sur un comptoir aléatoirement

	}//fin fonction

	public void ajouteArray(Sprite commande, Transform papier){

		//Pour mettre la commande dans l'affichage
		for(int i = 0; i < 10; i++){

			if(ArrayCommande[i].transform.GetChild(1).GetComponent<Image>().sprite == null){
				//Ajoute l'image
				ArrayCommande[i].transform.GetChild(1).GetComponent<Image>().sprite = commande;

				//Ajoute le numéro de commande
				ArrayCommande[i].transform.GetChild(0).GetComponent<Text>().text = "No. " + papier.GetComponent<papierScript>().NoCommande;
				break;
			}//fin if

		}//fin for

		
	}//fin fonction


	public void supprimeCommande(int iNoCommande, int points){

        for(var i = 0; i < 10; i++)
        {
            if (ArrayCommande[i].transform.GetChild(0).GetComponent<Text>().text == "No. " + iNoCommande)
            {
                ArrayCommande[i].transform.GetChild(1).GetComponent<Image>().sprite = null;
                ArrayCommande[i].transform.GetChild(0).GetComponent<Text>().text = "No";
            }
        }

        if (score == 0 && points < 0)
        {
            score = 0;
        }
        else
        {
            score += points;

            fillScore.fillAmount = score / 30; 
            txtScore.text = score + " / 30";
        }
    }//fin fonction


}
