using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptLumiereAmbiance : MonoBehaviour {

    float intensity1 = 1;
    float intensity2 = 0;

	// Use this for initialization
	void Start () {
        StartCoroutine(ChangeIntensityOverSeconds(gameObject, intensity1, 60f));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator ChangeIntensityOverSeconds(GameObject objectToChange, float intensity, float seconds)
    {
        float elapsedTime = 0;
        float startIntensity = objectToChange.GetComponent<Light>().intensity;
        while (elapsedTime < seconds)
        {
            objectToChange.GetComponent<Light>().intensity = Mathf.Lerp(startIntensity, intensity, (elapsedTime / seconds));

            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        objectToChange.GetComponent<Light>().intensity = intensity;
        StartCoroutine(SecondChangeIntensityOverSeconds(gameObject, intensity2, 60f));
    }

    IEnumerator SecondChangeIntensityOverSeconds(GameObject objectToChange, float intensity, float seconds)
    {
        float elapsedTime = 0;
        float startIntensity = objectToChange.GetComponent<Light>().intensity;
        while (elapsedTime < seconds)
        {
            objectToChange.GetComponent<Light>().intensity = Mathf.Lerp(startIntensity, intensity, (elapsedTime / seconds));

            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        objectToChange.GetComponent<Light>().intensity = intensity;
    }

    public void ResetLumiere()
    {
        gameObject.GetComponent<Light>().intensity = 0;

        StartCoroutine(ChangeIntensityOverSeconds(gameObject, intensity1, 60f));
    }
}
