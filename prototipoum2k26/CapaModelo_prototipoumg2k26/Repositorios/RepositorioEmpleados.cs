using CapaModelo_prototipoumg2k26.Contratos;
using CapaModelo_prototipoumg2k26.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo_prototipoumg2k26.Repositorios
{
    public class RepositorioEmpleados : RepositorioMaestro, IRepositorioEmpleados
    {
        private string selectAll;
        private string insert;
        private string update;
        private string delete;

        public RepositorioEmpleados()
        {
            selectAll = "SELECT id_empleado, id_tipo_empleado, id_estado_empleado, " +
                        "nombre_empleado, apellido_empleado, dpi_empleado, nit_empleado, " +
                        "telefono_empleado, direccion_empleado, fecha_nacimiento_empleado, " +
                        "fecha_contratacion_empleado FROM empleados";

            insert = "INSERT INTO empleados (id_tipo_empleado, id_estado_empleado, " +
                      "nombre_empleado, apellido_empleado, dpi_empleado, nit_empleado, " +
                      "telefono_empleado, direccion_empleado, fecha_nacimiento_empleado, " +
                      "fecha_contratacion_empleado) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

            update = "UPDATE empleados SET id_tipo_empleado=?, id_estado_empleado=?, " +
                      "nombre_empleado=?, apellido_empleado=?, dpi_empleado=?, nit_empleado=?, " +
                      "telefono_empleado=?, direccion_empleado=?, fecha_nacimiento_empleado=?, " +
                      "fecha_contratacion_empleado=? WHERE id_empleado=?";

            delete = "DELETE FROM empleados WHERE id_empleado=?";
        }

        public int Agregar(Empleados entidad)
        {
            var _parametros = new List<OdbcParameter>();
            _parametros.Add(new OdbcParameter("p_IdTipoEmpleado", entidad.IdTipoEmpleado));
            _parametros.Add(new OdbcParameter("p_IdEstadoEmpleado", entidad.IdEstadoEmpleado));
            _parametros.Add(new OdbcParameter("p_Nombre", entidad.NombreEmpleado));
            _parametros.Add(new OdbcParameter("p_Apellido", entidad.ApellidoEmpleado));
            _parametros.Add(new OdbcParameter("p_Dpi", (object)entidad.DpiEmpleado ?? DBNull.Value));
            _parametros.Add(new OdbcParameter("p_Nit", (object)entidad.NitEmpleado ?? DBNull.Value));
            _parametros.Add(new OdbcParameter("p_Telefono", (object)entidad.TelefonoEmpleado ?? DBNull.Value));
            _parametros.Add(new OdbcParameter("p_Direccion", (object)entidad.DireccionEmpleado ?? DBNull.Value));
            _parametros.Add(new OdbcParameter("p_FechaNacimiento", (object)entidad.FechaNacimientoEmpleado ?? DBNull.Value));
            _parametros.Add(new OdbcParameter("p_FechaContratacion", (object)entidad.FechaContratacionEmpleado ?? DBNull.Value));

            return EjecucionNonQuery(insert, _parametros, CommandType.Text);
        }

        public int Editar(Empleados entidad)
        {
            var _parametros = new List<OdbcParameter>();
            _parametros.Add(new OdbcParameter("p_IdTipoEmpleado", entidad.IdTipoEmpleado));
            _parametros.Add(new OdbcParameter("p_IdEstadoEmpleado", entidad.IdEstadoEmpleado));
            _parametros.Add(new OdbcParameter("p_Nombre", entidad.NombreEmpleado));
            _parametros.Add(new OdbcParameter("p_Apellido", entidad.ApellidoEmpleado));
            _parametros.Add(new OdbcParameter("p_Dpi", (object)entidad.DpiEmpleado ?? DBNull.Value));
            _parametros.Add(new OdbcParameter("p_Nit", (object)entidad.NitEmpleado ?? DBNull.Value));
            _parametros.Add(new OdbcParameter("p_Telefono", (object)entidad.TelefonoEmpleado ?? DBNull.Value));
            _parametros.Add(new OdbcParameter("p_Direccion", (object)entidad.DireccionEmpleado ?? DBNull.Value));
            _parametros.Add(new OdbcParameter("p_FechaNacimiento", (object)entidad.FechaNacimientoEmpleado ?? DBNull.Value));
            _parametros.Add(new OdbcParameter("p_FechaContratacion", (object)entidad.FechaContratacionEmpleado ?? DBNull.Value));
            _parametros.Add(new OdbcParameter("p_IdEmpleado", entidad.IdEmpleado));

            return EjecucionNonQuery(update, _parametros, CommandType.Text);
        }

        public int Remover(Empleados entidad)
        {
            var _parametros = new List<OdbcParameter>();
            _parametros.Add(new OdbcParameter("p_IdEmpleado", entidad.IdEmpleado));
            return EjecucionNonQuery(delete, _parametros, CommandType.Text);
        }

        public IEnumerable<Empleados> GetAll()
        {
            var lstEmpleado = new List<Empleados>();
            var tblTabla = EjecucionConsulta(selectAll, CommandType.Text);
            foreach (DataRow row in tblTabla.Rows)
            {
                var empleado = new Empleados();
                empleado.IdEmpleado = Convert.ToInt32(row[0]);
                empleado.IdTipoEmpleado = Convert.ToInt32(row[1]);
                empleado.IdEstadoEmpleado = Convert.ToInt32(row[2]);
                empleado.NombreEmpleado = row[3].ToString();
                empleado.ApellidoEmpleado = row[4].ToString();
                empleado.DpiEmpleado = row[5] == DBNull.Value ? null : row[5].ToString();
                empleado.NitEmpleado = row[6] == DBNull.Value ? null : row[6].ToString();
                empleado.TelefonoEmpleado = row[7] == DBNull.Value ? null : row[7].ToString();
                empleado.DireccionEmpleado = row[8] == DBNull.Value ? null : row[8].ToString();
                empleado.FechaNacimientoEmpleado = row[9] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row[9]);
                empleado.FechaContratacionEmpleado = row[10] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row[10]);
                lstEmpleado.Add(empleado);
            }
            tblTabla.Clear();
            tblTabla = null;
            return lstEmpleado;
        }
    }
}