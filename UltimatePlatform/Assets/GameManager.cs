using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameManager instance;
    public PlayerScript player;
    public Creatore creatore;
    public int lifeCount;
    public float respawnCD = 2;
    public bool playerDead = false;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        lifeCount = 3;
    }
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerScript>();
        creatore = FindObjectOfType<Creatore>();
    }

    // Update is called once per frame
    void Update()
    {
        player = FindObjectOfType<PlayerScript>();
        if (playerDead && lifeCount > 0)
        {
            respawnCD -= Time.deltaTime;
            if (respawnCD <= 0)
            {
                creatore.Create();
                respawnCD = 2;
                playerDead = false;
            }
        }     
    }

    private void GameOver()
    {

    }

    public void KillAndRespawn()
    {
        Destroy(player.gameObject);
        playerDead = true;
        lifeCount--;
        if (lifeCount <= 0)
        {
            GameOver();
        }
    }
}
