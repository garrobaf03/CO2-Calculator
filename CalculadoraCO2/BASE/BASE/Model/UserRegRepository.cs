using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace BASE.Model
{
    class UserRegRepository
    {

        private SQLiteConnection con;

        private static UserRegRepository intancia;
        public static UserRegRepository Instancia
        {
            get
            {
                if (intancia == null)
                    throw new Exception("Debe llamar al inicializador, acción detenida");
                return intancia;
            }
        }

        public static void Inicializador(String filename)
        {
            if (filename == null)
            {
                throw new ArgumentException();
            }



            if (intancia != null)
            {
                intancia.con.Close();
            }
            intancia = new UserRegRepository(filename);
        }

        private UserRegRepository(String dbPath)
        {
            con = new SQLiteConnection(dbPath);
            con.CreateTable<User>();
        }

        public string EstadoMensaje;



        public int addNewUser(int id, string name, string address, DateTime birthdate, string username, string password, string email)
        {
            int result = 0;
            try
            {
                result = con.Insert(new User
                {
                    Id = id,
                    Name = name,
                    Address = address,
                    Birthdate = birthdate,
                    Username = username,
                    Password = password,
                    Email = email,
                });
                EstadoMensaje = string.Format("Cantidad filas : {0}", result);
            }
            catch (Exception e)
            { EstadoMensaje = e.Message; }
            return result;
        }


        public bool loginUser(string username, string password)
        {
            var usuarioEncontrado = con.Table<User>().Where(u => u.Username == username && u.Password == password).FirstOrDefault();

            if (usuarioEncontrado != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}


