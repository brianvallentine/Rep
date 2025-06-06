using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0118B
{
    public class M_0284_00_SOMA_IS_DB_SELECT_1_Query1 : QueryBasis<M_0284_00_SOMA_IS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IMP_MORNATU
            INTO :HISCOBPR-IMP-MORNATU
            FROM SEGUROS.HIS_COBER_PROPOST
            WHERE NUM_CERTIFICADO = :WS-NUM-CERTIFICADO-RISCO
            AND DATA_TERVIGENCIA = '9999-12-31'
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT IMP_MORNATU
											FROM SEGUROS.HIS_COBER_PROPOST
											WHERE NUM_CERTIFICADO = '{this.WS_NUM_CERTIFICADO_RISCO}'
											AND DATA_TERVIGENCIA = '9999-12-31'
											WITH UR";

            return query;
        }
        public string HISCOBPR_IMP_MORNATU { get; set; }
        public string WS_NUM_CERTIFICADO_RISCO { get; set; }

        public static M_0284_00_SOMA_IS_DB_SELECT_1_Query1 Execute(M_0284_00_SOMA_IS_DB_SELECT_1_Query1 m_0284_00_SOMA_IS_DB_SELECT_1_Query1)
        {
            var ths = m_0284_00_SOMA_IS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0284_00_SOMA_IS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0284_00_SOMA_IS_DB_SELECT_1_Query1();
            var i = 0;
            dta.HISCOBPR_IMP_MORNATU = result[i++].Value?.ToString();
            return dta;
        }

    }
}