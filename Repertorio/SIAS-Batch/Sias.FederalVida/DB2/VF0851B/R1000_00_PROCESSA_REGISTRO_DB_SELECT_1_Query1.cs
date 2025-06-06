using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0851B
{
    public class R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 : QueryBasis<R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PERIPGTO,
            OPCAOPAG,
            AGECTADEB,
            OPRCTADEB,
            NUMCTADEB,
            DIGCTADEB
            INTO :V0OPCP-PERIPGTO,
            :V0OPCP-OPCAOPAG,
            :V0OPCP-AGECTADEB:V0OPCP-IAGECTADEB,
            :V0OPCP-OPRCTADEB:V0OPCP-IOPRCTADEB,
            :V0OPCP-NUMCTADEB:V0OPCP-INUMCTADEB,
            :V0OPCP-DIGCTADEB:V0OPCP-IDIGCTADEB
            FROM SEGUROS.V0OPCAOPAGVA
            WHERE NRCERTIF = :V0PROP-NRCERTIF
            AND DTTERVIG = '9999-12-31'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PERIPGTO
							,
											OPCAOPAG
							,
											AGECTADEB
							,
											OPRCTADEB
							,
											NUMCTADEB
							,
											DIGCTADEB
											FROM SEGUROS.V0OPCAOPAGVA
											WHERE NRCERTIF = '{this.V0PROP_NRCERTIF}'
											AND DTTERVIG = '9999-12-31'";

            return query;
        }
        public string V0OPCP_PERIPGTO { get; set; }
        public string V0OPCP_OPCAOPAG { get; set; }
        public string V0OPCP_AGECTADEB { get; set; }
        public string V0OPCP_IAGECTADEB { get; set; }
        public string V0OPCP_OPRCTADEB { get; set; }
        public string V0OPCP_IOPRCTADEB { get; set; }
        public string V0OPCP_NUMCTADEB { get; set; }
        public string V0OPCP_INUMCTADEB { get; set; }
        public string V0OPCP_DIGCTADEB { get; set; }
        public string V0OPCP_IDIGCTADEB { get; set; }
        public string V0PROP_NRCERTIF { get; set; }

        public static R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 Execute(R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 r1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1)
        {
            var ths = r1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0OPCP_PERIPGTO = result[i++].Value?.ToString();
            dta.V0OPCP_OPCAOPAG = result[i++].Value?.ToString();
            dta.V0OPCP_AGECTADEB = result[i++].Value?.ToString();
            dta.V0OPCP_IAGECTADEB = string.IsNullOrWhiteSpace(dta.V0OPCP_AGECTADEB) ? "-1" : "0";
            dta.V0OPCP_OPRCTADEB = result[i++].Value?.ToString();
            dta.V0OPCP_IOPRCTADEB = string.IsNullOrWhiteSpace(dta.V0OPCP_OPRCTADEB) ? "-1" : "0";
            dta.V0OPCP_NUMCTADEB = result[i++].Value?.ToString();
            dta.V0OPCP_INUMCTADEB = string.IsNullOrWhiteSpace(dta.V0OPCP_NUMCTADEB) ? "-1" : "0";
            dta.V0OPCP_DIGCTADEB = result[i++].Value?.ToString();
            dta.V0OPCP_IDIGCTADEB = string.IsNullOrWhiteSpace(dta.V0OPCP_DIGCTADEB) ? "-1" : "0";
            return dta;
        }

    }
}