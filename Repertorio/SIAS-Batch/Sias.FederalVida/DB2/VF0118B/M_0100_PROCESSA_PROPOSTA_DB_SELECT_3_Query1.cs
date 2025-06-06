using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0118B
{
    public class M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1 : QueryBasis<M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IMPMORNATU,
            IMPMORACID,
            IMPINVPERM,
            IMPDIT,
            VLPREMIO,
            PRMVG,
            PRMAP,
            IMPSEGAUXF,
            VLCUSTAUXF
            INTO :COBERP-IMPMORNATU,
            :COBERP-IMPMORACID,
            :COBERP-IMPINVPERM,
            :COBERP-IMPDIT,
            :COBERP-VLPREMIO,
            :COBERP-PRMVG,
            :COBERP-PRMAP,
            :COBERP-IMPSEGAUXF:COBERP-IIMPSEGAUXF,
            :COBERP-VLCUSTAUXF:COBERP-IVLCUSTAUXF
            FROM SEGUROS.V0COBERPROPVA
            WHERE NRCERTIF = :PROPVA-NRCERTIF
            AND OCORHIST = 1
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT IMPMORNATU
							,
											IMPMORACID
							,
											IMPINVPERM
							,
											IMPDIT
							,
											VLPREMIO
							,
											PRMVG
							,
											PRMAP
							,
											IMPSEGAUXF
							,
											VLCUSTAUXF
											FROM SEGUROS.V0COBERPROPVA
											WHERE NRCERTIF = '{this.PROPVA_NRCERTIF}'
											AND OCORHIST = 1";

            return query;
        }
        public string COBERP_IMPMORNATU { get; set; }
        public string COBERP_IMPMORACID { get; set; }
        public string COBERP_IMPINVPERM { get; set; }
        public string COBERP_IMPDIT { get; set; }
        public string COBERP_VLPREMIO { get; set; }
        public string COBERP_PRMVG { get; set; }
        public string COBERP_PRMAP { get; set; }
        public string COBERP_IMPSEGAUXF { get; set; }
        public string COBERP_IIMPSEGAUXF { get; set; }
        public string COBERP_VLCUSTAUXF { get; set; }
        public string COBERP_IVLCUSTAUXF { get; set; }
        public string PROPVA_NRCERTIF { get; set; }

        public static M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1 Execute(M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1 m_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1)
        {
            var ths = m_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1();
            var i = 0;
            dta.COBERP_IMPMORNATU = result[i++].Value?.ToString();
            dta.COBERP_IMPMORACID = result[i++].Value?.ToString();
            dta.COBERP_IMPINVPERM = result[i++].Value?.ToString();
            dta.COBERP_IMPDIT = result[i++].Value?.ToString();
            dta.COBERP_VLPREMIO = result[i++].Value?.ToString();
            dta.COBERP_PRMVG = result[i++].Value?.ToString();
            dta.COBERP_PRMAP = result[i++].Value?.ToString();
            dta.COBERP_IMPSEGAUXF = result[i++].Value?.ToString();
            dta.COBERP_IIMPSEGAUXF = string.IsNullOrWhiteSpace(dta.COBERP_IMPSEGAUXF) ? "-1" : "0";
            dta.COBERP_VLCUSTAUXF = result[i++].Value?.ToString();
            dta.COBERP_IVLCUSTAUXF = string.IsNullOrWhiteSpace(dta.COBERP_VLCUSTAUXF) ? "-1" : "0";
            return dta;
        }

    }
}