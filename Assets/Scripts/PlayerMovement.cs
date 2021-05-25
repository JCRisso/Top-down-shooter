﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    public Camera cam;

    public float Tiempo = 0f;

    Vector2 movement;
    Vector2 mousePos;

        void Update()
     {
       movement.x = Input.GetAxisRaw("Horizontal");
       movement.y = Input.GetAxisRaw("Vertical");

        
       mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Tiempo += Time.deltaTime;
        if (Tiempo >= 15)
        {
            SceneManager.LoadScene("Victoria");
        }

        cam.transform.position = new Vector3(transform.position.x, transform.position.y, cam.transform.position.z);

    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;


    }

    public void Die()
    {
        //Destroy(gameObject);
        SceneManager.LoadScene("Derrota");
    }

}