using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemDescriptions : MonoBehaviour
{
    public static ItemDescriptions Instance { get; private set; }

    [SerializeField] private RectTransform canvasRectTransform;
    private TextMeshProUGUI descriptionText;
    private RectTransform bgRectTransform;
    private RectTransform rectTransform;

    [SerializeField] float xchange = 0f;
    [SerializeField] float ychange = 0f;

    private void Awake()
    {
        Instance = this;

        bgRectTransform = transform.Find("background").GetComponent<RectTransform>();
        descriptionText = transform.Find("text").GetComponent<TextMeshProUGUI>();
        rectTransform = transform.GetComponent<RectTransform>();

        HideDescription();
    }

    private void Update()
    {
        Vector2 anchoredPosition = Input.mousePosition / canvasRectTransform.localScale.x;
        anchoredPosition[0] += xchange;
        anchoredPosition[1] += ychange;

        //if (anchoredPosition.x + bgRectTransform.rect.width > canvasRectTransform.rect.width)
        //    anchoredPosition.x = canvasRectTransform.rect.width - bgRectTransform.rect.width;

        //if (anchoredPosition.y + bgRectTransform.rect.height > canvasRectTransform.rect.height)
        //    anchoredPosition.y = canvasRectTransform.rect.height - bgRectTransform.rect.height;

        rectTransform.anchoredPosition = anchoredPosition;
    }
    private void SetText(string itemDescription)
    {
        descriptionText.SetText(itemDescription);
        descriptionText.ForceMeshUpdate();
        Vector2 paddingSize = new Vector2(descriptionText.margin.x *2, descriptionText.margin.y *2);
        Vector2 textSize = descriptionText.GetRenderedValues(false);
        bgRectTransform.sizeDelta = textSize + paddingSize;
        
    }

    private void ShowDescription(string itemDescription)
    {
        gameObject.SetActive(true);
        SetText(itemDescription);
    }

    private void HideDescription()
    {
        gameObject.SetActive(false);
    }

    public static void ShowDescription_Static(string itemDescription)
    {
        Instance.ShowDescription(itemDescription);
    }

    public static void HideDescription_Static()
    {
        Instance.HideDescription();
    }
}
