using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float upForce = 100f;
    public float maxSpeed = 5f;
    bool facingRight = true;
    private bool isDead = false;
    private Rigidbody2D m_Rigidbody2D;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        m_Rigidbody2D.velocity = new Vector2(move * maxSpeed, m_Rigidbody2D.velocity.y);

        if(move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false)
        {
            if (Input.GetButtonDown("Jump"))
            {
                m_Rigidbody2D.velocity = Vector2.zero;
                m_Rigidbody2D.AddForce(new Vector2(0, upForce));
                anim.SetTrigger("Flap");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        m_Rigidbody2D.velocity = Vector2.zero;
        m_Rigidbody2D.gravityScale = 0;
        isDead = true;
        anim.SetTrigger("Die");
        GameControl.instance.BirdDied();
    }
}
