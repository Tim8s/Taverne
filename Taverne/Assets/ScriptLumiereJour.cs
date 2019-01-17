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

    public GameObject objetsVictoire;

    public GameObject txt1;
    public GameObject txt2;
    public GameObject txt3;
    public GameObject ballounes;

    public ScriptLumiereAmbiance lumiereAmbiance;

    // Use this for initialization
    void Start ()
    {
        angleDebut = gameObject.transform.eulerAngles;

        secondColor = new Color(1, 0.9960784f, 0.6f, 1);
        thirdColor = new Color(0.6627451f, 0.4235294f, 0.1058824f, 1);
        endColor = new Color(0, 0, 0, 1);
        angleFin = new Vector3(gameObject.transform.eulerAngles.x, 400, gameObject.transform.eulerAngles.z);

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
        print(startingPos);
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

        txt1.SetActive(true);
        txt2.SetActive(true);
        txt3.SetActive(true);

        ballounes.SetActive(true);
        objetsVictoire.SetActive(true);

        StartCoroutine(DetruireBallounes());

        yield return null;
    }

    IEnumerator DetruireBallounes()
    {
        yield return new WaitForSeconds(2);

        ballounes.SetActive(false);
    }

    public void ResetLumiere()
    {
        gameObject.transform.eulerAngles = angleDebut;

        lumiereAmbiance.ResetLumiere();
        StartCoroutine(MoveOverSeconds(gameObject, angleFin, 120f));
        StartCoroutine(ChangeColorOverSeconds(gameObject, secondColor, 30f));
    }
}
