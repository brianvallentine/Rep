using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class DB138_ACESSA_BANCOS_DB_SELECT_1_Query1 : QueryBasis<DB138_ACESSA_BANCOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_TITULO
            INTO :BANCOS-NUM-TITULO
            FROM SEGUROS.BANCOS
            WHERE COD_BANCO = 104
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NUM_TITULO
											FROM SEGUROS.BANCOS
											WHERE COD_BANCO = 104";

            return query;
        }
        public string BANCOS_NUM_TITULO { get; set; }

        public static DB138_ACESSA_BANCOS_DB_SELECT_1_Query1 Execute(DB138_ACESSA_BANCOS_DB_SELECT_1_Query1 dB138_ACESSA_BANCOS_DB_SELECT_1_Query1)
        {
            var ths = dB138_ACESSA_BANCOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override DB138_ACESSA_BANCOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new DB138_ACESSA_BANCOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.BANCOS_NUM_TITULO = result[i++].Value?.ToString();
            return dta;
        }

    }
}