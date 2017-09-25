using System;
using System.Collections.Generic;
using System.Text;

namespace MikeBot.API.Method.Account
{
    public static class SetOffline
    {
        public static void Start()
        {
            Request.Api("account.setOffline", "");
        }
    }
}
