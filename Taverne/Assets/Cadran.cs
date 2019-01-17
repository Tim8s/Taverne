using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cadran : MonoBehaviour {

    public Image image;
    Color startColor = new Color(1, 1, 1, 0.1f);
    Color rouge = new Color(1, 0.1843137f, 0.1843137f, 1f);

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Image>().color = startColor;
        StartCoroutine(ColorOverSeconds(image, rouge, 30f));
    }
	
	// Update is called once per frame
	void Update () {
		
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

        yield return null;
    }
}
