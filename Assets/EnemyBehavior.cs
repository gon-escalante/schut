using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {
  public string colorTag;
  private GameObject player;
  void Start() {
    player = GameObject.Find("Player");
  }

  void Update() {
    gameObject.GetComponent<Rigidbody2D>().AddForce((player.transform.position- transform.position) / 400);
  }
}
