using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0004B
{
    public class R0800_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1 : QueryBasis<R0800_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_EMPRESA ,
            CONGENER ,
            DTMOVTO_AC
            INTO :V0CCHQ-COD-EMPR,
            :V0CCHQ-CONGENER,
            :V0CCHQ-DTMOVTO-AC
            FROM SEGUROS.V0COSCED_CHEQUE
            WHERE COD_EMPRESA = :V0RELA-COD-EMPR
            AND CONGENER = :V0RELA-CONGENER
            AND DTMOVTO_AC = :V0RELA-PERI-INICIAL
            AND DTMOVTO_FI = :V0RELA-PERI-FINAL
            AND SITUACAO = '2'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_EMPRESA 
							,
											CONGENER 
							,
											DTMOVTO_AC
											FROM SEGUROS.V0COSCED_CHEQUE
											WHERE COD_EMPRESA = '{this.V0RELA_COD_EMPR}'
											AND CONGENER = '{this.V0RELA_CONGENER}'
											AND DTMOVTO_AC = '{this.V0RELA_PERI_INICIAL}'
											AND DTMOVTO_FI = '{this.V0RELA_PERI_FINAL}'
											AND SITUACAO = '2'";

            return query;
        }
        public string V0CCHQ_COD_EMPR { get; set; }
        public string V0CCHQ_CONGENER { get; set; }
        public string V0CCHQ_DTMOVTO_AC { get; set; }
        public string V0RELA_PERI_INICIAL { get; set; }
        public string V0RELA_PERI_FINAL { get; set; }
        public string V0RELA_COD_EMPR { get; set; }
        public string V0RELA_CONGENER { get; set; }

        public static R0800_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1 Execute(R0800_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1 r0800_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1)
        {
            var ths = r0800_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0800_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0800_00_SELECT_COSCED_CHEQUE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0CCHQ_COD_EMPR = result[i++].Value?.ToString();
            dta.V0CCHQ_CONGENER = result[i++].Value?.ToString();
            dta.V0CCHQ_DTMOVTO_AC = result[i++].Value?.ToString();
            return dta;
        }

    }
}