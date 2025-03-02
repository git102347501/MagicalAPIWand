using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalAPIWand
{
    public static class AppConfig
    {
        public static int TaskNum { get; set; }

        public static int MaxTaskMsgLength { get; set; } = 300;

        public static int TaskFormWidth { get; set; } = 400;

        public static int TaskFormHeight { get; set; } = 400;
    }
}
