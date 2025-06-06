using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0133B
{
    public class M_360_200_ACESSA_PRODUTOR_DB_SELECT_1_Query1 : QueryBasis<M_360_200_ACESSA_PRODUTOR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOMPDT
            INTO :PROD-NOMPDT
            FROM SEGUROS.V1PRODUTOR
            WHERE CODPDT = :APDCORR-CODCORR
            AND FONTE = :ENDOS-FONTE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOMPDT
											FROM SEGUROS.V1PRODUTOR
											WHERE CODPDT = '{this.APDCORR_CODCORR}'
											AND FONTE = '{this.ENDOS_FONTE}'";

            return query;
        }
        public string PROD_NOMPDT { get; set; }
        public string APDCORR_CODCORR { get; set; }
        public string ENDOS_FONTE { get; set; }

        public static M_360_200_ACESSA_PRODUTOR_DB_SELECT_1_Query1 Execute(M_360_200_ACESSA_PRODUTOR_DB_SELECT_1_Query1 m_360_200_ACESSA_PRODUTOR_DB_SELECT_1_Query1)
        {
            var ths = m_360_200_ACESSA_PRODUTOR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_360_200_ACESSA_PRODUTOR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_360_200_ACESSA_PRODUTOR_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROD_NOMPDT = result[i++].Value?.ToString();
            return dta;
        }

    }
}