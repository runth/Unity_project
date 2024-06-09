using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Back : MonoBehaviour
{
    public Button button;
    public GameObject UIscreen;
    // Start is called before the first frame update
        void Start()
    {
        UIscreen.SetActive(true);
        button = GetComponent<Button>();
                
        // 버튼 클릭 이벤트 추가
        button.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void OnClick()
    {
        UIscreen.SetActive(false);
    }
}
