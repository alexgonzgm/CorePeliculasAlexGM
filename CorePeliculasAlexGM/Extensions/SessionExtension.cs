using CorePeliculasAlexGM.Helpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePeliculasAlexGM.Extensions
{
    public static class SessionExtension
    {
        public static  void SetObject(this ISession session , string key , object value)
        {
            string objetostring = ToolkitService.SerializeJsonObject(value);
            session.SetString(key, objetostring);
        }
        public static T GetObject<T> (this ISession session , string key)
        {
            string objString = session.GetString(key);
            if (objString == null) return default(T);
            return ToolkitService.DeserializeJsonObject<T>(objString);
        }
    }
}
