using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    float time = 0.0f;
    TextMeshProUGUI timerText; //타이머
    TextMeshProUGUI lap1Text; //1바퀴 돌았을 때 시간 측정
    TextMeshProUGUI lap2Text; //2바퀴 돌았을 때 시간 측정
    TextMeshProUGUI lap3Text; //완주했을 때 시간 측정
    int lapCount = 0;

    TextMeshProUGUI countdownText; //3, 2, 1, GO! 라고 외치는 오브젝트
    public bool gameStarted = false; // 게임 시작 여부 확인


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timerText = GameObject.Find("Time").GetComponent<TextMeshProUGUI>();
        lap1Text = GameObject.Find("Lap1").GetComponent<TextMeshProUGUI>();
        lap2Text = GameObject.Find("Lap2").GetComponent<TextMeshProUGUI>();
        lap3Text = GameObject.Find("Lap3").GetComponent<TextMeshProUGUI>();
        countdownText = GameObject.Find("countdown").GetComponent<TextMeshProUGUI>();
        // 카운트다운 시작
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        TextMeshProUGUI countdown = countdownText; // Text 컴포넌트 가져오기

        // 3, 2, 1 순차적으로 표시
        for (int i = 3; i > 0; i--)
        {
            countdown.text = i.ToString(); // 숫자 표시
            countdownText.gameObject.SetActive(true); // 텍스트 활성화
            yield return new WaitForSeconds(1f); // 1초 대기
        }

        // "GO!" 표시
        countdown.text = "GO!";
        yield return new WaitForSeconds(1f);

        // 카운트다운 텍스트 숨기기
        countdownText.gameObject.SetActive(false);

        // 게임 시작
        gameStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (gameStarted == true) // 게임 시작 전에는 타이머 동작 X
        {
            time += Time.deltaTime;
            timerText.text = "Time : " + time.ToString("F2"); //Time: 000.00 형식 표현
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            lapCount++;
            switch(lapCount)
            {
                case 1:
                    lap1Text.text = "Lap 1: " + time.ToString("000.00");
                    break;
                case 2:
                    lap2Text.text = "Lap 2: " + time.ToString("000.00");
                    break;
                case 3:
                    lap3Text.text = "Lap 3: " + time.ToString("000.00");
                    break;
            }
        }
    }
}