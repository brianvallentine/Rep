using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0853B
{
    public class R1018_00_CONS_OPCAOPAGVA_DB_SELECT_1_Query1 : QueryBasis<R1018_00_CONS_OPCAOPAGVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(OPCAOPAG , ' ' ),
            VALUE(PERIPGTO, 0),
            VALUE(DIA_DEBITO, 0),
            VALUE(AGECTADEB, 0),
            VALUE(OPRCTADEB, 0),
            VALUE(NUMCTADEB, 0),
            VALUE(DIGCTADEB, 0),
            NUM_CARTAO_CREDITO
            INTO :V0OPCP-OPCAOPAG,
            :V0OPCP-PERIPGTO,
            :V0OPCP-DIA-DEBITO,
            :V0OPCP-AGECTADEB,
            :V0OPCP-OPRCTADEB,
            :V0OPCP-NUMCTADEB,
            :V0OPCP-DIGCTADEB,
            :V0OPCP-CARTAO-CRED:VIND-CCRE
            FROM SEGUROS.V0OPCAOPAGVA
            WHERE NRCERTIF = :V0PROP-NRCERTIF
            AND DTINIVIG <= :V0PROP-DTPROXVEN
            AND DTTERVIG >= :V0PROP-DTPROXVEN
            FETCH FIRST 1 ROW ONLY
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(OPCAOPAG 
							, ' ' )
							,
											VALUE(PERIPGTO
							, 0)
							,
											VALUE(DIA_DEBITO
							, 0)
							,
											VALUE(AGECTADEB
							, 0)
							,
											VALUE(OPRCTADEB
							, 0)
							,
											VALUE(NUMCTADEB
							, 0)
							,
											VALUE(DIGCTADEB
							, 0)
							,
											NUM_CARTAO_CREDITO
											FROM SEGUROS.V0OPCAOPAGVA
											WHERE NRCERTIF = '{this.V0PROP_NRCERTIF}'
											AND DTINIVIG <= '{this.V0PROP_DTPROXVEN}'
											AND DTTERVIG >= '{this.V0PROP_DTPROXVEN}'
											FETCH FIRST 1 ROW ONLY
											WITH UR";

            return query;
        }
        public string V0OPCP_OPCAOPAG { get; set; }
        public string V0OPCP_PERIPGTO { get; set; }
        public string V0OPCP_DIA_DEBITO { get; set; }
        public string V0OPCP_AGECTADEB { get; set; }
        public string V0OPCP_OPRCTADEB { get; set; }
        public string V0OPCP_NUMCTADEB { get; set; }
        public string V0OPCP_DIGCTADEB { get; set; }
        public string V0OPCP_CARTAO_CRED { get; set; }
        public string VIND_CCRE { get; set; }
        public string V0PROP_DTPROXVEN { get; set; }
        public string V0PROP_NRCERTIF { get; set; }

        public static R1018_00_CONS_OPCAOPAGVA_DB_SELECT_1_Query1 Execute(R1018_00_CONS_OPCAOPAGVA_DB_SELECT_1_Query1 r1018_00_CONS_OPCAOPAGVA_DB_SELECT_1_Query1)
        {
            var ths = r1018_00_CONS_OPCAOPAGVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1018_00_CONS_OPCAOPAGVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1018_00_CONS_OPCAOPAGVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0OPCP_OPCAOPAG = result[i++].Value?.ToString();
            dta.V0OPCP_PERIPGTO = result[i++].Value?.ToString();
            dta.V0OPCP_DIA_DEBITO = result[i++].Value?.ToString();
            dta.V0OPCP_AGECTADEB = result[i++].Value?.ToString();
            dta.V0OPCP_OPRCTADEB = result[i++].Value?.ToString();
            dta.V0OPCP_NUMCTADEB = result[i++].Value?.ToString();
            dta.V0OPCP_DIGCTADEB = result[i++].Value?.ToString();
            dta.V0OPCP_CARTAO_CRED = result[i++].Value?.ToString();
            dta.VIND_CCRE = string.IsNullOrWhiteSpace(dta.V0OPCP_CARTAO_CRED) ? "-1" : "0";
            return dta;
        }

    }
}