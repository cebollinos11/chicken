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
