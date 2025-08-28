using UnityEngine;

public class EndZone : MonoBehaviour
{
    public Timer timer;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            timer.levelFinished = true;
        }
    }
}
