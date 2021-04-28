using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField]
    private GameObject object_pre;

    private float time1 = 0.0f;
    public float interpolationPeriod1 = 1.5f; // inspector overridee tän

    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    void Update()
    {
        time1 += Time.deltaTime;

        if (time1 >= interpolationPeriod1)
        {
            time1 = time1 - interpolationPeriod1;

            SpawnObj(); //spawnataan näitä ihan saatanasti.

        }
    }

    public void SpawnObj()
    {
        bool objectSpawned = false;
        while (!objectSpawned)
          {
            Vector3 objectPosition = new Vector3(Random.Range(-7f, 7f), Random.Range(-4f, 4f), 0f);
            Instantiate(object_pre, objectPosition, Quaternion.identity);
            //AudioManager.instance.PlaySFX("SFX1");
            objectSpawned = true;
          }
    }

}
