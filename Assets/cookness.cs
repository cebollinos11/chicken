using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class cookness : MonoBehaviour {

    chicken ch;
    Text tx;

    void findCurrentChicken() {

        ch = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().currentChicken;
    }
	// Use this for initialization
	void Start () {
        findCurrentChicken();
        tx = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (ch == null)
        {
            findCurrentChicken();
        }
        tx.text = ((int)(ch.cookness)).ToString()+"%";
	}
}
