using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelClose : MonoBehaviour
{
    public int water;
    private void OnEnable()
    {
        GameManger.Instance.AddScore(water);
        Invoke("HidePanel", 2);
    }
    private void HidePanel()
    {
        if(water ==50)
        {
            GameManger.Instance.ShowTip(7);
            GameManger.Instance.ShowTigger(6);
            GameManger.Instance.showgos(2);
        }
        GameManger.Instance.InitHighOBJ();
        gameObject.SetActive(false);
    }
}
