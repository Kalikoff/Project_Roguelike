using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteExits : MonoBehaviour
{
    public GameObject block;
    private bool isEmpty = true;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Block_Wall"))
        {
            Instantiate(block, transform.GetChild(0).position, gameObject.transform.rotation);
            Destroy(gameObject);
        }

        if (collision.CompareTag("Block_Door"))
        {
            isEmpty = false;
        }
    }

    private void Start()
    {
        Invoke("Play", 5f);
    }

    private void Play()
    {
        if (isEmpty)
        {
            Instantiate(block, transform.GetChild(0).position, gameObject.transform.rotation);
            Destroy(gameObject);
        }    
    }
}