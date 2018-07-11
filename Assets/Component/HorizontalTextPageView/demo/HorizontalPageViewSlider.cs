using DG.Tweening;
using UnityEngine;

public class HorizontalPageViewSlider : MonoBehaviour
{
    private float _pageScrollViewWidth;
    private float _sliderViewWidth;
    public GameObject sliderImage;

    private float animationTime = 0.2f;

    void Awake()
    {
         _pageScrollViewWidth = (GetComponent<RectTransform>().sizeDelta.x);
        _sliderViewWidth = (sliderImage.GetComponent<RectTransform>().sizeDelta.x);

        Debug.Log("m_PageScrollViewWidth:" + _pageScrollViewWidth + "  m_SliderViewWidth:" + _sliderViewWidth);
    }

    public void SetPositon(int pageCount, int pageNumber)
    {
        Debug.Log("pageCount:" + pageCount + "  pageNumber:" + pageNumber);
        float x = 0;
        if (pageCount > 1)
        {
            x = ((_pageScrollViewWidth - _sliderViewWidth) / (pageCount - 1)) * (pageNumber % pageCount);
        }

        Debug.Log("x:" + x);


        sliderImage.transform.DOLocalMoveX(x, animationTime);
    }
}