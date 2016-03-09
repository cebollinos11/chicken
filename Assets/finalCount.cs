using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class finalCount : MonoBehaviour {

    public GameManager GM;

    public Text juicyCount;
    public Text crispyCount;
    public Text perfectCount;

    public Text juicySum;
    public Text crispySum;
    public Text perfectSum;

    public Text totalText;
    int total;


    runClass cRun;

    

	// Use this for initialization
	public void CountEverything () {

        Debug.Log("Run awake");

        cRun = GM.currentRun;

        if (GM.currentRun == null)
        {
            return;

        }

        juicyCount.text = cRun.juicy.ToString();
        crispyCount.text = cRun.crispy.ToString();
        perfectCount.text = cRun.perfect.ToString();

        int jSum,cSum,pSum;

        jSum = 5*cRun.juicy;
        cSum = 8*cRun.crispy;
        pSum = 10*cRun.perfect;

        juicySum.text = jSum.ToString();
        crispySum.text = cSum.ToString();
        perfectSum.text = pSum.ToString();

        total = jSum + cSum + pSum;
        totalText.text = total.ToString();



	
	}
	
	
}
