using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0121B
{
    public class M_0100_OPCAOPAGVA_DB_SELECT_5_Query1 : QueryBasis<M_0100_OPCAOPAGVA_DB_SELECT_5_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTINIVIG,
            IMPMORNATU,
            IMPMORACID,
            IMPINVPERM,
            IMPAMDS,
            IMPDH,
            IMPDIT,
            VLPREMIO,
            PRMVG,
            PRMAP,
            IMPSEGCDC,
            VLCUSTCDG,
            VLCUSTCAP,
            IMPSEGAUXF,
            VLCUSTAUXF,
            QTTITCAP
            INTO :COBERP-DTINIVIG,
            :COBERP-IMPMORNATU,
            :COBERP-IMPMORACID,
            :COBERP-IMPINVPERM,
            :COBERP-IMPAMDS,
            :COBERP-IMPDH,
            :COBERP-IMPDIT,
            :COBERP-VLPREMIO,
            :COBERP-PRMVG,
            :COBERP-PRMAP,
            :COBERP-IMPSEGCDG,
            :COBERP-VLCUSTCDG,
            :COBERP-VLCUSTCAP,
            :COBERP-IMPSEGAUXF:COBERP-IIMPSEGAUXF,
            :COBERP-VLCUSTAUXF:COBERP-IVLCUSTAUXF,
            :COBERP-QTTITCAP:COBERP-IQTTITCAP
            FROM SEGUROS.V0COBERPROPVA
            WHERE NRCERTIF = :PROPVA-NRCERTIF
            AND OCORHIST = :PROPVA-OCORHIST
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DTINIVIG
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
											IMPSEGCDC
							,
											VLCUSTCDG
							,
											VLCUSTCAP
							,
											IMPSEGAUXF
							,
											VLCUSTAUXF
							,
											QTTITCAP
											FROM SEGUROS.V0COBERPROPVA
											WHERE NRCERTIF = '{this.PROPVA_NRCERTIF}'
											AND OCORHIST = '{this.PROPVA_OCORHIST}'
											WITH UR";

            return query;
        }
        public string COBERP_DTINIVIG { get; set; }
        public string COBERP_IMPMORNATU { get; set; }
        public string COBERP_IMPMORACID { get; set; }
        public string COBERP_IMPINVPERM { get; set; }
        public string COBERP_IMPAMDS { get; set; }
        public string COBERP_IMPDH { get; set; }
        public string COBERP_IMPDIT { get; set; }
        public string COBERP_VLPREMIO { get; set; }
        public string COBERP_PRMVG { get; set; }
        public string COBERP_PRMAP { get; set; }
        public string COBERP_IMPSEGCDG { get; set; }
        public string COBERP_VLCUSTCDG { get; set; }
        public string COBERP_VLCUSTCAP { get; set; }
        public string COBERP_IMPSEGAUXF { get; set; }
        public string COBERP_IIMPSEGAUXF { get; set; }
        public string COBERP_VLCUSTAUXF { get; set; }
        public string COBERP_IVLCUSTAUXF { get; set; }
        public string COBERP_QTTITCAP { get; set; }
        public string COBERP_IQTTITCAP { get; set; }
        public string PROPVA_NRCERTIF { get; set; }
        public string PROPVA_OCORHIST { get; set; }

        public static M_0100_OPCAOPAGVA_DB_SELECT_5_Query1 Execute(M_0100_OPCAOPAGVA_DB_SELECT_5_Query1 m_0100_OPCAOPAGVA_DB_SELECT_5_Query1)
        {
            var ths = m_0100_OPCAOPAGVA_DB_SELECT_5_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0100_OPCAOPAGVA_DB_SELECT_5_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0100_OPCAOPAGVA_DB_SELECT_5_Query1();
            var i = 0;
            dta.COBERP_DTINIVIG = result[i++].Value?.ToString();
            dta.COBERP_IMPMORNATU = result[i++].Value?.ToString();
            dta.COBERP_IMPMORACID = result[i++].Value?.ToString();
            dta.COBERP_IMPINVPERM = result[i++].Value?.ToString();
            dta.COBERP_IMPAMDS = result[i++].Value?.ToString();
            dta.COBERP_IMPDH = result[i++].Value?.ToString();
            dta.COBERP_IMPDIT = result[i++].Value?.ToString();
            dta.COBERP_VLPREMIO = result[i++].Value?.ToString();
            dta.COBERP_PRMVG = result[i++].Value?.ToString();
            dta.COBERP_PRMAP = result[i++].Value?.ToString();
            dta.COBERP_IMPSEGCDG = result[i++].Value?.ToString();
            dta.COBERP_VLCUSTCDG = result[i++].Value?.ToString();
            dta.COBERP_VLCUSTCAP = result[i++].Value?.ToString();
            dta.COBERP_IMPSEGAUXF = result[i++].Value?.ToString();
            dta.COBERP_IIMPSEGAUXF = string.IsNullOrWhiteSpace(dta.COBERP_IMPSEGAUXF) ? "-1" : "0";
            dta.COBERP_VLCUSTAUXF = result[i++].Value?.ToString();
            dta.COBERP_IVLCUSTAUXF = string.IsNullOrWhiteSpace(dta.COBERP_VLCUSTAUXF) ? "-1" : "0";
            dta.COBERP_QTTITCAP = result[i++].Value?.ToString();
            dta.COBERP_IQTTITCAP = string.IsNullOrWhiteSpace(dta.COBERP_QTTITCAP) ? "-1" : "0";
            return dta;
        }

    }
}