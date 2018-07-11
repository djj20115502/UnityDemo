using System;
using HorizontalTextPageView;
using UnityEngine;
using UnityEngine.UI;

public class AgreementPanel : MonoBehaviour
{
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;
    [SerializeField] private Button backButton;
    [SerializeField] private HorizontalPageViewSlider slider;
    [SerializeField] private HorizontalPageView horizontalPageView;
    [SerializeField] private Text Title;

    public Action agreementPanelCakkBack;

    private GameObject currentPanel;

    private void Start()
    {
        leftButton.onClick.AddListener(LeftButtonOnClick);
        rightButton.onClick.AddListener(RightButtonOnClick);
        backButton.onClick.AddListener(OnBackClick);
        horizontalPageView.OnPageEdge += OnPageEdge;
        horizontalPageView.OnPageChanged += OnPageChanged;
        GetAgreementShowText();
    }

    private void OnEnable()
    {
        horizontalPageView.PageTo(0);
    }


    private void OnBackClick()
    {
        if (agreementPanelCakkBack != null)
        {
            agreementPanelCakkBack();
        }
    }


    #region call android GetAgreementShowText

    private void GetAgreementShowText()
    {
        horizontalPageView.SetShowText(
            "11111\n  " +
            "2222\n  " +
            "3333\n  3" +
            "4444\n  " +
            "5555\n  " +
            "666\n  6" +
            "77\n  7" +
            "88\n  88" +
            "99\n  9" +
            "12\n  13 ");
    }

    #endregion

    #region horizontal control

    private void LeftButtonOnClick()
    {
        Debug.Log("debugtest::left");
        horizontalPageView.PageChangeTo(-1);
    }

    private void RightButtonOnClick()
    {
        Debug.Log("debugtest::right");
        horizontalPageView.PageChangeTo(1);
    }

    private void OnPageEdge(bool isEdge, HorizontalPageView.Direction direction)
    {
        switch (direction)
        {
            case HorizontalPageView.Direction.LEFT:
                leftButton.interactable = !isEdge;
                break;
            case HorizontalPageView.Direction.RIGHT:
                rightButton.interactable = !isEdge;
                break;
        }
    }

    #endregion


    private void OnPageChanged(int pageIndex)
    {
        slider.SetPositon(horizontalPageView.GetPageCount(), pageIndex);
    }
}