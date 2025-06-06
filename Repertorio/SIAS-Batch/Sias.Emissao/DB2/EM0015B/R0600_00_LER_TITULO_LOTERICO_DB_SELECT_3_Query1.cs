using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0015B
{
    public class R0600_00_LER_TITULO_LOTERICO_DB_SELECT_3_Query1 : QueryBasis<R0600_00_LER_TITULO_LOTERICO_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VLRCAP ,
            VALUE(SITUACAO, ' ' )
            INTO :RCAPS-VAL-RCAP ,
            :RCAPS-SIT-REGISTRO
            FROM SEGUROS.V0RCAP
            WHERE NRTIT = :RCAPS-NUM-TITULO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VLRCAP 
							,
											VALUE(SITUACAO
							, ' ' )
											FROM SEGUROS.V0RCAP
											WHERE NRTIT = '{this.RCAPS_NUM_TITULO}'";

            return query;
        }
        public string RCAPS_VAL_RCAP { get; set; }
        public string RCAPS_SIT_REGISTRO { get; set; }
        public string RCAPS_NUM_TITULO { get; set; }

        public static R0600_00_LER_TITULO_LOTERICO_DB_SELECT_3_Query1 Execute(R0600_00_LER_TITULO_LOTERICO_DB_SELECT_3_Query1 r0600_00_LER_TITULO_LOTERICO_DB_SELECT_3_Query1)
        {
            var ths = r0600_00_LER_TITULO_LOTERICO_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0600_00_LER_TITULO_LOTERICO_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0600_00_LER_TITULO_LOTERICO_DB_SELECT_3_Query1();
            var i = 0;
            dta.RCAPS_VAL_RCAP = result[i++].Value?.ToString();
            dta.RCAPS_SIT_REGISTRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}