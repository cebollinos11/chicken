using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class chicken : MonoBehaviour {




    public float updateRate;
    float updateme;
    public float cookness;
    Slider sl;
    public GameObject particles;
    bool particlesAlreadyStarted;

    AudioSource aSource;


    float cookRatio = 1f;

    GameManager GM;

    [HideInInspector]public spriteShaker sShaker;


	// Use this for initialization
	void Start () {
        GM = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        sShaker = GetComponent<spriteShaker>();
        aSource = GetComponent<AudioSource>();
        sl = GM.sliderGrill;
        //sR = GetComponent<SpriteRenderer>();

        string weight = "2 Kg.";
        

        int i = Random.Range(0, 100);
        if (i < 20) {
            transform.localScale = Vector3.one * 0.75f;
            cookRatio = 2;
            weight = "1 Kg.";
        }

        if (i >80)
        {
            transform.localScale = Vector3.one * 1.5f;
            cookRatio = 0.7f;
            weight = "4 Kg.";
        }

        GM.UI.chickenWeight.text = weight;

	}
	
	// Update is called once per frame
	void Update () {

        if (GM.status == GameManager.GameStates.cooking) {
            updateme -= Time.deltaTime;
            if (updateme < 0)
            {
                updateme = updateRate;
                updateChicken();
            }
        }
        

        
	
	}

    void updateChicken() {



        cookness += sl.value/100f*cookRatio*2;
        if (cookness > 200f)
        {
            cookness = 200f;
        }

        if (cookness >= 115 && !particlesAlreadyStarted)
        {
            cookness = 200f;
            particles.GetComponent<ParticleSystem>().Play();
            particlesAlreadyStarted = true;
            sShaker.ShakeIt();
            GM.PlayerWantsToFinishCooking();
            aSource.Play();
        }

        Debug.Log(cookness);

    }

   
}
