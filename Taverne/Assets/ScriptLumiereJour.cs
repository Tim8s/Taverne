using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptLumiereJour : MonoBehaviour {

    Vector3 angleFin;

    Color secondColor;
    Color thirdColor;
    Color endColor;

    // Use this for initialization
    void Start ()
    {
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
            print(elapsedTime);
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
            print("SECOND");
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
            print("THIRD");
            objectToChange.GetComponent<Light>().color = Color.Lerp(startColor, black, (elapsedTime / seconds));

            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        objectToChange.GetComponent<Light>().color = black;
    }
}
