using UnityEngine;
using UnityEngine.UI;

public class Btn : MonoBehaviour
{
    [Header("water consumption")]
    public int water;
    [Header("next_task")]
    public int NextTask;
    //[Header("next")]
    //public int NextTrigger;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            GameManger.Instance.InitHighOBJ();
            GameManger.Instance.AddScore(water);
            if (NextTask != -1)
            {
                GameManger.Instance.ShowTip(NextTask);
                GameManger.Instance.ShowTigger(NextTask - 1);

                transform.parent.gameObject.SetActive(false);

            }
            else
            {
                GameManger.Instance.ShowEndPanel();
                transform.parent.gameObject.SetActive(false);
            }
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
