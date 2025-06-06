using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI8070B
{
    public class R0600_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 : QueryBasis<R0600_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.NUM_APOLICE
            ,A.RAMO_EMISSOR
            ,A.COD_PRODUTO
            ,A.COD_SUBGRUPO
            ,A.COD_FONTE
            ,A.DATA_PROPOSTA
            ,A.DATA_LIBERACAO
            ,A.BCO_COBRANCA
            ,A.AGE_COBRANCA
            ,A.DAC_COBRANCA
            ,A.DATA_TERVIGENCIA + 1 DAYS
            ,A.DATA_TERVIGENCIA + 1 DAYS + 1 MONTH
            ,A.DATA_TERVIGENCIA + 1 DAYS + 2 MONTH
            ,A.PLANO_SEGURO
            ,A.PCT_ENTRADA
            ,A.PCT_ADIC_FRACIO
            ,A.QTD_DIAS_PRIMEIRA
            ,A.QTD_PARCELAS
            ,A.QTD_PRESTACOES
            ,A.QTD_ITENS
            ,A.COD_TEXTO_PADRAO
            ,A.COD_ACEITACAO
            ,A.COD_MOEDA_IMP
            ,A.COD_MOEDA_PRM
            ,A.TIPO_ENDOSSO
            ,A.OCORR_ENDERECO
            ,A.COD_EMPRESA
            ,A.TIPO_CORRECAO
            ,A.ISENTA_CUSTO
            ,A.COEF_PREFIX
            ,A.VAL_CUSTO_EMISSAO
            ,B.COD_EMPRESA
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
            ,:WSGER00-DATA-INIVIGENCIA
            ,:WSGER00-DATA-TERVIGENCIA
            ,:WSGER00-DATA-CORRETOR
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
            ,:PRODUTO-COD-EMPRESA
            FROM SEGUROS.ENDOSSOS A
            ,SEGUROS.PRODUTO B
            WHERE A.NUM_APOLICE = :MOVDEBCE-NUM-APOLICE
            AND A.NUM_ENDOSSO = :WHOST-NUM-ENDOSSO
            AND B.COD_PRODUTO = A.COD_PRODUTO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.NUM_APOLICE
											,A.RAMO_EMISSOR
											,A.COD_PRODUTO
											,A.COD_SUBGRUPO
											,A.COD_FONTE
											,A.DATA_PROPOSTA
											,A.DATA_LIBERACAO
											,A.BCO_COBRANCA
											,A.AGE_COBRANCA
											,A.DAC_COBRANCA
											,A.DATA_TERVIGENCIA + 1 DAYS
											,A.DATA_TERVIGENCIA + 1 DAYS + 1 MONTH
											,A.DATA_TERVIGENCIA + 1 DAYS + 2 MONTH
											,A.PLANO_SEGURO
											,A.PCT_ENTRADA
											,A.PCT_ADIC_FRACIO
											,A.QTD_DIAS_PRIMEIRA
											,A.QTD_PARCELAS
											,A.QTD_PRESTACOES
											,A.QTD_ITENS
											,A.COD_TEXTO_PADRAO
											,A.COD_ACEITACAO
											,A.COD_MOEDA_IMP
											,A.COD_MOEDA_PRM
											,A.TIPO_ENDOSSO
											,A.OCORR_ENDERECO
											,A.COD_EMPRESA
											,A.TIPO_CORRECAO
											,A.ISENTA_CUSTO
											,A.COEF_PREFIX
											,A.VAL_CUSTO_EMISSAO
											,B.COD_EMPRESA
											FROM SEGUROS.ENDOSSOS A
											,SEGUROS.PRODUTO B
											WHERE A.NUM_APOLICE = '{this.MOVDEBCE_NUM_APOLICE}'
											AND A.NUM_ENDOSSO = '{this.WHOST_NUM_ENDOSSO}'
											AND B.COD_PRODUTO = A.COD_PRODUTO
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
        public string WSGER00_DATA_INIVIGENCIA { get; set; }
        public string WSGER00_DATA_TERVIGENCIA { get; set; }
        public string WSGER00_DATA_CORRETOR { get; set; }
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
        public string PRODUTO_COD_EMPRESA { get; set; }
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
            dta.WSGER00_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.WSGER00_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            dta.WSGER00_DATA_CORRETOR = result[i++].Value?.ToString();
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
            dta.PRODUTO_COD_EMPRESA = result[i++].Value?.ToString();
            return dta;
        }

    }
}