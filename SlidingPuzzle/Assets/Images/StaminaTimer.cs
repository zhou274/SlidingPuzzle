using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class StaminaTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // ������ʾ����ʱ��UI Text
    public TextMeshProUGUI currentStaminaText;
    public int staminaIncreaseInterval = 300; // �������ӵļ��ʱ�䣨�룩��Ĭ��5����
    public static int BestSamina;
    public static int currentStamina = 0; // ��ǰ����ֵ
    public GameObject AddStaminaPanel;
    private float timeRemaining; // ʣ��ĵ���ʱʱ��
    public void OpenAddPanel()
    {
        AddStaminaPanel.SetActive(true);
    }
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        
        currentStamina = PlayerPrefs.GetInt("Stamina");
        BestSamina = 10;
        if (!PlayerPrefs.HasKey("First"))
        {
            // ִ���״�����ʱ�Ĳ���
            Debug.Log("��ȡ10��ʼ����");
            currentStamina = BestSamina;
            PlayerPrefs.SetInt("Stamina", currentStamina);
            // �������������Ҫ���״�����ʱִ�еĴ���

            // ���ü�"FirstStart"����ʾ�����״�������
            PlayerPrefs.SetInt("First", 1);
            PlayerPrefs.Save(); // ȷ����������
        }
        else
        {
            Debug.Log("�Ѿ���ȡ����ʼ����");
        }
        timeRemaining = staminaIncreaseInterval; // ��ʼ������ʱʱ��
    }
    public void ShowAdd()
    {
        AddStaminaPanel.SetActive(true);
    }
    public static void subtract(int number)
    {
        currentStamina -= number;
        PlayerPrefs.SetInt("Stamina", currentStamina);
    }
    public static void Add(int number)
    {
        
        currentStamina += number;
        if(currentStamina> BestSamina)
        {
            currentStamina = BestSamina;
        }
        PlayerPrefs.SetInt("Stamina", currentStamina);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            currentStamina -= 1;
        }
        PlayerPrefs.SetInt("Stamina", currentStamina);
        currentStaminaText.text = currentStamina.ToString()+"/"+BestSamina.ToString();
        if (currentStamina >= 10)
        {
            timerText.gameObject.SetActive(false);
            return;
        }
        else
        {
            timerText.gameObject.SetActive(true);
        }
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime; // ���ٵ���ʱʱ��
            UpdateTimerDisplay(); // ����UI��ʾ
        }
        else
        {
            // ����ʱ��������������
            currentStamina++;
            Debug.Log("�������ӣ���ǰ����: " + currentStamina);

            // ���õ���ʱ
            timeRemaining = staminaIncreaseInterval;
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60); // �������
        int seconds = Mathf.FloorToInt(timeRemaining % 60); // ��������

        // ����UI Text��ʾ
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
