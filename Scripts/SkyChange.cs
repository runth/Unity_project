using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyChange : MonoBehaviour
{
    public Material daySkyMaterial; // 낮에 보여질 스카이 재질
    public Material nightSkyMaterial; // 밤에 보여질 스카이 재질
    private int currentHealth;

    void Update()
    {
        currentHealth = PlayerPrefs.GetInt("CurrentHealth");
        if (currentHealth <= 50)
        {
            RenderSettings.skybox = nightSkyMaterial; // 밤으로 변경
        }
        else
        {
            RenderSettings.skybox = daySkyMaterial; // 낮으로 변경
        }
    }
}
