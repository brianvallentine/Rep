using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0414B
{
    public class R1500_00_SELECT_V1AGENCEF_DB_SELECT_1_Query1 : QueryBasis<R1500_00_SELECT_V1AGENCEF_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.NOME_AGENCIA,
            B.COD_FONTE
            INTO :DCLAGENCIAS-CEF.AGENCCEF-NOME-AGENCIA,
            :DCLMALHA-CEF.MALHACEF-COD-FONTE
            FROM SEGUROS.AGENCIAS_CEF A,
            SEGUROS.MALHA_CEF B
            WHERE A.COD_ESCNEG > 99
            AND A.COD_ESCNEG = B.COD_SUREG
            AND A.COD_AGENCIA =
            :DCLAGENCIAS-CEF.AGENCCEF-COD-AGENCIA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.NOME_AGENCIA
							,
											B.COD_FONTE
											FROM SEGUROS.AGENCIAS_CEF A
							,
											SEGUROS.MALHA_CEF B
											WHERE A.COD_ESCNEG > 99
											AND A.COD_ESCNEG = B.COD_SUREG
											AND A.COD_AGENCIA =
											'{this.AGENCCEF_COD_AGENCIA}'";

            return query;
        }
        public string AGENCCEF_NOME_AGENCIA { get; set; }
        public string MALHACEF_COD_FONTE { get; set; }
        public string AGENCCEF_COD_AGENCIA { get; set; }

        public static R1500_00_SELECT_V1AGENCEF_DB_SELECT_1_Query1 Execute(R1500_00_SELECT_V1AGENCEF_DB_SELECT_1_Query1 r1500_00_SELECT_V1AGENCEF_DB_SELECT_1_Query1)
        {
            var ths = r1500_00_SELECT_V1AGENCEF_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1500_00_SELECT_V1AGENCEF_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1500_00_SELECT_V1AGENCEF_DB_SELECT_1_Query1();
            var i = 0;
            dta.AGENCCEF_NOME_AGENCIA = result[i++].Value?.ToString();
            dta.MALHACEF_COD_FONTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}