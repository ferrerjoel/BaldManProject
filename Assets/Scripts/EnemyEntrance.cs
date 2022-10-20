using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class EnemyEntrance : MonoBehaviour
{

    private PlayableDirector director;
    public GameObject controlPanel;
    public Camera cam1;
    public Camera cam2;

    private void Awake()
    {
        director = GetComponent<PlayableDirector>();
        director.played += Director_Played;
        director.stopped += Director_Stopped;
    }
    private void Director_Stopped(PlayableDirector obj)
    {
        controlPanel.SetActive(true);
    }
    private void Director_Played(PlayableDirector obj)
    {
        controlPanel.SetActive(false);
    }
    public void StartTimeline()
    {
        director.Play();
        cam1.enabled = false;
        cam2.enabled = true;
        Invoke("changeCamera", 5);
    }

    private void changeCamera()
    {
        cam2.enabled = false;
        cam1.enabled = true;
    }
}
