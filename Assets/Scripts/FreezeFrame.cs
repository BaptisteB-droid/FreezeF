using UnityEngine;

public class FreezeFrame : MonoBehaviour
{
    public bool isFreeze = false;

    [Header("References")]
    [SerializeField] private Timer timer;

    public void Freeze()
    {
        if (isFreeze)
        {
            isFreeze = false;
        }
        else if(!isFreeze)
        {
            isFreeze = true;
        }
        Debug.Log(isFreeze);
    }
}
