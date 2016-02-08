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

    spriteShaker sShaker;


	// Use this for initialization
	void Start () {
        GM = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        sShaker = GetComponent<spriteShaker>();
        aSource = GetComponent<AudioSource>();
        sl = GM.sliderGrill;
        //sR = GetComponent<SpriteRenderer>();

        int i = Random.Range(0, 100);
        if (i < 20) {
            transform.localScale = Vector3.one * 0.75f;
            cookRatio = 2;
        }

        if (i >80)
        {
            transform.localScale = Vector3.one * 1.5f;
            cookRatio = 0.7f;
        }

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
        cookness += sl.value/100f*cookRatio;
        if (cookness > 100f)
        {
            cookness = 100f;
        }

        if (cookness > 62 && !particlesAlreadyStarted)
        {
            particles.GetComponent<ParticleSystem>().Play();
            particlesAlreadyStarted = true;
            sShaker.ShakeIt();
            GM.PlayerWantsToFinishCooking();
            aSource.Play();
        }

    }

   
}
