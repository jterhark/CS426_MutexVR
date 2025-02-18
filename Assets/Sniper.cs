﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : MonoBehaviour {

    public Transform player;
    public float range = 70.0f;
    public float bulletImpulse = 25.0f;

    private bool onRange = false;

    public Rigidbody projectile;
    protected AudioSource audioSource;


    void Start()
    {
        float rand = Random.Range(1.0f, 2.0f);
        InvokeRepeating("Shoot", 2, rand);
        audioSource = GetComponent<AudioSource>();

    }

    void Shoot()
    {

        if (onRange)
        {
            audioSource.Play();
            Rigidbody bullet = (Rigidbody)Instantiate(projectile, transform.position + transform.forward, transform.rotation);
            bullet.AddForce(transform.forward * bulletImpulse, ForceMode.Impulse);
            Destroy(bullet.gameObject, 3);
        }


    }

    void Update()
    {

        onRange = Vector3.Distance(transform.position, player.position) < range;

        if (onRange)
            transform.LookAt(player);
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("gun_bullet"))
        {
            
            // Debug.Log("Say");
            Destroy(gameObject);
           
        }
    }


}