using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creatore : MonoBehaviour
{
    public GameObject playerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Create()
    {
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
    }
}
