﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
  bool canJump;
  public GameObject particle;
	void Start() {
	  
	}

	void Update() {
    if (Input.GetKey(KeyCode.A)) {
      gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-40000f * Time.deltaTime, 0));
      gameObject.GetComponent<Animator>().SetBool("moving", true);
      gameObject.GetComponent<SpriteRenderer>().flipX = true;
    }
    if (Input.GetKey(KeyCode.D)) {
      gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(40000f * Time.deltaTime, 0));
      gameObject.GetComponent<Animator>().SetBool("moving", true);
      gameObject.GetComponent<SpriteRenderer>().flipX = false;
    }
    if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) {
      gameObject.GetComponent<Animator>().SetBool("moving", false);
    }
    if (Input.GetKeyDown(KeyCode.W) && canJump) {
      canJump = false;
      gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 10000));
    }
	}
  private void OnCollisionEnter2D(Collision2D other) {
    if (other.transform.tag == "Ground") {
      canJump = true;
    }
  }

}

