using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTailEffect : MonoBehaviour
{
    public float StartTimeBtwSpawm;

    public float timeBtwSpawm;

    public GameObject TailPrefab;

    private void Update()
    {
        if(timeBtwSpawm <= 0)
        {
            GameObject tail = Instantiate(TailPrefab, transform.position, Quaternion.identity);
            timeBtwSpawm = StartTimeBtwSpawm;
            Destroy(tail,4f);  
        }
        else
        {
            timeBtwSpawm -= Time.deltaTime;
        }
    }
}
