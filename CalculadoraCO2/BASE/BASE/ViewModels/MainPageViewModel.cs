using System;
using BASE.Datos;
using BASE.Modelos;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace BASE.ViewModels
{

    public class CrearCalculosInterfazViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<Operacion> operaciones;
        public List<Operacion> Operaciones
        {
            get { return operaciones; }
            set
            {
                operaciones = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Operaciones)));
            }
        }

        public async Task LoadOperacionesAsync()
        {
            Operaciones = await OperacionesDatabase.Database.Table<Operacion>().ToListAsync();
        }

        public async Task DeleteOperacionesAsync()
        {
            await OperacionesDatabase.Database.DeleteAllAsync<Operacion>();
            Operaciones.Clear();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Operaciones)));
        }

        public async Task RefreshOperacionesAsync()
        {
            Operaciones.Clear();
            Operaciones = await OperacionesDatabase.Database.Table<Operacion>().ToListAsync();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Operaciones)));
        }
    }
}

