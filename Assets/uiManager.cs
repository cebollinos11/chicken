using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class uiManager : MonoBehaviour {

    GameManager GM;

    public GameObject ResultsTab;
    public GameObject CookingTab;
    public Text resultText;
    public Text satisfiedCustomers;

    public AudioClip soundNice;
    public AudioClip soundraw;
    public AudioClip soundperfect;
    AudioSource aSource;


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
    public void SetForCooking() {


        StartCoroutine(showCookingTabCo());
        ResultsTab.SetActive(false);
    
    }

    public void SetForResults() {
        
        CookingTab.SetActive(false);
        StartCoroutine(showResultsTabCo());
        UpdateResultText(GM.currentChicken.cookness);
        satisfiedCustomers.text = GM.satisfiedCustomers+"/" + GM.tries;
    
    }

    IEnumerator showResultsTabCo() {

        yield return new WaitForSeconds(0.5f);
        ResultsTab.SetActive(true);
        aSource.Play();
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
        float diff = cookness - 60;

        aSource.clip = null;


        if (diff < -10){
            t = "too raw";
            aSource.clip = soundraw;
           
            
            
        }
            
        else if (diff >= 2){
            t = "you burned it!";
            c = Color.black;
            
        }
        else if (Mathf.Abs(diff) < 2){
            t = "perfect!";
            c = Color.yellow;
            GM.satisfiedCustomers++;
            aSource.clip = soundperfect;
        }
        else{
            t = "nice!";
            c = Color.blue;
            GM.satisfiedCustomers++;
            aSource.clip = soundNice;
        }

        resultText.text = t;
        resultText.color = c;
            
        
    }
    
}
