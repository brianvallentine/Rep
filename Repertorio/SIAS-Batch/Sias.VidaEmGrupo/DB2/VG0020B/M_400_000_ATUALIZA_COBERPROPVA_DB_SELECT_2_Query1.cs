using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0020B
{
    public class M_400_000_ATUALIZA_COBERPROPVA_DB_SELECT_2_Query1 : QueryBasis<M_400_000_ATUALIZA_COBERPROPVA_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            DTINIVIG ,
            DTTERVIG ,
            IMPSEGUR ,
            QUANT_VIDAS,
            IMPSEGIND ,
            CODOPER ,
            OPCAO_COBER,
            IMPMORNATU ,
            IMPMORACID ,
            IMPINVPERM ,
            IMPAMDS ,
            IMPDH ,
            IMPDIT ,
            VLPREMIO ,
            PRMVG ,
            PRMAP ,
            QTTITCAP ,
            VLTITCAP ,
            VLCUSTCAP ,
            IMPSEGCDC ,
            VLCUSTCDG ,
            IMPSEGAUXF ,
            VLCUSTAUXF ,
            PRMDIT ,
            QTDIT
            INTO
            :V0COBP-DTINIVIG ,
            :V0COBP-DTTERVIG ,
            :V0COBP-IMPSEGUR ,
            :V0COBP-QUANT-VIDAS,
            :V0COBP-IMPSEGIND ,
            :V0COBP-CODOPER ,
            :V0COBP-OPCAO-COBER,
            :V0COBP-IMPMORNATU ,
            :V0COBP-IMPMORACID ,
            :V0COBP-IMPINVPERM ,
            :V0COBP-IMPAMDS ,
            :V0COBP-IMPDH ,
            :V0COBP-IMPDIT ,
            :V0COBP-VLPREMIO ,
            :V0COBP-PRMVG ,
            :V0COBP-PRMAP ,
            :V0COBP-QTTITCAP ,
            :V0COBP-VLTITCAP ,
            :V0COBP-VLCUSTCAP ,
            :V0COBP-IMPSEGCDC ,
            :V0COBP-VLCUSTCDG ,
            :V0COBP-IMPSEGAUXF
            :V0COBP-IMPSEGAUXF-I,
            :V0COBP-VLCUSTAUXF
            :V0COBP-VLCUSTAUXF-I,
            :V0COBP-PRMDIT
            :V0COBP-PRMDIT-I,
            :V0COBP-QTDIT
            :V0COBP-QTDIT-I
            FROM SEGUROS.V0COBERPROPVA
            WHERE NRCERTIF = :MNUM-CERTIFICADO
            AND OCORHIST = :V0PROP-OCORHIST
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
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
											WHERE NRCERTIF = '{this.MNUM_CERTIFICADO}'
											AND OCORHIST = '{this.V0PROP_OCORHIST}'
											WITH UR";

            return query;
        }
        public string V0COBP_DTINIVIG { get; set; }
        public string V0COBP_DTTERVIG { get; set; }
        public string V0COBP_IMPSEGUR { get; set; }
        public string V0COBP_QUANT_VIDAS { get; set; }
        public string V0COBP_IMPSEGIND { get; set; }
        public string V0COBP_CODOPER { get; set; }
        public string V0COBP_OPCAO_COBER { get; set; }
        public string V0COBP_IMPMORNATU { get; set; }
        public string V0COBP_IMPMORACID { get; set; }
        public string V0COBP_IMPINVPERM { get; set; }
        public string V0COBP_IMPAMDS { get; set; }
        public string V0COBP_IMPDH { get; set; }
        public string V0COBP_IMPDIT { get; set; }
        public string V0COBP_VLPREMIO { get; set; }
        public string V0COBP_PRMVG { get; set; }
        public string V0COBP_PRMAP { get; set; }
        public string V0COBP_QTTITCAP { get; set; }
        public string V0COBP_VLTITCAP { get; set; }
        public string V0COBP_VLCUSTCAP { get; set; }
        public string V0COBP_IMPSEGCDC { get; set; }
        public string V0COBP_VLCUSTCDG { get; set; }
        public string V0COBP_IMPSEGAUXF { get; set; }
        public string V0COBP_IMPSEGAUXF_I { get; set; }
        public string V0COBP_VLCUSTAUXF { get; set; }
        public string V0COBP_VLCUSTAUXF_I { get; set; }
        public string V0COBP_PRMDIT { get; set; }
        public string V0COBP_PRMDIT_I { get; set; }
        public string V0COBP_QTDIT { get; set; }
        public string V0COBP_QTDIT_I { get; set; }
        public string MNUM_CERTIFICADO { get; set; }
        public string V0PROP_OCORHIST { get; set; }

        public static M_400_000_ATUALIZA_COBERPROPVA_DB_SELECT_2_Query1 Execute(M_400_000_ATUALIZA_COBERPROPVA_DB_SELECT_2_Query1 m_400_000_ATUALIZA_COBERPROPVA_DB_SELECT_2_Query1)
        {
            var ths = m_400_000_ATUALIZA_COBERPROPVA_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_400_000_ATUALIZA_COBERPROPVA_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_400_000_ATUALIZA_COBERPROPVA_DB_SELECT_2_Query1();
            var i = 0;
            dta.V0COBP_DTINIVIG = result[i++].Value?.ToString();
            dta.V0COBP_DTTERVIG = result[i++].Value?.ToString();
            dta.V0COBP_IMPSEGUR = result[i++].Value?.ToString();
            dta.V0COBP_QUANT_VIDAS = result[i++].Value?.ToString();
            dta.V0COBP_IMPSEGIND = result[i++].Value?.ToString();
            dta.V0COBP_CODOPER = result[i++].Value?.ToString();
            dta.V0COBP_OPCAO_COBER = result[i++].Value?.ToString();
            dta.V0COBP_IMPMORNATU = result[i++].Value?.ToString();
            dta.V0COBP_IMPMORACID = result[i++].Value?.ToString();
            dta.V0COBP_IMPINVPERM = result[i++].Value?.ToString();
            dta.V0COBP_IMPAMDS = result[i++].Value?.ToString();
            dta.V0COBP_IMPDH = result[i++].Value?.ToString();
            dta.V0COBP_IMPDIT = result[i++].Value?.ToString();
            dta.V0COBP_VLPREMIO = result[i++].Value?.ToString();
            dta.V0COBP_PRMVG = result[i++].Value?.ToString();
            dta.V0COBP_PRMAP = result[i++].Value?.ToString();
            dta.V0COBP_QTTITCAP = result[i++].Value?.ToString();
            dta.V0COBP_VLTITCAP = result[i++].Value?.ToString();
            dta.V0COBP_VLCUSTCAP = result[i++].Value?.ToString();
            dta.V0COBP_IMPSEGCDC = result[i++].Value?.ToString();
            dta.V0COBP_VLCUSTCDG = result[i++].Value?.ToString();
            dta.V0COBP_IMPSEGAUXF = result[i++].Value?.ToString();
            dta.V0COBP_IMPSEGAUXF_I = string.IsNullOrWhiteSpace(dta.V0COBP_IMPSEGAUXF) ? "-1" : "0";
            dta.V0COBP_VLCUSTAUXF = result[i++].Value?.ToString();
            dta.V0COBP_VLCUSTAUXF_I = string.IsNullOrWhiteSpace(dta.V0COBP_VLCUSTAUXF) ? "-1" : "0";
            dta.V0COBP_PRMDIT = result[i++].Value?.ToString();
            dta.V0COBP_PRMDIT_I = string.IsNullOrWhiteSpace(dta.V0COBP_PRMDIT) ? "-1" : "0";
            dta.V0COBP_QTDIT = result[i++].Value?.ToString();
            dta.V0COBP_QTDIT_I = string.IsNullOrWhiteSpace(dta.V0COBP_QTDIT) ? "-1" : "0";
            return dta;
        }

    }
}