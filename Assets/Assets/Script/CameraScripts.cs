using Unity.Cinemachine;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class CameraScripts : MonoBehaviour
{
    public static CameraScripts Instance { get; private set; }

    private CinemachineCamera cinemachineCamera;
    private CinemachineBasicMultiChannelPerlin noiseComponent;

    private void Awake()
    {
        Instance = this;

        cinemachineCamera = GetComponent<CinemachineCamera>();

        noiseComponent = cinemachineCamera.GetComponent<CinemachineBasicMultiChannelPerlin>();

        if (noiseComponent == null)
        {
            Debug.LogError("CinemachineBasicMultiChannelPerlin is missing. Add it to the camera.");
        }
    }

    public void ShakeCamera(float intensity)
    {
        if (noiseComponent != null)
        {
            noiseComponent.AmplitudeGain = intensity;
        }
    }
}
