using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecorderHandler : Photon.MonoBehaviour {

    private void Start()
    {
        if (photonView.isMine)
        {
            GetComponent<PhotonVoiceRecorder>().enabled = true;
        }
    }
}
