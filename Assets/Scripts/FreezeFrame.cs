using UnityEngine;

public class FreezeFrame : MonoBehaviour
{
    public bool isFreeze = false;

    public void Freeze()
    {
        if (isFreeze)
        {
            isFreeze = false;
        }
        else
        {
            isFreeze = true;
        }
    }
}
