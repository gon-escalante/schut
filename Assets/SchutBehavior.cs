using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SchutBehavior : MonoBehaviour {
  public GameObject cameraGO;
  public GameObject bulletPrefab;
  public int bpm = 100;
  public GameObject BeatUI;
  private int nextColorIndex = 0;
  private Color green = new Color(0f, 1f, 0f);
  private Color red = new Color(1f, 0f, 0f);
  private Color blue = new Color(0f, 0f, 1f);
  private Color[] colorCycle;
  private int[] colorTagCycle;

  int getAndUpdateNextColor() {
    nextColorIndex += 1;
    if (nextColorIndex >= colorCycle.Length) {
      nextColorIndex -= (colorCycle.Length);
    }
    return nextColorIndex;
  }

  void Start() {
    colorCycle = new Color[] { green, red, blue };
    colorTagCycle = new int[] { 2, 1, 0 };
  }

  void Update() {
    if (Input.GetMouseButtonDown(0)) {
      GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);      
      BeatUI.GetComponent<Image>().color = colorCycle[getAndUpdateNextColor()];
      int colorIndex = getAndUpdateNextColor();
      bullet.GetComponent<Renderer>().material.color = colorCycle[colorIndex];
      bullet.GetComponent<Animator>().SetInteger("colorID", colorTagCycle[colorIndex]);
      bullet.GetComponent<BulletBehavior>().colorTag = colorTagCycle[colorIndex];
      Camera camera =  cameraGO.GetComponent<Camera>();
      Vector2 playerScreenPoint = camera.WorldToScreenPoint(transform.position);
      float xDir = Input.mousePosition.x - playerScreenPoint.x;
      float yDir = Input.mousePosition.y - playerScreenPoint.y;
      bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(xDir, yDir).normalized * 3000);
    }
  }
}
