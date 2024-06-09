using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cafebutton2 : MonoBehaviour
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
        if (currentWeek == 1 || currentWeek == 5)
        {
            health = 20;
            study = 10;
            money = -20;
            friendship = 0;

            buttonText.text = $"카페에서 책 읽기 with 케이크\nHP -{health}  Money {money}";
        }
        else if (currentWeek == 2 || currentWeek == 6)
        {
            health = 30;
            study = 0;
            money = -20;
            friendship = 10;

            buttonText.text = $"카페에서 친구들과 수다 떨기\nHP -{health}  Money {money}  Friend Ship +{friendship}";
        }
        else if (currentWeek == 3 || currentWeek == 7)
        {
            health = 30;
            study = 10;
            money = -10;
            friendship = 10;

            buttonText.text = $"카페에서 공부하기\nHP -{health}  Money {money}  Friend Ship +{friendship}";
        }
        else if (currentWeek == 4)
        {
            health = 30;
            study = 0;
            money = -10;
            friendship = 40;

            buttonText.text = $"카페 옆 맛집에서 중간고사 끝난 기념 파티하기~!\nHP -{health}  Money {money}  Friend Ship +{friendship}";
        }
        else if (currentWeek == 8)
        {
            health = 30;
            study = 0;
            money = -20;
            friendship = 40;

            buttonText.text = $"카페 옆 맛집에서 종파하기~!\nHP -{health}  Money {money}  Friend Ship +{friendship}";
        }
    }
}
