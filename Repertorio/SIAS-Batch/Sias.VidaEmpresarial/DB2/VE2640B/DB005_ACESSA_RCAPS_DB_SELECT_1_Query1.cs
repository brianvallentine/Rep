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
    public class DB005_ACESSA_RCAPS_DB_SELECT_1_Query1 : QueryBasis<DB005_ACESSA_RCAPS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_TITULO
            INTO :RCAPS-NUM-TITULO
            FROM SEGUROS.RCAPS
            WHERE NUM_CERTIFICADO = :RCAPS-NUM-CERTIFICADO
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NUM_TITULO
											FROM SEGUROS.RCAPS
											WHERE NUM_CERTIFICADO = '{this.RCAPS_NUM_CERTIFICADO}'";

            return query;
        }
        public string RCAPS_NUM_TITULO { get; set; }
        public string RCAPS_NUM_CERTIFICADO { get; set; }

        public static DB005_ACESSA_RCAPS_DB_SELECT_1_Query1 Execute(DB005_ACESSA_RCAPS_DB_SELECT_1_Query1 dB005_ACESSA_RCAPS_DB_SELECT_1_Query1)
        {
            var ths = dB005_ACESSA_RCAPS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override DB005_ACESSA_RCAPS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new DB005_ACESSA_RCAPS_DB_SELECT_1_Query1();
            var i = 0;
            dta.RCAPS_NUM_TITULO = result[i++].Value?.ToString();
            return dta;
        }

    }
}