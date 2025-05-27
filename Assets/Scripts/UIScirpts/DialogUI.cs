using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogUI : MonoBehaviour
{
    public static DialogUI Instance { get; private set; }

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI contentText;
    public Button contuineButton;

    public List<string> contentList;
    private int contentIndex = 0;

    private GameObject uiGameObject;
    private void Awake()
    {
        if (Instance != null&&Instance!=this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }
    private void Start()
    {
        //nameText = transform.Find("NameTextBg/NameText").GetComponentInChildren<TextMeshProUGUI>();
        //contentText = transform.Find("ContentText").GetComponent<TextMeshProUGUI>();
        //contuineButton = transform.Find("ContinueButton").GetComponent<Button>();
        contuineButton.onClick.AddListener(this.OnContinueButtonClick);
        uiGameObject = transform.Find("UI").gameObject;
        Hide();
    }
    public void Show()
    {
        uiGameObject.SetActive(true);
    }
    public void Show(string name,string[] content)
    {
        uiGameObject.SetActive(true);
        nameText.text = name;
        contentList = new List<string>();
        contentList.AddRange(content);
        contentIndex = 0;
        contentText.text = contentList[contentIndex];
    }
    public void Hide()
    {
        uiGameObject.SetActive(false);
    }

    private void OnContinueButtonClick()
    {
        if (contentIndex >= contentList.Count-1)
        {
            Hide();
            return;
        }
        contentIndex++; 
        contentText.text = contentList[contentIndex];
    }

}
