using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0070B
{
    public class R0600_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 : QueryBasis<R0600_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE
            ,RAMO_EMISSOR
            ,COD_PRODUTO
            ,COD_SUBGRUPO
            ,COD_FONTE
            ,DATA_PROPOSTA
            ,DATA_LIBERACAO
            ,BCO_COBRANCA
            ,AGE_COBRANCA
            ,DAC_COBRANCA
            ,PLANO_SEGURO
            ,PCT_ENTRADA
            ,PCT_ADIC_FRACIO
            ,QTD_DIAS_PRIMEIRA
            ,QTD_PARCELAS
            ,QTD_PRESTACOES
            ,QTD_ITENS
            ,COD_TEXTO_PADRAO
            ,COD_ACEITACAO
            ,COD_MOEDA_IMP
            ,COD_MOEDA_PRM
            ,TIPO_ENDOSSO
            ,OCORR_ENDERECO
            ,COD_EMPRESA
            ,TIPO_CORRECAO
            ,ISENTA_CUSTO
            ,COEF_PREFIX
            ,VAL_CUSTO_EMISSAO
            INTO :ENDOSSOS-NUM-APOLICE
            ,:ENDOSSOS-RAMO-EMISSOR
            ,:ENDOSSOS-COD-PRODUTO
            ,:ENDOSSOS-COD-SUBGRUPO
            ,:ENDOSSOS-COD-FONTE
            ,:ENDOSSOS-DATA-PROPOSTA
            ,:ENDOSSOS-DATA-LIBERACAO
            ,:ENDOSSOS-BCO-COBRANCA
            ,:ENDOSSOS-AGE-COBRANCA
            ,:ENDOSSOS-DAC-COBRANCA
            ,:ENDOSSOS-PLANO-SEGURO
            ,:ENDOSSOS-PCT-ENTRADA
            ,:ENDOSSOS-PCT-ADIC-FRACIO
            ,:ENDOSSOS-QTD-DIAS-PRIMEIRA
            ,:ENDOSSOS-QTD-PARCELAS
            ,:ENDOSSOS-QTD-PRESTACOES
            ,:ENDOSSOS-QTD-ITENS
            ,:ENDOSSOS-COD-TEXTO-PADRAO
            ,:ENDOSSOS-COD-ACEITACAO
            ,:ENDOSSOS-COD-MOEDA-IMP
            ,:ENDOSSOS-COD-MOEDA-PRM
            ,:ENDOSSOS-TIPO-ENDOSSO
            ,:ENDOSSOS-OCORR-ENDERECO
            ,:ENDOSSOS-COD-EMPRESA:VIND-COD-EMPRESA
            ,:ENDOSSOS-TIPO-CORRECAO:VIND-TIPO-CORRECAO
            ,:ENDOSSOS-ISENTA-CUSTO:VIND-ISENTA-CUSTO
            ,:ENDOSSOS-COEF-PREFIX:VIND-COEF-PREFIX
            ,:ENDOSSOS-VAL-CUSTO-EMISSAO:VIND-VAL-CUSTO
            FROM SEGUROS.ENDOSSOS
            WHERE NUM_APOLICE = :MOVDEBCE-NUM-APOLICE
            AND NUM_ENDOSSO = :WHOST-NUM-ENDOSSO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE
											,RAMO_EMISSOR
											,COD_PRODUTO
											,COD_SUBGRUPO
											,COD_FONTE
											,DATA_PROPOSTA
											,DATA_LIBERACAO
											,BCO_COBRANCA
											,AGE_COBRANCA
											,DAC_COBRANCA
											,PLANO_SEGURO
											,PCT_ENTRADA
											,PCT_ADIC_FRACIO
											,QTD_DIAS_PRIMEIRA
											,QTD_PARCELAS
											,QTD_PRESTACOES
											,QTD_ITENS
											,COD_TEXTO_PADRAO
											,COD_ACEITACAO
											,COD_MOEDA_IMP
											,COD_MOEDA_PRM
											,TIPO_ENDOSSO
											,OCORR_ENDERECO
											,COD_EMPRESA
											,TIPO_CORRECAO
											,ISENTA_CUSTO
											,COEF_PREFIX
											,VAL_CUSTO_EMISSAO
											FROM SEGUROS.ENDOSSOS
											WHERE NUM_APOLICE = '{this.MOVDEBCE_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.WHOST_NUM_ENDOSSO}'
											WITH UR";

            return query;
        }
        public string ENDOSSOS_NUM_APOLICE { get; set; }
        public string ENDOSSOS_RAMO_EMISSOR { get; set; }
        public string ENDOSSOS_COD_PRODUTO { get; set; }
        public string ENDOSSOS_COD_SUBGRUPO { get; set; }
        public string ENDOSSOS_COD_FONTE { get; set; }
        public string ENDOSSOS_DATA_PROPOSTA { get; set; }
        public string ENDOSSOS_DATA_LIBERACAO { get; set; }
        public string ENDOSSOS_BCO_COBRANCA { get; set; }
        public string ENDOSSOS_AGE_COBRANCA { get; set; }
        public string ENDOSSOS_DAC_COBRANCA { get; set; }
        public string ENDOSSOS_PLANO_SEGURO { get; set; }
        public string ENDOSSOS_PCT_ENTRADA { get; set; }
        public string ENDOSSOS_PCT_ADIC_FRACIO { get; set; }
        public string ENDOSSOS_QTD_DIAS_PRIMEIRA { get; set; }
        public string ENDOSSOS_QTD_PARCELAS { get; set; }
        public string ENDOSSOS_QTD_PRESTACOES { get; set; }
        public string ENDOSSOS_QTD_ITENS { get; set; }
        public string ENDOSSOS_COD_TEXTO_PADRAO { get; set; }
        public string ENDOSSOS_COD_ACEITACAO { get; set; }
        public string ENDOSSOS_COD_MOEDA_IMP { get; set; }
        public string ENDOSSOS_COD_MOEDA_PRM { get; set; }
        public string ENDOSSOS_TIPO_ENDOSSO { get; set; }
        public string ENDOSSOS_OCORR_ENDERECO { get; set; }
        public string ENDOSSOS_COD_EMPRESA { get; set; }
        public string VIND_COD_EMPRESA { get; set; }
        public string ENDOSSOS_TIPO_CORRECAO { get; set; }
        public string VIND_TIPO_CORRECAO { get; set; }
        public string ENDOSSOS_ISENTA_CUSTO { get; set; }
        public string VIND_ISENTA_CUSTO { get; set; }
        public string ENDOSSOS_COEF_PREFIX { get; set; }
        public string VIND_COEF_PREFIX { get; set; }
        public string ENDOSSOS_VAL_CUSTO_EMISSAO { get; set; }
        public string VIND_VAL_CUSTO { get; set; }
        public string MOVDEBCE_NUM_APOLICE { get; set; }
        public string WHOST_NUM_ENDOSSO { get; set; }

        public static R0600_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 Execute(R0600_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 r0600_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1)
        {
            var ths = r0600_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0600_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0600_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.ENDOSSOS_NUM_APOLICE = result[i++].Value?.ToString();
            dta.ENDOSSOS_RAMO_EMISSOR = result[i++].Value?.ToString();
            dta.ENDOSSOS_COD_PRODUTO = result[i++].Value?.ToString();
            dta.ENDOSSOS_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.ENDOSSOS_COD_FONTE = result[i++].Value?.ToString();
            dta.ENDOSSOS_DATA_PROPOSTA = result[i++].Value?.ToString();
            dta.ENDOSSOS_DATA_LIBERACAO = result[i++].Value?.ToString();
            dta.ENDOSSOS_BCO_COBRANCA = result[i++].Value?.ToString();
            dta.ENDOSSOS_AGE_COBRANCA = result[i++].Value?.ToString();
            dta.ENDOSSOS_DAC_COBRANCA = result[i++].Value?.ToString();
            dta.ENDOSSOS_PLANO_SEGURO = result[i++].Value?.ToString();
            dta.ENDOSSOS_PCT_ENTRADA = result[i++].Value?.ToString();
            dta.ENDOSSOS_PCT_ADIC_FRACIO = result[i++].Value?.ToString();
            dta.ENDOSSOS_QTD_DIAS_PRIMEIRA = result[i++].Value?.ToString();
            dta.ENDOSSOS_QTD_PARCELAS = result[i++].Value?.ToString();
            dta.ENDOSSOS_QTD_PRESTACOES = result[i++].Value?.ToString();
            dta.ENDOSSOS_QTD_ITENS = result[i++].Value?.ToString();
            dta.ENDOSSOS_COD_TEXTO_PADRAO = result[i++].Value?.ToString();
            dta.ENDOSSOS_COD_ACEITACAO = result[i++].Value?.ToString();
            dta.ENDOSSOS_COD_MOEDA_IMP = result[i++].Value?.ToString();
            dta.ENDOSSOS_COD_MOEDA_PRM = result[i++].Value?.ToString();
            dta.ENDOSSOS_TIPO_ENDOSSO = result[i++].Value?.ToString();
            dta.ENDOSSOS_OCORR_ENDERECO = result[i++].Value?.ToString();
            dta.ENDOSSOS_COD_EMPRESA = result[i++].Value?.ToString();
            dta.VIND_COD_EMPRESA = string.IsNullOrWhiteSpace(dta.ENDOSSOS_COD_EMPRESA) ? "-1" : "0";
            dta.ENDOSSOS_TIPO_CORRECAO = result[i++].Value?.ToString();
            dta.VIND_TIPO_CORRECAO = string.IsNullOrWhiteSpace(dta.ENDOSSOS_TIPO_CORRECAO) ? "-1" : "0";
            dta.ENDOSSOS_ISENTA_CUSTO = result[i++].Value?.ToString();
            dta.VIND_ISENTA_CUSTO = string.IsNullOrWhiteSpace(dta.ENDOSSOS_ISENTA_CUSTO) ? "-1" : "0";
            dta.ENDOSSOS_COEF_PREFIX = result[i++].Value?.ToString();
            dta.VIND_COEF_PREFIX = string.IsNullOrWhiteSpace(dta.ENDOSSOS_COEF_PREFIX) ? "-1" : "0";
            dta.ENDOSSOS_VAL_CUSTO_EMISSAO = result[i++].Value?.ToString();
            dta.VIND_VAL_CUSTO = string.IsNullOrWhiteSpace(dta.ENDOSSOS_VAL_CUSTO_EMISSAO) ? "-1" : "0";
            return dta;
        }

    }
}