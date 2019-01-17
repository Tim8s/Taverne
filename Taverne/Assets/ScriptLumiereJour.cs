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

    public GameObject assiette;
    public GameObject cheese;
    public GameObject bread;
    public GameObject potato;

    public GameObject txt1;
    public GameObject txt2;
    public GameObject txt3;

    public ScriptLumiereAmbiance lumiereAmbiance;

    // Use this for initialization
    void Start ()
    {
        print(assiette.GetComponent<MeshRenderer>().material.color);
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
        assiette.GetComponent<MeshRenderer>().material.color = new Color(assiette.GetComponent<MeshRenderer>().material.color.r, assiette.GetComponent<MeshRenderer>().material.color.g, assiette.GetComponent<MeshRenderer>().material.color.b, 0);
        bread.GetComponent<MeshRenderer>().material.color = new Color(bread.GetComponent<MeshRenderer>().material.color.r, bread.GetComponent<MeshRenderer>().material.color.g, bread.GetComponent<MeshRenderer>().material.color.b, 0);
        potato.GetComponent<MeshRenderer>().material.color = new Color(potato.GetComponent<MeshRenderer>().material.color.r, potato.GetComponent<MeshRenderer>().material.color.g, potato.GetComponent<MeshRenderer>().material.color.b, 0);
        cheese.GetComponent<MeshRenderer>().material.color = new Color(cheese.GetComponent<MeshRenderer>().material.color.r, cheese.GetComponent<MeshRenderer>().material.color.g, cheese.GetComponent<MeshRenderer>().material.color.b, 0);

        print(assiette.GetComponent<MeshRenderer>().material.color);
        assiette.SetActive(true);
        bread.SetActive(true);
        cheese.SetActive(true);
        potato.SetActive(true);

        txt1.SetActive(true);
        txt2.SetActive(true);
        txt3.SetActive(true);

        Color assietteStart = assiette.GetComponent<MeshRenderer>().material.color;
        Color breadStart = bread.GetComponent<MeshRenderer>().material.color;
        Color potatoStart = potato.GetComponent<MeshRenderer>().material.color;
        Color cheeseStart = cheese.GetComponent<MeshRenderer>().material.color;

        float elapsedTime = 0;
        while (elapsedTime > 2)
        {
            assiette.GetComponent<MeshRenderer>().material.color = Color.Lerp(assietteStart, new Color(assietteStart.r, assietteStart.g, assietteStart.b, 1), elapsedTime / 2);
            bread.GetComponent<MeshRenderer>().material.color = Color.Lerp(breadStart, new Color(breadStart.r, breadStart.g, breadStart.b, 1), elapsedTime / 2);
            potato.GetComponent<MeshRenderer>().material.color = Color.Lerp(potatoStart, new Color(potatoStart.r, potatoStart.g, potatoStart.b, 1), elapsedTime / 2);
            cheese.GetComponent<MeshRenderer>().material.color = Color.Lerp(cheeseStart, new Color(cheeseStart.r, cheeseStart.g, cheeseStart.b, 1), elapsedTime / 2);

            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        assiette.GetComponent<MeshRenderer>().material.color = new Color(assietteStart.r, assietteStart.g, assietteStart.b, 1);
        bread.GetComponent<MeshRenderer>().material.color = new Color(breadStart.r, breadStart.g, breadStart.b, 1);
        potato.GetComponent<MeshRenderer>().material.color = new Color(potatoStart.r, potatoStart.g, potatoStart.b, 1);
        cheese.GetComponent<MeshRenderer>().material.color = new Color(cheeseStart.r, cheeseStart.g, cheeseStart.b, 1);

        yield return null;
    }

    public void ResetLumiere()
    {
        gameObject.transform.eulerAngles = angleDebut;

        lumiereAmbiance.ResetLumiere();
        StartCoroutine(MoveOverSeconds(gameObject, angleFin, 120f));
        StartCoroutine(ChangeColorOverSeconds(gameObject, secondColor, 30f));
    }
}
