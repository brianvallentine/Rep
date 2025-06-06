using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0021B
{
    public class R1000_LE_USUARIO_DB_SELECT_1_Query1 : QueryBasis<R1000_LE_USUARIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_USUARIO
            ,DEPARTAMENTO
            INTO :V0USU-NOME-USUARIO
            ,:V0USU-DEPARTAMENTO
            FROM SEGUROS.USUARIOS
            WHERE COD_USUARIO = :AT-USUARIO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_USUARIO
											,DEPARTAMENTO
											FROM SEGUROS.USUARIOS
											WHERE COD_USUARIO = '{this.AT_USUARIO}'";

            return query;
        }
        public string V0USU_NOME_USUARIO { get; set; }
        public string V0USU_DEPARTAMENTO { get; set; }
        public string AT_USUARIO { get; set; }

        public static R1000_LE_USUARIO_DB_SELECT_1_Query1 Execute(R1000_LE_USUARIO_DB_SELECT_1_Query1 r1000_LE_USUARIO_DB_SELECT_1_Query1)
        {
            var ths = r1000_LE_USUARIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_LE_USUARIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_LE_USUARIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0USU_NOME_USUARIO = result[i++].Value?.ToString();
            dta.V0USU_DEPARTAMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}