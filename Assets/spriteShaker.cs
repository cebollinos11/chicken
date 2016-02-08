using UnityEngine;
using System.Collections;

public class spriteShaker : MonoBehaviour {

    public float amplitude;
    public float freq;
    public float howLong;

    
    public void ShakeIt() {

        StartCoroutine(ShakeMe());
    }

    IEnumerator ShakeMe()
    {

        float t = 0f ;

        do
        {

            t += Time.deltaTime;
            transform.position += Vector3.left * amplitude * Mathf.Sin(2f*3.14f*t*freq);
            yield return new WaitForEndOfFrame();


        } while (t < howLong);
        

        yield return new WaitForSeconds(1f);

    }
}
