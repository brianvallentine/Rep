using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1601B
{
    public class M_120_000_ACESSA_V1SUBGRUPO_DB_SELECT_1_Query1 : QueryBasis<M_120_000_ACESSA_V1SUBGRUPO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_FONTE,
            TIPO_PLANO,
            FORMA_AVERBACAO,
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
            INTO :SUBG-COD-FONTE,
            :SUBG-TIPO-PLANO,
            :SUBG-FORMA-AVERBA,
            :SUBG-PERI-FATURAMENTO,
            :SUBG-PERI-RENOVACAO,
            :SUBG-BCO-COBRANCA,
            :SUBG-AGE-COBRANCA,
            :SUBG-DAC-COBRANCA,
            :SUBG-PCT-CONJUGE-VG,
            :SUBG-PCT-CONJUGE-AP,
            :SUBG-PLANO-ASSOCIA,
            :SUBG-TIPO-COBRANCA,
            :SUBG-COD-CLIENTE,
            :SUBG-OCORR-ENDERECO
            FROM SEGUROS.V1SUBGRUPO
            WHERE NUM_APOLICE = :SUBG-NUM-APOLICE
            AND COD_SUBGRUPO = :SUBG-COD-SUBGRUPO
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
											FROM SEGUROS.V1SUBGRUPO
											WHERE NUM_APOLICE = '{this.SUBG_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.SUBG_COD_SUBGRUPO}'";

            return query;
        }
        public string SUBG_COD_FONTE { get; set; }
        public string SUBG_TIPO_PLANO { get; set; }
        public string SUBG_FORMA_AVERBA { get; set; }
        public string SUBG_PERI_FATURAMENTO { get; set; }
        public string SUBG_PERI_RENOVACAO { get; set; }
        public string SUBG_BCO_COBRANCA { get; set; }
        public string SUBG_AGE_COBRANCA { get; set; }
        public string SUBG_DAC_COBRANCA { get; set; }
        public string SUBG_PCT_CONJUGE_VG { get; set; }
        public string SUBG_PCT_CONJUGE_AP { get; set; }
        public string SUBG_PLANO_ASSOCIA { get; set; }
        public string SUBG_TIPO_COBRANCA { get; set; }
        public string SUBG_COD_CLIENTE { get; set; }
        public string SUBG_OCORR_ENDERECO { get; set; }
        public string SUBG_COD_SUBGRUPO { get; set; }
        public string SUBG_NUM_APOLICE { get; set; }

        public static M_120_000_ACESSA_V1SUBGRUPO_DB_SELECT_1_Query1 Execute(M_120_000_ACESSA_V1SUBGRUPO_DB_SELECT_1_Query1 m_120_000_ACESSA_V1SUBGRUPO_DB_SELECT_1_Query1)
        {
            var ths = m_120_000_ACESSA_V1SUBGRUPO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_120_000_ACESSA_V1SUBGRUPO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_120_000_ACESSA_V1SUBGRUPO_DB_SELECT_1_Query1();
            var i = 0;
            dta.SUBG_COD_FONTE = result[i++].Value?.ToString();
            dta.SUBG_TIPO_PLANO = result[i++].Value?.ToString();
            dta.SUBG_FORMA_AVERBA = result[i++].Value?.ToString();
            dta.SUBG_PERI_FATURAMENTO = result[i++].Value?.ToString();
            dta.SUBG_PERI_RENOVACAO = result[i++].Value?.ToString();
            dta.SUBG_BCO_COBRANCA = result[i++].Value?.ToString();
            dta.SUBG_AGE_COBRANCA = result[i++].Value?.ToString();
            dta.SUBG_DAC_COBRANCA = result[i++].Value?.ToString();
            dta.SUBG_PCT_CONJUGE_VG = result[i++].Value?.ToString();
            dta.SUBG_PCT_CONJUGE_AP = result[i++].Value?.ToString();
            dta.SUBG_PLANO_ASSOCIA = result[i++].Value?.ToString();
            dta.SUBG_TIPO_COBRANCA = result[i++].Value?.ToString();
            dta.SUBG_COD_CLIENTE = result[i++].Value?.ToString();
            dta.SUBG_OCORR_ENDERECO = result[i++].Value?.ToString();
            return dta;
        }

    }
}