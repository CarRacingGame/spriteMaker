using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    float time = 0.0f;
    TextMeshProUGUI timerText; //Ÿ�̸�
    TextMeshProUGUI lap1Text; //1���� ������ �� �ð� ����
    TextMeshProUGUI lap2Text; //2���� ������ �� �ð� ����
    TextMeshProUGUI lap3Text; //�������� �� �ð� ����
    int lapCount = 0;

    TextMeshProUGUI countdownText; //3, 2, 1, GO! ��� ��ġ�� ������Ʈ
    public bool gameStarted = false; // ���� ���� ���� Ȯ��


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timerText = GameObject.Find("Time").GetComponent<TextMeshProUGUI>();
        lap1Text = GameObject.Find("Lap1").GetComponent<TextMeshProUGUI>();
        lap2Text = GameObject.Find("Lap2").GetComponent<TextMeshProUGUI>();
        lap3Text = GameObject.Find("Lap3").GetComponent<TextMeshProUGUI>();
        countdownText = GameObject.Find("countdown").GetComponent<TextMeshProUGUI>();
        // ī��Ʈ�ٿ� ����
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        TextMeshProUGUI countdown = countdownText; // Text ������Ʈ ��������

        // 3, 2, 1 ���������� ǥ��
        for (int i = 3; i > 0; i--)
        {
            countdown.text = i.ToString(); // ���� ǥ��
            countdownText.gameObject.SetActive(true); // �ؽ�Ʈ Ȱ��ȭ
            yield return new WaitForSeconds(1f); // 1�� ���
        }

        // "GO!" ǥ��
        countdown.text = "GO!";
        yield return new WaitForSeconds(1f);

        // ī��Ʈ�ٿ� �ؽ�Ʈ �����
        countdownText.gameObject.SetActive(false);

        // ���� ����
        gameStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (gameStarted == true) // ���� ���� ������ Ÿ�̸� ���� X
        {
            time += Time.deltaTime;
            timerText.text = "Time : " + time.ToString("F2"); //Time: 000.00 ���� ǥ��
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