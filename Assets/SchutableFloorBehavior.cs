using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchutableFloorBehavior : MonoBehaviour {
  public int colorTag;

  void Start() {
  }
  
  void Update() {
  }
  
  private void OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject.GetComponent<BulletBehavior>() && other.gameObject.GetComponent<BulletBehavior>().colorTag == colorTag) {
      Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 10f);
      foreach (Collider2D hit in colliders) {
        Rigidbody2D rb = hit.GetComponent<Rigidbody2D>();
        if (rb != null) {
          rb.AddForce(new Vector2(0f, 30000f));
        }
      }
    }
  }
}
