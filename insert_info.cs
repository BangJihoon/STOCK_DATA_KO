using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YOACOMClientCSharp
{
    class insert_info
    {
        public ObjectId Id { get; set; }

        public object Jongcode { get; set; }

        public object Curjuka { get; set; }

        public object Debi { get; set; }

        public object Debirate { get; set; }

        public object Volume { get; set; }
        // 추가 

        public override string ToString()
        {
            return Jongcode + " " + Curjuka + "" + Debi + "" + Debirate + "" + Volume;//  추가되면 뒤에 변수 + " "붙여 줄것
        }
    }
}
