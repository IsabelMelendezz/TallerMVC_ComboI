using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaModelo_prototipoumg2k26.Contratos;
using CapaModelo_prototipoumg2k26.Entidades;
using CapaModelo_prototipoumg2k26.Repositorios;
using System.ComponentModel.DataAnnotations;

namespace CapaControlador_prototipoumg2k26
{
    public class ModeloEmpleado
    {
        private int _idEmpleado;
        private int _idTipoEmpleado;
        private int _idEstadoEmpleado;
        private string _nombreEmpleado;
        private string _apellidoEmpleado;
        private string _dpiEmpleado;
        private string _nitEmpleado;
        private string _telefonoEmpleado;
        private string _direccionEmpleado;
        private DateTime? _fechaNacimientoEmpleado;
        private DateTime? _fechaContratacionEmpleado;
        private int _edad;
        private IRepositorioEmpleados RepositorioEmpleados;

        public EstadoEntidad Estado { private get; set; }
        private List<ModeloEmpleado> ListaEmpleados;

        public int IdEmpleado { get => _idEmpleado; set => _idEmpleado = value; }

        [Required(ErrorMessage = "Debe seleccionar el tipo de empleado")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un tipo de empleado válido")]
        public int IdTipoEmpleado { get => _idTipoEmpleado; set => _idTipoEmpleado = value; }

        [Required(ErrorMessage = "Debe seleccionar el estado del empleado")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un estado válido")]
        public int IdEstadoEmpleado { get => _idEstadoEmpleado; set => _idEstadoEmpleado = value; }

        [Required(ErrorMessage = "El campo Nombre es requerido")]
        [RegularExpression("^[a-zA-Zá-ú ]+$", ErrorMessage = "El campo Nombre debe ser solo letras")]
        [StringLength(maximumLength: 100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres")]
        public string NombreEmpleado { get => _nombreEmpleado; set => _nombreEmpleado = value; }

        [Required(ErrorMessage = "El campo Apellido es requerido")]
        [RegularExpression("^[a-zA-Zá-ú ]+$", ErrorMessage = "El campo Apellido debe ser solo letras")]
        [StringLength(maximumLength: 100, MinimumLength = 3, ErrorMessage = "El apellido debe tener entre 3 y 100 caracteres")]
        public string ApellidoEmpleado { get => _apellidoEmpleado; set => _apellidoEmpleado = value; }

        [RegularExpression("([0-9]{13})", ErrorMessage = "El DPI debe tener 13 dígitos numéricos")]
        public string DpiEmpleado { get => _dpiEmpleado; set => _dpiEmpleado = value; }

        [RegularExpression("^[0-9]{1,9}[kK]?-?[0-9]?$", ErrorMessage = "El NIT no tiene un formato válido")]
        [StringLength(maximumLength: 20, ErrorMessage = "El NIT no puede superar 20 caracteres")]
        public string NitEmpleado { get => _nitEmpleado; set => _nitEmpleado = value; }

        [RegularExpression("([0-9]{8})", ErrorMessage = "El teléfono debe tener 8 dígitos numéricos")]
        public string TelefonoEmpleado { get => _telefonoEmpleado; set => _telefonoEmpleado = value; }

        [StringLength(maximumLength: 255, ErrorMessage = "La dirección no puede superar 255 caracteres")]
        public string DireccionEmpleado { get => _direccionEmpleado; set => _direccionEmpleado = value; }

        public DateTime? FechaNacimientoEmpleado { get => _fechaNacimientoEmpleado; set => _fechaNacimientoEmpleado = value; }

        public DateTime? FechaContratacionEmpleado { get => _fechaContratacionEmpleado; set => _fechaContratacionEmpleado = value; }

        public int Edad { get => _edad; private set => _edad = value; }

        public ModeloEmpleado()
        {
            RepositorioEmpleados = new RepositorioEmpleados();
        }

        public string GrabarCambios()
        {
            string mensaje = null;
            try
            {
                var modeloDatosEmpleados = new Empleados();
                modeloDatosEmpleados.IdEmpleado = _idEmpleado;
                modeloDatosEmpleados.IdTipoEmpleado = _idTipoEmpleado;
                modeloDatosEmpleados.IdEstadoEmpleado = _idEstadoEmpleado;
                modeloDatosEmpleados.NombreEmpleado = _nombreEmpleado;
                modeloDatosEmpleados.ApellidoEmpleado = _apellidoEmpleado;
                modeloDatosEmpleados.DpiEmpleado = _dpiEmpleado;
                modeloDatosEmpleados.NitEmpleado = _nitEmpleado;
                modeloDatosEmpleados.TelefonoEmpleado = _telefonoEmpleado;
                modeloDatosEmpleados.DireccionEmpleado = _direccionEmpleado;
                modeloDatosEmpleados.FechaNacimientoEmpleado = _fechaNacimientoEmpleado;
                modeloDatosEmpleados.FechaContratacionEmpleado = _fechaContratacionEmpleado;

                switch (Estado)
                {
                    case EstadoEntidad.Added:
                        RepositorioEmpleados.Agregar(modeloDatosEmpleados);
                        mensaje = "Grabacion exitosa";
                        break;
                    case EstadoEntidad.Modified:
                        RepositorioEmpleados.Editar(modeloDatosEmpleados);
                        mensaje = "Actualizacion exitosa";
                        break;
                    case EstadoEntidad.Deleted:
                        RepositorioEmpleados.Remover(modeloDatosEmpleados);
                        mensaje = "Eliminacion exitosa";
                        break;
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.ToString();
            }
            return mensaje;
        }

        public List<ModeloEmpleado> GetAll()
        {
            var modeloDatosEmpleados = RepositorioEmpleados.GetAll();
            ListaEmpleados = new List<ModeloEmpleado>();
            foreach (Empleados item in modeloDatosEmpleados)
            {
                ListaEmpleados.Add(new ModeloEmpleado
                {
                    _idEmpleado = item.IdEmpleado,
                    _idTipoEmpleado = item.IdTipoEmpleado,
                    _idEstadoEmpleado = item.IdEstadoEmpleado,
                    _nombreEmpleado = item.NombreEmpleado,
                    _apellidoEmpleado = item.ApellidoEmpleado,
                    _dpiEmpleado = item.DpiEmpleado,
                    _nitEmpleado = item.NitEmpleado,
                    _telefonoEmpleado = item.TelefonoEmpleado,
                    _direccionEmpleado = item.DireccionEmpleado,
                    _fechaNacimientoEmpleado = item.FechaNacimientoEmpleado,
                    _fechaContratacionEmpleado = item.FechaContratacionEmpleado,
                    _edad = item.FechaNacimientoEmpleado.HasValue ? CalcularEdad(item.FechaNacimientoEmpleado.Value) : 0
                });
            }
            return ListaEmpleados;
        }

        public IEnumerable<ModeloEmpleado> FindbyId(string filter)
        {
            return ListaEmpleados.FindAll(e =>
                e._nombreEmpleado.Contains(filter) ||
                e._apellidoEmpleado.Contains(filter) ||
                (e._dpiEmpleado != null && e._dpiEmpleado.Contains(filter)));
        }

        public DataTable GetTiposEmpleado()
        {
            var repo = new RepositorioTipoEmpleado();
            var lista = repo.GetAll().ToList();
            var tabla = new DataTable();
            tabla.Columns.Add("IdTipoEmpleado", typeof(int));
            tabla.Columns.Add("NombreTipoEmpleado", typeof(string));
            foreach (var item in lista)
                tabla.Rows.Add(item.IdTipoEmpleado, item.NombreTipoEmpleado);
            return tabla;
        }

        public DataTable GetEstadosEmpleado()
        {
            var repo = new RepositorioEstadoEmpleado();
            var lista = repo.GetAll().ToList();
            var tabla = new DataTable();
            tabla.Columns.Add("IdEstadoEmpleado", typeof(int));
            tabla.Columns.Add("NombreEstadoEmpleado", typeof(string));
            foreach (var item in lista)
                tabla.Rows.Add(item.IdEstadoEmpleado, item.NombreEstadoEmpleado);
            return tabla;
        }

        private int CalcularEdad(DateTime date)
        {
            DateTime fechaActual = DateTime.Now;
            return fechaActual.Year - date.Year;
        }
    }
}