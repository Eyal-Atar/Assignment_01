using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class pill_player : MonoBehaviour
{

    public Rigidbody2D pillRB;

    public float pill_speed = 5;
    float aVal; 
    float sVal; 
    float wVal;
    float dVal;
    Vector2 moV;
    public const float xlim = 48f, ylim = 21f;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pillRB = GetComponent<Rigidbody2D>();
        //random spawn
        pillRB.transform.position=new Vector3(Random.Range(xlim,-xlim),Random.Range(ylim,-ylim),0);

    }


    // Update is called once per frame
    void Update()
    {
        //awsd
        aVal = Keyboard.current.aKey.ReadValue();
        sVal = Keyboard.current.sKey.ReadValue();
        wVal = Keyboard.current.wKey.ReadValue(); 
        dVal = Keyboard.current.dKey.ReadValue();
        //Debug.Log($"{aVal} + {sVal} + {wVal} + {dVal}");
        moV=new Vector2(dVal-aVal,wVal-sVal);


        
    }
    void FixedUpdate()
    {
        pillRB.AddForce(moV*pill_speed);
            
    }

}
