using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0601B
{
    public class R2100_00_LE_FUNCEF_DB_SELECT_1_Query1 : QueryBasis<R2100_00_LE_FUNCEF_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_FUNCIONARIO
            INTO :FUNCICEF-NOME-FUNCIONARIO
            FROM SEGUROS.FUNCIONARIOS_CEF
            WHERE NUM_MATRICULA =
            :PROPOVA-NUM-MATRI-VENDEDOR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_FUNCIONARIO
											FROM SEGUROS.FUNCIONARIOS_CEF
											WHERE NUM_MATRICULA =
											'{this.PROPOVA_NUM_MATRI_VENDEDOR}'";

            return query;
        }
        public string FUNCICEF_NOME_FUNCIONARIO { get; set; }
        public string PROPOVA_NUM_MATRI_VENDEDOR { get; set; }

        public static R2100_00_LE_FUNCEF_DB_SELECT_1_Query1 Execute(R2100_00_LE_FUNCEF_DB_SELECT_1_Query1 r2100_00_LE_FUNCEF_DB_SELECT_1_Query1)
        {
            var ths = r2100_00_LE_FUNCEF_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2100_00_LE_FUNCEF_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2100_00_LE_FUNCEF_DB_SELECT_1_Query1();
            var i = 0;
            dta.FUNCICEF_NOME_FUNCIONARIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}