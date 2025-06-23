using UnityEngine;
using Unity.Cinemachine;
using System.Collections;

public class CameraShakeCinemachine : MonoBehaviour
{
    CinemachineCamera virtualCamera;

    [Header("Cinemachine Settings")]
    private CinemachineBasicMultiChannelPerlin perlin;

    [Header("Shake Settings")]
    private float shakeTimer;
    private float shakeTimerTotal;
    private float startingAmplitude;

    void Awake()
    {
        virtualCamera = GetComponent<CinemachineCamera>();

        if (virtualCamera != null)
        {
            perlin = virtualCamera.GetComponent<CinemachineBasicMultiChannelPerlin>();
        }
    }

    /// <summary>
    /// Call this to shake the camera.
    /// </summary>
    /// <param name="intensity">Amplitude gain</param>
    /// <param name="time">Duration in seconds</param>
    public void ShakeCamera(float intensity, float time)
    {

        if (perlin == null) return;

        Debug.Log("shake camera");
        perlin.AmplitudeGain = intensity;
        StartCoroutine(WaitTime(time));
    }

    IEnumerator WaitTime(float shakeTime)
    {
        yield return new WaitForSeconds(shakeTime);
        ResetIntensity();
    }

    void ResetIntensity()
    {
        perlin.AmplitudeGain = 0;
    }
}
