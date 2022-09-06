using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    public int eventNumber = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (eventNumber != -1)
                GameManger.Instance.ShowTask(eventNumber);
            else
                GameManger.Instance.Enter_Toilet();
            
            gameObject.SetActive(false);
        }
    }
}
