using System;
using System.Collections.Generic;
using System.Text;

namespace Era.Core {
    /// <summary>
    /// 表示对计算产生影像的数据接口
    /// 三合局,冲克,
    /// </summary>
    public interface IInfluence
    {
        bool Effect { get; set; }
        bool IsAccumulation { get; set; }
        //断语
        string Assert { get; set; }

    }
}
