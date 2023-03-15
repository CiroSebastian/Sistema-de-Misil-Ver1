using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipPlayer : MonoBehaviour
{
    Rigidbody2D rb;
    float inputHorizontal;
    bool facingRight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");

        if (inputHorizontal < 0 && !facingRight)
        {
            Flip();
        }

        if (inputHorizontal > 0 && facingRight)
        {
            Flip();

        }
    }

    void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }

}
