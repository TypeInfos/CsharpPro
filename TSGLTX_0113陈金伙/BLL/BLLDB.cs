using System;
using System.Collections.Generic;
using System.Text;

namespace TSGLXT.BLL
{
    public class BLLDB
    {
        public static BLLDZB DZB { get { return new BLLDZB(); } }
        public static BLLGLB GLB { get { return new BLLGLB(); } }
        public static BLLSKB SKB { get { return new BLLSKB(); } }
        public static BLLTSB TSB { get { return new BLLTSB(); } }
        public static BLLYHB YHB { get { return new BLLYHB(); } }
    }
}
