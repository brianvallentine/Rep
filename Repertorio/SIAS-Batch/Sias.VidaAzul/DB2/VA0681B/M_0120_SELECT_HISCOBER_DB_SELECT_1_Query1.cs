using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0681B
{
    public class M_0120_SELECT_HISCOBER_DB_SELECT_1_Query1 : QueryBasis<M_0120_SELECT_HISCOBER_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VLPREMIO
            INTO :HISCOBPR-VLPREMIO
            FROM SEGUROS.HIS_COBER_PROPOST
            WHERE NUM_CERTIFICADO = :HISCOBPR-NUM-CERTIFICADO
            AND DATA_TERVIGENCIA = '9999-12-31'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VLPREMIO
											FROM SEGUROS.HIS_COBER_PROPOST
											WHERE NUM_CERTIFICADO = '{this.HISCOBPR_NUM_CERTIFICADO}'
											AND DATA_TERVIGENCIA = '9999-12-31'";

            return query;
        }
        public string HISCOBPR_VLPREMIO { get; set; }
        public string HISCOBPR_NUM_CERTIFICADO { get; set; }

        public static M_0120_SELECT_HISCOBER_DB_SELECT_1_Query1 Execute(M_0120_SELECT_HISCOBER_DB_SELECT_1_Query1 m_0120_SELECT_HISCOBER_DB_SELECT_1_Query1)
        {
            var ths = m_0120_SELECT_HISCOBER_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0120_SELECT_HISCOBER_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0120_SELECT_HISCOBER_DB_SELECT_1_Query1();
            var i = 0;
            dta.HISCOBPR_VLPREMIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}