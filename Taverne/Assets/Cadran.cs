using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cadran : MonoBehaviour {

    public Image image;
    Color startColor = new Color(1, 1, 1, 0.1f);
    Color rouge = new Color(1, 0.1843137f, 0.1843137f, 1f);

    public gestionCommande gererCommande;

    GameObject papier;

	// Use this for initialization
	void Start () {
        Initialize();
    }

    public void Initialize()
    {
        papier = gameObject.transform.parent.transform.parent.transform.parent.gameObject;
        gameObject.GetComponent<Image>().color = startColor;
        StartCoroutine(ColorOverSeconds(image, rouge, 50));
    }

    // Update is called once per frame
    void Update () {
        if (gameObject.GetComponent<Image>().fillAmount == 1)
        {
            DetruireCommande();
        }
	}

    IEnumerator ColorOverSeconds(Image image, Color rouge2, float seconds)
    {
        float elapsedTime = 0;

        while (elapsedTime < seconds)
        {
            gameObject.GetComponent<Image>().color = Color.Lerp(startColor, rouge2, elapsedTime / seconds);
            gameObject.GetComponent<Image>().fillAmount = Mathf.Lerp(0, 1, elapsedTime / seconds);
            elapsedTime += Time.deltaTime;
            yield return new WaitForSeconds(0.01f);
        }
        gameObject.GetComponent<Image>().color = rouge2;
        gameObject.GetComponent<Image>().fillAmount = 1;

        yield return null;
    }

    void DetruireCommande()
    {
        gameObject.GetComponent<Image>().fillAmount = 0;
        gererCommande.supprimeCommande(gameObject.GetComponentInParent<papierScript>().NoCommande, -10);
        gameObject.transform.parent.gameObject.SetActive(false);

        papier.GetComponent<papierScript>().commandeGenerer = false;
        papier.GetComponent<papierScript>().commandePris = false;
        papier.GetComponent<MeshRenderer>().enabled = false;
    }
}
