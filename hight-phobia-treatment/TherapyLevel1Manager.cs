using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TherapyLevel1Manager : MonoBehaviour {
    public Transform cameraPositions;
    public float personHeight;
    public GameObject mainCamera;
    public string nextLevel;

    private int nbrCameraPositions;
    private int cameraPositionIndex = 0;
    private Transform[] cameraPositionsParsed;
    // Use this for initialization
    void Start () {
        nbrCameraPositions = cameraPositions.childCount;
        cameraPositionsParsed = new Transform[nbrCameraPositions];
        for (int i = 0; i < nbrCameraPositions; i++)
        {
            cameraPositionsParsed[i] = cameraPositions.GetChild(i).transform;
        }
        cameraPositionIndex = 0;
        mainCamera.transform.position = cameraPositionsParsed[cameraPositionIndex].position+personHeight*Vector3.up;
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (cameraPositionIndex < nbrCameraPositions - 1)
            {
                cameraPositionIndex++;
                mainCamera.transform.position = cameraPositionsParsed[cameraPositionIndex].position + personHeight * Vector3.up;
            }
            else if (nextLevel.Length > 0)
                SceneManager.LoadScene(nextLevel);
        }
#else
        if (Input.touchCount>0)
        {
            if(Input.touches[0].phase==TouchPhase.Ended)
            {
                if (cameraPositionIndex < nbrCameraPositions - 1)
                {
                    cameraPositionIndex++;
                    mainCamera.transform.position = cameraPositionsParsed[cameraPositionIndex].position+personHeight*Vector3.up;
                }
                else if(nextLevel.Length>0)
                    SceneManager.LoadScene(nextLevel);
            }
        }
#endif
    }
}
