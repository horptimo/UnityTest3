using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySFX : MonoBehaviour
{
    // Start is called before the first frame update
   
    
    
    private float time = 0.0f;
    public float interpolationPeriod = 0.1f; // inspector overridee tän

    void Update()
    {
        time += Time.deltaTime;

        if (time >= interpolationPeriod)
        {
            time = time - interpolationPeriod;

            AudioManager.instance.PlaySFX("SFX1");
            Debug.Log("Soi");
            
        }
    }


    
    
}
