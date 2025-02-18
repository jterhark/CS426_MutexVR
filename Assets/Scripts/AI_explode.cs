﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AI_explode : MonoBehaviour
{

    public Transform Player;
    int MoveSpeed = 4;
    int MaxDist = 10;
    float MinDist = 0.5f ;
    public float range;
    public Transform player;
    public AudioSource audioSource;

    public GameObject explosionParticlesPrefab;
    Trig set;

    void Start()
    {
      //  set = GameObject.Find("Exploding_AI_Trig").GetComponent<Trig>();
        range = 20;
        //audioSource = GetComponent<AudioSource>();

    }

    void Update()
    {
        if ((Vector3.Distance(player.position, transform.position) <= range))
        {
            transform.LookAt(Player);

            if (Vector3.Distance(transform.position, Player.position) >= MinDist)
            {

                transform.position += transform.forward * MoveSpeed * Time.deltaTime;



                if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
                {
                    //Here Call any function U want Like Shoot at here or something
                }

            }
        }


    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            HealthSystem._curHealh -= 30;
            audioSource.Play();

            if (explosionParticlesPrefab)
            {
                GameObject explosion = (GameObject)Instantiate(explosionParticlesPrefab, transform.position, explosionParticlesPrefab.transform.rotation);
                Destroy(explosion, explosion.GetComponent<ParticleSystem>().main.startLifetimeMultiplier);
            }
            
           // Debug.Log("Say");
            Destroy(gameObject);
           
        }
    }
}