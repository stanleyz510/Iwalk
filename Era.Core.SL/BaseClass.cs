using System;
using System.Collections.Generic;
using System.Text;

namespace Era.Core {
    //Chinese era
    //the ten Heavenly Stems 10天干
    //terrestrial branch 地支
    public enum emStems
    {
        甲,乙,丙,丁,戊,己,庚,辛,壬,癸
    }
    public enum emBranch
    {
        子,丑,寅,卯,辰,巳,午,未,申,酉,戌,亥
    }
    public enum emEra
    {
        木,火,土,金,水
    }
    public enum emEraRelation {
        比肩, 劫财, 食神, 伤官, 偏财, 正财, 七煞, 正官, 偏印, 正印, 日元
    }
}
