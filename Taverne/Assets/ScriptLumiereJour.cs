using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptLumiereJour : MonoBehaviour {

    Vector3 angleFin;
    Vector3 angleDebut;

    Color secondColor;
    Color thirdColor;
    Color endColor;

    public GameObject panel;
    public GameObject retourMenu;
    public GameObject continuer;

    public Text txtQuit;
    public Text txtContinuer;

    public ScriptLumiereAmbiance lumiereAmbiance;

    // Use this for initialization
    void Start ()
    {
        angleDebut = gameObject.transform.eulerAngles;

        panel.GetComponent<CanvasRenderer>().SetAlpha(0);
        retourMenu.GetComponent<CanvasRenderer>().SetAlpha(0);
        continuer.GetComponent<CanvasRenderer>().SetAlpha(0);
        secondColor = new Color(255, 254, 153, 255);
        thirdColor = new Color(169, 108, 27, 255);
        endColor = new Color(0, 0, 0, 255);
        angleFin = new Vector3(gameObject.transform.eulerAngles.x, 160, gameObject.transform.eulerAngles.z);

        StartCoroutine(MoveOverSeconds(gameObject, angleFin, 120f));
        StartCoroutine(ChangeColorOverSeconds(gameObject, secondColor, 30f));
    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.eulerAngles;
        while (elapsedTime < seconds)
        {
            objectToMove.transform.eulerAngles = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
        
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        objectToMove.transform.eulerAngles = end;
    }

    IEnumerator ChangeColorOverSeconds(GameObject objectToChange, Color yellow, float seconds)
    {
        float elapsedTime = 0;
        Color startColor = objectToChange.GetComponent<Light>().color;
        while (elapsedTime < seconds)
        {
            objectToChange.GetComponent<Light>().color = Color.Lerp(startColor, yellow, (elapsedTime / seconds));
            
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        objectToChange.GetComponent<Light>().color = yellow;
        StartCoroutine(SecondChangeColorOverSeconds(gameObject, thirdColor, 30f));
    }

    IEnumerator SecondChangeColorOverSeconds(GameObject objectToChange, Color orange, float seconds)
    {
        float elapsedTime = 0;
        Color startColor = objectToChange.GetComponent<Light>().color;
        while (elapsedTime < seconds)
        {
            objectToChange.GetComponent<Light>().color = Color.Lerp(startColor, orange, (elapsedTime / seconds));

            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        objectToChange.GetComponent<Light>().color = orange;
        StartCoroutine(ThirdChangeColorOverSeconds(gameObject, endColor, 30f));
    }

    IEnumerator ThirdChangeColorOverSeconds(GameObject objectToChange, Color black, float seconds)
    {
        float elapsedTime = 0;
        Color startColor = objectToChange.GetComponent<Light>().color;
        while (elapsedTime < seconds)
        {
            objectToChange.GetComponent<Light>().color = Color.Lerp(startColor, black, (elapsedTime / seconds));

            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        objectToChange.GetComponent<Light>().color = black;
        StartCoroutine(FinPartie());
    }

    IEnumerator FinPartie()
    {
        panel.SetActive(true);
        retourMenu.SetActive(true);
        continuer.SetActive(true);

        panel.GetComponent<Image>().CrossFadeAlpha(0.5f, 2f, true);
        retourMenu.GetComponent<Image>().CrossFadeAlpha(0.5f, 2f, true);
        continuer.GetComponent<Image>().CrossFadeAlpha(0.5f, 2f, true);

        StartCoroutine(AfficherTextes());

        yield return null;
    }

    IEnumerator AfficherTextes()
    {
        yield return new WaitForSeconds(2);
        retourMenu.GetComponent<Button>().enabled = true;
        continuer.GetComponent<Button>().enabled = true;
        txtContinuer.enabled = true;
        txtQuit.enabled = true;
    }

    public void ResetLumiere()
    {
        panel.SetActive(false);
        retourMenu.SetActive(false);
        continuer.SetActive(false);

        panel.GetComponent<CanvasRenderer>().SetAlpha(0);
        retourMenu.GetComponent<CanvasRenderer>().SetAlpha(0);
        continuer.GetComponent<CanvasRenderer>().SetAlpha(0);

        gameObject.transform.eulerAngles = angleDebut;

        lumiereAmbiance.ResetLumiere();
        StartCoroutine(MoveOverSeconds(gameObject, angleFin, 120f));
        StartCoroutine(ChangeColorOverSeconds(gameObject, secondColor, 30f));
    }
}
