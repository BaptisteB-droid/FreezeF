using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject ghost;
    [SerializeField] private FreezeFrame freezeFrame;

    void Update()
    {
        if(!freezeFrame.isFreeze)
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);

        if (freezeFrame.isFreeze)
            transform.position = new Vector3(ghost.transform.position.x, transform.position.y, transform.position.z);
    }
}
