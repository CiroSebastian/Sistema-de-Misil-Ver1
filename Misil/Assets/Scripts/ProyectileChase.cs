using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectileChase : MonoBehaviour
{
    public GameObject Player;
    public float speed;
    public float targetDistance;

    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        distance = Vector2.Distance(transform.position, Player.transform.position);
        Vector2 direction = Player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        
    }

    // Update is called once per frame
    void Update()
    {
     
    } 
}
