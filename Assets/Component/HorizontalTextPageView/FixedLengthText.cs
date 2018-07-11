using UnityEngine;
using UnityEngine.UI;

namespace  HorizontalTextPageView
{
    public class FixedLengthText : MonoBehaviour
    {
        [SerializeField] private Text _text;
        private const float FONT_SIZE_TO_REAL = 1.14F;
        private int _lineCount;
        private int _width;
        private int _height;

        private void Awake()
        {
            var rect = _text.gameObject.GetComponent<RectTransform>();
            _width = (int) rect.sizeDelta.x;
            _height = (int) rect.sizeDelta.y;
            var oneHeight = (_text.fontSize * FONT_SIZE_TO_REAL);
            _lineCount = (int) ((_height - oneHeight) / (oneHeight * _text.lineSpacing));
            _lineCount++;
        }


        /// <summary>
        /// 设置text能装下的字符串，返回剩余的
        /// </summary>
        /// <returns>The text.</returns>
        public string SetText(string allTextString)
        {
            var showCount = StripLengthWithLine(allTextString, _width, _lineCount);
            var show = allTextString.Substring(0, showCount);
            _text.text = show;
            var rt = allTextString.Substring(showCount);
            return rt;
        }

        private int StripLengthWithLine(string input, int lineMaxWidth, int lineNum)
        {
            var font = _text.font;
            font.RequestCharactersInTexture(input, _text.fontSize, _text.fontStyle);
            var arr = input.ToCharArray();
            var count = 0;
            for (var i = 0; i < lineNum; i++)
            {
                var num = StripLengthOneLine(arr, _width, font, count);
                count += StripLengthOneLine(arr, _width, font, count);
            }

            return count;
        }

        /// <summary>
        /// 根据输入框的长宽来确定显示的文字长度。
        /// </summary>
        private int StripLengthOneLine(char[] input, int lineMaxWidth, Font font, int start)
        {
            var characterInfo = new CharacterInfo();
            var charCount = 0;
            var lineTotalLength = 0;
            for (var i = start; i < input.Length; i++)
            {
                var c = input[i];
                font.GetCharacterInfo(c, out characterInfo, _text.fontSize);
                lineTotalLength += characterInfo.advance;
                if (lineTotalLength > lineMaxWidth)
                {
                    break;
                }
                charCount++;
                if (c.Equals('\n'))
                {
                    break;
                }
            }
            return charCount;
        }
    }
}