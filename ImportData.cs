using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MagicalAPIWand
{
    public static class ImportData
    {
        public static List<object> Data { get; set; } = new List<object>();


        public static List<List<object>> SplitDataIntoChunks(List<object> data, int numberOfTasks)
        {
            List<List<object>> chunks = new List<List<object>>();
            int chunkSize = (int)Math.Ceiling(data.Count / (double)numberOfTasks);

            for (int i = 0; i < data.Count; i += chunkSize)
            {
                chunks.Add(data.GetRange(i, Math.Min(chunkSize, data.Count - i)));
            }

            return chunks;
        } 
    }
}
