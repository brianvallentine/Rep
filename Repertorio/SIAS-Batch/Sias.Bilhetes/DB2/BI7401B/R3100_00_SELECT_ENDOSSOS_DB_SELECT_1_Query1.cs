using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI7401B
{
    public class R3100_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 : QueryBasis<R3100_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE
            ,NUM_ENDOSSO
            ,RAMO_EMISSOR
            ,COD_PRODUTO
            ,COD_SUBGRUPO
            ,COD_FONTE
            ,NUM_PROPOSTA
            ,DATA_PROPOSTA
            ,DATA_LIBERACAO
            ,DATA_EMISSAO
            ,NUM_RCAP
            ,VAL_RCAP
            ,BCO_RCAP
            ,AGE_RCAP
            ,DAC_RCAP
            ,TIPO_RCAP
            ,BCO_COBRANCA
            ,AGE_COBRANCA
            ,DAC_COBRANCA
            ,DATA_INIVIGENCIA
            ,DATA_TERVIGENCIA
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
            ,COD_USUARIO
            ,OCORR_ENDERECO
            ,SIT_REGISTRO
            ,DATA_RCAP
            ,COD_EMPRESA
            ,TIPO_CORRECAO
            ,ISENTA_CUSTO
            ,DATA_VENCIMENTO
            ,COEF_PREFIX
            ,VAL_CUSTO_EMISSAO
            INTO :ENDOSSOS-NUM-APOLICE
            ,:ENDOSSOS-NUM-ENDOSSO
            ,:ENDOSSOS-RAMO-EMISSOR
            ,:ENDOSSOS-COD-PRODUTO
            ,:ENDOSSOS-COD-SUBGRUPO
            ,:ENDOSSOS-COD-FONTE
            ,:ENDOSSOS-NUM-PROPOSTA
            ,:ENDOSSOS-DATA-PROPOSTA
            ,:ENDOSSOS-DATA-LIBERACAO
            ,:ENDOSSOS-DATA-EMISSAO
            ,:ENDOSSOS-NUM-RCAP
            ,:ENDOSSOS-VAL-RCAP
            ,:ENDOSSOS-BCO-RCAP
            ,:ENDOSSOS-AGE-RCAP
            ,:ENDOSSOS-DAC-RCAP
            ,:ENDOSSOS-TIPO-RCAP
            ,:ENDOSSOS-BCO-COBRANCA
            ,:ENDOSSOS-AGE-COBRANCA
            ,:ENDOSSOS-DAC-COBRANCA
            ,:ENDOSSOS-DATA-INIVIGENCIA
            ,:ENDOSSOS-DATA-TERVIGENCIA
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
            ,:ENDOSSOS-COD-USUARIO
            ,:ENDOSSOS-OCORR-ENDERECO
            ,:ENDOSSOS-SIT-REGISTRO
            ,:ENDOSSOS-DATA-RCAP:VIND-DATA-RCAP
            ,:ENDOSSOS-COD-EMPRESA:VIND-COD-EMPRESA
            ,:ENDOSSOS-TIPO-CORRECAO:VIND-TIPO-CORRECAO
            ,:ENDOSSOS-ISENTA-CUSTO:VIND-ISENTA-CUSTO
            ,:ENDOSSOS-DATA-VENCIMENTO:VIND-DTVENCTO
            ,:ENDOSSOS-COEF-PREFIX:VIND-COEF-PREFIX
            ,:ENDOSSOS-VAL-CUSTO-EMISSAO:VIND-VAL-CUSTO
            FROM SEGUROS.ENDOSSOS
            WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE
            AND NUM_ENDOSSO = 0
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE
											,NUM_ENDOSSO
											,RAMO_EMISSOR
											,COD_PRODUTO
											,COD_SUBGRUPO
											,COD_FONTE
											,NUM_PROPOSTA
											,DATA_PROPOSTA
											,DATA_LIBERACAO
											,DATA_EMISSAO
											,NUM_RCAP
											,VAL_RCAP
											,BCO_RCAP
											,AGE_RCAP
											,DAC_RCAP
											,TIPO_RCAP
											,BCO_COBRANCA
											,AGE_COBRANCA
											,DAC_COBRANCA
											,DATA_INIVIGENCIA
											,DATA_TERVIGENCIA
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
											,COD_USUARIO
											,OCORR_ENDERECO
											,SIT_REGISTRO
											,DATA_RCAP
											,COD_EMPRESA
											,TIPO_CORRECAO
											,ISENTA_CUSTO
											,DATA_VENCIMENTO
											,COEF_PREFIX
											,VAL_CUSTO_EMISSAO
											FROM SEGUROS.ENDOSSOS
											WHERE NUM_APOLICE = '{this.ENDOSSOS_NUM_APOLICE}'
											AND NUM_ENDOSSO = 0
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string ENDOSSOS_NUM_APOLICE { get; set; }
        public string ENDOSSOS_NUM_ENDOSSO { get; set; }
        public string ENDOSSOS_RAMO_EMISSOR { get; set; }
        public string ENDOSSOS_COD_PRODUTO { get; set; }
        public string ENDOSSOS_COD_SUBGRUPO { get; set; }
        public string ENDOSSOS_COD_FONTE { get; set; }
        public string ENDOSSOS_NUM_PROPOSTA { get; set; }
        public string ENDOSSOS_DATA_PROPOSTA { get; set; }
        public string ENDOSSOS_DATA_LIBERACAO { get; set; }
        public string ENDOSSOS_DATA_EMISSAO { get; set; }
        public string ENDOSSOS_NUM_RCAP { get; set; }
        public string ENDOSSOS_VAL_RCAP { get; set; }
        public string ENDOSSOS_BCO_RCAP { get; set; }
        public string ENDOSSOS_AGE_RCAP { get; set; }
        public string ENDOSSOS_DAC_RCAP { get; set; }
        public string ENDOSSOS_TIPO_RCAP { get; set; }
        public string ENDOSSOS_BCO_COBRANCA { get; set; }
        public string ENDOSSOS_AGE_COBRANCA { get; set; }
        public string ENDOSSOS_DAC_COBRANCA { get; set; }
        public string ENDOSSOS_DATA_INIVIGENCIA { get; set; }
        public string ENDOSSOS_DATA_TERVIGENCIA { get; set; }
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
        public string ENDOSSOS_COD_USUARIO { get; set; }
        public string ENDOSSOS_OCORR_ENDERECO { get; set; }
        public string ENDOSSOS_SIT_REGISTRO { get; set; }
        public string ENDOSSOS_DATA_RCAP { get; set; }
        public string VIND_DATA_RCAP { get; set; }
        public string ENDOSSOS_COD_EMPRESA { get; set; }
        public string VIND_COD_EMPRESA { get; set; }
        public string ENDOSSOS_TIPO_CORRECAO { get; set; }
        public string VIND_TIPO_CORRECAO { get; set; }
        public string ENDOSSOS_ISENTA_CUSTO { get; set; }
        public string VIND_ISENTA_CUSTO { get; set; }
        public string ENDOSSOS_DATA_VENCIMENTO { get; set; }
        public string VIND_DTVENCTO { get; set; }
        public string ENDOSSOS_COEF_PREFIX { get; set; }
        public string VIND_COEF_PREFIX { get; set; }
        public string ENDOSSOS_VAL_CUSTO_EMISSAO { get; set; }
        public string VIND_VAL_CUSTO { get; set; }

        public static R3100_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 Execute(R3100_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 r3100_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1)
        {
            var ths = r3100_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3100_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3100_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.ENDOSSOS_NUM_APOLICE = result[i++].Value?.ToString();
            dta.ENDOSSOS_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.ENDOSSOS_RAMO_EMISSOR = result[i++].Value?.ToString();
            dta.ENDOSSOS_COD_PRODUTO = result[i++].Value?.ToString();
            dta.ENDOSSOS_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.ENDOSSOS_COD_FONTE = result[i++].Value?.ToString();
            dta.ENDOSSOS_NUM_PROPOSTA = result[i++].Value?.ToString();
            dta.ENDOSSOS_DATA_PROPOSTA = result[i++].Value?.ToString();
            dta.ENDOSSOS_DATA_LIBERACAO = result[i++].Value?.ToString();
            dta.ENDOSSOS_DATA_EMISSAO = result[i++].Value?.ToString();
            dta.ENDOSSOS_NUM_RCAP = result[i++].Value?.ToString();
            dta.ENDOSSOS_VAL_RCAP = result[i++].Value?.ToString();
            dta.ENDOSSOS_BCO_RCAP = result[i++].Value?.ToString();
            dta.ENDOSSOS_AGE_RCAP = result[i++].Value?.ToString();
            dta.ENDOSSOS_DAC_RCAP = result[i++].Value?.ToString();
            dta.ENDOSSOS_TIPO_RCAP = result[i++].Value?.ToString();
            dta.ENDOSSOS_BCO_COBRANCA = result[i++].Value?.ToString();
            dta.ENDOSSOS_AGE_COBRANCA = result[i++].Value?.ToString();
            dta.ENDOSSOS_DAC_COBRANCA = result[i++].Value?.ToString();
            dta.ENDOSSOS_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.ENDOSSOS_DATA_TERVIGENCIA = result[i++].Value?.ToString();
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
            dta.ENDOSSOS_COD_USUARIO = result[i++].Value?.ToString();
            dta.ENDOSSOS_OCORR_ENDERECO = result[i++].Value?.ToString();
            dta.ENDOSSOS_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.ENDOSSOS_DATA_RCAP = result[i++].Value?.ToString();
            dta.VIND_DATA_RCAP = string.IsNullOrWhiteSpace(dta.ENDOSSOS_DATA_RCAP) ? "-1" : "0";
            dta.ENDOSSOS_COD_EMPRESA = result[i++].Value?.ToString();
            dta.VIND_COD_EMPRESA = string.IsNullOrWhiteSpace(dta.ENDOSSOS_COD_EMPRESA) ? "-1" : "0";
            dta.ENDOSSOS_TIPO_CORRECAO = result[i++].Value?.ToString();
            dta.VIND_TIPO_CORRECAO = string.IsNullOrWhiteSpace(dta.ENDOSSOS_TIPO_CORRECAO) ? "-1" : "0";
            dta.ENDOSSOS_ISENTA_CUSTO = result[i++].Value?.ToString();
            dta.VIND_ISENTA_CUSTO = string.IsNullOrWhiteSpace(dta.ENDOSSOS_ISENTA_CUSTO) ? "-1" : "0";
            dta.ENDOSSOS_DATA_VENCIMENTO = result[i++].Value?.ToString();
            dta.VIND_DTVENCTO = string.IsNullOrWhiteSpace(dta.ENDOSSOS_DATA_VENCIMENTO) ? "-1" : "0";
            dta.ENDOSSOS_COEF_PREFIX = result[i++].Value?.ToString();
            dta.VIND_COEF_PREFIX = string.IsNullOrWhiteSpace(dta.ENDOSSOS_COEF_PREFIX) ? "-1" : "0";
            dta.ENDOSSOS_VAL_CUSTO_EMISSAO = result[i++].Value?.ToString();
            dta.VIND_VAL_CUSTO = string.IsNullOrWhiteSpace(dta.ENDOSSOS_VAL_CUSTO_EMISSAO) ? "-1" : "0";
            return dta;
        }

    }
}