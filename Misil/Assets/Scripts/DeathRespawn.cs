using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathRespawn : MonoBehaviour
{
    public GameObject death;
    public GameObject win;

    
    // Start is called before the first frame update
    void Start()
    {
        HideDeath();
        HideWin();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        transform.position = new Vector2(0, 0);   
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("KillBox"))
        {
            Respawn();
            ShowDeath();
            Invoke("HideDeath", 2f);
        }

        if (other.gameObject.CompareTag("Goal"))
        {
            Respawn();
            ShowWin();
            Invoke("HideWin", 2f);
        }
    }

    private void ShowDeath()
    {
        death.SetActive(true);
    }

    private void HideDeath()
    {
        death.SetActive(false);
    }

    private void ShowWin()
    {
        win.SetActive(true);
    }

    private void HideWin()
    {
        win.SetActive(false);
    }
}
