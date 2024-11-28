using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSeriesCollector
{
    public interface IRecordable
    {
        string prefix { get; set; }
        string path { get; set; }
        int interval { get; set; }
        int recordTime { get; set; }
        // 是否有效
        bool deleted { get; set; }
        // 开始录制
        void startRecord();
        // 停止录制并保存文件
        void stopRecord(bool saveOrNot);
        // 是否就绪
        bool isReady();
    }
}
