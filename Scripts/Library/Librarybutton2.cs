using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Librarybutton2 : MonoBehaviour
{
    private Button button;
    private Text buttonText;
    private int health;
    private int currentHealth;
    private int study;
    private int currentstudy;
    private int money;
    private int currentmoney;
    private int friendship;
    private int currentFS;
    private int currentWeek;
    public GameObject UIscreen;

    // Start is called before the first frame update
    void Start()
    {
        UIscreen.SetActive(true);
        button = GetComponent<Button>();
        buttonText = button.GetComponentInChildren<Text>();

        // 버튼 텍스트 업데이트
        UpdateButtonText();
        
        // 버튼 클릭 이벤트 추가
        button.onClick.AddListener(OnClick);
    }

    void Update()
    {
        UpdateButtonText();
    }

    // 버튼 클릭 시 호출될 함수
    void OnClick()
    {
        // 체력 관리
        currentHealth = PlayerPrefs.GetInt("CurrentHealth");
        currentHealth -= health;
        PlayerPrefs.SetInt("CurrentHealth", currentHealth);
        GameManager.Instance.TakeDamage();

        // 공부 관리
        currentstudy = PlayerPrefs.GetInt("Study");
        currentstudy += study;
        PlayerPrefs.SetInt("Study", currentstudy);
        GameManager.Instance.TakeStudy();

        // 돈 관리
        currentmoney = PlayerPrefs.GetInt("Money");
        currentmoney += money;
        PlayerPrefs.SetInt("Money", currentmoney);
        GameManager.Instance.TakeMoney();

        // 사교성 관리
        currentFS= PlayerPrefs.GetInt("FriendShip");
        currentFS += friendship;
        PlayerPrefs.SetInt("FriendShip", currentFS);
        GameManager.Instance.TakeFriendShip();

        UIscreen.SetActive(false);
    }

    // 버튼 텍스트 업데이트 함수
    void UpdateButtonText()
    {
        currentWeek = PlayerPrefs.GetInt("Week");
        // 주에 따라 버튼 텍스트 설정
        if (currentWeek == 1)
        {
            health = 20;
            study = 0;
            money = 0;
            friendship = 20;

            buttonText.text = $"도서관에서 영화 관람\nHP -{health}  Friend Ship +{friendship}";
        }
        else if (currentWeek == 2)
        {
            health = 40;
            study = 0;
            money = 0;
            friendship = 40;

            buttonText.text = $"MT 도와주기\nHP -{health}  Friend Ship +{friendship}";
        }
        else if (currentWeek == 3)
        {
            health = 20;
            study = 20;
            money = 0;
            friendship = 10;

            buttonText.text = $"예지관에 질문하기\nHP -{health}  Study +{study}  Friend Ship +{friendship}";
        }
        else if (currentWeek == 4)
        {
            health = 20;
            study = 0;
            money = 0;
            friendship = 20;

            buttonText.text = $"도서관 근처에서 꽃 구경하기\nHP -{health}  Friend Ship +{friendship}";
        }
        else if (currentWeek == 5)
        {
            health = 30;
            study = 10;
            money = 0;
            friendship = 10;

            buttonText.text = $"도서관에서 수수께끼 풀기\nHP -{health}  Study +{study}  Friend Ship +{friendship}";
        }
        else if (currentWeek == 6)
        {
            health = 40;
            study = 0;
            money = 0;
            friendship = 40;

            buttonText.text = $"학교 축제 도와주기\nHP -{health}  Friend Ship +{friendship}";
        }
        else if (currentWeek == 8)
        {
            health = 20;
            study = 20;
            money = 0;
            friendship = 10;

            buttonText.text = $"예지관에 질문하기\nHP -{health}  Study +{study}  Friend Ship +{friendship}";
        }
        else if (currentWeek == 9)
        {
            health = -10;
            study = 10;
            money = 0;
            friendship = 10;

            buttonText.text = $"도서관에서 휴식\nHP +{-health}  Study +{study} Friend Ship +{friendship} ";
        }
    }
}
