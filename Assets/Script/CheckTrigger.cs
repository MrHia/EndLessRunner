using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class CheckTrigger : MonoBehaviour
{
    public GameObject paticalPrefab;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coint")
        {
            FindObjectOfType<AudioManager>().Play("Coint");

            GameManager._instance.AddScore();
            //Debug.Log("Coint");

            Destroy(other.gameObject,0.02f);
        }
        if (other.gameObject.tag == "Wall")
        {
            Instantiate(paticalPrefab,transform.position,Quaternion.identity);
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Play("GameOver");
            GameManager._instance.GameOver();
            //Debug.Log("wall");
        }
    }
}
