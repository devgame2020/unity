﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    float h;
    float v;
    bool isHorizonMove; 
    Rigidbody2D rigid;

    float speed;

    Animator anim;

    Vector3 dirVec;

    GameObject scanObject; 

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        speed = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Move Key
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        // check button down&up
        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp = Input.GetButtonUp("Horizontal");
        bool vUp = Input.GetButtonUp("Vertical");

        // check Horizontal Move
        if(hDown)
            isHorizonMove = true;
        else if(vDown)
            isHorizonMove = false;
        else if(vUp || hUp)
            isHorizonMove = h != 0;

        // Animation 
        if(anim.GetInteger("hAxisRaw") != h) {
            anim.SetBool("isChange", true);
            anim.SetInteger("hAxisRaw",(int)h);
        }
        else if(anim.GetInteger("vAxisRaw") != v) {
            anim.SetBool("isChange", true);
            anim.SetInteger("vAxisRaw",(int)v);
        }
        else {
            anim.SetBool("isChange", false);
        }

        // Direction 
        if(vDown && v == 1) 
            dirVec = Vector3.up;
        else if(vDown && v == -1) 
            dirVec = Vector3.down;
        else if(hDown && h == -1) 
            dirVec = Vector3.left;
        else if(hDown && h == 1) 
            dirVec = Vector3.right;
        
        // Scan Object
        if(Input.GetButtonDown("Jump") && scanObject != null) {
            Debug.Log("This is : " + scanObject.name);
        }
    }

    void FixedUpdate() {
        // Move
        Vector2 moveVec = isHorizonMove ? new Vector2(h,0): new Vector2(0,v);
        rigid.velocity = moveVec * speed;;

        // Ray
        Debug.DrawRay(rigid.position, dirVec * 0.7f, new Color(0,1,0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec , 0.7f, LayerMask.GetMask("Object"));

        if(rayHit.collider != null) {
            scanObject = rayHit.collider.gameObject;
        }
        else {
            scanObject = null;
        }
    }
}
