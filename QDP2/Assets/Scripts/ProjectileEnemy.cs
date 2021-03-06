﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEnemy : MonoBehaviour
{
    public float speed;
    private Transform player;
    private Vector2 target;
    public int damageToGive;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Target").transform;
        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if ((transform.position.x == target.x) && (transform.position.y == target.y))
        {
            DestroyProjectile();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            DestroyProjectile();
            other.gameObject.GetComponent<DamageToPlayer>().HurtPlayer(damageToGive);
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
