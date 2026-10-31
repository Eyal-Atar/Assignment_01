using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public float playerScore = 0;
    private float coinsCollected = 0;
    public static GameManager managerRef;
    public bool lose=false;
    //ref
    private GameObject player ; 
    GameObject chasing_pill; 
    public GameObject[] coins;
    public TMPro.TextMeshProUGUI playerScoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        chasing_pill = GameObject.FindGameObjectWithTag("chasing");
        for (int i = 0; i < 5; i++)
        {
            spawnRandomCoin();
        }
    }
    void Awake()
    {
        managerRef = this;
    }

    // Update is called once per frame
    void Update()
    {
        playerScoreText.SetText(playerScore.ToString());
        if (playerScore > 1000)
        {
            Debug.Log("playerScore: " + playerScore);
            Debug.Log("You Won");
            playerScoreText.SetText("YOU WON");
            
            Destroy(player);
        }

        if (lose)
        {
            Debug.Log("playerScore: " + playerScore);
            Debug.Log("You Lost");
            playerScoreText.SetText("YOU Lose");
            
            Destroy(player);
            Destroy(chasing_pill);
        }
        

    }

    void spawnRandomCoin()
    {
        int rand = Random.Range(0, coins.Length);
        Vector2 temp = new Vector2(Random.Range(pill_player.xlim, -pill_player.xlim),
            Random.Range(pill_player.ylim, -pill_player.ylim));
        Instantiate(coins[rand], temp, transform.rotation);
    }
    
    public void addScore(float score)
    {
        
        playerScore += score;
        coinsCollected += 1;
        Debug.Log("Score: " + playerScore);
    }
    public void coinsManager()
    {
        if (coinsCollected % 5 == 0 && coinsCollected != 0)
        {
            for (int i=0; i<5; i++)
                spawnRandomCoin();
        }
    }
}
