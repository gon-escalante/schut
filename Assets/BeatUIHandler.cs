using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeatUIHandler : MonoBehaviour {
  public int bpm = 100;
  public GameObject BeatUI;
  private int nextColorIndex = 0;
  private Color green = new Color(0f, 1f, 0f);
  private Color red = new Color(1f, 0f, 0f);
  private Color blue = new Color(0f, 0f, 1f);
  private Color[] colorCycle;
  private int beatNumber = 1;

  int getAndUpdateNextColor() {
    nextColorIndex += 1;
    if (nextColorIndex >= colorCycle.Length) {
      nextColorIndex -= (colorCycle.Length);
    }
    return nextColorIndex;
  }

  void Start() {
    colorCycle = new Color[] { red, blue, green };
  }

  void Update() {
    if ((Time.time + 0.15f) % (60f / bpm * beatNumber) < 0.30f ) {
      beatNumber++;
      BeatUI.GetComponent<Animator>().SetTrigger("beat");
    } else {
      BeatUI.GetComponent<Animator>().ResetTrigger("beat");
    }
  }
}
