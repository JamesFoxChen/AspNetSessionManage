using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RedisCustom9000
{
    public partial class RedisTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RedisHelper.Set<string>("aa", DateTime.Now.ToString());
            var str = RedisHelper.Get<string>("aa");
        }
    }
}