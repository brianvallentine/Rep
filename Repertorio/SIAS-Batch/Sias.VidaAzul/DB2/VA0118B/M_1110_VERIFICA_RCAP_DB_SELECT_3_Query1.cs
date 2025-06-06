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
    public class M_1110_VERIFICA_RCAP_DB_SELECT_3_Query1 : QueryBasis<M_1110_VERIFICA_RCAP_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT BCOAVISO ,
            AGEAVISO ,
            NRAVISO ,
            DATARCAP
            INTO :V1RCAC-BCOAVISO ,
            :V1RCAC-AGEAVISO ,
            :V1RCAC-NRAVISO ,
            :V1RCAC-DATARCAP
            FROM SEGUROS.V1RCAPCOMP
            WHERE FONTE = :V0RCAP-FONTE
            AND NRRCAP = :V0RCAP-NRRCAP
            AND NRRCAPCO = 0
            AND OPERACAO >= 100
            AND OPERACAO <= 199
            AND SITUACAO = '0'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT BCOAVISO 
							,
											AGEAVISO 
							,
											NRAVISO 
							,
											DATARCAP
											FROM SEGUROS.V1RCAPCOMP
											WHERE FONTE = '{this.V0RCAP_FONTE}'
											AND NRRCAP = '{this.V0RCAP_NRRCAP}'
											AND NRRCAPCO = 0
											AND OPERACAO >= 100
											AND OPERACAO <= 199
											AND SITUACAO = '0'";

            return query;
        }
        public string V1RCAC_BCOAVISO { get; set; }
        public string V1RCAC_AGEAVISO { get; set; }
        public string V1RCAC_NRAVISO { get; set; }
        public string V1RCAC_DATARCAP { get; set; }
        public string V0RCAP_NRRCAP { get; set; }
        public string V0RCAP_FONTE { get; set; }

        public static M_1110_VERIFICA_RCAP_DB_SELECT_3_Query1 Execute(M_1110_VERIFICA_RCAP_DB_SELECT_3_Query1 m_1110_VERIFICA_RCAP_DB_SELECT_3_Query1)
        {
            var ths = m_1110_VERIFICA_RCAP_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1110_VERIFICA_RCAP_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1110_VERIFICA_RCAP_DB_SELECT_3_Query1();
            var i = 0;
            dta.V1RCAC_BCOAVISO = result[i++].Value?.ToString();
            dta.V1RCAC_AGEAVISO = result[i++].Value?.ToString();
            dta.V1RCAC_NRAVISO = result[i++].Value?.ToString();
            dta.V1RCAC_DATARCAP = result[i++].Value?.ToString();
            return dta;
        }

    }
}