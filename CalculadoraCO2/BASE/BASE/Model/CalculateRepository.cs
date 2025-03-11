using System;
using SQLite;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace BASE.Model
{
	 class CalculateRepository
{
        private SQLiteConnection con;



        private static CalculateRepository instancia;
        public static CalculateRepository Instancia
        {
            get
            {
                if (instancia == null)
                    throw new Exception("Debe llamar al inicializador, acción detenida");
                return instancia;
            }
        }



        public static void Inicializador(String filename)
        {
            if (filename == null)
            {
                throw new ArgumentException();
            }



            if (instancia != null)
            {
                instancia.con.Close();
            }
            instancia = new CalculateRepository(filename);
        }



        private CalculateRepository(String dbPath)
        {
            con = new SQLiteConnection(dbPath);
            con.CreateTable<Calculadora>();
        }



        public string EstadoMensaje;



        public int AddNewCalculate(string id, string organizationname, string emisiontype, string emisionname)
        {
            int result = 0;
            try
            {
                result = con.Insert(new Calculadora
                {
                    Id = id,
                    OrganizationName = organizationname,
                    EmisionType = emisiontype,
                    EmisionName = emisionname

                });
                EstadoMensaje = string.Format("Cantidad filas : {0}", result);
            }
            catch (Exception e)
            { EstadoMensaje = e.Message; }
            return result;
        }



        public IEnumerable<Calculadora> GetAllCalculates()
        {
            try
            {
                return con.Table<Calculadora>();
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return Enumerable.Empty<Calculadora>();
        }

        public int DeleteCalculations()
        {
            int result = 0;
            try
            {
                result = con.DeleteAll<Calculadora>();
                EstadoMensaje = string.Format("Se borran {0} registros", result);
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return result;
        }
    }
}

