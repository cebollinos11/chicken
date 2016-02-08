using UnityEngine;
using System.Collections;

public class grill : MonoBehaviour {

    public int nFiresX;
    public int nFiresY;
    public GameObject firePrefab;

    float xSpace = 1f;
    float ySpace = 1f;

    float speed = 1f;

    IEnumerator GoTo(Vector3 destination) {

        Vector3 origin = transform.position;

        int parts = 30;

        Vector3 delta = (destination - origin) / parts;

        for (int i = 0; i < parts; i++)
        {
            transform.position += delta;
            yield return new WaitForEndOfFrame();
        }

        transform.position = destination;
        yield return new WaitForEndOfFrame();
    }

    public void GoToGrill() {
        //transform.position = Vector3.zero;
        StartCoroutine(GoTo(Vector3.zero));
    }

    public void GoToRestaurant() {
        //transform.position = Vector3.zero + Vector3.left * 10;
        StartCoroutine(GoTo(Vector3.zero+ Vector3.down * 20));
    }
	// Use this for initialization
	void Start () {

        for (int j = 0; j < nFiresY; j++)
        {
            for (int i = 0; i < nFiresX; i++)
            {
                GameObject foo= (GameObject) Instantiate(firePrefab, new Vector3(xSpace * i, ySpace * j, 0f)-new Vector3(xSpace*(nFiresX-1)/2,ySpace*nFiresY/2,0), Quaternion.identity);
                foo.transform.parent = transform;
            }
        }

        
	
	}

}
