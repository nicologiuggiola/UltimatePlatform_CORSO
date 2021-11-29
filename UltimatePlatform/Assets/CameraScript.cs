using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public Transform playerTraform;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerTraform = FindObjectOfType<PlayerScript>().transform;
        transform.position = new Vector3(playerTraform.position.x, playerTraform.position.y, playerTraform.position.z -1);
    }
}
