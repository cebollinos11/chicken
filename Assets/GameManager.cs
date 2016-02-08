using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {


    public enum GameStates { 
    cooking,resultTab
    }

    [HideInInspector]
    public GameStates status;

    uiManager UI;

    public grill Grill;
    [HideInInspector]
    public chicken currentChicken;
    public GameObject chickenPrefab;

    public Slider sliderGrill;

    public int satisfiedCustomers;
    public int tries;

	// Use this for initialization
	void Start () {
        UI = GetComponent<uiManager>();
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



    public void StartNewChicken() {

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
