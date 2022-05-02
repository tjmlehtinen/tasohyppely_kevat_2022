using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // muuttujat liikkumista varten
    float speed = 5.0f;
    float horizontalMovement = 0.0f;
    // muuttuja hyppyvoimalle
    float jumpForce = 7.0f;
    // muuttuja Rigidbodylle, jota liikutetaan
    public Rigidbody2D myRigidbody;
    // muuttuja maata varten
    public LayerMask Ground;
    // muuttuja jalkoja varten
    public CircleCollider2D Feet;
    // animaattori animaatioita varten
    public Animator myAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // haetaan näppäimistöltä tieto halutusta sivuttaisliikkeestä
        horizontalMovement = Input.GetAxis("Horizontal");
        // kerrotaan tämän itseisarvo animaattorille
        myAnimator.SetFloat("Speed", Mathf.Abs(horizontalMovement));
        // käännetään pelaaja menosuuntaan
        if (horizontalMovement < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        if (horizontalMovement > 0)
        {
            transform.localScale = new Vector2(1, 1);
        }
        if (Input.GetButtonDown("Jump") && Feet.IsTouchingLayers(Ground))
        {
            // tehdään vektori, joka annetaan hyppykäskyllä pelihahmolle
            Vector2 jumpVector = new Vector2(0, jumpForce);
            // lisätään pelaajan rigidbodyyn vektorin voima impulssina
            myRigidbody.AddForce(jumpVector, ForceMode2D.Impulse);
        }
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
