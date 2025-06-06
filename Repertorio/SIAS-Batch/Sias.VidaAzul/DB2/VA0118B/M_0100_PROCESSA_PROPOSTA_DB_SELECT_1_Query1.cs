using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0118B
{
    public class M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1 : QueryBasis<M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CODPRODAZ,
            PERIPGTO,
            ESTR_COBR,
            ORIG_PRODU,
            COD_AGENCIADOR,
            TEM_SAF,
            TEM_CDG,
            CODRELAT,
            COBERADIC_PREMIO,
            CUSTOCAP_TOTAL,
            DESCONTO_ADESAO,
            CODPRODU,
            VALUE(RISCO, '1' ),
            SITPLANCEF,
            ARQ_FDCAP,
            COD_RUBRICA
            INTO :PRODVG-CODPRODAZ,
            :PRODVG-PERIPGTO,
            :PRODVG-ESTR-COBR :VIND-ESTR-COBR ,
            :PRODVG-ORIG-PRODU:VIND-ORIG-PRODU,
            :PRODVG-AGENCIADOR:VIND-AGENCIADOR,
            :PRODVG-TEM-SAF:VIND-TEM-SAF,
            :PRODVG-TEM-CDG:VIND-TEM-CDG,
            :PRODVG-CODRELAT:VIND-CODRELAT,
            :PRODVG-COBERADIC-PREMIO,
            :PRODVG-CUSTOCAP-TOTAL,
            :PRODVG-DESCONTO-ADESAO,
            :PRODVG-COD-PRODUTO,
            :PRODVG-RISCO,
            :PRODVG-SITPLANCEF,
            :PRODVG-ARQ-FDCAP:WS-IND-ARQFDCAP,
            :PRODVG-COD-RUBRICA:WS-IND-RUBRICA
            FROM SEGUROS.V0PRODUTOSVG
            WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE
            AND CODSUBES = :PROPVA-CODSUBES
            AND ESTR_EMISS = 'MULT'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CODPRODAZ
							,
											PERIPGTO
							,
											ESTR_COBR
							,
											ORIG_PRODU
							,
											COD_AGENCIADOR
							,
											TEM_SAF
							,
											TEM_CDG
							,
											CODRELAT
							,
											COBERADIC_PREMIO
							,
											CUSTOCAP_TOTAL
							,
											DESCONTO_ADESAO
							,
											CODPRODU
							,
											VALUE(RISCO
							, '1' )
							,
											SITPLANCEF
							,
											ARQ_FDCAP
							,
											COD_RUBRICA
											FROM SEGUROS.V0PRODUTOSVG
											WHERE NUM_APOLICE = '{this.PROPVA_NUM_APOLICE}'
											AND CODSUBES = '{this.PROPVA_CODSUBES}'
											AND ESTR_EMISS = 'MULT'
											WITH UR";

            return query;
        }
        public string PRODVG_CODPRODAZ { get; set; }
        public string PRODVG_PERIPGTO { get; set; }
        public string PRODVG_ESTR_COBR { get; set; }
        public string VIND_ESTR_COBR { get; set; }
        public string PRODVG_ORIG_PRODU { get; set; }
        public string VIND_ORIG_PRODU { get; set; }
        public string PRODVG_AGENCIADOR { get; set; }
        public string VIND_AGENCIADOR { get; set; }
        public string PRODVG_TEM_SAF { get; set; }
        public string VIND_TEM_SAF { get; set; }
        public string PRODVG_TEM_CDG { get; set; }
        public string VIND_TEM_CDG { get; set; }
        public string PRODVG_CODRELAT { get; set; }
        public string VIND_CODRELAT { get; set; }
        public string PRODVG_COBERADIC_PREMIO { get; set; }
        public string PRODVG_CUSTOCAP_TOTAL { get; set; }
        public string PRODVG_DESCONTO_ADESAO { get; set; }
        public string PRODVG_COD_PRODUTO { get; set; }
        public string PRODVG_RISCO { get; set; }
        public string PRODVG_SITPLANCEF { get; set; }
        public string PRODVG_ARQ_FDCAP { get; set; }
        public string WS_IND_ARQFDCAP { get; set; }
        public string PRODVG_COD_RUBRICA { get; set; }
        public string WS_IND_RUBRICA { get; set; }
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
            dta.PRODVG_CODPRODAZ = result[i++].Value?.ToString();
            dta.PRODVG_PERIPGTO = result[i++].Value?.ToString();
            dta.PRODVG_ESTR_COBR = result[i++].Value?.ToString();
            dta.VIND_ESTR_COBR = string.IsNullOrWhiteSpace(dta.PRODVG_ESTR_COBR) ? "-1" : "0";
            dta.PRODVG_ORIG_PRODU = result[i++].Value?.ToString();
            dta.VIND_ORIG_PRODU = string.IsNullOrWhiteSpace(dta.PRODVG_ORIG_PRODU) ? "-1" : "0";
            dta.PRODVG_AGENCIADOR = result[i++].Value?.ToString();
            dta.VIND_AGENCIADOR = string.IsNullOrWhiteSpace(dta.PRODVG_AGENCIADOR) ? "-1" : "0";
            dta.PRODVG_TEM_SAF = result[i++].Value?.ToString();
            dta.VIND_TEM_SAF = string.IsNullOrWhiteSpace(dta.PRODVG_TEM_SAF) ? "-1" : "0";
            dta.PRODVG_TEM_CDG = result[i++].Value?.ToString();
            dta.VIND_TEM_CDG = string.IsNullOrWhiteSpace(dta.PRODVG_TEM_CDG) ? "-1" : "0";
            dta.PRODVG_CODRELAT = result[i++].Value?.ToString();
            dta.VIND_CODRELAT = string.IsNullOrWhiteSpace(dta.PRODVG_CODRELAT) ? "-1" : "0";
            dta.PRODVG_COBERADIC_PREMIO = result[i++].Value?.ToString();
            dta.PRODVG_CUSTOCAP_TOTAL = result[i++].Value?.ToString();
            dta.PRODVG_DESCONTO_ADESAO = result[i++].Value?.ToString();
            dta.PRODVG_COD_PRODUTO = result[i++].Value?.ToString();
            dta.PRODVG_RISCO = result[i++].Value?.ToString();
            dta.PRODVG_SITPLANCEF = result[i++].Value?.ToString();
            dta.PRODVG_ARQ_FDCAP = result[i++].Value?.ToString();
            dta.WS_IND_ARQFDCAP = string.IsNullOrWhiteSpace(dta.PRODVG_ARQ_FDCAP) ? "-1" : "0";
            dta.PRODVG_COD_RUBRICA = result[i++].Value?.ToString();
            dta.WS_IND_RUBRICA = string.IsNullOrWhiteSpace(dta.PRODVG_COD_RUBRICA) ? "-1" : "0";
            return dta;
        }

    }
}