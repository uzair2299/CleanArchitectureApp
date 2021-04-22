using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Interfaces.SessionManager
{
    public interface ISessionManager
    {
        public void  SetJson(string key,object value);
        public T GetJson<T>(string key);
        public void SessionClear();
        public void SessionRemove(string key);


    }
}
