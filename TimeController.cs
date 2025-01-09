using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    float time = 0.0f;
    GameObject timerText; //타이머
    GameObject lap1Text; //1바퀴 돌았을 때 시간 측정
    GameObject lap2Text; //2바퀴 돌았을 때 시간 측정
    GameObject lap3Text; //완주했을 때 시간 측정
    int lapCount = 0;

    public Sprite[] countdownSprites; // 3, 2, 1 숫자 Sprite 배열
    Image countdownImage; // 중앙에 표시할 이미지
    bool gameStarted = false; // 게임 시작 여부 확인


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 카운트다운 코루틴 시작
        StartCoroutine(StartCountdown());

        timerText = GameObject.Find("Time");
        lap1Text = GameObject.Find("Lap1");
        lap2Text = GameObject.Find("Lap2");
        lap3Text = GameObject.Find("Lap3");
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted) return; // 게임 시작 전에는 타이머 동작 X

        time += Time.deltaTime;
        timerText.GetComponent<TextMeshProUGUI>().text = "Time: " + time.ToString("F2"); //Time: 000.00 형식 표현
        if (Input.GetKeyDown(KeyCode.E))
        {
            lapCount++;
            if (lapCount == 1)
            {
                lap1Text.GetComponent<TextMeshProUGUI>().text = "lap1: " + time.ToString("000.00");
            }
            else if (lapCount == 2)
            {
                lap2Text.GetComponent<TextMeshProUGUI>().text = "lap2: " + time.ToString("000.00");
            }
            else
            {
                lap3Text.GetComponent<TextMeshProUGUI>().text = "lap3: " + time.ToString("000.00");
            }


        }
}

    // 카운트다운 코루틴
    IEnumerator StartCountdown()
    {
        // Sprite를 순차적으로 화면 중앙에 표시
        for (int i = countdownSprites.Length - 1; i >= 0; i--)
        {
            countdownImage.sprite = countdownSprites[i];
            countdownImage.gameObject.SetActive(true);
            yield return new WaitForSeconds(1f);
        }

        // 카운트다운 완료 후 이미지 숨기기
        countdownImage.gameObject.SetActive(false);

        // 게임 시작
        gameStarted = true;
    }
}