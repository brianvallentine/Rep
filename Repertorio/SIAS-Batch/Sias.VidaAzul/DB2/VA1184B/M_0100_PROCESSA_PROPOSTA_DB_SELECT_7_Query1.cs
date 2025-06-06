using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1184B
{
    public class M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1 : QueryBasis<M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PERIPGTO,
            AGECTADEB,
            OPRCTADEB,
            NUMCTADEB,
            DIGCTADEB
            INTO :OPCAOP-PERIPGTO,
            :OPCAOP-AGECTADEB:INDAGE,
            :OPCAOP-OPRCTADEB:INDOPR,
            :OPCAOP-NUMCTADEB:INDNUM,
            :OPCAOP-DIGCTADEB:INDDIG
            FROM SEGUROS.V0OPCAOPAGVA
            WHERE NRCERTIF = :RELATO-NRCERTIF
            AND DTTERVIG = '9999-12-31'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PERIPGTO
							,
											AGECTADEB
							,
											OPRCTADEB
							,
											NUMCTADEB
							,
											DIGCTADEB
											FROM SEGUROS.V0OPCAOPAGVA
											WHERE NRCERTIF = '{this.RELATO_NRCERTIF}'
											AND DTTERVIG = '9999-12-31'";

            return query;
        }
        public string OPCAOP_PERIPGTO { get; set; }
        public string OPCAOP_AGECTADEB { get; set; }
        public string INDAGE { get; set; }
        public string OPCAOP_OPRCTADEB { get; set; }
        public string INDOPR { get; set; }
        public string OPCAOP_NUMCTADEB { get; set; }
        public string INDNUM { get; set; }
        public string OPCAOP_DIGCTADEB { get; set; }
        public string INDDIG { get; set; }
        public string RELATO_NRCERTIF { get; set; }

        public static M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1 Execute(M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1 m_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1)
        {
            var ths = m_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1();
            var i = 0;
            dta.OPCAOP_PERIPGTO = result[i++].Value?.ToString();
            dta.OPCAOP_AGECTADEB = result[i++].Value?.ToString();
            dta.INDAGE = string.IsNullOrWhiteSpace(dta.OPCAOP_AGECTADEB) ? "-1" : "0";
            dta.OPCAOP_OPRCTADEB = result[i++].Value?.ToString();
            dta.INDOPR = string.IsNullOrWhiteSpace(dta.OPCAOP_OPRCTADEB) ? "-1" : "0";
            dta.OPCAOP_NUMCTADEB = result[i++].Value?.ToString();
            dta.INDNUM = string.IsNullOrWhiteSpace(dta.OPCAOP_NUMCTADEB) ? "-1" : "0";
            dta.OPCAOP_DIGCTADEB = result[i++].Value?.ToString();
            dta.INDDIG = string.IsNullOrWhiteSpace(dta.OPCAOP_DIGCTADEB) ? "-1" : "0";
            return dta;
        }

    }
}