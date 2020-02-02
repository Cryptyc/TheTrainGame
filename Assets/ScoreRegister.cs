using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreRegister : MonoBehaviour
{
    private int CurrentScore = 0;
    public float MaxEngineTime = 60.0f;
    private float CurrentEngineTime = 0.0f;
    private Slider progressSlider;
    private Text TextValue;
    private bool GameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        progressSlider = GetComponentsInChildren<Slider>()[0];
        progressSlider.value = 1.0f;
        TextValue  = GetComponentsInChildren<Text>()[0];
        progressSlider.value = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameOver)
        {
            CurrentEngineTime += Time.deltaTime;
            if (CurrentEngineTime > MaxEngineTime)
            {
                TextValue.text = "Game Over Score " + CurrentScore;
                GameOver = true;
            }
            progressSlider.value = 1.0f - CurrentEngineTime/MaxEngineTime;
        }
    }

    public void DamageFixed()
    {
        CurrentScore++;
        TextValue.text = "Repaired: " + CurrentScore;
    }
    public void EngineFixed()
    {
        CurrentEngineTime = 0.0f;
    }
}
