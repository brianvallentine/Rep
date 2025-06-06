using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SISAP03B
{
    public class R1000_LE_RESSARCIMENTO_SAP_DB_SELECT_1_Query1 : QueryBasis<R1000_LE_RESSARCIMENTO_SAP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            NUM_OCORR_MOVTO ,
            NUM_APOL_SINISTRO ,
            COD_OPERACAO ,
            NUM_OCORR_HISTORICO,
            NUM_RESSARC ,
            SEQ_RESSARC ,
            NUM_PARCELA ,
            NUM_NOSSO_TITULO ,
            NSAS ,
            IDE_SISTEMA ,
            DTH_CADASTRAMENTO
            INTO
            :GE098-NUM-OCORR-MOVTO ,
            :GE098-NUM-APOL-SINISTRO ,
            :GE098-COD-OPERACAO ,
            :GE098-NUM-OCORR-HISTORICO ,
            :GE098-NUM-RESSARC ,
            :GE098-SEQ-RESSARC ,
            :GE098-NUM-PARCELA ,
            :GE098-NUM-NOSSO-TITULO ,
            :GE098-NSAS ,
            :GE098-IDE-SISTEMA ,
            :GE098-DTH-CADASTRAMENTO
            FROM SEGUROS.GE_BOLETO_RESSARC_SINI
            WHERE NUM_OCORR_MOVTO = :GE100-NUM-OCORR-MOVTO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NUM_OCORR_MOVTO 
							,
											NUM_APOL_SINISTRO 
							,
											COD_OPERACAO 
							,
											NUM_OCORR_HISTORICO
							,
											NUM_RESSARC 
							,
											SEQ_RESSARC 
							,
											NUM_PARCELA 
							,
											NUM_NOSSO_TITULO 
							,
											NSAS 
							,
											IDE_SISTEMA 
							,
											DTH_CADASTRAMENTO
											FROM SEGUROS.GE_BOLETO_RESSARC_SINI
											WHERE NUM_OCORR_MOVTO = '{this.GE100_NUM_OCORR_MOVTO}'";

            return query;
        }
        public string GE098_NUM_OCORR_MOVTO { get; set; }
        public string GE098_NUM_APOL_SINISTRO { get; set; }
        public string GE098_COD_OPERACAO { get; set; }
        public string GE098_NUM_OCORR_HISTORICO { get; set; }
        public string GE098_NUM_RESSARC { get; set; }
        public string GE098_SEQ_RESSARC { get; set; }
        public string GE098_NUM_PARCELA { get; set; }
        public string GE098_NUM_NOSSO_TITULO { get; set; }
        public string GE098_NSAS { get; set; }
        public string GE098_IDE_SISTEMA { get; set; }
        public string GE098_DTH_CADASTRAMENTO { get; set; }
        public string GE100_NUM_OCORR_MOVTO { get; set; }

        public static R1000_LE_RESSARCIMENTO_SAP_DB_SELECT_1_Query1 Execute(R1000_LE_RESSARCIMENTO_SAP_DB_SELECT_1_Query1 r1000_LE_RESSARCIMENTO_SAP_DB_SELECT_1_Query1)
        {
            var ths = r1000_LE_RESSARCIMENTO_SAP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_LE_RESSARCIMENTO_SAP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_LE_RESSARCIMENTO_SAP_DB_SELECT_1_Query1();
            var i = 0;
            dta.GE098_NUM_OCORR_MOVTO = result[i++].Value?.ToString();
            dta.GE098_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.GE098_COD_OPERACAO = result[i++].Value?.ToString();
            dta.GE098_NUM_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.GE098_NUM_RESSARC = result[i++].Value?.ToString();
            dta.GE098_SEQ_RESSARC = result[i++].Value?.ToString();
            dta.GE098_NUM_PARCELA = result[i++].Value?.ToString();
            dta.GE098_NUM_NOSSO_TITULO = result[i++].Value?.ToString();
            dta.GE098_NSAS = result[i++].Value?.ToString();
            dta.GE098_IDE_SISTEMA = result[i++].Value?.ToString();
            dta.GE098_DTH_CADASTRAMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}