using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Entrance : MonoBehaviour
{
    public GameObject UIObject; // 이미지와 버튼을 포함한 부모 GameObject

    void Start()
    {
        // 시작 시 UI를 비활성화
        UIObject.SetActive(false);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            // 플레이어가 진입하면 UI를 활성화
            UIObject.SetActive(true);
        }
    }
}
