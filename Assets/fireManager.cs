using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class fireManager : MonoBehaviour {

    Slider slider;
    float currentSliderValue;
    Vector3 origScale;

    public float amplitude;
    public float freq;
    float osciOffset;

	// Use this for initialization
	void Start () {
        currentSliderValue = -1f;
        origScale = transform.localScale;
        slider = GameObject.FindGameObjectWithTag("Slider").GetComponent<Slider>();
        osciOffset = Random.Range(0f, 1f);
	}

    
	
	// Update is called once per frame
	void Update () {

        
        if(currentSliderValue != slider.value)
        {
            currentSliderValue = slider.value;
            transform.localScale = origScale*(currentSliderValue/20);
        
        }

        transform.localScale += Vector3.one* transform.localScale.x*0.01f * Mathf.Sin(2 * 3.14f * freq * Time.time+osciOffset);
        transform.position += Vector3.one  * 0.001f * Mathf.Sin(2 * 3.14f * freq * Time.time + osciOffset);
	
	}
}
