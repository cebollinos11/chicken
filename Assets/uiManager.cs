﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class uiManager : MonoBehaviour {

    GameManager GM;

    public GameObject ResultsTab;
    public GameObject CookingTab;
    public GameObject FinalTab;
    public Text resultText;
    public Text satisfiedCustomers;

    public Text chickenWeight;

    public AudioClip soundNice;
    public AudioClip soundraw;
    public AudioClip soundperfect;
    AudioSource aSource;
    bool shouldShake;
    bool shouldHighlight;

    public GameObject Salmonella;

	// Use this for initialization
	void Start () {
        GM = GetComponent<GameManager>();
        aSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ShowResultsTab() {

        ResultsTab.SetActive(true);    
    
    }

    public void PlayerClickedFinish() {
        GM.PlayerWantsToFinishCooking();
    
    }


    public void SetForFinal() {
        ResultsTab.SetActive(false);
        CookingTab.SetActive(false);
        FinalTab.SetActive(true);
        FinalTab.GetComponent<finalCount>().CountEverything();
    }

    public void SetForCooking() {


        StartCoroutine(showCookingTabCo());
        ResultsTab.SetActive(false);
        FinalTab.SetActive(false);
    
    }

    public void SetForResults() {
        
        CookingTab.SetActive(false);
        StartCoroutine(showResultsTabCo());
        UpdateResultText(GM.currentChicken.cookness);
        //satisfiedCustomers.text = GM.satisfiedCustomers+"/" + GM.tries;
        satisfiedCustomers.text = GM.currentRun.chickensleft.ToString();
    
    }

    IEnumerator executeSalmonellaStamp() {

        yield return new WaitForSeconds(1f);
        Salmonella.SetActive(true);
    
    }

    IEnumerator showResultsTabCo() {

        yield return new WaitForSeconds(0.5f);
        ResultsTab.SetActive(true);
        aSource.Play();
        Salmonella.SetActive(false);
        if (aSource.clip == soundraw) {
            StartCoroutine(executeSalmonellaStamp());
        }
        if (shouldShake) {
            GM.currentChicken.sShaker.ShakeIt();
        }
        if (shouldHighlight) {
            GM.currentChicken.GetComponent<chickendecorator>().FocusOnMe();
        }
    }

    IEnumerator showCookingTabCo()
    {

        yield return new WaitForSeconds(0.5f);
        CookingTab.SetActive(true);
    }

    public void PlayerClickedOnNewChicken() {

        GM.StartNewChicken();
    
    }

    

    public void UpdateResultText(float cookness) {

        string t = "too raw!";
        Color c = Color.white;
        float diff = cookness - 100;
        shouldShake = false;
        shouldHighlight = false;

        aSource.clip = null;


        if (cookness < 80){
            shouldShake = true;
            t = "too raw";
            aSource.clip = soundraw;        
            
        }
            
        else if (cookness<95){
            t = "juicy!";
            c = Color.green;
            aSource.clip = soundNice;
            shouldHighlight = true;
            shouldHighlight = true;
            GM.currentRun.juicy++;
            
        }
        else if (cookness < 105)
        {
            t = "perfect!";
            c = Color.yellow;
            GM.satisfiedCustomers++;
            aSource.clip = soundperfect;
            shouldHighlight = true;
            GM.currentRun.perfect++;
        }
        else if(cookness<120){
            t = "crispy!";
            c = Color.red;
            GM.satisfiedCustomers++;
            aSource.clip = soundNice;
            shouldHighlight = true;
            GM.currentRun.crispy++;
        }

        else{
            t = "you burnt it!";
            c = Color.black;
            
            
        }

        resultText.text = t;
        resultText.color = c;
            
        
    }
    
}
