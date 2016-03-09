using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {


    public enum GameStates { 
    cooking,resultTab
    }

    [HideInInspector]
    public GameStates status;

    [HideInInspector] public uiManager UI;

    public grill Grill;
    [HideInInspector]
    public chicken currentChicken;
    public GameObject chickenPrefab;

    public Slider sliderGrill;

    public int satisfiedCustomers;
    public int tries;

    public runClass currentRun;



	// Use this for initialization
	void Start () {
        UI = GetComponent<uiManager>();

        currentRun = new runClass();
        currentRun.init();
        
        StartNewChicken();
        
	
	}

    public void PlayerWantsToFinishCooking() {
        if (status == GameStates.cooking)
        {
            
            status = GameStates.resultTab;
            UI.SetForResults();
            Grill.GoToRestaurant();
            
        }
    }


    public void StartNewGame() {

        currentRun = new runClass();
        currentRun.init();
        Debug.Log("new");
        Debug.Log(currentRun.chickensleft);
        StartNewChicken();
        
    
    }



    public void StartNewChicken() {


        if (currentRun.chickensleft < 1)
        {
            UI.SetForFinal();
            return;
        
        }
        
        currentRun.chickensleft--;
        
        tries++;

        if (currentChicken != null) {
            Destroy(currentChicken.gameObject);            
        }      



        Grill.GoToGrill();
        status = GameStates.cooking;
        UI.SetForCooking();

        //restart the grill
        sliderGrill.value = 10f;

        GameObject foo = (GameObject)Instantiate(chickenPrefab);
        currentChicken = foo.GetComponent<chicken>();
    
    
    }
	
	
}
