using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    int facing = 1;
    public Rigidbody2D myRigidbody;
    public BoxCollider2D myFace;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector2(facing, 1);
    }
    void FixedUpdate()
    {
        // liikutetaan tyyppiä nopeuden verran naaman suuntaan, y-suunnassa haetaan oleva liike
        myRigidbody.velocity = new Vector2(facing * moveSpeed, myRigidbody.velocity.y);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        facing *= -1;
    }
}
