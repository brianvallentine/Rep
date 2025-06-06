using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0590B
{
    public class R0500_00_LE_MAT_FUNC_DB_SELECT_1_Query1 : QueryBasis<R0500_00_LE_MAT_FUNC_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_MATRICULA
            , NOME_FUNCIONARIO
            INTO :FUNCICEF-NUM-MATRICULA
            ,:FUNCICEF-NOME-FUNCIONARIO
            FROM SEGUROS.FUNCIONARIOS_CEF
            WHERE NUM_MATRICULA = :FUNCICEF-NUM-MATRICULA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_MATRICULA
											, NOME_FUNCIONARIO
											FROM SEGUROS.FUNCIONARIOS_CEF
											WHERE NUM_MATRICULA = '{this.FUNCICEF_NUM_MATRICULA}'
											WITH UR";

            return query;
        }
        public string FUNCICEF_NUM_MATRICULA { get; set; }
        public string FUNCICEF_NOME_FUNCIONARIO { get; set; }

        public static R0500_00_LE_MAT_FUNC_DB_SELECT_1_Query1 Execute(R0500_00_LE_MAT_FUNC_DB_SELECT_1_Query1 r0500_00_LE_MAT_FUNC_DB_SELECT_1_Query1)
        {
            var ths = r0500_00_LE_MAT_FUNC_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0500_00_LE_MAT_FUNC_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0500_00_LE_MAT_FUNC_DB_SELECT_1_Query1();
            var i = 0;
            dta.FUNCICEF_NUM_MATRICULA = result[i++].Value?.ToString();
            dta.FUNCICEF_NOME_FUNCIONARIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}