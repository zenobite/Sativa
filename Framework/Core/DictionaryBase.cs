using System;
using System.Data;
using System.Collections;

namespace Sativa.Framework.Core
{
    /// <summary>
    /// Sativa Dictionary Base Class
    /// </summary>
    [Serializable()]
    public class SativaDictionaryBase : DictionaryBase
    {
        public ArrayList DeletedList;

        public SativaDictionaryBase()
        {
            DeletedList = new ArrayList();
        }

        public void Remove(string key)
        {
            DeletedList.Add(this.InnerHashtable[key]);
            base.InnerHashtable.Remove(key);
        }

        protected DataTable GetDataTable(IDictionary dics, Object item)
        {
            IDictionaryEnumerator enm = dics.GetEnumerator();
            ArrayList arr = new ArrayList();
            while (enm.MoveNext())
            {
                arr.Add(enm.Value);
            }

            SativaCollectionBase adaptee = new SativaCollectionBase();
            adaptee.DeletedList = this.DeletedList;

            return adaptee.FriendGetDataTable(arr, item);
        }
    }
}