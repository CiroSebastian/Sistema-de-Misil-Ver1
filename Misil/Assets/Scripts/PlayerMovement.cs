using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jump;

    private float Move;

    int JumpCount = 1;

    public Rigidbody2D rb;

    public bool isJumping;

    public GameObject Standing;
    public GameObject Crouching;

    // Start is called before the first frame update
    void Start()
    {
        Crouching.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(speed * Move, rb.velocity.y); 

        if(Input.GetKeyDown(KeyCode.W) && isJumping == false && JumpCount < 1)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            isJumping = true;

            JumpCount++;
        }
        
        if(Input.GetKeyDown(KeyCode.S) && isJumping == false)
        {
            rb.transform.localScale = new Vector2(transform.localScale.x, 0.5f);
            rb.AddForce(new Vector2(rb.velocity.x, (jump * -2)));
            Standing.SetActive(false);
            Crouching.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.S) && isJumping == false)
        {
            rb.transform.localScale = new Vector2(transform.localScale.x, 1f);
            Crouching.SetActive(false);
            Standing.SetActive(true);
        }
        
        if (Input.GetKeyDown(KeyCode.S) && isJumping == true)
        {
            rb.AddForce(new Vector2(rb.velocity.x, (jump * -2)));
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
            JumpCount--;
        }

        if (other.gameObject.CompareTag("KillBox"))
        {
            StartCoroutine(Lose());
        }
    } 

    IEnumerator Lose()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
