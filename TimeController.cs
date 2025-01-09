using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    float time = 0.0f;
    GameObject timerText; //Ÿ�̸�
    GameObject lap1Text; //1���� ������ �� �ð� ����
    GameObject lap2Text; //2���� ������ �� �ð� ����
    GameObject lap3Text; //�������� �� �ð� ����
    int lapCount = 0;

    public Sprite[] countdownSprites; // 3, 2, 1 ���� Sprite �迭
    Image countdownImage; // �߾ӿ� ǥ���� �̹���
    bool gameStarted = false; // ���� ���� ���� Ȯ��


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // ī��Ʈ�ٿ� �ڷ�ƾ ����
        StartCoroutine(StartCountdown());

        timerText = GameObject.Find("Time");
        lap1Text = GameObject.Find("Lap1");
        lap2Text = GameObject.Find("Lap2");
        lap3Text = GameObject.Find("Lap3");
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted) return; // ���� ���� ������ Ÿ�̸� ���� X

        time += Time.deltaTime;
        timerText.GetComponent<TextMeshProUGUI>().text = "Time: " + time.ToString("F2"); //Time: 000.00 ���� ǥ��
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

    // ī��Ʈ�ٿ� �ڷ�ƾ
    IEnumerator StartCountdown()
    {
        // Sprite�� ���������� ȭ�� �߾ӿ� ǥ��
        for (int i = countdownSprites.Length - 1; i >= 0; i--)
        {
            countdownImage.sprite = countdownSprites[i];
            countdownImage.gameObject.SetActive(true);
            yield return new WaitForSeconds(1f);
        }

        // ī��Ʈ�ٿ� �Ϸ� �� �̹��� �����
        countdownImage.gameObject.SetActive(false);

        // ���� ����
        gameStarted = true;
    }
}