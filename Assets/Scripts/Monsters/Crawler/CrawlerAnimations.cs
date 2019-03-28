﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlerAnimations : MonoBehaviour
{
    public GameObject crawlerGameObject;
    CrawlerController sc;
    Animator animator;
    public bool NeutralBool = false;
    // Start is called before the first frame update
    void Start()
    {
        sc = crawlerGameObject.GetComponent<CrawlerController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (NeutralBool)
        {
            GetComponent<PolygonCollider2D>().enabled = false;
            Neutral();
        }
        else {
            Monster();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "CrusherProjectile")
        {
            NeutralBool = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "ThrowerProjectile")
        {
            NeutralBool = true;
        }
        if (collision.gameObject.name == "LittleSteve")
        {
            NeutralBool = true;
        }
        if (collision.gameObject.name == "StopperProjectile")
        {
            NeutralBool = true;
        }
    }
    void Monster()
    {
        animator.SetBool("Monster", true);
        animator.SetBool("Neutral", false);
    }
    void Neutral()
    {
        animator.SetBool("Monster", false);
        animator.SetBool("Neutral", true);
    }
}