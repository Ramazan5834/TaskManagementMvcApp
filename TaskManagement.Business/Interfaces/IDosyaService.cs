using System.Collections.Generic;

namespace TaskManagement.Business.Interfaces
{
    public interface IDosyaService
    {
        string AktarPdf<T>(List<T> list) where T:class,new();
        byte[] AktarExcel<T>(List<T> list) where T:class,new();
    }
}
