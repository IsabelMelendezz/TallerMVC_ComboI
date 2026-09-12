using CapaModelo_prototipoumg2k26.Contratos;
using CapaModelo_prototipoumg2k26.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;

namespace CapaModelo_prototipoumg2k26.Repositorios
{
    public class RepositorioEstadoEmpleado : RepositorioMaestro, IRepositorioEstadoEmpleado
    {
        private string selectAll;
        private string insert;
        private string update;
        private string delete;

        public RepositorioEstadoEmpleado()
        {
            selectAll = "SELECT id_estado_empleado, nombre_estado_empleado FROM estado_empleado";
            insert = "INSERT INTO estado_empleado (nombre_estado_empleado) VALUES (?)";
            update = "UPDATE estado_empleado SET nombre_estado_empleado=? WHERE id_estado_empleado=?";
            delete = "DELETE FROM estado_empleado WHERE id_estado_empleado=?";
        }

        public int Agregar(EstadoEmpleado entidad)
        {
            var _parametros = new List<OdbcParameter>();
            _parametros.Add(new OdbcParameter("p_Nombre", entidad.NombreEstadoEmpleado));
            return EjecucionNonQuery(insert, _parametros, CommandType.Text);
        }

        public int Editar(EstadoEmpleado entidad)
        {
            var _parametros = new List<OdbcParameter>();
            _parametros.Add(new OdbcParameter("p_Nombre", entidad.NombreEstadoEmpleado));
            _parametros.Add(new OdbcParameter("p_Id", entidad.IdEstadoEmpleado));
            return EjecucionNonQuery(update, _parametros, CommandType.Text);
        }

        public int Remover(EstadoEmpleado entidad)
        {
            var _parametros = new List<OdbcParameter>();
            _parametros.Add(new OdbcParameter("p_Id", entidad.IdEstadoEmpleado));
            return EjecucionNonQuery(delete, _parametros, CommandType.Text);
        }

        public IEnumerable<EstadoEmpleado> GetAll()
        {
            var lista = new List<EstadoEmpleado>();
            var tblTabla = EjecucionConsulta(selectAll, CommandType.Text);
            foreach (DataRow row in tblTabla.Rows)
            {
                lista.Add(new EstadoEmpleado
                {
                    IdEstadoEmpleado = Convert.ToInt32(row[0]),
                    NombreEstadoEmpleado = row[1].ToString()
                });
            }
            tblTabla.Clear();
            tblTabla = null;
            return lista;
        }
    }
}