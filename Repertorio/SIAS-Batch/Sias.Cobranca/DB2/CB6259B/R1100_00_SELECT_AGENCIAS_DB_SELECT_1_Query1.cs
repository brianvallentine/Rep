using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB6259B
{
    public class R1100_00_SELECT_AGENCIAS_DB_SELECT_1_Query1 : QueryBasis<R1100_00_SELECT_AGENCIAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT B.COD_FONTE
            INTO :MALHACEF-COD-FONTE
            FROM SEGUROS.AGENCIAS_CEF A,
            SEGUROS.MALHA_CEF B
            WHERE A.COD_AGENCIA = :AGENCCEF-COD-AGENCIA
            AND A.COD_SUREG = B.COD_SUREG
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT B.COD_FONTE
											FROM SEGUROS.AGENCIAS_CEF A
							,
											SEGUROS.MALHA_CEF B
											WHERE A.COD_AGENCIA = '{this.AGENCCEF_COD_AGENCIA}'
											AND A.COD_SUREG = B.COD_SUREG
											WITH UR";

            return query;
        }
        public string MALHACEF_COD_FONTE { get; set; }
        public string AGENCCEF_COD_AGENCIA { get; set; }

        public static R1100_00_SELECT_AGENCIAS_DB_SELECT_1_Query1 Execute(R1100_00_SELECT_AGENCIAS_DB_SELECT_1_Query1 r1100_00_SELECT_AGENCIAS_DB_SELECT_1_Query1)
        {
            var ths = r1100_00_SELECT_AGENCIAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_00_SELECT_AGENCIAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_00_SELECT_AGENCIAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.MALHACEF_COD_FONTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}