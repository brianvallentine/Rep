using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0853S
{
    public class R0000_00_PRINCIPAL_DB_SELECT_1_Query1 : QueryBasis<R0000_00_PRINCIPAL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.NRCERTIF,
            A.NRPARCEL,
            A.NRTIT,
            A.CODOPER,
            A.DTVENCTO,
            A.DTVENCTO + 30 DAYS,
            A.OPCAOPAG,
            A.VLPRMTOT,
            A.SITUACAO,
            A.OCORHIST,
            A.NRTITCOMP,
            B.NRCERTIF,
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
            C.PERIPGTO,
            C.OPCAOCAP,
            VALUE(C.ESTR_COBR, ' ' ),
            VALUE(C.ORIG_PRODU, ' ' ),
            VALUE(C.TEM_SAF, ' ' ),
            VALUE(C.TEM_CDG, ' ' ),
            C.COBERADIC_PREMIO,
            C.CUSTOCAP_TOTAL,
            D.PERIPGTO,
            D.OPCAOPAG,
            VALUE(D.AGECTADEB, 0),
            VALUE(D.OPRCTADEB, 0),
            VALUE(D.NUMCTADEB, 0),
            VALUE(D.DIGCTADEB, 0),
            E.PRMVG + E.PRMAP - E.VLMULTA,
            E.PRMVG,
            E.PRMAP,
            E.DTVENCTO,
            E.OCORHIST,
            VALUE(E.SITUACAO, ' ' )
            INTO :V0HISC-NRCERTIF,
            :V0HISC-NRPARCEL,
            :V0HISC-NRTIT,
            :V0HISC-CODOPER,
            :V0HISC-DTVENCTO,
            :V0HISC-DTVENCTO-30,
            :V0HISC-OPCAOPAG,
            :V0HISC-VLPRMTOT,
            :V0HISC-SITUACAO,
            :V0HISC-OCORHIST,
            :V0HISC-NRTITCOMP,
            :V0PROP-NRCERTIF,
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
            :V0PROP-PERIPGTO,
            :V0PROP-OPCAOCAP,
            :V0PROP-ESTR-COBR,
            :V0PROP-ORIG-PRODU,
            :V0PROP-TEM-SAF,
            :V0PROP-TEM-CDG,
            :V0PROP-COBERADIC,
            :V0PROP-CUSTOCAP,
            :V0OPCP-PERIPGTO,
            :V0OPCP-OPCAOPAG,
            :V0OPCP-AGECTADEB,
            :V0OPCP-OPRCTADEB,
            :V0OPCP-NUMCTADEB,
            :V0OPCP-DIGCTADEB,
            :V0PARC-VLPRMTOT,
            :V0PARC-PRMVG,
            :V0PARC-PRMAP,
            :V0PARC-DTVENCTO,
            :V0PARC-OCORHIST,
            :V0PARC-SITUACAO
            FROM SEGUROS.V0HISTCOBVA A,
            SEGUROS.V0PARCELVA E,
            SEGUROS.V0PROPOSTAVA B,
            SEGUROS.V0PRODUTOSVG C,
            SEGUROS.V0OPCAOPAGVA D
            WHERE A.NRCERTIF = :LK-GE853-NUM-CERTIFICADO
            AND A.NRPARCEL = :LK-GE853-NUM-PARCELA
            AND E.NRCERTIF = :LK-GE853-NUM-CERTIFICADO
            AND E.NRPARCEL = :LK-GE853-NUM-PARCELA
            AND E.SITUACAO IN ( ' ' , '0' , X '00' )
            AND B.NRCERTIF = A.NRCERTIF
            AND B.SITUACAO NOT IN ( '2' , '4' )
            AND B.DTPROXVEN <> '9999-12-31'
            AND D.NRCERTIF = B.NRCERTIF
            AND D.DTINIVIG <= B.DTPROXVEN
            AND D.DTTERVIG >= B.DTPROXVEN
            AND C.NUM_APOLICE = B.NUM_APOLICE
            AND C.CODSUBES = B.CODSUBES
            AND C.ESTR_COBR = 'MULT'
            AND C.ORIG_PRODU NOT IN ( 'ESPEC' , 'EMPRE' , 'GLOBAL' ,
            'ESPE1' , 'ESPE2' , 'ESPE3' )
            ORDER BY A.NRCERTIF, A.NRPARCEL, A.NRTIT
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.NRCERTIF
							,
											A.NRPARCEL
							,
											A.NRTIT
							,
											A.CODOPER
							,
											A.DTVENCTO
							,
											A.DTVENCTO + 30 DAYS
							,
											A.OPCAOPAG
							,
											A.VLPRMTOT
							,
											A.SITUACAO
							,
											A.OCORHIST
							,
											A.NRTITCOMP
							,
											B.NRCERTIF
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
											C.PERIPGTO
							,
											C.OPCAOCAP
							,
											VALUE(C.ESTR_COBR
							, ' ' )
							,
											VALUE(C.ORIG_PRODU
							, ' ' )
							,
											VALUE(C.TEM_SAF
							, ' ' )
							,
											VALUE(C.TEM_CDG
							, ' ' )
							,
											C.COBERADIC_PREMIO
							,
											C.CUSTOCAP_TOTAL
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
											E.PRMVG + E.PRMAP - E.VLMULTA
							,
											E.PRMVG
							,
											E.PRMAP
							,
											E.DTVENCTO
							,
											E.OCORHIST
							,
											VALUE(E.SITUACAO
							, ' ' )
											FROM SEGUROS.V0HISTCOBVA A
							,
											SEGUROS.V0PARCELVA E
							,
											SEGUROS.V0PROPOSTAVA B
							,
											SEGUROS.V0PRODUTOSVG C
							,
											SEGUROS.V0OPCAOPAGVA D
											WHERE A.NRCERTIF = '{this.LK_GE853_NUM_CERTIFICADO}'
											AND A.NRPARCEL = '{this.LK_GE853_NUM_PARCELA}'
											AND E.NRCERTIF = '{this.LK_GE853_NUM_CERTIFICADO}'
											AND E.NRPARCEL = '{this.LK_GE853_NUM_PARCELA}'
											AND E.SITUACAO IN ( ' ' 
							, '0' 
							, X'00' )
											AND B.NRCERTIF = A.NRCERTIF
											AND B.SITUACAO NOT IN ( '2' 
							, '4' )
											AND B.DTPROXVEN <> '9999-12-31'
											AND D.NRCERTIF = B.NRCERTIF
											AND D.DTINIVIG <= B.DTPROXVEN
											AND D.DTTERVIG >= B.DTPROXVEN
											AND C.NUM_APOLICE = B.NUM_APOLICE
											AND C.CODSUBES = B.CODSUBES
											AND C.ESTR_COBR = 'MULT'
											AND C.ORIG_PRODU NOT IN ( 'ESPEC' 
							, 'EMPRE' 
							, 'GLOBAL' 
							,
											'ESPE1' 
							, 'ESPE2' 
							, 'ESPE3' )
											ORDER BY A.NRCERTIF
							, A.NRPARCEL
							, A.NRTIT
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string V0HISC_NRCERTIF { get; set; }
        public string V0HISC_NRPARCEL { get; set; }
        public string V0HISC_NRTIT { get; set; }
        public string V0HISC_CODOPER { get; set; }
        public string V0HISC_DTVENCTO { get; set; }
        public string V0HISC_DTVENCTO_30 { get; set; }
        public string V0HISC_OPCAOPAG { get; set; }
        public string V0HISC_VLPRMTOT { get; set; }
        public string V0HISC_SITUACAO { get; set; }
        public string V0HISC_OCORHIST { get; set; }
        public string V0HISC_NRTITCOMP { get; set; }
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
        public string V0PROP_PERIPGTO { get; set; }
        public string V0PROP_OPCAOCAP { get; set; }
        public string V0PROP_ESTR_COBR { get; set; }
        public string V0PROP_ORIG_PRODU { get; set; }
        public string V0PROP_TEM_SAF { get; set; }
        public string V0PROP_TEM_CDG { get; set; }
        public string V0PROP_COBERADIC { get; set; }
        public string V0PROP_CUSTOCAP { get; set; }
        public string V0OPCP_PERIPGTO { get; set; }
        public string V0OPCP_OPCAOPAG { get; set; }
        public string V0OPCP_AGECTADEB { get; set; }
        public string V0OPCP_OPRCTADEB { get; set; }
        public string V0OPCP_NUMCTADEB { get; set; }
        public string V0OPCP_DIGCTADEB { get; set; }
        public string V0PARC_VLPRMTOT { get; set; }
        public string V0PARC_PRMVG { get; set; }
        public string V0PARC_PRMAP { get; set; }
        public string V0PARC_DTVENCTO { get; set; }
        public string V0PARC_OCORHIST { get; set; }
        public string V0PARC_SITUACAO { get; set; }
        public string LK_GE853_NUM_CERTIFICADO { get; set; }
        public string LK_GE853_NUM_PARCELA { get; set; }

        public static R0000_00_PRINCIPAL_DB_SELECT_1_Query1 Execute(R0000_00_PRINCIPAL_DB_SELECT_1_Query1 r0000_00_PRINCIPAL_DB_SELECT_1_Query1)
        {
            var ths = r0000_00_PRINCIPAL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0000_00_PRINCIPAL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0000_00_PRINCIPAL_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0HISC_NRCERTIF = result[i++].Value?.ToString();
            dta.V0HISC_NRPARCEL = result[i++].Value?.ToString();
            dta.V0HISC_NRTIT = result[i++].Value?.ToString();
            dta.V0HISC_CODOPER = result[i++].Value?.ToString();
            dta.V0HISC_DTVENCTO = result[i++].Value?.ToString();
            dta.V0HISC_DTVENCTO_30 = result[i++].Value?.ToString();
            dta.V0HISC_OPCAOPAG = result[i++].Value?.ToString();
            dta.V0HISC_VLPRMTOT = result[i++].Value?.ToString();
            dta.V0HISC_SITUACAO = result[i++].Value?.ToString();
            dta.V0HISC_OCORHIST = result[i++].Value?.ToString();
            dta.V0HISC_NRTITCOMP = result[i++].Value?.ToString();
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
            dta.V0PROP_PERIPGTO = result[i++].Value?.ToString();
            dta.V0PROP_OPCAOCAP = result[i++].Value?.ToString();
            dta.V0PROP_ESTR_COBR = result[i++].Value?.ToString();
            dta.V0PROP_ORIG_PRODU = result[i++].Value?.ToString();
            dta.V0PROP_TEM_SAF = result[i++].Value?.ToString();
            dta.V0PROP_TEM_CDG = result[i++].Value?.ToString();
            dta.V0PROP_COBERADIC = result[i++].Value?.ToString();
            dta.V0PROP_CUSTOCAP = result[i++].Value?.ToString();
            dta.V0OPCP_PERIPGTO = result[i++].Value?.ToString();
            dta.V0OPCP_OPCAOPAG = result[i++].Value?.ToString();
            dta.V0OPCP_AGECTADEB = result[i++].Value?.ToString();
            dta.V0OPCP_OPRCTADEB = result[i++].Value?.ToString();
            dta.V0OPCP_NUMCTADEB = result[i++].Value?.ToString();
            dta.V0OPCP_DIGCTADEB = result[i++].Value?.ToString();
            dta.V0PARC_VLPRMTOT = result[i++].Value?.ToString();
            dta.V0PARC_PRMVG = result[i++].Value?.ToString();
            dta.V0PARC_PRMAP = result[i++].Value?.ToString();
            dta.V0PARC_DTVENCTO = result[i++].Value?.ToString();
            dta.V0PARC_OCORHIST = result[i++].Value?.ToString();
            dta.V0PARC_SITUACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}