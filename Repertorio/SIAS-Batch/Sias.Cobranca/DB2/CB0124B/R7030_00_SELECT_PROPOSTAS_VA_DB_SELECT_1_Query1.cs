using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0124B
{
    public class R7030_00_SELECT_PROPOSTAS_VA_DB_SELECT_1_Query1 : QueryBasis<R7030_00_SELECT_PROPOSTAS_VA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT B.NRCERTIF,
            B.FONTE,
            B.NUM_APOLICE,
            B.CODSUBES,
            B.CODPRODU,
            B.CODCLIEN,
            B.NRPARCE,
            B.SITUACAO,
            B.DTQITBCO,
            B.DTVENCTO,
            B.DTPROXVEN,
            B.NRPRIPARATZ,
            B.QTDPARATZ,
            VALUE(B.NUM_MATRICULA, 0),
            VALUE(B.DATA_ADMISSAO, '2001-01-01' ),
            B.TIMESTAMP,
            D.PERIPGTO,
            D.OPCAOPAG,
            VALUE(D.AGECTADEB, 0),
            VALUE(D.OPRCTADEB, 0),
            VALUE(D.NUMCTADEB, 0),
            VALUE(D.DIGCTADEB, 0),
            VALUE(D.NUM_CARTAO_CREDITO, '' )
            INTO :V0PROP-NRCERTIF,
            :V0PROP-FONTE,
            :V0PROP-NUM-APOLICE,
            :V0PROP-CODSUBES,
            :V0PROP-CODPRODU,
            :V0PROP-CODCLIEN,
            :V0PROP-NRPARCEL,
            :V0PROP-SITUACAO,
            :V0PROP-DTQITBCO,
            :V0PROP-DTVENCTO,
            :V0PROP-DTPROXVEN,
            :V0PROP-NRPRIPARATZ,
            :V0PROP-QTDPARATZ,
            :V0PROP-NRMATRFUN,
            :V0PROP-DTADMISSAO,
            :V0PROP-TIMESTAMP,
            :V0OPCP-PERIPGTO,
            :V0OPCP-OPCAOPAG,
            :V0OPCP-AGECTADEB,
            :V0OPCP-OPRCTADEB,
            :V0OPCP-NUMCTADEB,
            :V0OPCP-DIGCTADEB,
            :V0OPCP-CARTAOCRED
            FROM SEGUROS.V0PROPOSTAVA B,
            SEGUROS.V0OPCAOPAGVA D
            WHERE B.NRCERTIF = :HISLANCT-NUM-CERTIFICADO
            AND D.NRCERTIF = B.NRCERTIF
            AND D.DTTERVIG = '9999-12-31'
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT B.NRCERTIF
							,
											B.FONTE
							,
											B.NUM_APOLICE
							,
											B.CODSUBES
							,
											B.CODPRODU
							,
											B.CODCLIEN
							,
											B.NRPARCE
							,
											B.SITUACAO
							,
											B.DTQITBCO
							,
											B.DTVENCTO
							,
											B.DTPROXVEN
							,
											B.NRPRIPARATZ
							,
											B.QTDPARATZ
							,
											VALUE(B.NUM_MATRICULA
							, 0)
							,
											VALUE(B.DATA_ADMISSAO
							, '2001-01-01' )
							,
											B.TIMESTAMP
							,
											D.PERIPGTO
							,
											D.OPCAOPAG
							,
											VALUE(D.AGECTADEB
							, 0)
							,
											VALUE(D.OPRCTADEB
							, 0)
							,
											VALUE(D.NUMCTADEB
							, 0)
							,
											VALUE(D.DIGCTADEB
							, 0)
							,
											VALUE(D.NUM_CARTAO_CREDITO
							, '' )
											FROM SEGUROS.V0PROPOSTAVA B
							,
											SEGUROS.V0OPCAOPAGVA D
											WHERE B.NRCERTIF = '{this.HISLANCT_NUM_CERTIFICADO}'
											AND D.NRCERTIF = B.NRCERTIF
											AND D.DTTERVIG = '9999-12-31'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string V0PROP_NRCERTIF { get; set; }
        public string V0PROP_FONTE { get; set; }
        public string V0PROP_NUM_APOLICE { get; set; }
        public string V0PROP_CODSUBES { get; set; }
        public string V0PROP_CODPRODU { get; set; }
        public string V0PROP_CODCLIEN { get; set; }
        public string V0PROP_NRPARCEL { get; set; }
        public string V0PROP_SITUACAO { get; set; }
        public string V0PROP_DTQITBCO { get; set; }
        public string V0PROP_DTVENCTO { get; set; }
        public string V0PROP_DTPROXVEN { get; set; }
        public string V0PROP_NRPRIPARATZ { get; set; }
        public string V0PROP_QTDPARATZ { get; set; }
        public string V0PROP_NRMATRFUN { get; set; }
        public string V0PROP_DTADMISSAO { get; set; }
        public string V0PROP_TIMESTAMP { get; set; }
        public string V0OPCP_PERIPGTO { get; set; }
        public string V0OPCP_OPCAOPAG { get; set; }
        public string V0OPCP_AGECTADEB { get; set; }
        public string V0OPCP_OPRCTADEB { get; set; }
        public string V0OPCP_NUMCTADEB { get; set; }
        public string V0OPCP_DIGCTADEB { get; set; }
        public string V0OPCP_CARTAOCRED { get; set; }
        public string HISLANCT_NUM_CERTIFICADO { get; set; }

        public static R7030_00_SELECT_PROPOSTAS_VA_DB_SELECT_1_Query1 Execute(R7030_00_SELECT_PROPOSTAS_VA_DB_SELECT_1_Query1 r7030_00_SELECT_PROPOSTAS_VA_DB_SELECT_1_Query1)
        {
            var ths = r7030_00_SELECT_PROPOSTAS_VA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R7030_00_SELECT_PROPOSTAS_VA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R7030_00_SELECT_PROPOSTAS_VA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PROP_NRCERTIF = result[i++].Value?.ToString();
            dta.V0PROP_FONTE = result[i++].Value?.ToString();
            dta.V0PROP_NUM_APOLICE = result[i++].Value?.ToString();
            dta.V0PROP_CODSUBES = result[i++].Value?.ToString();
            dta.V0PROP_CODPRODU = result[i++].Value?.ToString();
            dta.V0PROP_CODCLIEN = result[i++].Value?.ToString();
            dta.V0PROP_NRPARCEL = result[i++].Value?.ToString();
            dta.V0PROP_SITUACAO = result[i++].Value?.ToString();
            dta.V0PROP_DTQITBCO = result[i++].Value?.ToString();
            dta.V0PROP_DTVENCTO = result[i++].Value?.ToString();
            dta.V0PROP_DTPROXVEN = result[i++].Value?.ToString();
            dta.V0PROP_NRPRIPARATZ = result[i++].Value?.ToString();
            dta.V0PROP_QTDPARATZ = result[i++].Value?.ToString();
            dta.V0PROP_NRMATRFUN = result[i++].Value?.ToString();
            dta.V0PROP_DTADMISSAO = result[i++].Value?.ToString();
            dta.V0PROP_TIMESTAMP = result[i++].Value?.ToString();
            dta.V0OPCP_PERIPGTO = result[i++].Value?.ToString();
            dta.V0OPCP_OPCAOPAG = result[i++].Value?.ToString();
            dta.V0OPCP_AGECTADEB = result[i++].Value?.ToString();
            dta.V0OPCP_OPRCTADEB = result[i++].Value?.ToString();
            dta.V0OPCP_NUMCTADEB = result[i++].Value?.ToString();
            dta.V0OPCP_DIGCTADEB = result[i++].Value?.ToString();
            dta.V0OPCP_CARTAOCRED = result[i++].Value?.ToString();
            return dta;
        }

    }
}