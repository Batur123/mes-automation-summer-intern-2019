using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeshEkran
{
    class Arşiv
    {
    }
}

/*
           bool result = false;
           if (!MakineVarsa(degisken))
           {
               using (var connection = MeshEkran.Veritabani.Database.GetConnection())
               {
                   var command = new SqlCommand("INSERT INTO MakinelerTablosu(MakineAdi,MakineKodu,OperasyonID) VALUES('" + degisken.MakineAdi + "','" + degisken.MakineKodu + "','" + degisken.OperasyonID + "')");
                   command.Connection = connection;
                   connection.Open();
                   if (command.ExecuteNonQuery() != -1)
                   {
                       result = true;
                   }
                   connection.Close();
               }
           }
           return result; */
