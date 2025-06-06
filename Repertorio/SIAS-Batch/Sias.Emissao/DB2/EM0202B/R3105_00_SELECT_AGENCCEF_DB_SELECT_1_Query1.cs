using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0202B
{
    public class R3105_00_SELECT_AGENCCEF_DB_SELECT_1_Query1 : QueryBasis<R3105_00_SELECT_AGENCCEF_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.COD_ESCNEG ,
            B.COD_FONTE
            INTO :AGENCCEF-COD-ESCNEG ,
            :MALHACEF-COD-FONTE
            FROM SEGUROS.AGENCIAS_CEF A ,
            SEGUROS.MALHA_CEF B
            WHERE A.COD_AGENCIA = :V1HIST-AGECOBR
            AND A.COD_SUREG = B.COD_SUREG
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.COD_ESCNEG 
							,
											B.COD_FONTE
											FROM SEGUROS.AGENCIAS_CEF A 
							,
											SEGUROS.MALHA_CEF B
											WHERE A.COD_AGENCIA = '{this.V1HIST_AGECOBR}'
											AND A.COD_SUREG = B.COD_SUREG";

            return query;
        }
        public string AGENCCEF_COD_ESCNEG { get; set; }
        public string MALHACEF_COD_FONTE { get; set; }
        public string V1HIST_AGECOBR { get; set; }

        public static R3105_00_SELECT_AGENCCEF_DB_SELECT_1_Query1 Execute(R3105_00_SELECT_AGENCCEF_DB_SELECT_1_Query1 r3105_00_SELECT_AGENCCEF_DB_SELECT_1_Query1)
        {
            var ths = r3105_00_SELECT_AGENCCEF_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3105_00_SELECT_AGENCCEF_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3105_00_SELECT_AGENCCEF_DB_SELECT_1_Query1();
            var i = 0;
            dta.AGENCCEF_COD_ESCNEG = result[i++].Value?.ToString();
            dta.MALHACEF_COD_FONTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}