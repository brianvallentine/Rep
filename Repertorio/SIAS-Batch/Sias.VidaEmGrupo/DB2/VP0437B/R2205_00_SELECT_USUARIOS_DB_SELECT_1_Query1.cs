using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0437B
{
    public class R2205_00_SELECT_USUARIOS_DB_SELECT_1_Query1 : QueryBasis<R2205_00_SELECT_USUARIOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_USUARIO
            INTO :USUARIOS-COD-USUARIO
            FROM SEGUROS.USUARIOS
            WHERE COD_USUARIO = :WHOST-CODUSU
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_USUARIO
											FROM SEGUROS.USUARIOS
											WHERE COD_USUARIO = '{this.WHOST_CODUSU}'";

            return query;
        }
        public string USUARIOS_COD_USUARIO { get; set; }
        public string WHOST_CODUSU { get; set; }

        public static R2205_00_SELECT_USUARIOS_DB_SELECT_1_Query1 Execute(R2205_00_SELECT_USUARIOS_DB_SELECT_1_Query1 r2205_00_SELECT_USUARIOS_DB_SELECT_1_Query1)
        {
            var ths = r2205_00_SELECT_USUARIOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2205_00_SELECT_USUARIOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2205_00_SELECT_USUARIOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.USUARIOS_COD_USUARIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}