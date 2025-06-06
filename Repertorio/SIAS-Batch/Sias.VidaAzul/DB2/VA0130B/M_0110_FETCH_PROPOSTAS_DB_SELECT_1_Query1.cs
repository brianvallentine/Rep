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
    public class M_0110_FETCH_PROPOSTAS_DB_SELECT_1_Query1 : QueryBasis<M_0110_FETCH_PROPOSTAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT TEM_IGPM,
            TEM_FAIXAETA,
            RAMO,
            COBERADIC_PREMIO,
            CUSTOCAP_TOTAL,
            TEM_CDG,
            TEM_SAF,
            CODPRODU,
            NOMPRODU
            INTO :PRODVG-TEM-IGPM:VIND-TEM-IGPM,
            :PRODVG-TEM-FAIXAETA:VIND-TEM-FAIXAETA,
            :PRODVG-RAMO,
            :PRODVG-COBERADIC-PREMIO,
            :PRODVG-CUSTOCAP-TOTAL,
            :PRODVG-TEM-CDG:VIND-TEM-CDG,
            :PRODVG-TEM-SAF:VIND-TEM-SAF,
            :PRODVG-COD-PRODUTO,
            :PRODVG-NOME-PRODUTO
            FROM SEGUROS.V0PRODUTOSVG
            WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE
            AND CODSUBES = :PROPVA-CODSUBES
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT TEM_IGPM
							,
											TEM_FAIXAETA
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
											CODPRODU
							,
											NOMPRODU
											FROM SEGUROS.V0PRODUTOSVG
											WHERE NUM_APOLICE = '{this.PROPVA_NUM_APOLICE}'
											AND CODSUBES = '{this.PROPVA_CODSUBES}'
											WITH UR";

            return query;
        }
        public string PRODVG_TEM_IGPM { get; set; }
        public string VIND_TEM_IGPM { get; set; }
        public string PRODVG_TEM_FAIXAETA { get; set; }
        public string VIND_TEM_FAIXAETA { get; set; }
        public string PRODVG_RAMO { get; set; }
        public string PRODVG_COBERADIC_PREMIO { get; set; }
        public string PRODVG_CUSTOCAP_TOTAL { get; set; }
        public string PRODVG_TEM_CDG { get; set; }
        public string VIND_TEM_CDG { get; set; }
        public string PRODVG_TEM_SAF { get; set; }
        public string VIND_TEM_SAF { get; set; }
        public string PRODVG_COD_PRODUTO { get; set; }
        public string PRODVG_NOME_PRODUTO { get; set; }
        public string PROPVA_NUM_APOLICE { get; set; }
        public string PROPVA_CODSUBES { get; set; }

        public static M_0110_FETCH_PROPOSTAS_DB_SELECT_1_Query1 Execute(M_0110_FETCH_PROPOSTAS_DB_SELECT_1_Query1 m_0110_FETCH_PROPOSTAS_DB_SELECT_1_Query1)
        {
            var ths = m_0110_FETCH_PROPOSTAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0110_FETCH_PROPOSTAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0110_FETCH_PROPOSTAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.PRODVG_TEM_IGPM = result[i++].Value?.ToString();
            dta.VIND_TEM_IGPM = string.IsNullOrWhiteSpace(dta.PRODVG_TEM_IGPM) ? "-1" : "0";
            dta.PRODVG_TEM_FAIXAETA = result[i++].Value?.ToString();
            dta.VIND_TEM_FAIXAETA = string.IsNullOrWhiteSpace(dta.PRODVG_TEM_FAIXAETA) ? "-1" : "0";
            dta.PRODVG_RAMO = result[i++].Value?.ToString();
            dta.PRODVG_COBERADIC_PREMIO = result[i++].Value?.ToString();
            dta.PRODVG_CUSTOCAP_TOTAL = result[i++].Value?.ToString();
            dta.PRODVG_TEM_CDG = result[i++].Value?.ToString();
            dta.VIND_TEM_CDG = string.IsNullOrWhiteSpace(dta.PRODVG_TEM_CDG) ? "-1" : "0";
            dta.PRODVG_TEM_SAF = result[i++].Value?.ToString();
            dta.VIND_TEM_SAF = string.IsNullOrWhiteSpace(dta.PRODVG_TEM_SAF) ? "-1" : "0";
            dta.PRODVG_COD_PRODUTO = result[i++].Value?.ToString();
            dta.PRODVG_NOME_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}