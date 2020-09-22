using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeatUIHandler : MonoBehaviour {
  public int bpm = 100;
  public GameObject BeatUI;
  private float lastBeatTime = 0f;
  private float deltaTime = 0f;
  private int nextColorIndex = 0;
  private Color green = new Color(0f, 1f, 0f);
  private Color red = new Color(1f, 0f, 0f);
  private Color blue = new Color(0f, 0f, 1f);
  private Color[] colorCycle;

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
    deltaTime += Time.deltaTime;
    Debug.Log(60f/bpm);
    if (deltaTime >= (60f / bpm)) {
      deltaTime -= (60f / bpm);
      BeatUI.GetComponent<Animator>().SetTrigger("beat");
      BeatUI.GetComponent<Image>().color = colorCycle[getAndUpdateNextColor()];
    } else {
      BeatUI.GetComponent<Animator>().ResetTrigger("beat");
    }
  }
}
