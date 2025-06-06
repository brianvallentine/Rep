using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0128B
{
    public class M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1 : QueryBasis<M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT TEM_IGPM,
            RAMO,
            COBERADIC_PREMIO,
            CUSTOCAP_TOTAL,
            TEM_CDG,
            TEM_SAF,
            VALUE(ORIG_PRODU, '****' ),
            VALUE(ESTR_COBR, 'XXXX' )
            INTO :PRODVG-TEM-IGPM:VIND-TEM-IGPM,
            :PRODVG-RAMO,
            :PRODVG-COBERADIC-PREMIO,
            :PRODVG-CUSTOCAP-TOTAL,
            :PRODVG-TEM-CDG:VIND-TEM-CDG,
            :PRODVG-TEM-SAF:VIND-TEM-SAF,
            :PRODVG-ORIG-PRODU,
            :PRODVG-ESTR-COBR
            FROM SEGUROS.V0PRODUTOSVG
            WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE
            AND CODSUBES = :PROPVA-CODSUBES
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT TEM_IGPM
							,
											RAMO
							,
											COBERADIC_PREMIO
							,
											CUSTOCAP_TOTAL
							,
											TEM_CDG
							,
											TEM_SAF
							,
											VALUE(ORIG_PRODU
							, '****' )
							,
											VALUE(ESTR_COBR
							, 'XXXX' )
											FROM SEGUROS.V0PRODUTOSVG
											WHERE NUM_APOLICE = '{this.PROPVA_NUM_APOLICE}'
											AND CODSUBES = '{this.PROPVA_CODSUBES}'";

            return query;
        }
        public string PRODVG_TEM_IGPM { get; set; }
        public string VIND_TEM_IGPM { get; set; }
        public string PRODVG_RAMO { get; set; }
        public string PRODVG_COBERADIC_PREMIO { get; set; }
        public string PRODVG_CUSTOCAP_TOTAL { get; set; }
        public string PRODVG_TEM_CDG { get; set; }
        public string VIND_TEM_CDG { get; set; }
        public string PRODVG_TEM_SAF { get; set; }
        public string VIND_TEM_SAF { get; set; }
        public string PRODVG_ORIG_PRODU { get; set; }
        public string PRODVG_ESTR_COBR { get; set; }
        public string PROPVA_NUM_APOLICE { get; set; }
        public string PROPVA_CODSUBES { get; set; }

        public static M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1 Execute(M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1 m_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1)
        {
            var ths = m_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1();
            var i = 0;
            dta.PRODVG_TEM_IGPM = result[i++].Value?.ToString();
            dta.VIND_TEM_IGPM = string.IsNullOrWhiteSpace(dta.PRODVG_TEM_IGPM) ? "-1" : "0";
            dta.PRODVG_RAMO = result[i++].Value?.ToString();
            dta.PRODVG_COBERADIC_PREMIO = result[i++].Value?.ToString();
            dta.PRODVG_CUSTOCAP_TOTAL = result[i++].Value?.ToString();
            dta.PRODVG_TEM_CDG = result[i++].Value?.ToString();
            dta.VIND_TEM_CDG = string.IsNullOrWhiteSpace(dta.PRODVG_TEM_CDG) ? "-1" : "0";
            dta.PRODVG_TEM_SAF = result[i++].Value?.ToString();
            dta.VIND_TEM_SAF = string.IsNullOrWhiteSpace(dta.PRODVG_TEM_SAF) ? "-1" : "0";
            dta.PRODVG_ORIG_PRODU = result[i++].Value?.ToString();
            dta.PRODVG_ESTR_COBR = result[i++].Value?.ToString();
            return dta;
        }

    }
}