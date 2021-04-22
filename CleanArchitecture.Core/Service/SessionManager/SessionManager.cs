using CleanArchitecture.Core.Interfaces.SessionManager;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Service.SessionManager
{
    public class SessionManager : ISessionManager
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ISession session;
        public SessionManager(IHttpContextAccessor httpContextAccessor, ISession session)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.session = httpContextAccessor.HttpContext.Session;
        }

        public T GetJson<T>(string key)
        {
            var sessionData =  session.GetString(key);
            return sessionData == null ? default(T) : JsonConvert.DeserializeObject<T>(sessionData);
        }

        public void SetJson(string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        /// <summary>
        /// Clear the Session
        /// </summary>
        public void SessionClear()
        {
            session.Clear();
        }

        /// <summary>
        /// Remove the given key from the session if present
        /// </summary>
        public void SessionRemove(string key)
        {
            session.Remove(key);
        }
    }
}
