using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRoom : MonoBehaviour
{
    public Vector3 cameraChangePos;
    public Vector3 playerChangePos;
    private Camera cam;

    private void Start()
    {
        cam = Camera.main.GetComponent<Camera>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            collision.transform.position += playerChangePos;
            cam.transform.position += cameraChangePos;
        }
    }
}
