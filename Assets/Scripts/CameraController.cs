using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject ghost;
    [SerializeField] private FreezeFrame freezeFrame;
    public bool isHardMode = false;

    void Update()
    {
        if(!freezeFrame.isFreeze)
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        }
        else if (freezeFrame.isFreeze && !isHardMode)
        {
            transform.position = new Vector3(ghost.transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
