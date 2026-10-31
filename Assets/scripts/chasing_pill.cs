using UnityEngine;

public class chasing_pill : MonoBehaviour
{
    //
    public GameObject player;
    public float chasingSpeed=5f;
    private Rigidbody2D chasingRB;

    private Vector2 targetVector;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            Debug.unityLogger.Log("player not found");
        }

        chasingRB=gameObject.GetComponent<Rigidbody2D>();
        
        //random pos
        do
        {
            chasingRB.transform.position = new Vector3(Random.Range(pill_player.xlim, -pill_player.xlim),
                Random.Range(pill_player.ylim, -pill_player.ylim), 0);
        } while (Vector2.Distance(player.transform.position, chasingRB.transform.position) < 30);
            {
                chasingRB.transform.position = new Vector3(Random.Range(pill_player.xlim, -pill_player.xlim),
                    Random.Range(pill_player.ylim, -pill_player.ylim), 0);
                
            }
        


    }

    // Update is called once per frame
    void Update()
    {
        targetVector=new Vector2(player.transform.position.x-chasingRB.transform.position.x,player.transform.position.y-chasingRB.transform.position.y).normalized;
    }

    void FixedUpdate()
    {
        chasingRB.AddForce(targetVector*chasingSpeed);
        
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("you Lose");
            GameManager.managerRef.lose=true;
            GameManager.managerRef.playerScore = 0;
        }
    }
}
