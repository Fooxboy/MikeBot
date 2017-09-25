using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Models;
namespace MikeBot.API.Method.Users
{
    public static class Get
    {

        public static Response<RootObjectList<User>> Start(string id, string fields="")
        {
            string json = Request.Api("users.get", $"user_ids={id}&fields={fields}");

            try
            {
                var ok = JsonConvert.DeserializeObject<RootObjectList<User>>(json);
                var resp = new Response<RootObjectList<User>>();
                resp.obj = ok;
                resp.error_code = 0;
                return resp;
            } catch
            {
                var error_obj = JsonConvert.DeserializeObject<Models.Error>(json);
                var resp = new Response<RootObjectList<User>>();
                resp.obj = null;
                resp.error_code = 5;
                resp.error = error_obj;
                API.Error.Proccesing.Start(error_obj.error.error_code);
                return resp;
            }
        }

    }
}
