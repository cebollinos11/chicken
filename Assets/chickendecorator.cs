using UnityEngine;
using System.Collections;

public class chickendecorator : MonoBehaviour {


    public SpriteRenderer rawSprite;
    public SpriteRenderer cookedSprite;
    public SpriteRenderer burntSprite;

    chicken chickenScript;

	// Use this for initialization
	void Start () {
        chickenScript = GetComponent<chicken>();
        
	}

    public void FocusOnMe() {
        StartCoroutine(HighlightMe());
    }

    IEnumerator HighlightMe() {
        yield return new WaitForEndOfFrame();

        int hits = 3;

        Vector3 originScale = transform.localScale;
        float multiplier = 1.2f;
        float freq = 0.2f;
        for (int i = 0; i < hits; i++)
        {
            transform.localScale = originScale * multiplier;
            yield return new WaitForSeconds(freq);
            transform.localScale = originScale;
            yield return new WaitForSeconds(freq);

        }
    }
	
	// Update is called once per frame
	void Update () {
        float cookness = chickenScript.cookness;


        //handle Sprite
        float c;
        c = cookness * (1f / 100f) ;
        cookedSprite.color = new Color(1, 1, 1, c);

        if (cookness > 100)
        {
            c = (cookness-100f) * (1f / 100f);
            burntSprite.color = new Color(0, 0, 0, c);
        }


	}
}
