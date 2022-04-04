using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speed = 5.0f;
    private float horizontalMovement = 0.0f;
    // muuttuja Rigidbodylle, jota liikutetaan
    public Rigidbody2D myRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // haetaan näppäimistöltä tieto halutusta sivuttaisliikkeestä
        horizontalMovement = Input.GetAxis("Horizontal");
        // testataan kirjoittamalla konsoliin
        Debug.Log(horizontalMovement);
    }
    // tasaisesti pyörivä luuppi liikettä varten
    void FixedUpdate()
    {
        // tehdään liikevektori osissa, ensin x-akseli
        // nopeus kertaa näppäimistöltä tullut tieto
        float xVelocity = speed * horizontalMovement;
        // y-akselille otetaan tieto rigidbodylta
        float yVelocity = myRigidbody.velocity.y;
        // luodaan näiden avulla uusi liikevektori rigidbodylle
        myRigidbody.velocity = new Vector2(xVelocity, yVelocity);
    }
}
