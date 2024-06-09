using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Schoolbutton1 : MonoBehaviour
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
        // 게임 매니저에서 현재 주 가져오기
        currentWeek = PlayerPrefs.GetInt("Week");

        // 주에 따라 버튼 텍스트 설정
        if (currentWeek == 1)
        {
            health = 20;
            study = 20;
            money = 0;
            friendship = 0;

            buttonText.text = $"학교에서 강의 듣기\nHP -{health}  Study +{study}";
        }
        else if (currentWeek == 2)
        {
            health = 60;
            money = -30;
            friendship = 30;
            study = 0;
            
            buttonText.text = $"학과 MT 참석하기\nHP -{health}  Money {money}  Friend Ship +{friendship}";
        }
        else if (currentWeek == 3)
        {
            health = 20;
            study = 20;
            money = 0;
            friendship = 0;

            buttonText.text = $"학교에서 강의 듣기\nHP -{health}  Study +{study}";
        }
        else if (currentWeek == 4)
        {
            health = 60;
            study = 60;
            money = 0;
            friendship = 0;

            buttonText.text = $"중간고사 응시하기\nHP -{health}  Study +{study}";
        }
        else if (currentWeek == 5)
        {
            health = 40;
            study = 40;
            money = 0;
            friendship = 0;
        
            buttonText.text = $"학교에서 강의 듣기\nHP -{health}  Study +{study}";
        }
        else if (currentWeek == 6)
        {
            health = 60;
            friendship= 30;
            money = -20;
            study = 0;
        
            buttonText.text = $"학교 축제 체험하기\nHP -{health}  Money {money}  Friend Ship +{friendship}";
        }
        else if (currentWeek == 7)
        {
            health = 40;
            study = 40;
            money = 0;
            friendship = 0;
        
            buttonText.text = $"학교에서 강의 듣기\nHP -{health}  Study +{study}";
        }
        else if (currentWeek == 8)
        {
            health = 60;
            study = 60;
            money = 0;
            friendship = 0;
        
            buttonText.text = $"기말고사 응시하기\nHP -{health}  Study +{study}";
        }
    }
}
