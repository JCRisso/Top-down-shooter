using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Enemies : MonoBehaviour
{
    private Transform Player;
    private Rigidbody2D rb;
    public float moveSpeed = 8f;
    private Vector2 movement;
    public GameObject Jugador;
    
    



    void Start()
    {
        Player = GameObject.Find("Player").transform;
        rb = this.GetComponent<Rigidbody2D>();


    }

    
    void Update()
    {
        Vector3 direction = Player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;


        


    }

    private void FixedUpdate()
    {

        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

        void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Disparo"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().Die();
            //StartCoroutine(DeadTime());
        }

    }

  // IEnumerator DeadTime()
    //{
        //yield return new WaitForSeconds(1);
       // SceneManager.LoadScene("Derrota");
    //}
}
