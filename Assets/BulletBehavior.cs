using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
  public string colorTag;
  private float ttd;

  void Start() {
    ttd = Time.time + 2;
  }

  void Update() {
    if(Time.time > ttd) {
      Destroy(gameObject);
    }
  }
  private void OnTriggerEnter2D(Collider2D other) {
    Debug.Log(other);
    if (other.gameObject.GetComponent<EnemyBehavior>() && other.gameObject.GetComponent<EnemyBehavior>().colorTag == colorTag) {
      Destroy(other.gameObject);
    }
  }
}
