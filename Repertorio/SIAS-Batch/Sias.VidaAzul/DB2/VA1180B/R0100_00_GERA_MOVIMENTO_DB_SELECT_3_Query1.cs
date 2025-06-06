using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1180B
{
    public class R0100_00_GERA_MOVIMENTO_DB_SELECT_3_Query1 : QueryBasis<R0100_00_GERA_MOVIMENTO_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*), 0)
            INTO :MOVFEDCA-QUANT-TIT-CAPITALI
            FROM SEGUROS.MOVIMEN_FED_CAP_VA
            WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							, 0)
											FROM SEGUROS.MOVIMEN_FED_CAP_VA
											WHERE NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'";

            return query;
        }
        public string MOVFEDCA_QUANT_TIT_CAPITALI { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static R0100_00_GERA_MOVIMENTO_DB_SELECT_3_Query1 Execute(R0100_00_GERA_MOVIMENTO_DB_SELECT_3_Query1 r0100_00_GERA_MOVIMENTO_DB_SELECT_3_Query1)
        {
            var ths = r0100_00_GERA_MOVIMENTO_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0100_00_GERA_MOVIMENTO_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0100_00_GERA_MOVIMENTO_DB_SELECT_3_Query1();
            var i = 0;
            dta.MOVFEDCA_QUANT_TIT_CAPITALI = result[i++].Value?.ToString();
            return dta;
        }

    }
}