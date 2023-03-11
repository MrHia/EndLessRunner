using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CointSpawner : MonoBehaviour
{
    public float maxTime;

    float time;
    public float maxHeight;
    public float minHeight;

    public GameObject cointPrefab;
    GameObject coint;


    private void Update()
    {
        if (time > maxTime && GameManager._instance.isPlay)
        {
            coint = Instantiate(cointPrefab);
            coint.transform.position = transform.position + new Vector3(0, Random.Range(maxHeight, minHeight), 0);
            time = 0;
        }
        time += Time.deltaTime;
        Destroy(coint, 8f);
    }
}
