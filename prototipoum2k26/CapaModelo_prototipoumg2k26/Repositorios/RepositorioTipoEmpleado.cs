using CapaModelo_prototipoumg2k26.Contratos;
using CapaModelo_prototipoumg2k26.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;

namespace CapaModelo_prototipoumg2k26.Repositorios
{
    public class RepositorioTipoEmpleado : RepositorioMaestro, IRepositorioTipoEmpleado
    {
        private string selectAll;
        private string insert;
        private string update;
        private string delete;

        public RepositorioTipoEmpleado()
        {
            selectAll = "SELECT id_tipo_empleado, nombre_tipo_empleado FROM tipo_empleado";
            insert = "INSERT INTO tipo_empleado (nombre_tipo_empleado) VALUES (?)";
            update = "UPDATE tipo_empleado SET nombre_tipo_empleado=? WHERE id_tipo_empleado=?";
            delete = "DELETE FROM tipo_empleado WHERE id_tipo_empleado=?";
        }

        public int Agregar(TipoEmpleado entidad)
        {
            var _parametros = new List<OdbcParameter>();
            _parametros.Add(new OdbcParameter("p_Nombre", entidad.NombreTipoEmpleado));
            return EjecucionNonQuery(insert, _parametros, CommandType.Text);
        }

        public int Editar(TipoEmpleado entidad)
        {
            var _parametros = new List<OdbcParameter>();
            _parametros.Add(new OdbcParameter("p_Nombre", entidad.NombreTipoEmpleado));
            _parametros.Add(new OdbcParameter("p_Id", entidad.IdTipoEmpleado));
            return EjecucionNonQuery(update, _parametros, CommandType.Text);
        }

        public int Remover(TipoEmpleado entidad)
        {
            var _parametros = new List<OdbcParameter>();
            _parametros.Add(new OdbcParameter("p_Id", entidad.IdTipoEmpleado));
            return EjecucionNonQuery(delete, _parametros, CommandType.Text);
        }

        public IEnumerable<TipoEmpleado> GetAll()
        {
            var lista = new List<TipoEmpleado>();
            var tblTabla = EjecucionConsulta(selectAll, CommandType.Text);
            foreach (DataRow row in tblTabla.Rows)
            {
                lista.Add(new TipoEmpleado
                {
                    IdTipoEmpleado = Convert.ToInt32(row[0]),
                    NombreTipoEmpleado = row[1].ToString()
                });
            }
            tblTabla.Clear();
            tblTabla = null;
            return lista;
        }
    }
}