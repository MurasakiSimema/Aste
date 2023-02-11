using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BergonziVerifica
{
    public class BLLPezzi:DAL
    {
        public BLLPezzi()
        {

        }
        public void PopolaPezzi(string Nome,string Descrizione,string Tipologia,int AnnoPezzo,int IDCasa)
        {
            string sql = "INSERT INTO Pezzi(Nome,Descrizione,Tipologia,AnnoPezzo,IDCasa) VALUES(@Nome,@Descrizione,@Tipologia,@AnnoPezzo,@IDCasa)";

            SqlCommand cmd = base.CreaCommand(sql);
            cmd.Parameters.AddWithValue("@Nome", Nome);
            cmd.Parameters.AddWithValue("@Descrizione", Descrizione);
            cmd.Parameters.AddWithValue("@Tipologia", Tipologia);
            cmd.Parameters.AddWithValue("@AnnoPezzo", AnnoPezzo);
            cmd.Parameters.AddWithValue("@IDCasa", IDCasa);


            cmd.ExecuteNonQuery();
        }
        public DataTable A()
        {
            string sql = "SELECT Pezzi.IDPezzo, Pezzi.Nome, Descrizione,Tipologia,AnnoPezzo,CasaAste.Nome AS CasaAsta " +
                "FROM Pezzi INNER JOIN CasaAste ON Pezzi.IDCasa=CasaAste.IDCasa";


            return base.LeggiDB(sql);
        }
        public DataTable Ricerca(string txt)
        {
            string sql = "SELECT Pezzi.Nome, Descrizione,Tipologia,AnnoPezzo,CasaAste.Nome AS CasaAsta " +
                "FROM Pezzi INNER JOIN CasaAste ON Pezzi.IDCasa=CasaAste.IDCasa " +
                "WHERE CasaAste.Nome LIKE '" + txt + "%'";

            return base.LeggiDB(sql);
        }
        public DataTable SelectID(int ID)
        {
            string sql = "SELECT * FROM Pezzi WHERE IDPezzo = " + ID;


            return base.LeggiDB(sql);
        }
        public DataTable CMBCase()
        {
            string sql = "SELECT Nome, IDCasa FROM CasaAste";


            return base.LeggiDB(sql);
        }
        public DataTable SelectCMB(int id)
        {
            string sql = "SELECT CasaAste.Nome, Pezzi.Nome, Pezzi.Descrizione, Pezzi.Tipologia, Pezzi.AnnoPezzo " +
                "FROM CasaAste INNER JOIN Pezzi ON CasaAste.IDCasa = Pezzi.IDCasa " +
                "WHERE IDPezzo =" + id;


            return base.LeggiDB(sql);
        }
        public void Modifica(int ID, string Nome, string Descrizione, string Tipologia, int AnnoPezzo, int IDCasa)
        {
            string sql = "UPDATE Pezzi " +
                "SET Nome=@Nome,Descrizione=@Descrizione,Tipologia=@Tipologia,AnnoPezzo=@AnnoPezzo,IDCasa=@IDCasa " +
                "WHERE IDPezzo=" + ID;

            SqlCommand cmd = base.CreaCommand(sql);
            cmd.Parameters.AddWithValue("@Nome", Nome);
            cmd.Parameters.AddWithValue("@Descrizione", Descrizione);
            cmd.Parameters.AddWithValue("@Tipologia", Tipologia);
            cmd.Parameters.AddWithValue("@AnnoPezzo", AnnoPezzo);
            cmd.Parameters.AddWithValue("@IDCasa", IDCasa);


            cmd.ExecuteNonQuery();
        }
        public void Elimina(int ID)
        {
            string query = "DELETE FROM Pezzi WHERE IDPezzo=" + ID;
            SqlCommand cmd = base.CreaCommand(query);


            cmd.ExecuteNonQuery();
        }
        public string Esporta(int ID)
        {
            StringBuilder sb = new StringBuilder();
            string esp;
            string sql = "SELECT Pezzi.IDPezzo, Pezzi.Nome, Descrizione,Tipologia,AnnoPezzo " +
                "FROM Pezzi " +
                "WHERE IDCasa =" + ID;
            DataTable data = base.LeggiDB(sql);

            for (int i = 0; i < data.Columns.Count; i++)
            {
                sb.Append(data.Columns[i]);
                if (i < data.Columns.Count - 1)
                {
                    sb.Append(",");
                }
            }
            sb.AppendLine();

            foreach (DataRow dr in data.Rows)
            {
                for (int i = 0; i < data.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (value.Contains(','))
                        {
                            value = String.Format("\"{0}\"", value);
                            sb.Append(value);
                        }
                        else
                        {
                            sb.Append(dr[i].ToString());
                        }
                    }
                    if (i < data.Columns.Count - 1)
                    {
                        sb.Append(",");
                    }
                }
                sb.AppendLine();
            }

            esp = sb.ToString();
            
            return esp;
        }
    }
}
