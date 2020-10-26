using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ClassLibrary
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<string[]> GetData();
        [OperationContract]
        Dictionary<int, string> Clients();
        [OperationContract]
        Dictionary<int, string> Services();
        [OperationContract]
        void NewRec(int IdC, int IdS, int Time, DateTime Date);
    }
}
