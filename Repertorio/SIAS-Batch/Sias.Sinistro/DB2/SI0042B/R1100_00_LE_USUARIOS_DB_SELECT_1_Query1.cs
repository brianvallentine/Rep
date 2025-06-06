using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0042B
{
    public class R1100_00_LE_USUARIOS_DB_SELECT_1_Query1 : QueryBasis<R1100_00_LE_USUARIOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_USUARIO
            INTO :USUARIOS-NOME-USUARIO
            FROM SEGUROS.USUARIOS
            WHERE COD_USUARIO = :SIANAROD-COD-USUARIO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_USUARIO
											FROM SEGUROS.USUARIOS
											WHERE COD_USUARIO = '{this.SIANAROD_COD_USUARIO}'";

            return query;
        }
        public string USUARIOS_NOME_USUARIO { get; set; }
        public string SIANAROD_COD_USUARIO { get; set; }

        public static R1100_00_LE_USUARIOS_DB_SELECT_1_Query1 Execute(R1100_00_LE_USUARIOS_DB_SELECT_1_Query1 r1100_00_LE_USUARIOS_DB_SELECT_1_Query1)
        {
            var ths = r1100_00_LE_USUARIOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_00_LE_USUARIOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_00_LE_USUARIOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.USUARIOS_NOME_USUARIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}