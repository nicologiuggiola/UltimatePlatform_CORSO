using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameManager gameManager;
    public Transform playerTraform;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.playerDead)
        {
            playerTraform = FindObjectOfType<PlayerScript>().transform;
            transform.position = new Vector3(playerTraform.position.x, playerTraform.position.y, playerTraform.position.z - 1);
        }
        else
        {
            playerTraform = transform;
        }
    }
}
