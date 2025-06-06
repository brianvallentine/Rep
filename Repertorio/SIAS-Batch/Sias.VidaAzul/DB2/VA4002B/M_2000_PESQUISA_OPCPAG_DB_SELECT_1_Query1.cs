using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA4002B
{
    public class M_2000_PESQUISA_OPCPAG_DB_SELECT_1_Query1 : QueryBasis<M_2000_PESQUISA_OPCPAG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT OPCAOPAG,
            PERIPGTO,
            DIA_DEBITO,
            AGECTADEB,
            OPRCTADEB,
            NUMCTADEB,
            DIGCTADEB
            NUM_CARTAO_CREDITO
            INTO :OPCAOP-OPCAOPAG,
            :OPCAOP-PERIPGTO,
            :OPCAOP-DIA-DEB,
            :OPCAOP-AGECTADEB:INDAGE,
            :OPCAOP-OPRCTADEB:INDOPR,
            :OPCAOP-NUMCTADEB:INDNUM,
            :OPCAOP-DIGCTADEB:INDDIG
            FROM SEGUROS.V0OPCAOPAGVA
            WHERE NRCERTIF = :PROPVA-NRCERTIF
            AND DTTERVIG IN ( '1999-12-31' , '9999-12-31' )
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT OPCAOPAG
							,
											PERIPGTO
							,
											DIA_DEBITO
							,
											AGECTADEB
							,
											OPRCTADEB
							,
											NUMCTADEB
							,
											DIGCTADEB
											NUM_CARTAO_CREDITO
											FROM SEGUROS.V0OPCAOPAGVA
											WHERE NRCERTIF = '{this.PROPVA_NRCERTIF}'
											AND DTTERVIG IN ( '1999-12-31' 
							, '9999-12-31' )
											WITH UR";

            return query;
        }
        public string OPCAOP_OPCAOPAG { get; set; }
        public string OPCAOP_PERIPGTO { get; set; }
        public string OPCAOP_DIA_DEB { get; set; }
        public string OPCAOP_AGECTADEB { get; set; }
        public string INDAGE { get; set; }
        public string OPCAOP_OPRCTADEB { get; set; }
        public string INDOPR { get; set; }
        public string OPCAOP_NUMCTADEB { get; set; }
        public string INDNUM { get; set; }
        public string OPCAOP_DIGCTADEB { get; set; }
        public string INDDIG { get; set; }
        public string PROPVA_NRCERTIF { get; set; }

        public static M_2000_PESQUISA_OPCPAG_DB_SELECT_1_Query1 Execute(M_2000_PESQUISA_OPCPAG_DB_SELECT_1_Query1 m_2000_PESQUISA_OPCPAG_DB_SELECT_1_Query1)
        {
            var ths = m_2000_PESQUISA_OPCPAG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_2000_PESQUISA_OPCPAG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_2000_PESQUISA_OPCPAG_DB_SELECT_1_Query1();
            var i = 0;
            dta.OPCAOP_OPCAOPAG = result[i++].Value?.ToString();
            dta.OPCAOP_PERIPGTO = result[i++].Value?.ToString();
            dta.OPCAOP_DIA_DEB = result[i++].Value?.ToString();
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