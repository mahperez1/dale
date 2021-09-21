using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Repositorio.SqlServer
{
    public static class MapInstance
    {
        public static List<T> MapearInstanciaObjeto<T>(DataTable dataTable)
        {
            List<T> functionReturnValue = new List<T>();
            try
            {
                string serializedObject = JsonConvert.SerializeObject(dataTable, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                if (serializedObject != null)
                {
                    functionReturnValue = (List<T>)JsonConvert.DeserializeObject(serializedObject, typeof(List<T>));
                }
            }
            catch (JsonSerializationException)
            {
                try
                {
                    string serializedObject = JsonConvert.SerializeObject(dataTable, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                    var sb = new StringBuilder(serializedObject);
                    sb[0] = string.Empty.FirstOrDefault();
                    sb[serializedObject.Length - 1] = string.Empty.FirstOrDefault();
                    serializedObject = sb.ToString();
                    functionReturnValue = (List<T>)JsonConvert.DeserializeObject(serializedObject, typeof(List<T>));
                }
                catch (Exception exc)
                { throw exc; }
            }
            catch (Exception ex)
            { throw ex; }
            return functionReturnValue;
        }

        public static List<T> MapearInstanciaObjeto<T>(string strLstObjSerialized)
        {
            List<T> functionReturnValue = new List<T>() { };
            try
            {
                if (strLstObjSerialized != null)
                {
                    functionReturnValue = (List<T>)JsonConvert.DeserializeObject(strLstObjSerialized, typeof(List<T>));
                }
            }
            catch (JsonSerializationException)
            {
                try
                {
                    var sb = new StringBuilder(strLstObjSerialized);
                    sb[0] = string.Empty.FirstOrDefault();
                    sb[strLstObjSerialized.Length - 1] = string.Empty.FirstOrDefault();
                    strLstObjSerialized = sb.ToString();
                    functionReturnValue = (List<T>)JsonConvert.DeserializeObject(strLstObjSerialized, typeof(List<T>));
                }
                catch (Exception exc)
                { throw exc; }
            }
            catch (Exception ex)
            { throw ex; }
            return functionReturnValue;
        }

        public static T MapearInstanciaUnObjeto<T>(string strLstObjSerialized)
        {
            T functionReturnValue = (T)Activator.CreateInstance(typeof(T));
            try
            {
                if (strLstObjSerialized != null)
                {
                    functionReturnValue = (T)JsonConvert.DeserializeObject(strLstObjSerialized, typeof(T));
                }
            }
            catch (JsonSerializationException)
            {
                try
                {
                    var sb = new StringBuilder(strLstObjSerialized);
                    sb[0] = string.Empty.FirstOrDefault();
                    sb[strLstObjSerialized.Length - 1] = string.Empty.FirstOrDefault();
                    strLstObjSerialized = sb.ToString();
                    functionReturnValue = (T)JsonConvert.DeserializeObject(strLstObjSerialized, typeof(T));
                }
                catch (Exception exc)
                { throw exc; }
            }
            catch (Exception ex)
            { throw ex; }
            return functionReturnValue;
        }
    }
}