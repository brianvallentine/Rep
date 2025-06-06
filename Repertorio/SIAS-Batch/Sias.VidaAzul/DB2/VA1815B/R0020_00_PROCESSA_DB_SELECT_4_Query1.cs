using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1815B
{
    public class R0020_00_PROCESSA_DB_SELECT_4_Query1 : QueryBasis<R0020_00_PROCESSA_DB_SELECT_4_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.CODCLIEN,
            A.NUM_APOLICE,
            A.CODSUBES,
            A.FONTE,
            A.QTDPARATZ,
            A.SITUACAO,
            A.NUM_MATRICULA,
            A.CODPRODU,
            A.NRPARCE,
            B.PERIPGTO,
            B.TEM_SAF,
            B.TEM_CDG,
            B.RISCO,
            B.OPCAOPAG,
            B.CUSTOCAP_TOTAL,
            VALUE(B.ORIG_PRODU, ' ' )
            INTO :V0PROP-CODCLIEN,
            :V0PROP-NUM-APOLICE,
            :V0PROP-CODSUBES,
            :V0PROP-FONTE,
            :V0PROP-QTDPARATZ,
            :V0PROP-SITUACAO,
            :V0PROP-NRMATRFUN:V0PROP-INRMATRFUN,
            :V0PROP-CODPRODU,
            :V0PROP-NRPARCE,
            :V0PRVG-PERIPGTO,
            :V0PRVG-TEM-SAF:VIND-TEM-SAF,
            :V0PRVG-TEM-CDG:VIND-TEM-CDG,
            :V0PRVG-RISCO:VIND-RISCO,
            :V0PRVG-OPCAOPAG,
            :V0PRVG-CUSTOCAP-TOTAL,
            :V0PRVG-ORIG-PRODU
            FROM SEGUROS.V0PROPOSTAVA A,
            SEGUROS.V0PRODUTOSVG B
            WHERE A.NRCERTIF = :V0HCTA-NRCERTIF
            AND B.NUM_APOLICE = A.NUM_APOLICE
            AND B.CODSUBES = A.CODSUBES
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.CODCLIEN
							,
											A.NUM_APOLICE
							,
											A.CODSUBES
							,
											A.FONTE
							,
											A.QTDPARATZ
							,
											A.SITUACAO
							,
											A.NUM_MATRICULA
							,
											A.CODPRODU
							,
											A.NRPARCE
							,
											B.PERIPGTO
							,
											B.TEM_SAF
							,
											B.TEM_CDG
							,
											B.RISCO
							,
											B.OPCAOPAG
							,
											B.CUSTOCAP_TOTAL
							,
											VALUE(B.ORIG_PRODU
							, ' ' )
											FROM SEGUROS.V0PROPOSTAVA A
							,
											SEGUROS.V0PRODUTOSVG B
											WHERE A.NRCERTIF = '{this.V0HCTA_NRCERTIF}'
											AND B.NUM_APOLICE = A.NUM_APOLICE
											AND B.CODSUBES = A.CODSUBES";

            return query;
        }
        public string V0PROP_CODCLIEN { get; set; }
        public string V0PROP_NUM_APOLICE { get; set; }
        public string V0PROP_CODSUBES { get; set; }
        public string V0PROP_FONTE { get; set; }
        public string V0PROP_QTDPARATZ { get; set; }
        public string V0PROP_SITUACAO { get; set; }
        public string V0PROP_NRMATRFUN { get; set; }
        public string V0PROP_INRMATRFUN { get; set; }
        public string V0PROP_CODPRODU { get; set; }
        public string V0PROP_NRPARCE { get; set; }
        public string V0PRVG_PERIPGTO { get; set; }
        public string V0PRVG_TEM_SAF { get; set; }
        public string VIND_TEM_SAF { get; set; }
        public string V0PRVG_TEM_CDG { get; set; }
        public string VIND_TEM_CDG { get; set; }
        public string V0PRVG_RISCO { get; set; }
        public string VIND_RISCO { get; set; }
        public string V0PRVG_OPCAOPAG { get; set; }
        public string V0PRVG_CUSTOCAP_TOTAL { get; set; }
        public string V0PRVG_ORIG_PRODU { get; set; }
        public string V0HCTA_NRCERTIF { get; set; }

        public static R0020_00_PROCESSA_DB_SELECT_4_Query1 Execute(R0020_00_PROCESSA_DB_SELECT_4_Query1 r0020_00_PROCESSA_DB_SELECT_4_Query1)
        {
            var ths = r0020_00_PROCESSA_DB_SELECT_4_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0020_00_PROCESSA_DB_SELECT_4_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0020_00_PROCESSA_DB_SELECT_4_Query1();
            var i = 0;
            dta.V0PROP_CODCLIEN = result[i++].Value?.ToString();
            dta.V0PROP_NUM_APOLICE = result[i++].Value?.ToString();
            dta.V0PROP_CODSUBES = result[i++].Value?.ToString();
            dta.V0PROP_FONTE = result[i++].Value?.ToString();
            dta.V0PROP_QTDPARATZ = result[i++].Value?.ToString();
            dta.V0PROP_SITUACAO = result[i++].Value?.ToString();
            dta.V0PROP_NRMATRFUN = result[i++].Value?.ToString();
            dta.V0PROP_INRMATRFUN = string.IsNullOrWhiteSpace(dta.V0PROP_NRMATRFUN) ? "-1" : "0";
            dta.V0PROP_CODPRODU = result[i++].Value?.ToString();
            dta.V0PROP_NRPARCE = result[i++].Value?.ToString();
            dta.V0PRVG_PERIPGTO = result[i++].Value?.ToString();
            dta.V0PRVG_TEM_SAF = result[i++].Value?.ToString();
            dta.VIND_TEM_SAF = string.IsNullOrWhiteSpace(dta.V0PRVG_TEM_SAF) ? "-1" : "0";
            dta.V0PRVG_TEM_CDG = result[i++].Value?.ToString();
            dta.VIND_TEM_CDG = string.IsNullOrWhiteSpace(dta.V0PRVG_TEM_CDG) ? "-1" : "0";
            dta.V0PRVG_RISCO = result[i++].Value?.ToString();
            dta.VIND_RISCO = string.IsNullOrWhiteSpace(dta.V0PRVG_RISCO) ? "-1" : "0";
            dta.V0PRVG_OPCAOPAG = result[i++].Value?.ToString();
            dta.V0PRVG_CUSTOCAP_TOTAL = result[i++].Value?.ToString();
            dta.V0PRVG_ORIG_PRODU = result[i++].Value?.ToString();
            return dta;
        }

    }
}