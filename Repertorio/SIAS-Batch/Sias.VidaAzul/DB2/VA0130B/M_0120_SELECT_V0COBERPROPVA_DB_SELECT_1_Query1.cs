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
    public class M_0120_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1 : QueryBasis<M_0120_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IMPSEGUR,
            QUANT_VIDAS,
            IMPSEGIND,
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
            QTDIT,
            DTINIVIG,
            DTINIVIG + 1 DAY
            INTO :COBERP-IMPSEGUR-ANT,
            :COBERP-QUANT-VIDAS-ANT,
            :COBERP-IMPSEGIND-ANT,
            :COBERP-OPCAO-COBER-ANT,
            :COBERP-IMPMORNATU-ANT,
            :COBERP-IMPMORACID-ANT,
            :COBERP-IMPINVPERM-ANT,
            :COBERP-IMPAMDS-ANT,
            :COBERP-IMPDH-ANT,
            :COBERP-IMPDIT-ANT,
            :COBERP-VLPREMIO-ANT,
            :COBERP-PRMVG-ANT,
            :COBERP-PRMAP-ANT,
            :COBERP-QTTITCAP,
            :COBERP-VLTITCAP,
            :COBERP-VLCUSTCAP,
            :COBERP-IMPSEGCDG,
            :COBERP-VLCUSTCDG,
            :COBERP-IMPSEGAUXF:COBERP-IMPSEGAUXF-I,
            :COBERP-VLCUSTAUXF:COBERP-VLCUSTAUXF-I,
            :COBERP-PRMDIT-ANT:COBERP-PRMDIT-I,
            :COBERP-QTDIT:COBERP-QTDIT-I,
            :COBERP-DTINIVIG-ANT,
            :COBERP-DTINIVIG-NEW
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
				SELECT IMPSEGUR
							,
											QUANT_VIDAS
							,
											IMPSEGIND
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
							,
											DTINIVIG
							,
											DTINIVIG + 1 DAY
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
        public string COBERP_IMPSEGUR_ANT { get; set; }
        public string COBERP_QUANT_VIDAS_ANT { get; set; }
        public string COBERP_IMPSEGIND_ANT { get; set; }
        public string COBERP_OPCAO_COBER_ANT { get; set; }
        public string COBERP_IMPMORNATU_ANT { get; set; }
        public string COBERP_IMPMORACID_ANT { get; set; }
        public string COBERP_IMPINVPERM_ANT { get; set; }
        public string COBERP_IMPAMDS_ANT { get; set; }
        public string COBERP_IMPDH_ANT { get; set; }
        public string COBERP_IMPDIT_ANT { get; set; }
        public string COBERP_VLPREMIO_ANT { get; set; }
        public string COBERP_PRMVG_ANT { get; set; }
        public string COBERP_PRMAP_ANT { get; set; }
        public string COBERP_QTTITCAP { get; set; }
        public string COBERP_VLTITCAP { get; set; }
        public string COBERP_VLCUSTCAP { get; set; }
        public string COBERP_IMPSEGCDG { get; set; }
        public string COBERP_VLCUSTCDG { get; set; }
        public string COBERP_IMPSEGAUXF { get; set; }
        public string COBERP_IMPSEGAUXF_I { get; set; }
        public string COBERP_VLCUSTAUXF { get; set; }
        public string COBERP_VLCUSTAUXF_I { get; set; }
        public string COBERP_PRMDIT_ANT { get; set; }
        public string COBERP_PRMDIT_I { get; set; }
        public string COBERP_QTDIT { get; set; }
        public string COBERP_QTDIT_I { get; set; }
        public string COBERP_DTINIVIG_ANT { get; set; }
        public string COBERP_DTINIVIG_NEW { get; set; }
        public string PROPVA_NRCERTIF { get; set; }

        public static M_0120_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1 Execute(M_0120_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1 m_0120_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1)
        {
            var ths = m_0120_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0120_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0120_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.COBERP_IMPSEGUR_ANT = result[i++].Value?.ToString();
            dta.COBERP_QUANT_VIDAS_ANT = result[i++].Value?.ToString();
            dta.COBERP_IMPSEGIND_ANT = result[i++].Value?.ToString();
            dta.COBERP_OPCAO_COBER_ANT = result[i++].Value?.ToString();
            dta.COBERP_IMPMORNATU_ANT = result[i++].Value?.ToString();
            dta.COBERP_IMPMORACID_ANT = result[i++].Value?.ToString();
            dta.COBERP_IMPINVPERM_ANT = result[i++].Value?.ToString();
            dta.COBERP_IMPAMDS_ANT = result[i++].Value?.ToString();
            dta.COBERP_IMPDH_ANT = result[i++].Value?.ToString();
            dta.COBERP_IMPDIT_ANT = result[i++].Value?.ToString();
            dta.COBERP_VLPREMIO_ANT = result[i++].Value?.ToString();
            dta.COBERP_PRMVG_ANT = result[i++].Value?.ToString();
            dta.COBERP_PRMAP_ANT = result[i++].Value?.ToString();
            dta.COBERP_QTTITCAP = result[i++].Value?.ToString();
            dta.COBERP_VLTITCAP = result[i++].Value?.ToString();
            dta.COBERP_VLCUSTCAP = result[i++].Value?.ToString();
            dta.COBERP_IMPSEGCDG = result[i++].Value?.ToString();
            dta.COBERP_VLCUSTCDG = result[i++].Value?.ToString();
            dta.COBERP_IMPSEGAUXF = result[i++].Value?.ToString();
            dta.COBERP_IMPSEGAUXF_I = string.IsNullOrWhiteSpace(dta.COBERP_IMPSEGAUXF) ? "-1" : "0";
            dta.COBERP_VLCUSTAUXF = result[i++].Value?.ToString();
            dta.COBERP_VLCUSTAUXF_I = string.IsNullOrWhiteSpace(dta.COBERP_VLCUSTAUXF) ? "-1" : "0";
            dta.COBERP_PRMDIT_ANT = result[i++].Value?.ToString();
            dta.COBERP_PRMDIT_I = string.IsNullOrWhiteSpace(dta.COBERP_PRMDIT_ANT) ? "-1" : "0";
            dta.COBERP_QTDIT = result[i++].Value?.ToString();
            dta.COBERP_QTDIT_I = string.IsNullOrWhiteSpace(dta.COBERP_QTDIT) ? "-1" : "0";
            dta.COBERP_DTINIVIG_ANT = result[i++].Value?.ToString();
            dta.COBERP_DTINIVIG_NEW = result[i++].Value?.ToString();
            return dta;
        }

    }
}