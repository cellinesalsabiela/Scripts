using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerPos; // variable , untuk player. PlayerPost" Player Position
    public Vector3 offset;
    public float cameraSpeed;

// public biar bisa diatur dicamera

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, playerPos.position + offset , cameraSpeed * Time.deltaTime);
        // Vector 3 agar cameranya bagus
        // cameraSpeed * Time.deltaTime : agar smooth
    }
}


// Camera follows : 