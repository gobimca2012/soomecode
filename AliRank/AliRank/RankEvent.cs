﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AliRank
{

    public delegate void RankSearchingEvent(object sender, RankEventArgs e);
    public delegate void RankSearchEndEvent(object sender, RankEventArgs e);

    public delegate void RankClickEndEvent(object sender, RankEventArgs e);
    public delegate void RankClickingEvent(object sender, RankEventArgs e);

    public class RankEventArgs : EventArgs
    {
        public Keywords Item;
        public string Msg;

        public RankEventArgs(Keywords _obj, string _msg)
        {
            this.Item = _obj;
            this.Msg = _msg;
        }
    }

}
