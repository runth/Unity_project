using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleUI : MonoBehaviour
{
    public Button button;     
    public GameObject UIscreen;

    void Start()
    {
        UIscreen.SetActive(false);

        button = GetComponent<Button>();
        // 버튼 클릭 이벤트 추가
        button.onClick.AddListener(OnClick);

        
    }

    void OnClick()
    {
        UIscreen.SetActive(true);
    }
}
