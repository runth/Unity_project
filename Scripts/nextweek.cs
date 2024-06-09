using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nextweek : MonoBehaviour
{
    public GameManager GameManager;
    
    void Start()
    {
        // GameManager 클래스의 인스턴스를 찾기
        GameManager = FindObjectOfType<GameManager>();
    }

    public void NextWeekOnClick()
    {
        // GameManager의 NextWeek 함수 호출
        GameManager.NextWeek();
    }
}
