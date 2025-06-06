using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0815B
{
    public class R1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1 : QueryBasis<R1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT MAX(DTLIBERA)
            INTO :V1CCHQ-DTLIBERA:VIND-DTLIBERA
            FROM SEGUROS.V0COSCED_CHEQUE
            WHERE COD_EMPRESA = :V1RELA-COD-EMPR
            AND CONGENER = :V1RELA-CONGENER
            AND DTMOVTO_AC < :V1SIST-DTMOVABE
            AND SITUACAO <> '2'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT MAX(DTLIBERA)
											FROM SEGUROS.V0COSCED_CHEQUE
											WHERE COD_EMPRESA = '{this.V1RELA_COD_EMPR}'
											AND CONGENER = '{this.V1RELA_CONGENER}'
											AND DTMOVTO_AC < '{this.V1SIST_DTMOVABE}'
											AND SITUACAO <> '2'";

            return query;
        }
        public string V1CCHQ_DTLIBERA { get; set; }
        public string VIND_DTLIBERA { get; set; }
        public string V1RELA_COD_EMPR { get; set; }
        public string V1RELA_CONGENER { get; set; }
        public string V1SIST_DTMOVABE { get; set; }

        public static R1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1 Execute(R1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1 r1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1)
        {
            var ths = r1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1CCHQ_DTLIBERA = result[i++].Value?.ToString();
            dta.VIND_DTLIBERA = string.IsNullOrWhiteSpace(dta.V1CCHQ_DTLIBERA) ? "-1" : "0";
            return dta;
        }

    }
}