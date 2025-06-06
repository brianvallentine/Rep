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
    public class R0455_00_SELECT_V0FOLLOWUP_DB_SELECT_1_Query1 : QueryBasis<R0455_00_SELECT_V0FOLLOWUP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VLPREMIO ,
            BCOAVISO ,
            AGEAVISO ,
            NRAVISO ,
            DTQITBCO ,
            SITUACAO
            INTO :V0FOLL-VLPREMIO ,
            :V0FOLL-BCOAVISO ,
            :V0FOLL-AGEAVISO ,
            :V0FOLL-NRAVISO ,
            :V0FOLL-DTQITBCO ,
            :V0FOLL-SITUACAO
            FROM SEGUROS.V0FOLLOWUP
            WHERE NUM_APOLICE = :V0FOLL-NUMAPOL
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VLPREMIO 
							,
											BCOAVISO 
							,
											AGEAVISO 
							,
											NRAVISO 
							,
											DTQITBCO 
							,
											SITUACAO
											FROM SEGUROS.V0FOLLOWUP
											WHERE NUM_APOLICE = '{this.V0FOLL_NUMAPOL}'";

            return query;
        }
        public string V0FOLL_VLPREMIO { get; set; }
        public string V0FOLL_BCOAVISO { get; set; }
        public string V0FOLL_AGEAVISO { get; set; }
        public string V0FOLL_NRAVISO { get; set; }
        public string V0FOLL_DTQITBCO { get; set; }
        public string V0FOLL_SITUACAO { get; set; }
        public string V0FOLL_NUMAPOL { get; set; }

        public static R0455_00_SELECT_V0FOLLOWUP_DB_SELECT_1_Query1 Execute(R0455_00_SELECT_V0FOLLOWUP_DB_SELECT_1_Query1 r0455_00_SELECT_V0FOLLOWUP_DB_SELECT_1_Query1)
        {
            var ths = r0455_00_SELECT_V0FOLLOWUP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0455_00_SELECT_V0FOLLOWUP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0455_00_SELECT_V0FOLLOWUP_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0FOLL_VLPREMIO = result[i++].Value?.ToString();
            dta.V0FOLL_BCOAVISO = result[i++].Value?.ToString();
            dta.V0FOLL_AGEAVISO = result[i++].Value?.ToString();
            dta.V0FOLL_NRAVISO = result[i++].Value?.ToString();
            dta.V0FOLL_DTQITBCO = result[i++].Value?.ToString();
            dta.V0FOLL_SITUACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}