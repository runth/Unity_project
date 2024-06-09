using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton instance
    public static GameManager Instance;
    public Vector3 initialPosition;

    public int maxHealth = 100;
    public int currentHealth;
    public int money;
    public int study;
    public int friend;
    public int week = 1;
    
    public Text healthText;
    public Text moneyText;
    public Text studyText;
    public Text friendText;
    public Text weekText;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;

        PlayerPrefs.SetInt("Week", 1);
        PlayerPrefs.SetInt("CurrentHealth", maxHealth);
        PlayerPrefs.SetInt("Money", 50);
        PlayerPrefs.SetInt("Study", 0);
        PlayerPrefs.SetInt("FriendShip", 0);
        PlayerPrefs.Save();

        // UI 업데이트
        UpdateHealthUI();
        UpdateMoneyUI();
        UpdateStudyUI();
        UpdateFriendShipUI();
        UpdateWeekUI();
    }

    private void Awake()
    {
        // Initialize singleton instance
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    // Health update
    private void UpdateHealthUI()
    {
        if (healthText != null)
        {
            currentHealth = PlayerPrefs.GetInt("CurrentHealth");
            healthText.text = currentHealth.ToString();
        }
    }

    // money update
    private void UpdateMoneyUI()
    {
        if (moneyText != null)
        {
            money = PlayerPrefs.GetInt("Money");
            moneyText.text = money.ToString();
        }
    }
    
    private void UpdateStudyUI()
    {
        if (studyText != null)
        {
            study = PlayerPrefs.GetInt("Study");
            studyText.text = study.ToString();
        }
    }
    private void UpdateFriendShipUI()
    {
        if (friendText != null)
        {
            friend = PlayerPrefs.GetInt("FriendShip");
            friendText.text = friend.ToString();
        }
    }
    
    
    // week update
    private void UpdateWeekUI()
    {        
        transform.position = initialPosition;

        PlayerPrefs.SetInt("CurrentHealth", maxHealth);
        currentHealth = PlayerPrefs.GetInt("CurrentHealth");
        
        if (weekText != null)
        {  
        weekText.text = week.ToString() + " week";
        healthText.text = currentHealth.ToString();
        }
    }

    // 체력 관리 함수
    public void TakeDamage()
    {
        currentHealth = PlayerPrefs.GetInt("CurrentHealth");
        UpdateHealthUI();
        if (currentHealth < 0)
        {
            CheckThresholds();
        }

        // 체력이 0이 되면 다음 주
        if (currentHealth <= 0)
        {
            NextWeek();
        }
    }

    // 돈 관리 함수
    public void TakeMoney()
    {
        money = PlayerPrefs.GetInt("Money");
        UpdateMoneyUI();
    }

    // 공부 관리 함수
    public void TakeStudy()
    {
        study = PlayerPrefs.GetInt("Study");
        UpdateStudyUI();
    }

    // 사교성 관리 함수
    public void TakeFriendShip()
    {
        friend = PlayerPrefs.GetInt("FriendShip");
        UpdateFriendShipUI();
    }

    // 다음 주로 넘어가는 함수
    public void NextWeek()
    {
        // 체력을 최대치로 회복
        UpdateHealthUI();

        // 주 증가
        week = PlayerPrefs.GetInt("Week");
        week += 1;
        PlayerPrefs.SetInt("Week", week);

        // 16까지가 1학기이기 때문
        if (week > 8)
        {
            CheckThresholds();
        }

        UpdateWeekUI();
    }

    // 게임이 끝나고 점수 계산
    private void CheckThresholds()
    {
        // 각 스탯의 threshold 값
        int moneyThreshold = 250; // 돈이 250 이상일 때
        int moneyThreshold1 = 150;
        int studyThreshold = 350;  // 공부가 350 이상일 때
        int studyThreshold1 = 200;
        int friendThreshold = 200; // 사교성이 200 이상일 때
        int friendThreshold1 = 100; 
        int currentHealth = PlayerPrefs.GetInt("CurrentHealth");

        if (money >= moneyThreshold && study >= studyThreshold && friend >= friendThreshold)
        {
            // 만약 모든 스탯이 threshold를 넘으면 특정 결말로 이동하도록 설정
            SceneManager.LoadScene("excellentEnding");
        }
        else if (money >= moneyThreshold1 && study >= studyThreshold1 && friend >= friendThreshold1)
        {
            // 만약 모든 스탯이 threshold를 넘으면 특정 결말로 이동하도록 설정
            SceneManager.LoadScene("goodEnding");
        }
        else if (money <= moneyThreshold1 || study <= studyThreshold1 || friend <= friendThreshold1)
        {
            // 만약 모든 스탯이 threshold를 넘으면 특정 결말로 이동하도록 설정
            SceneManager.LoadScene("badEnding");
        }
        else if (currentHealth < 0)
        {
            SceneManager.LoadScene("badEnding");
        }
    }
}
