
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Toilet : MonoBehaviour
{
    public Transform PlayerFPS;
    public GameObject Go;
    private void OnEnable()
    {
        //You used the toilet and used 10 liters of water.
        GetComponent<Image>().DOFade(1, 2).OnComplete(() =>
        {
            gameObject.SetActive(false);
            GetComponent<Image>().DOFade(0, 0.1f);

            PlayerFPS.GetComponent<PlayerMove>().enabled = false;
            PlayerFPS.GetChild(0).GetComponent<PlayerLook>().enabled = false;
            PlayerFPS.localPosition = new Vector3(-3.335884f, 0.730125f, -6.471622f);
            PlayerFPS.eulerAngles = new Vector3(0, -110.364f, 0);
            PlayerFPS.GetChild(0).localEulerAngles = new Vector3(28.158f, 0, 0);
            Go.SetActive(true);
            GameManger.Instance.ShowToiletHigh();
        });
    }
}
