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
    public class R1520_00_INSERT_ENDOSSOS_DB_INSERT_1_Insert1 : QueryBasis<R1520_00_INSERT_ENDOSSOS_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.ENDOSSOS
            (NUM_APOLICE
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
            ,TIMESTAMP
            ,DATA_VENCIMENTO
            ,COEF_PREFIX
            ,VAL_CUSTO_EMISSAO)
            VALUES
            (:ENDOSSOS-NUM-APOLICE
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
            , CURRENT TIMESTAMP
            ,:ENDOSSOS-DATA-VENCIMENTO:VIND-DTVENCTO
            ,:ENDOSSOS-COEF-PREFIX:VIND-COEF-PREFIX
            ,:ENDOSSOS-VAL-CUSTO-EMISSAO:VIND-VAL-CUSTO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.ENDOSSOS (NUM_APOLICE ,NUM_ENDOSSO ,RAMO_EMISSOR ,COD_PRODUTO ,COD_SUBGRUPO ,COD_FONTE ,NUM_PROPOSTA ,DATA_PROPOSTA ,DATA_LIBERACAO ,DATA_EMISSAO ,NUM_RCAP ,VAL_RCAP ,BCO_RCAP ,AGE_RCAP ,DAC_RCAP ,TIPO_RCAP ,BCO_COBRANCA ,AGE_COBRANCA ,DAC_COBRANCA ,DATA_INIVIGENCIA ,DATA_TERVIGENCIA ,PLANO_SEGURO ,PCT_ENTRADA ,PCT_ADIC_FRACIO ,QTD_DIAS_PRIMEIRA ,QTD_PARCELAS ,QTD_PRESTACOES ,QTD_ITENS ,COD_TEXTO_PADRAO ,COD_ACEITACAO ,COD_MOEDA_IMP ,COD_MOEDA_PRM ,TIPO_ENDOSSO ,COD_USUARIO ,OCORR_ENDERECO ,SIT_REGISTRO ,DATA_RCAP ,COD_EMPRESA ,TIPO_CORRECAO ,ISENTA_CUSTO ,TIMESTAMP ,DATA_VENCIMENTO ,COEF_PREFIX ,VAL_CUSTO_EMISSAO) VALUES ({FieldThreatment(this.ENDOSSOS_NUM_APOLICE)} ,{FieldThreatment(this.ENDOSSOS_NUM_ENDOSSO)} ,{FieldThreatment(this.ENDOSSOS_RAMO_EMISSOR)} ,{FieldThreatment(this.ENDOSSOS_COD_PRODUTO)} ,{FieldThreatment(this.ENDOSSOS_COD_SUBGRUPO)} ,{FieldThreatment(this.ENDOSSOS_COD_FONTE)} ,{FieldThreatment(this.ENDOSSOS_NUM_PROPOSTA)} ,{FieldThreatment(this.ENDOSSOS_DATA_PROPOSTA)} ,{FieldThreatment(this.ENDOSSOS_DATA_LIBERACAO)} ,{FieldThreatment(this.ENDOSSOS_DATA_EMISSAO)} ,{FieldThreatment(this.ENDOSSOS_NUM_RCAP)} ,{FieldThreatment(this.ENDOSSOS_VAL_RCAP)} ,{FieldThreatment(this.ENDOSSOS_BCO_RCAP)} ,{FieldThreatment(this.ENDOSSOS_AGE_RCAP)} ,{FieldThreatment(this.ENDOSSOS_DAC_RCAP)} ,{FieldThreatment(this.ENDOSSOS_TIPO_RCAP)} ,{FieldThreatment(this.ENDOSSOS_BCO_COBRANCA)} ,{FieldThreatment(this.ENDOSSOS_AGE_COBRANCA)} ,{FieldThreatment(this.ENDOSSOS_DAC_COBRANCA)} ,{FieldThreatment(this.ENDOSSOS_DATA_INIVIGENCIA)} ,{FieldThreatment(this.ENDOSSOS_DATA_TERVIGENCIA)} ,{FieldThreatment(this.ENDOSSOS_PLANO_SEGURO)} ,{FieldThreatment(this.ENDOSSOS_PCT_ENTRADA)} ,{FieldThreatment(this.ENDOSSOS_PCT_ADIC_FRACIO)} ,{FieldThreatment(this.ENDOSSOS_QTD_DIAS_PRIMEIRA)} ,{FieldThreatment(this.ENDOSSOS_QTD_PARCELAS)} ,{FieldThreatment(this.ENDOSSOS_QTD_PRESTACOES)} ,{FieldThreatment(this.ENDOSSOS_QTD_ITENS)} ,{FieldThreatment(this.ENDOSSOS_COD_TEXTO_PADRAO)} ,{FieldThreatment(this.ENDOSSOS_COD_ACEITACAO)} ,{FieldThreatment(this.ENDOSSOS_COD_MOEDA_IMP)} ,{FieldThreatment(this.ENDOSSOS_COD_MOEDA_PRM)} ,{FieldThreatment(this.ENDOSSOS_TIPO_ENDOSSO)} ,{FieldThreatment(this.ENDOSSOS_COD_USUARIO)} ,{FieldThreatment(this.ENDOSSOS_OCORR_ENDERECO)} ,{FieldThreatment(this.ENDOSSOS_SIT_REGISTRO)} , {FieldThreatment((this.VIND_DATA_RCAP?.ToInt() == -1 ? null : this.ENDOSSOS_DATA_RCAP))} , {FieldThreatment((this.VIND_COD_EMPRESA?.ToInt() == -1 ? null : this.ENDOSSOS_COD_EMPRESA))} , {FieldThreatment((this.VIND_TIPO_CORRECAO?.ToInt() == -1 ? null : this.ENDOSSOS_TIPO_CORRECAO))} , {FieldThreatment((this.VIND_ISENTA_CUSTO?.ToInt() == -1 ? null : this.ENDOSSOS_ISENTA_CUSTO))} , CURRENT TIMESTAMP , {FieldThreatment((this.VIND_DTVENCTO?.ToInt() == -1 ? null : this.ENDOSSOS_DATA_VENCIMENTO))} , {FieldThreatment((this.VIND_COEF_PREFIX?.ToInt() == -1 ? null : this.ENDOSSOS_COEF_PREFIX))} , {FieldThreatment((this.VIND_VAL_CUSTO?.ToInt() == -1 ? null : this.ENDOSSOS_VAL_CUSTO_EMISSAO))})";

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

        public static void Execute(R1520_00_INSERT_ENDOSSOS_DB_INSERT_1_Insert1 r1520_00_INSERT_ENDOSSOS_DB_INSERT_1_Insert1)
        {
            var ths = r1520_00_INSERT_ENDOSSOS_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1520_00_INSERT_ENDOSSOS_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}