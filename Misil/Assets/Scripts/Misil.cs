using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Misil : MonoBehaviour
{
    public GameObject Player;
    public float speed;
    public bool IsLaunching = false;
    private float distance;

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(Launch());
    }

    // Update is called once per frame
    void Update()
    {
        
        if (IsLaunching == true)
        {
            Follow();
        }

        speed = speed - .01f;
    }

    private void Follow()
    {
        distance = Vector2.Distance(transform.position, Player.transform.position);
        Vector2 direction = Player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }

    IEnumerator Launch()
    {

        rb.AddForce(new Vector2(rb.velocity.x, (speed*10)));
        yield return new WaitForSeconds(1.0f);
        rb.AddForce(new Vector2(0,0));
        IsLaunching = true;
    }

   


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Destroy(gameObject); 
        }
    }
}
