using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0009B
{
    public class R7165_00_SELECT_FAIXA_RCAP_DB_SELECT_1_Query1 : QueryBasis<R7165_00_SELECT_FAIXA_RCAP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_RAMO
            INTO :BILFAI-RAMO
            FROM SEGUROS.BILHETE_FAIXA
            WHERE NUMBIL_INI <= :V0BILH-NUMBIL
            AND NUMBIL_FIM >= :V0BILH-NUMBIL
            AND COD_RAMO IN (72,82)
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_RAMO
											FROM SEGUROS.BILHETE_FAIXA
											WHERE NUMBIL_INI <= '{this.V0BILH_NUMBIL}'
											AND NUMBIL_FIM >= '{this.V0BILH_NUMBIL}'
											AND COD_RAMO IN (72
							,82)";

            return query;
        }
        public string BILFAI_RAMO { get; set; }
        public string V0BILH_NUMBIL { get; set; }

        public static R7165_00_SELECT_FAIXA_RCAP_DB_SELECT_1_Query1 Execute(R7165_00_SELECT_FAIXA_RCAP_DB_SELECT_1_Query1 r7165_00_SELECT_FAIXA_RCAP_DB_SELECT_1_Query1)
        {
            var ths = r7165_00_SELECT_FAIXA_RCAP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R7165_00_SELECT_FAIXA_RCAP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R7165_00_SELECT_FAIXA_RCAP_DB_SELECT_1_Query1();
            var i = 0;
            dta.BILFAI_RAMO = result[i++].Value?.ToString();
            return dta;
        }

    }
}