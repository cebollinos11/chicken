using UnityEngine;
using System.Collections;

public class animateFire : MonoBehaviour {

    public Sprite[] frames;
    public float animSpeed;
    bool animate;
    int index;
    SpriteRenderer sR;
    

	// Use this for initialization
	void Start () {

        sR = GetComponent<SpriteRenderer>();
        animate = true;
        StartCoroutine(AnimateUntilStop());
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator AnimateUntilStop() {
        index = 0;
        do
        {

            sR.sprite = frames[index];
            yield return new WaitForSeconds(animSpeed);
            index++;
            if (index >= frames.Length)
                index = 0;

        } while (animate);

        
    
    }

}
