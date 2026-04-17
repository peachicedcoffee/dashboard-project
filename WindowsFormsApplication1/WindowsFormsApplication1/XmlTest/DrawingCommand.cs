using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Reflection;

namespace WindowsFormsApplication1.XmlTest
{
    /// <summary>
    /// 바코드 드로잉 객체를 생성합니다.
    /// </summary>
    public class DrawingCommand
    {
        /// <summary>
        /// 커맨드 타입 
        /// ex. DrawTextCmd
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 텍스트 필드
        /// </summary>
        public string DataField { get; set; }

        public string X { get; set; }
        public double XValue { get { return GetDouble(X); } }

        public string Y { get; set; }
        public double YValue { get { return GetDouble(Y); } }
        

        public string Width { get; set; }
        public double WidthValue { get { return GetDouble(Width); } }

        public string Height { get; set; }
        public double HeightValue { get { return GetDouble(Height); } }

        /// <summary>
        /// 각도 
        /// ex. Degree0
        /// </summary>
        public string Angle { get; set; }

        /// <summary>
        /// 선 두께
        /// </summary>
        public string LineWidth { get; set; }
        public double LineWidthValue { get { return GetDouble(LineWidth); } }

        public string DashStyle { get; set; }

        /// <summary>
        /// visible 속성
        /// </summary>
        public string Visible { get; set; }
        public bool IsVisible { get { return GetBoolean(Visible); } }

        /// <summary>
        /// 색상 int값
        /// ex. -16777216
        /// </summary>
        public string Color { get; set; }
        public Color BasicColor { get { return GetColor(Color); } }

        /// <summary>
        /// 배경색상
        /// </summary>
        public string BackColor { get; set; }
        public Color BackGroundColor { get { return GetColor(BackColor); } }

        /// <summary>
        /// 내용 문자
        /// ex. HCCD
        /// </summary>
        public string ContentText { get; set; }

        public string AspectRatio { get; set; }
        public double? AspectRatioValue { get { return string.IsNullOrEmpty(AspectRatio) ? (double?)null : GetDouble(AspectRatio); } }

        public string LetterSpacing { get; set; }
        public int? LetterSpacingValue { get { return string.IsNullOrEmpty(LetterSpacing) ? (int?)null : GetInt(LetterSpacing); } }

        /// <summary>
        /// 가로 정렬
        /// </summary>
        public string HorizontalAlign { get; set; }

        /// <summary>
        /// 세로 정렬
        /// </summary>
        public string VerticalAlign { get; set; }

        /// <summary>
        /// 문자 wrapping 여부
        /// </summary>
        public string WordWrap { get; set; }
        public bool IsWordWrap { get { return GetBoolean(WordWrap); } }

        /// <summary>
        /// 폰트
        /// </summary>
        public string Font { get; set; }


        private Color GetColor(string colorText)
        {
            int result = 0;
            if (int.TryParse(colorText, out result))
                return System.Drawing.Color.FromArgb(result);
            
            return System.Drawing.Color.Black;
        }

        private double GetDouble(string doubleText)
        {
            double result = 0;
            if(double.TryParse(doubleText, out result))
                return result;
            
            return 0;
        }

        private int GetInt(string intText)
        {
            int result = 0;
            if(int.TryParse(intText, out result))
                return result;
            return 0;
        }


        private bool GetBoolean(string boolText)
        {
            bool result = false;
            if(bool.TryParse(boolText, out result))
                return result;

            return false;
        }


        /// <summary>
        /// 속성명을 기준으로 속성값을 설정합니다.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        public void SetProperty(string propertyName, string value)
        {
            PropertyInfo[] infos = (typeof(DrawingCommand)).GetProperties();
            foreach (PropertyInfo propertyInfo in (typeof(DrawingCommand)).GetProperties())
            {
                if (string.Equals(propertyInfo.Name, propertyName, StringComparison.OrdinalIgnoreCase))
                {
                    propertyInfo.SetValue(this, value,null);
                    break;
                }
            }
        }



    }
}
