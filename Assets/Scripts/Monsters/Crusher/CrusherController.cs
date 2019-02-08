﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrusherController : MonoBehaviour
{
    public GameObject crusherBody;
    public GameObject projectile;
    public GameObject playerObject;
    public GameObject points;
    public bool destroyProjectiles=false;
    
    float attackDelay = 2f;
    float attackTime;
    float attackLast = 8f;
    float attackLastTime;
    float projectileSpawnDelay = 0.2f;
    float projectileSpawnTime;
    bool attack = false;
    int counter = 0;

    Animator crusherAnimator;

    // Start is called before the first frame update
    void Start()
    {
        crusherAnimator = crusherBody.GetComponent<Animator>();
        attackTime = Time.time + attackDelay;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //obrni proti playerju
        if (playerObject.transform.position.x > crusherBody.transform.position.x)
        {
            crusherBody.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        else
        {
            crusherBody.transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        if (Time.time > attackTime && !attack) {
            attackingAnimation();
            crusherBody.GetComponent<PolygonCollider2D>().enabled = false;
            destroyProjectiles = false;
            attack = true;
            projectileSpawnTime = Time.time + projectileSpawnDelay;
            attackLastTime = Time.time + attackLast;
        }
        if (attack && Time.time>attackLastTime) {
            normalAnimation();
            crusherBody.GetComponent<PolygonCollider2D>().enabled = true;
            attack = false;
            counter = 0;
            destroyProjectiles = true;
            attackTime = Time.time + attackDelay;
        }
        if (attack) {
            if (Time.time > projectileSpawnTime)
            {
                counter++;
                if (counter <= 12)
                {
                    GameObject tempProjectile = Instantiate(projectile);
                    tempProjectile.GetComponent<CrusherProjectileController>().crusher = gameObject;
                    tempProjectile.GetComponent<CrusherProjectileController>().points = points;
                    projectileSpawnTime = Time.time + projectileSpawnDelay;
                    
                }
            }
        }
    }
    void normalAnimation() {
        crusherAnimator.SetBool("normal", true);
        crusherAnimator.SetBool("attacking", false);
    }
    void attackingAnimation()
    {
        crusherAnimator.SetBool("normal", false);
        crusherAnimator.SetBool("attacking", true);

    }
}