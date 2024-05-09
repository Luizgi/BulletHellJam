using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineShake : MonoBehaviour
{   
    CinemachineVirtualCamera cmVCAM;
    float shakerTimer;
    public static CinemachineShake instace { get; private set; }
    private void Awake()
    {
        instace = this; 
        cmVCAM = GetComponent<CinemachineVirtualCamera>();
    }

    public void Shake(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin bscCP = cmVCAM.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        bscCP.m_AmplitudeGain = intensity;
        shakerTimer = time;
    }

    private void Update()
    {
        shakerTimer -= Time.deltaTime;
        if(shakerTimer < 0 )
        {
            CinemachineBasicMultiChannelPerlin bscCP = cmVCAM.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            bscCP.m_AmplitudeGain = 0f;
        }
    }
}
