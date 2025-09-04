using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class ProtoManager : MonoBehaviour
{
    [SerializeField] private MeshRenderer ghostMesh;
    [SerializeField] private MeshRenderer ghostEyesMesh;
    private bool isHardMode = false;

    [SerializeField] private Timer timer;
    [SerializeField] private CameraController camera;


    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

    public void ResetTimer()
    {
        timer.levelTime = 0;
    }

    public void HardMode()
    {
        if (isHardMode)
        {
            isHardMode = false;
            ghostMesh.enabled = true;
            ghostEyesMesh.enabled = true;
        }

        else
        {
            isHardMode = true;
            ghostMesh.enabled = false;
            ghostEyesMesh.enabled = false;
        }
        camera.isHardMode = isHardMode;
        Debug.Log(isHardMode);
    }

}
