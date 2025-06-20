using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA6005B
{
    public class R3000_00_ACUMULA_BILHETE_DB_SELECT_1_Query1 : QueryBasis<R3000_00_ACUMULA_BILHETE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT FONTE,
            NRRCAP,
            VLRCAP,
            SITUACAO,
            OPERACAO
            INTO :V0RCAP-FONTE,
            :V0RCAP-NRRCAP,
            :V2RCAP-VLRCAP,
            :V0RCAP-SITUACAO,
            :V0RCAP-OPERACAO
            FROM SEGUROS.V0RCAP
            WHERE NRTIT = :V0RCAP-NRTIT
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT FONTE
							,
											NRRCAP
							,
											VLRCAP
							,
											SITUACAO
							,
											OPERACAO
											FROM SEGUROS.V0RCAP
											WHERE NRTIT = '{this.V0RCAP_NRTIT}'";

            return query;
        }
        public string V0RCAP_FONTE { get; set; }
        public string V0RCAP_NRRCAP { get; set; }
        public string V2RCAP_VLRCAP { get; set; }
        public string V0RCAP_SITUACAO { get; set; }
        public string V0RCAP_OPERACAO { get; set; }
        public string V0RCAP_NRTIT { get; set; }

        public static R3000_00_ACUMULA_BILHETE_DB_SELECT_1_Query1 Execute(R3000_00_ACUMULA_BILHETE_DB_SELECT_1_Query1 r3000_00_ACUMULA_BILHETE_DB_SELECT_1_Query1)
        {
            var ths = r3000_00_ACUMULA_BILHETE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3000_00_ACUMULA_BILHETE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3000_00_ACUMULA_BILHETE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0RCAP_FONTE = result[i++].Value?.ToString();
            dta.V0RCAP_NRRCAP = result[i++].Value?.ToString();
            dta.V2RCAP_VLRCAP = result[i++].Value?.ToString();
            dta.V0RCAP_SITUACAO = result[i++].Value?.ToString();
            dta.V0RCAP_OPERACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}