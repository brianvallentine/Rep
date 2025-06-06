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
    public class R0460_00_SELECT_V0RCAP_DB_SELECT_1_Query1 : QueryBasis<R0460_00_SELECT_V0RCAP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.VLRCAP ,
            A.VALPRI ,
            A.SITUACAO ,
            A.AGECOBR ,
            B.FONTE ,
            B.NRRCAP ,
            B.BCOAVISO ,
            B.AGEAVISO ,
            B.NRAVISO ,
            B.VLRCAP ,
            B.DATARCAP ,
            B.DTCADAST ,
            B.DTMOVTO ,
            B.SITCONTB
            INTO :V0RCAP-VLRCAP ,
            :V0RCAP-VALPRI ,
            :V0RCAP-SITUACAO ,
            :V0RCAP-AGECOBR:VIND-AGECOBR ,
            :V0RCOM-FONTE ,
            :V0RCOM-NRRCAP ,
            :V0RCOM-BCOAVISO ,
            :V0RCOM-AGEAVISO ,
            :V0RCOM-NRAVISO ,
            :V0RCOM-VLRCAP ,
            :V0RCOM-DATARCAP ,
            :V0RCOM-DTCADAST ,
            :V0RCOM-DTMOVTO ,
            :V0RCOM-SITCONTB
            FROM SEGUROS.V0RCAP A,
            SEGUROS.V0RCAPCOMP B
            WHERE A.NRRCAP = :V0RCAP-NRRCAP
            AND A.FONTE = :V0BILH-FONTE
            AND B.FONTE = A.FONTE
            AND B.NRRCAP = A.NRRCAP
            AND B.NRRCAPCO = 0
            AND B.SITUACAO = '0'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.VLRCAP 
							,
											A.VALPRI 
							,
											A.SITUACAO 
							,
											A.AGECOBR 
							,
											B.FONTE 
							,
											B.NRRCAP 
							,
											B.BCOAVISO 
							,
											B.AGEAVISO 
							,
											B.NRAVISO 
							,
											B.VLRCAP 
							,
											B.DATARCAP 
							,
											B.DTCADAST 
							,
											B.DTMOVTO 
							,
											B.SITCONTB
											FROM SEGUROS.V0RCAP A
							,
											SEGUROS.V0RCAPCOMP B
											WHERE A.NRRCAP = '{this.V0RCAP_NRRCAP}'
											AND A.FONTE = '{this.V0BILH_FONTE}'
											AND B.FONTE = A.FONTE
											AND B.NRRCAP = A.NRRCAP
											AND B.NRRCAPCO = 0
											AND B.SITUACAO = '0'";

            return query;
        }
        public string V0RCAP_VLRCAP { get; set; }
        public string V0RCAP_VALPRI { get; set; }
        public string V0RCAP_SITUACAO { get; set; }
        public string V0RCAP_AGECOBR { get; set; }
        public string VIND_AGECOBR { get; set; }
        public string V0RCOM_FONTE { get; set; }
        public string V0RCOM_NRRCAP { get; set; }
        public string V0RCOM_BCOAVISO { get; set; }
        public string V0RCOM_AGEAVISO { get; set; }
        public string V0RCOM_NRAVISO { get; set; }
        public string V0RCOM_VLRCAP { get; set; }
        public string V0RCOM_DATARCAP { get; set; }
        public string V0RCOM_DTCADAST { get; set; }
        public string V0RCOM_DTMOVTO { get; set; }
        public string V0RCOM_SITCONTB { get; set; }
        public string V0RCAP_NRRCAP { get; set; }
        public string V0BILH_FONTE { get; set; }

        public static R0460_00_SELECT_V0RCAP_DB_SELECT_1_Query1 Execute(R0460_00_SELECT_V0RCAP_DB_SELECT_1_Query1 r0460_00_SELECT_V0RCAP_DB_SELECT_1_Query1)
        {
            var ths = r0460_00_SELECT_V0RCAP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0460_00_SELECT_V0RCAP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0460_00_SELECT_V0RCAP_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0RCAP_VLRCAP = result[i++].Value?.ToString();
            dta.V0RCAP_VALPRI = result[i++].Value?.ToString();
            dta.V0RCAP_SITUACAO = result[i++].Value?.ToString();
            dta.V0RCAP_AGECOBR = result[i++].Value?.ToString();
            dta.VIND_AGECOBR = string.IsNullOrWhiteSpace(dta.V0RCAP_AGECOBR) ? "-1" : "0";
            dta.V0RCOM_FONTE = result[i++].Value?.ToString();
            dta.V0RCOM_NRRCAP = result[i++].Value?.ToString();
            dta.V0RCOM_BCOAVISO = result[i++].Value?.ToString();
            dta.V0RCOM_AGEAVISO = result[i++].Value?.ToString();
            dta.V0RCOM_NRAVISO = result[i++].Value?.ToString();
            dta.V0RCOM_VLRCAP = result[i++].Value?.ToString();
            dta.V0RCOM_DATARCAP = result[i++].Value?.ToString();
            dta.V0RCOM_DTCADAST = result[i++].Value?.ToString();
            dta.V0RCOM_DTMOVTO = result[i++].Value?.ToString();
            dta.V0RCOM_SITCONTB = result[i++].Value?.ToString();
            return dta;
        }

    }
}