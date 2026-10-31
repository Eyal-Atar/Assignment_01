using UnityEngine;

public class coin_script : MonoBehaviour
{
    public float coinVal = 50;
    private GameObject player; 

    public float duration = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player=GameObject.FindGameObjectWithTag("Player");


    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.managerRef.addScore(coinVal);
            Destroy(gameObject);
            GameManager.managerRef.coinsManager();
        }



    }
}
    

