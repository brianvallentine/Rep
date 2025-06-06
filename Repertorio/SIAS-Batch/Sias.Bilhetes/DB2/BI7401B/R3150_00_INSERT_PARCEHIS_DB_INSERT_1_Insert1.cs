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
    public class R3150_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1 : QueryBasis<R3150_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.PARCELA_HISTORICO
            (NUM_APOLICE
            ,NUM_ENDOSSO
            ,NUM_PARCELA
            ,DAC_PARCELA
            ,DATA_MOVIMENTO
            ,COD_OPERACAO
            ,HORA_OPERACAO
            ,OCORR_HISTORICO
            ,PRM_TARIFARIO
            ,VAL_DESCONTO
            ,PRM_LIQUIDO
            ,ADICIONAL_FRACIO
            ,VAL_CUSTO_EMISSAO
            ,VAL_IOCC
            ,PRM_TOTAL
            ,VAL_OPERACAO
            ,DATA_VENCIMENTO
            ,BCO_COBRANCA
            ,AGE_COBRANCA
            ,NUM_AVISO_CREDITO
            ,ENDOS_CANCELA
            ,SIT_CONTABIL
            ,COD_USUARIO
            ,RENUM_DOCUMENTO
            ,DATA_QUITACAO
            ,COD_EMPRESA
            ,TIMESTAMP)
            VALUES
            (:PARCEHIS-NUM-APOLICE
            ,:PARCEHIS-NUM-ENDOSSO
            ,:PARCEHIS-NUM-PARCELA
            ,:PARCEHIS-DAC-PARCELA
            ,:PARCEHIS-DATA-MOVIMENTO
            ,:PARCEHIS-COD-OPERACAO
            , CURRENT TIME
            ,:PARCEHIS-OCORR-HISTORICO
            ,:PARCEHIS-PRM-TARIFARIO
            ,:PARCEHIS-VAL-DESCONTO
            ,:PARCEHIS-PRM-LIQUIDO
            ,:PARCEHIS-ADICIONAL-FRACIO
            ,:PARCEHIS-VAL-CUSTO-EMISSAO
            ,:PARCEHIS-VAL-IOCC
            ,:PARCEHIS-PRM-TOTAL
            ,:PARCEHIS-VAL-OPERACAO
            ,:PARCEHIS-DATA-VENCIMENTO
            ,:PARCEHIS-BCO-COBRANCA
            ,:PARCEHIS-AGE-COBRANCA
            ,:PARCEHIS-NUM-AVISO-CREDITO
            ,:PARCEHIS-ENDOS-CANCELA
            ,:PARCEHIS-SIT-CONTABIL
            ,:PARCEHIS-COD-USUARIO
            ,:PARCEHIS-RENUM-DOCUMENTO
            ,:PARCEHIS-DATA-QUITACAO:VIND-NULL01
            ,:PARCEHIS-COD-EMPRESA:VIND-NULL02
            , CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PARCELA_HISTORICO (NUM_APOLICE ,NUM_ENDOSSO ,NUM_PARCELA ,DAC_PARCELA ,DATA_MOVIMENTO ,COD_OPERACAO ,HORA_OPERACAO ,OCORR_HISTORICO ,PRM_TARIFARIO ,VAL_DESCONTO ,PRM_LIQUIDO ,ADICIONAL_FRACIO ,VAL_CUSTO_EMISSAO ,VAL_IOCC ,PRM_TOTAL ,VAL_OPERACAO ,DATA_VENCIMENTO ,BCO_COBRANCA ,AGE_COBRANCA ,NUM_AVISO_CREDITO ,ENDOS_CANCELA ,SIT_CONTABIL ,COD_USUARIO ,RENUM_DOCUMENTO ,DATA_QUITACAO ,COD_EMPRESA ,TIMESTAMP) VALUES ({FieldThreatment(this.PARCEHIS_NUM_APOLICE)} ,{FieldThreatment(this.PARCEHIS_NUM_ENDOSSO)} ,{FieldThreatment(this.PARCEHIS_NUM_PARCELA)} ,{FieldThreatment(this.PARCEHIS_DAC_PARCELA)} ,{FieldThreatment(this.PARCEHIS_DATA_MOVIMENTO)} ,{FieldThreatment(this.PARCEHIS_COD_OPERACAO)} , CURRENT TIME ,{FieldThreatment(this.PARCEHIS_OCORR_HISTORICO)} ,{FieldThreatment(this.PARCEHIS_PRM_TARIFARIO)} ,{FieldThreatment(this.PARCEHIS_VAL_DESCONTO)} ,{FieldThreatment(this.PARCEHIS_PRM_LIQUIDO)} ,{FieldThreatment(this.PARCEHIS_ADICIONAL_FRACIO)} ,{FieldThreatment(this.PARCEHIS_VAL_CUSTO_EMISSAO)} ,{FieldThreatment(this.PARCEHIS_VAL_IOCC)} ,{FieldThreatment(this.PARCEHIS_PRM_TOTAL)} ,{FieldThreatment(this.PARCEHIS_VAL_OPERACAO)} ,{FieldThreatment(this.PARCEHIS_DATA_VENCIMENTO)} ,{FieldThreatment(this.PARCEHIS_BCO_COBRANCA)} ,{FieldThreatment(this.PARCEHIS_AGE_COBRANCA)} ,{FieldThreatment(this.PARCEHIS_NUM_AVISO_CREDITO)} ,{FieldThreatment(this.PARCEHIS_ENDOS_CANCELA)} ,{FieldThreatment(this.PARCEHIS_SIT_CONTABIL)} ,{FieldThreatment(this.PARCEHIS_COD_USUARIO)} ,{FieldThreatment(this.PARCEHIS_RENUM_DOCUMENTO)} , {FieldThreatment((this.VIND_NULL01?.ToInt() == -1 ? null : this.PARCEHIS_DATA_QUITACAO))} , {FieldThreatment((this.VIND_NULL02?.ToInt() == -1 ? null : this.PARCEHIS_COD_EMPRESA))} , CURRENT TIMESTAMP)";

            return query;
        }
        public string PARCEHIS_NUM_APOLICE { get; set; }
        public string PARCEHIS_NUM_ENDOSSO { get; set; }
        public string PARCEHIS_NUM_PARCELA { get; set; }
        public string PARCEHIS_DAC_PARCELA { get; set; }
        public string PARCEHIS_DATA_MOVIMENTO { get; set; }
        public string PARCEHIS_COD_OPERACAO { get; set; }
        public string PARCEHIS_OCORR_HISTORICO { get; set; }
        public string PARCEHIS_PRM_TARIFARIO { get; set; }
        public string PARCEHIS_VAL_DESCONTO { get; set; }
        public string PARCEHIS_PRM_LIQUIDO { get; set; }
        public string PARCEHIS_ADICIONAL_FRACIO { get; set; }
        public string PARCEHIS_VAL_CUSTO_EMISSAO { get; set; }
        public string PARCEHIS_VAL_IOCC { get; set; }
        public string PARCEHIS_PRM_TOTAL { get; set; }
        public string PARCEHIS_VAL_OPERACAO { get; set; }
        public string PARCEHIS_DATA_VENCIMENTO { get; set; }
        public string PARCEHIS_BCO_COBRANCA { get; set; }
        public string PARCEHIS_AGE_COBRANCA { get; set; }
        public string PARCEHIS_NUM_AVISO_CREDITO { get; set; }
        public string PARCEHIS_ENDOS_CANCELA { get; set; }
        public string PARCEHIS_SIT_CONTABIL { get; set; }
        public string PARCEHIS_COD_USUARIO { get; set; }
        public string PARCEHIS_RENUM_DOCUMENTO { get; set; }
        public string PARCEHIS_DATA_QUITACAO { get; set; }
        public string VIND_NULL01 { get; set; }
        public string PARCEHIS_COD_EMPRESA { get; set; }
        public string VIND_NULL02 { get; set; }

        public static void Execute(R3150_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1 r3150_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1)
        {
            var ths = r3150_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3150_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}