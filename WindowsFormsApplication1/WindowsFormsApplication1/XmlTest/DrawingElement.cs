using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.XmlTest
{
    /// <summary>
    /// xml 문서를 도식화 합니다.
    /// </summary>
    public class DrawingElement
    {
        public DrawingElement()
        {
            CommandList = new List<DrawingCommand>();
        }

        //public DrawingElement(string name, string value) : this()
        //{
        //    this.Name = name;
        //    this.Value = value;
        //}

        /// <summary>
        /// xelement의 이름
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// xelement의 값
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 드로잉 커맨드 목록
        /// </summary>
        public List<DrawingCommand> CommandList { get; set; }

        /// <summary>
        /// 드로잉 커맨드가 있는지 확인
        /// </summary>
        public bool HasCommands { get { return CommandList.Count > 0; } }
    }
}
