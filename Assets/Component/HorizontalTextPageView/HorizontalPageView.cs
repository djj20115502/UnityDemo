using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace HorizontalTextPageView
{
    public class HorizontalPageView : MonoBehaviour, IEndDragHandler, IBeginDragHandler
    {
        [SerializeField] private GameObject textTemplate;
        public Action<int> OnPageChanged;
        public Action<bool, Direction> OnPageEdge;

        public enum Direction
        {
            LEFT,
            RIGHT,
        }

        public float animationTime = 0.5F;
        public float sensitivity = 5;

        private float startDragHorizontal;
        private int pageCount;

        private ScrollRect rect;

        //滑动结束点
        private List<float> posList = new List<float>();
        private int currentPageIndex = -1;
        private const string NO_BREAKING_SPACE = "\u00A0";

        private void Awake()
        {
            rect = transform.GetComponent<ScrollRect>();
        }

        private void Start()
        {
            LoadIndexData();
            PageTo(0);
        }

        public int GetPageCount()
        {
            return pageCount;
        }

        public void SetShowText(string textString)
        {
            textString = ReplaceSpace(textString);

            while (textString.Length != 0)
            {
                var textShow = Instantiate<GameObject>(textTemplate, rect.content.transform);
                textShow.SetActive(true);
                var fixtext = textShow.GetComponent<FixedLengthText>();
                textString = fixtext.SetText(textString);
            }

            LoadIndexData();
        }

        private string ReplaceSpace(string textString)
        {
            return textString.Replace(" ", NO_BREAKING_SPACE);
        }

        #region page change control

        public void PageTo(int index)
        {
            if (index >= 0 && index < posList.Count)
            {
                if (index == currentPageIndex)
                {
                    return;
                }

                DOTweenTo(posList[index]);
                SetPageIndex(index);
            }
            else
            {
                Debug.LogWarning("页码不存在");
            }
        }

        public void PageChangeTo(int change)
        {
            PageTo(currentPageIndex + change);
        }

        private void LoadIndexData()
        {
            pageCount = rect.content.childCount;
            Debug.Log("debugtest::childCount::" + pageCount);
            posList.Clear();
            if (pageCount < 2)
            {
                posList.Add(0);
                posList.Add(1);
            }
            else
            {
                for (var i = 0; i < pageCount; i++)
                {
                    posList.Add((i * 1.0F) / (pageCount - 1));
                }
            }
        }

        private void SetPageIndex(int index)
        {
            if (currentPageIndex == index)
            {
                return;
            }

            currentPageIndex = index;
            if (OnPageChanged != null)
            {
                OnPageChanged(currentPageIndex);
            }

            NotificationEdgeListener();
        }

        #endregion

        #region Drag control

        public void OnBeginDrag(PointerEventData eventData)
        {
            startDragHorizontal = rect.horizontalNormalizedPosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            var change = startDragHorizontal > rect.horizontalNormalizedPosition ? -1 : 1;
            var position = currentPageIndex + change;
            position = Math.Min(posList.Count - 1, position);
            position = Math.Max(position, 0);
            PageTo(position);
        }

        #endregion

        private void DOTweenTo(float position)
        {
            DOTween.To(() => rect.horizontalNormalizedPosition, x => rect.horizontalNormalizedPosition = x, position,
                animationTime);
        }

        private void NotificationEdgeListener()
        {
            if (OnPageEdge == null) return;
            var leftEdge = currentPageIndex == 0;
            var rightEdge = currentPageIndex == pageCount - 1;
            OnPageEdge(leftEdge, Direction.LEFT);
            OnPageEdge(rightEdge, Direction.RIGHT);
        }
    }
}