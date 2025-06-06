using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1613B
{
    public class R3210_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1 : QueryBasis<R3210_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_FONTE,
            TIPO_PLANO,
            FORMA_AVERBACAO,
            TIPO_FATURAMENTO,
            PERI_FATURAMENTO,
            PERI_RENOVACAO,
            BCO_COBRANCA,
            AGE_COBRANCA,
            DAC_COBRANCA,
            PCT_CONJUGE_VG,
            PCT_CONJUGE_AP,
            IND_PLANO_ASSOCIA,
            TIPO_COBRANCA,
            COD_CLIENTE,
            OCORR_ENDERECO
            INTO :SUBGVGAP-COD-FONTE,
            :SUBGVGAP-TIPO-PLANO,
            :SUBGVGAP-FORMA-AVERBACAO,
            :SUBGVGAP-TIPO-FATURAMENTO,
            :SUBGVGAP-PERI-FATURAMENTO,
            :SUBGVGAP-PERI-RENOVACAO,
            :SUBGVGAP-BCO-COBRANCA,
            :SUBGVGAP-AGE-COBRANCA,
            :SUBGVGAP-DAC-COBRANCA,
            :SUBGVGAP-PCT-CONJUGE-VG,
            :SUBGVGAP-PCT-CONJUGE-AP,
            :SUBGVGAP-IND-PLANO-ASSOCIA,
            :SUBGVGAP-TIPO-COBRANCA,
            :SUBGVGAP-COD-CLIENTE,
            :SUBGVGAP-OCORR-ENDERECO
            FROM SEGUROS.SUBGRUPOS_VGAP
            WHERE NUM_APOLICE = :SUBGVGAP-NUM-APOLICE
            AND COD_SUBGRUPO = :SUBGVGAP-COD-SUBGRUPO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_FONTE
							,
											TIPO_PLANO
							,
											FORMA_AVERBACAO
							,
											TIPO_FATURAMENTO
							,
											PERI_FATURAMENTO
							,
											PERI_RENOVACAO
							,
											BCO_COBRANCA
							,
											AGE_COBRANCA
							,
											DAC_COBRANCA
							,
											PCT_CONJUGE_VG
							,
											PCT_CONJUGE_AP
							,
											IND_PLANO_ASSOCIA
							,
											TIPO_COBRANCA
							,
											COD_CLIENTE
							,
											OCORR_ENDERECO
											FROM SEGUROS.SUBGRUPOS_VGAP
											WHERE NUM_APOLICE = '{this.SUBGVGAP_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.SUBGVGAP_COD_SUBGRUPO}'
											WITH UR";

            return query;
        }
        public string SUBGVGAP_COD_FONTE { get; set; }
        public string SUBGVGAP_TIPO_PLANO { get; set; }
        public string SUBGVGAP_FORMA_AVERBACAO { get; set; }
        public string SUBGVGAP_TIPO_FATURAMENTO { get; set; }
        public string SUBGVGAP_PERI_FATURAMENTO { get; set; }
        public string SUBGVGAP_PERI_RENOVACAO { get; set; }
        public string SUBGVGAP_BCO_COBRANCA { get; set; }
        public string SUBGVGAP_AGE_COBRANCA { get; set; }
        public string SUBGVGAP_DAC_COBRANCA { get; set; }
        public string SUBGVGAP_PCT_CONJUGE_VG { get; set; }
        public string SUBGVGAP_PCT_CONJUGE_AP { get; set; }
        public string SUBGVGAP_IND_PLANO_ASSOCIA { get; set; }
        public string SUBGVGAP_TIPO_COBRANCA { get; set; }
        public string SUBGVGAP_COD_CLIENTE { get; set; }
        public string SUBGVGAP_OCORR_ENDERECO { get; set; }
        public string SUBGVGAP_COD_SUBGRUPO { get; set; }
        public string SUBGVGAP_NUM_APOLICE { get; set; }

        public static R3210_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1 Execute(R3210_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1 r3210_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1)
        {
            var ths = r3210_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3210_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3210_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1();
            var i = 0;
            dta.SUBGVGAP_COD_FONTE = result[i++].Value?.ToString();
            dta.SUBGVGAP_TIPO_PLANO = result[i++].Value?.ToString();
            dta.SUBGVGAP_FORMA_AVERBACAO = result[i++].Value?.ToString();
            dta.SUBGVGAP_TIPO_FATURAMENTO = result[i++].Value?.ToString();
            dta.SUBGVGAP_PERI_FATURAMENTO = result[i++].Value?.ToString();
            dta.SUBGVGAP_PERI_RENOVACAO = result[i++].Value?.ToString();
            dta.SUBGVGAP_BCO_COBRANCA = result[i++].Value?.ToString();
            dta.SUBGVGAP_AGE_COBRANCA = result[i++].Value?.ToString();
            dta.SUBGVGAP_DAC_COBRANCA = result[i++].Value?.ToString();
            dta.SUBGVGAP_PCT_CONJUGE_VG = result[i++].Value?.ToString();
            dta.SUBGVGAP_PCT_CONJUGE_AP = result[i++].Value?.ToString();
            dta.SUBGVGAP_IND_PLANO_ASSOCIA = result[i++].Value?.ToString();
            dta.SUBGVGAP_TIPO_COBRANCA = result[i++].Value?.ToString();
            dta.SUBGVGAP_COD_CLIENTE = result[i++].Value?.ToString();
            dta.SUBGVGAP_OCORR_ENDERECO = result[i++].Value?.ToString();
            return dta;
        }

    }
}