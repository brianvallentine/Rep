using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0816B
{
    public class R0400_00_SELECT_V0PROPOVA_DB_SELECT_1_Query1 : QueryBasis<R0400_00_SELECT_V0PROPOVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.CODCLIEN
            ,A.NUM_APOLICE
            ,A.CODSUBES
            ,A.FONTE
            ,A.SITUACAO
            ,A.QTDPARATZ
            ,A.NUM_MATRICULA
            ,A.OPCAO_COBER
            ,A.DTQITBCO
            ,A.CODPRODU
            ,A.NRPARCE
            ,B.TEM_SAF
            ,B.TEM_CDG
            ,B.RISCO
            ,B.ESTR_COBR
            ,B.ORIG_PRODU
            ,B.CUSTOCAP_TOTAL
            ,C.RAMO
            INTO :V0PROP-CODCLIEN
            ,:V0PROP-NUM-APOLICE
            ,:V0PROP-CODSUBES
            ,:V0PROP-FONTE
            ,:V0PROP-SITUACAO
            ,:V0PROP-QTDPARATZ
            ,:V0PROP-NRMATRFUN:V0PROP-INRMATRFUN
            ,:V0PROP-OPCAO-COBER
            ,:V0PROP-DTQITBCO
            ,:V0PROP-CODPRODU
            ,:V0PROP-NRPARCEL
            ,:V0PROP-TEM-SAF:VIND-TEM-SAF
            ,:V0PROP-TEM-CDG:VIND-TEM-CDG
            ,:V0PROP-RISCO:VIND-RISCO
            ,:V0PROP-ESTR-COBR:VIND-ESTR-COBR
            ,:V0PROP-ORIG-PRODU:VIND-ORIG-PRODU
            ,:V0PROP-CUSTOCAP-TOTAL
            ,:V0PROP-RAMO
            FROM SEGUROS.V0PROPOSTAVA A
            ,SEGUROS.V0PRODUTOSVG B
            ,SEGUROS.V0APOLICE C
            WHERE A.NRCERTIF = :V0HCOB-NRCERTIF
            AND B.NUM_APOLICE = A.NUM_APOLICE
            AND C.NUM_APOLICE = A.NUM_APOLICE
            AND B.CODSUBES = A.CODSUBES
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.CODCLIEN
											,A.NUM_APOLICE
											,A.CODSUBES
											,A.FONTE
											,A.SITUACAO
											,A.QTDPARATZ
											,A.NUM_MATRICULA
											,A.OPCAO_COBER
											,A.DTQITBCO
											,A.CODPRODU
											,A.NRPARCE
											,B.TEM_SAF
											,B.TEM_CDG
											,B.RISCO
											,B.ESTR_COBR
											,B.ORIG_PRODU
											,B.CUSTOCAP_TOTAL
											,C.RAMO
											FROM SEGUROS.V0PROPOSTAVA A
											,SEGUROS.V0PRODUTOSVG B
											,SEGUROS.V0APOLICE C
											WHERE A.NRCERTIF = '{this.V0HCOB_NRCERTIF}'
											AND B.NUM_APOLICE = A.NUM_APOLICE
											AND C.NUM_APOLICE = A.NUM_APOLICE
											AND B.CODSUBES = A.CODSUBES
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string V0PROP_CODCLIEN { get; set; }
        public string V0PROP_NUM_APOLICE { get; set; }
        public string V0PROP_CODSUBES { get; set; }
        public string V0PROP_FONTE { get; set; }
        public string V0PROP_SITUACAO { get; set; }
        public string V0PROP_QTDPARATZ { get; set; }
        public string V0PROP_NRMATRFUN { get; set; }
        public string V0PROP_INRMATRFUN { get; set; }
        public string V0PROP_OPCAO_COBER { get; set; }
        public string V0PROP_DTQITBCO { get; set; }
        public string V0PROP_CODPRODU { get; set; }
        public string V0PROP_NRPARCEL { get; set; }
        public string V0PROP_TEM_SAF { get; set; }
        public string VIND_TEM_SAF { get; set; }
        public string V0PROP_TEM_CDG { get; set; }
        public string VIND_TEM_CDG { get; set; }
        public string V0PROP_RISCO { get; set; }
        public string VIND_RISCO { get; set; }
        public string V0PROP_ESTR_COBR { get; set; }
        public string VIND_ESTR_COBR { get; set; }
        public string V0PROP_ORIG_PRODU { get; set; }
        public string VIND_ORIG_PRODU { get; set; }
        public string V0PROP_CUSTOCAP_TOTAL { get; set; }
        public string V0PROP_RAMO { get; set; }
        public string V0HCOB_NRCERTIF { get; set; }

        public static R0400_00_SELECT_V0PROPOVA_DB_SELECT_1_Query1 Execute(R0400_00_SELECT_V0PROPOVA_DB_SELECT_1_Query1 r0400_00_SELECT_V0PROPOVA_DB_SELECT_1_Query1)
        {
            var ths = r0400_00_SELECT_V0PROPOVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0400_00_SELECT_V0PROPOVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0400_00_SELECT_V0PROPOVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PROP_CODCLIEN = result[i++].Value?.ToString();
            dta.V0PROP_NUM_APOLICE = result[i++].Value?.ToString();
            dta.V0PROP_CODSUBES = result[i++].Value?.ToString();
            dta.V0PROP_FONTE = result[i++].Value?.ToString();
            dta.V0PROP_SITUACAO = result[i++].Value?.ToString();
            dta.V0PROP_QTDPARATZ = result[i++].Value?.ToString();
            dta.V0PROP_NRMATRFUN = result[i++].Value?.ToString();
            dta.V0PROP_INRMATRFUN = string.IsNullOrWhiteSpace(dta.V0PROP_NRMATRFUN) ? "-1" : "0";
            dta.V0PROP_OPCAO_COBER = result[i++].Value?.ToString();
            dta.V0PROP_DTQITBCO = result[i++].Value?.ToString();
            dta.V0PROP_CODPRODU = result[i++].Value?.ToString();
            dta.V0PROP_NRPARCEL = result[i++].Value?.ToString();
            dta.V0PROP_TEM_SAF = result[i++].Value?.ToString();
            dta.VIND_TEM_SAF = string.IsNullOrWhiteSpace(dta.V0PROP_TEM_SAF) ? "-1" : "0";
            dta.V0PROP_TEM_CDG = result[i++].Value?.ToString();
            dta.VIND_TEM_CDG = string.IsNullOrWhiteSpace(dta.V0PROP_TEM_CDG) ? "-1" : "0";
            dta.V0PROP_RISCO = result[i++].Value?.ToString();
            dta.VIND_RISCO = string.IsNullOrWhiteSpace(dta.V0PROP_RISCO) ? "-1" : "0";
            dta.V0PROP_ESTR_COBR = result[i++].Value?.ToString();
            dta.VIND_ESTR_COBR = string.IsNullOrWhiteSpace(dta.V0PROP_ESTR_COBR) ? "-1" : "0";
            dta.V0PROP_ORIG_PRODU = result[i++].Value?.ToString();
            dta.VIND_ORIG_PRODU = string.IsNullOrWhiteSpace(dta.V0PROP_ORIG_PRODU) ? "-1" : "0";
            dta.V0PROP_CUSTOCAP_TOTAL = result[i++].Value?.ToString();
            dta.V0PROP_RAMO = result[i++].Value?.ToString();
            return dta;
        }

    }
}