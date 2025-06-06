using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0130B
{
    public class M_0400_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1 : QueryBasis<M_0400_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NRCERTIF,
            OCORHIST,
            DTINIVIG,
            DTTERVIG,
            IMPSEGUR,
            QUANT_VIDAS,
            IMPSEGIND,
            CODOPER,
            OPCAO_COBER,
            IMPMORNATU,
            IMPMORACID,
            IMPINVPERM,
            IMPAMDS,
            IMPDH,
            IMPDIT,
            VLPREMIO,
            PRMVG,
            PRMAP,
            QTTITCAP,
            VLTITCAP,
            VLCUSTCAP,
            IMPSEGCDC,
            VLCUSTCDG,
            IMPSEGAUXF,
            VLCUSTAUXF,
            PRMDIT,
            QTDIT
            INTO :COBERP-NRCERTIF,
            :COBERP-OCORHIST,
            :COBERP-DTINIVIG,
            :COBERP-DTTERVIG,
            :COBERP-IMPSEGUR,
            :COBERP-QUANT-VIDAS,
            :COBERP-IMPSEGIND,
            :COBERP-CODOPER,
            :COBERP-OPCAO-COBER,
            :COBERP-IMPMORNATU-ATU,
            :COBERP-IMPMORACID-ATU,
            :COBERP-IMPINVPERM-ATU,
            :COBERP-IMPAMDS-ATU,
            :COBERP-IMPDH-ATU,
            :COBERP-IMPDIT-ATU,
            :COBERP-VLPREMIO-ATU,
            :COBERP-PRMVG-ATU,
            :COBERP-PRMAP-ATU,
            :COBERP-QTTITCAP,
            :COBERP-VLTITCAP,
            :COBERP-VLCUSTCAP,
            :COBERP-IMPSEGCDG,
            :COBERP-VLCUSTCDG,
            :COBERP-IMPSEGAUXF:COBERP-IMPSEGAUXF-I,
            :COBERP-VLCUSTAUXF:COBERP-VLCUSTAUXF-I,
            :COBERP-PRMDIT-ATU:COBERP-PRMDIT-I,
            :COBERP-QTDIT:COBERP-QTDIT-I
            FROM SEGUROS.V0COBERPROPVA
            WHERE NRCERTIF = :PROPVA-NRCERTIF
            AND OCORHIST =
            (SELECT MAX(T1.OCORHIST)
            FROM SEGUROS.V0COBERPROPVA T1
            WHERE T1.NRCERTIF = :PROPVA-NRCERTIF
            AND T1.DTTERVIG = '9999-12-31' )
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NRCERTIF
							,
											OCORHIST
							,
											DTINIVIG
							,
											DTTERVIG
							,
											IMPSEGUR
							,
											QUANT_VIDAS
							,
											IMPSEGIND
							,
											CODOPER
							,
											OPCAO_COBER
							,
											IMPMORNATU
							,
											IMPMORACID
							,
											IMPINVPERM
							,
											IMPAMDS
							,
											IMPDH
							,
											IMPDIT
							,
											VLPREMIO
							,
											PRMVG
							,
											PRMAP
							,
											QTTITCAP
							,
											VLTITCAP
							,
											VLCUSTCAP
							,
											IMPSEGCDC
							,
											VLCUSTCDG
							,
											IMPSEGAUXF
							,
											VLCUSTAUXF
							,
											PRMDIT
							,
											QTDIT
											FROM SEGUROS.V0COBERPROPVA
											WHERE NRCERTIF = '{this.PROPVA_NRCERTIF}'
											AND OCORHIST =
											(SELECT MAX(T1.OCORHIST)
											FROM SEGUROS.V0COBERPROPVA T1
											WHERE T1.NRCERTIF = '{this.PROPVA_NRCERTIF}'
											AND T1.DTTERVIG = '9999-12-31' )
											WITH UR";

            return query;
        }
        public string COBERP_NRCERTIF { get; set; }
        public string COBERP_OCORHIST { get; set; }
        public string COBERP_DTINIVIG { get; set; }
        public string COBERP_DTTERVIG { get; set; }
        public string COBERP_IMPSEGUR { get; set; }
        public string COBERP_QUANT_VIDAS { get; set; }
        public string COBERP_IMPSEGIND { get; set; }
        public string COBERP_CODOPER { get; set; }
        public string COBERP_OPCAO_COBER { get; set; }
        public string COBERP_IMPMORNATU_ATU { get; set; }
        public string COBERP_IMPMORACID_ATU { get; set; }
        public string COBERP_IMPINVPERM_ATU { get; set; }
        public string COBERP_IMPAMDS_ATU { get; set; }
        public string COBERP_IMPDH_ATU { get; set; }
        public string COBERP_IMPDIT_ATU { get; set; }
        public string COBERP_VLPREMIO_ATU { get; set; }
        public string COBERP_PRMVG_ATU { get; set; }
        public string COBERP_PRMAP_ATU { get; set; }
        public string COBERP_QTTITCAP { get; set; }
        public string COBERP_VLTITCAP { get; set; }
        public string COBERP_VLCUSTCAP { get; set; }
        public string COBERP_IMPSEGCDG { get; set; }
        public string COBERP_VLCUSTCDG { get; set; }
        public string COBERP_IMPSEGAUXF { get; set; }
        public string COBERP_IMPSEGAUXF_I { get; set; }
        public string COBERP_VLCUSTAUXF { get; set; }
        public string COBERP_VLCUSTAUXF_I { get; set; }
        public string COBERP_PRMDIT_ATU { get; set; }
        public string COBERP_PRMDIT_I { get; set; }
        public string COBERP_QTDIT { get; set; }
        public string COBERP_QTDIT_I { get; set; }
        public string PROPVA_NRCERTIF { get; set; }

        public static M_0400_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1 Execute(M_0400_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1 m_0400_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1)
        {
            var ths = m_0400_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0400_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0400_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.COBERP_NRCERTIF = result[i++].Value?.ToString();
            dta.COBERP_OCORHIST = result[i++].Value?.ToString();
            dta.COBERP_DTINIVIG = result[i++].Value?.ToString();
            dta.COBERP_DTTERVIG = result[i++].Value?.ToString();
            dta.COBERP_IMPSEGUR = result[i++].Value?.ToString();
            dta.COBERP_QUANT_VIDAS = result[i++].Value?.ToString();
            dta.COBERP_IMPSEGIND = result[i++].Value?.ToString();
            dta.COBERP_CODOPER = result[i++].Value?.ToString();
            dta.COBERP_OPCAO_COBER = result[i++].Value?.ToString();
            dta.COBERP_IMPMORNATU_ATU = result[i++].Value?.ToString();
            dta.COBERP_IMPMORACID_ATU = result[i++].Value?.ToString();
            dta.COBERP_IMPINVPERM_ATU = result[i++].Value?.ToString();
            dta.COBERP_IMPAMDS_ATU = result[i++].Value?.ToString();
            dta.COBERP_IMPDH_ATU = result[i++].Value?.ToString();
            dta.COBERP_IMPDIT_ATU = result[i++].Value?.ToString();
            dta.COBERP_VLPREMIO_ATU = result[i++].Value?.ToString();
            dta.COBERP_PRMVG_ATU = result[i++].Value?.ToString();
            dta.COBERP_PRMAP_ATU = result[i++].Value?.ToString();
            dta.COBERP_QTTITCAP = result[i++].Value?.ToString();
            dta.COBERP_VLTITCAP = result[i++].Value?.ToString();
            dta.COBERP_VLCUSTCAP = result[i++].Value?.ToString();
            dta.COBERP_IMPSEGCDG = result[i++].Value?.ToString();
            dta.COBERP_VLCUSTCDG = result[i++].Value?.ToString();
            dta.COBERP_IMPSEGAUXF = result[i++].Value?.ToString();
            dta.COBERP_IMPSEGAUXF_I = string.IsNullOrWhiteSpace(dta.COBERP_IMPSEGAUXF) ? "-1" : "0";
            dta.COBERP_VLCUSTAUXF = result[i++].Value?.ToString();
            dta.COBERP_VLCUSTAUXF_I = string.IsNullOrWhiteSpace(dta.COBERP_VLCUSTAUXF) ? "-1" : "0";
            dta.COBERP_PRMDIT_ATU = result[i++].Value?.ToString();
            dta.COBERP_PRMDIT_I = string.IsNullOrWhiteSpace(dta.COBERP_PRMDIT_ATU) ? "-1" : "0";
            dta.COBERP_QTDIT = result[i++].Value?.ToString();
            dta.COBERP_QTDIT_I = string.IsNullOrWhiteSpace(dta.COBERP_QTDIT) ? "-1" : "0";
            return dta;
        }

    }
}