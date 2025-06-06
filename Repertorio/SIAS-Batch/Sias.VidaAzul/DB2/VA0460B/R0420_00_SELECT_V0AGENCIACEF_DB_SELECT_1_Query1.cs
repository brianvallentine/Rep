using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0460B
{
    public class R0420_00_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1 : QueryBasis<R0420_00_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.COD_AGENCIA ,
            A.COD_ESCNEG ,
            B.COD_FONTE
            INTO :AGENCCEF-COD-AGENCIA ,
            :AGENCCEF-COD-ESCNEG ,
            :MALHACEF-COD-FONTE
            FROM SEGUROS.AGENCIAS_CEF A,
            SEGUROS.MALHA_CEF B
            WHERE A.COD_AGENCIA = :AGENCCEF-COD-AGENCIA
            AND A.COD_SUREG = B.COD_SUREG
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.COD_AGENCIA 
							,
											A.COD_ESCNEG 
							,
											B.COD_FONTE
											FROM SEGUROS.AGENCIAS_CEF A
							,
											SEGUROS.MALHA_CEF B
											WHERE A.COD_AGENCIA = '{this.AGENCCEF_COD_AGENCIA}'
											AND A.COD_SUREG = B.COD_SUREG";

            return query;
        }
        public string AGENCCEF_COD_AGENCIA { get; set; }
        public string AGENCCEF_COD_ESCNEG { get; set; }
        public string MALHACEF_COD_FONTE { get; set; }

        public static R0420_00_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1 Execute(R0420_00_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1 r0420_00_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1)
        {
            var ths = r0420_00_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0420_00_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0420_00_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1();
            var i = 0;
            dta.AGENCCEF_COD_AGENCIA = result[i++].Value?.ToString();
            dta.AGENCCEF_COD_ESCNEG = result[i++].Value?.ToString();
            dta.MALHACEF_COD_FONTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}