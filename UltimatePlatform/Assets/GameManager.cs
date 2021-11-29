using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public PlayerScript player;
    public GameObject creatore;
    public float respawnCD = 2;
    public bool playerDead = false;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        player = FindObjectOfType<PlayerScript>();
        if (playerDead)
        {
            respawnCD -= Time.deltaTime;
            if (respawnCD <= 0)
            {
                Instantiate(playerPrefab, creatore.transform.position, Quaternion.identity);
                respawnCD = 2;
                playerDead = false;
            }
        }
    }

    public void KillAndRespawn()
    {
        Destroy(player.gameObject);
        playerDead = true;
    }
}
