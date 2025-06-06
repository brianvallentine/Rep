using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM8024B
{
    public class R0550_00_INS_RETORNO_CA_CIELO_DB_INSERT_1_Insert1 : QueryBasis<R0550_00_INS_RETORNO_CA_CIELO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.GE_RETORNO_CA_CIELO
            ( NUM_PROPOSTA
            , NUM_CERTIFICADO
            , NUM_PARCELA
            , NUM_APOLICE
            , NUM_ENDOSSO
            , SEQ_CONTROL_CARTAO
            , SEQ_RET_CONTROL_HIST
            , DTA_MOVIMENTO
            , NUM_COM_CIELO
            , COD_BCO_CRED
            , NUM_AGE_CRED
            , NUM_CTA_CRED
            , NUM_DIG_CTA_CRED
            , COD_CART_BANDEIRA
            , NUM_CARTAO
            , COD_TOKEN_CARTAO
            , STA_CART_PADRAO_SAP
            , COD_TID_CIELO
            , VLR_COBRANCA
            , VLR_LIQUIDO
            , VLR_TAX_ADM
            , DTA_VENCIMENTO
            , DTA_CREDITO
            , DTA_DEB_TARIFA_ADM
            , DTA_AJU_CAPTURA
            , COD_MOVIMENTO
            , COD_RETORNO
            , COD_USUARIO
            , DTH_PROCESSAMENTO
            , COD_PROCE_ADVERTENCIA
            , COD_NIVEL_ADVERTENCIA
            )
            VALUES ( :GE408-NUM-PROPOSTA
            , :GE408-NUM-CERTIFICADO
            , :GE408-NUM-PARCELA
            , :GE408-NUM-APOLICE
            , :GE408-NUM-ENDOSSO
            , :GE408-SEQ-CONTROL-CARTAO
            , :GE408-SEQ-RET-CONTROL-HIST
            , :GE408-DTA-MOVIMENTO
            , :GE408-NUM-COM-CIELO
            , :GE408-COD-BCO-CRED
            , :GE408-NUM-AGE-CRED
            , :GE408-NUM-CTA-CRED
            , :GE408-NUM-DIG-CTA-CRED
            , :GE408-COD-CART-BANDEIRA
            , :GE408-NUM-CARTAO
            , :GE408-COD-TOKEN-CARTAO
            , :GE408-STA-CART-PADRAO-SAP
            , :GE408-COD-TID-CIELO
            , :GE408-VLR-COBRANCA
            , :GE408-VLR-LIQUIDO
            , :GE408-VLR-TAX-ADM
            , :GE408-DTA-VENCIMENTO
            , :GE408-DTA-CREDITO
            , :GE408-DTA-DEB-TARIFA-ADM
            , :GE408-DTA-AJU-CAPTURA
            , :GE408-COD-MOVIMENTO
            , :GE408-COD-RETORNO
            , :GE408-COD-USUARIO
            , CURRENT TIMESTAMP
            , :GE408-COD-PROCE-ADVERTENCIA:VIND-PROC-ADVERT
            , :GE408-COD-NIVEL-ADVERTENCIA:VIND-NIVE-ADVERT
            )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.GE_RETORNO_CA_CIELO ( NUM_PROPOSTA , NUM_CERTIFICADO , NUM_PARCELA , NUM_APOLICE , NUM_ENDOSSO , SEQ_CONTROL_CARTAO , SEQ_RET_CONTROL_HIST , DTA_MOVIMENTO , NUM_COM_CIELO , COD_BCO_CRED , NUM_AGE_CRED , NUM_CTA_CRED , NUM_DIG_CTA_CRED , COD_CART_BANDEIRA , NUM_CARTAO , COD_TOKEN_CARTAO , STA_CART_PADRAO_SAP , COD_TID_CIELO , VLR_COBRANCA , VLR_LIQUIDO , VLR_TAX_ADM , DTA_VENCIMENTO , DTA_CREDITO , DTA_DEB_TARIFA_ADM , DTA_AJU_CAPTURA , COD_MOVIMENTO , COD_RETORNO , COD_USUARIO , DTH_PROCESSAMENTO , COD_PROCE_ADVERTENCIA , COD_NIVEL_ADVERTENCIA ) VALUES ( {FieldThreatment(this.GE408_NUM_PROPOSTA)} , {FieldThreatment(this.GE408_NUM_CERTIFICADO)} , {FieldThreatment(this.GE408_NUM_PARCELA)} , {FieldThreatment(this.GE408_NUM_APOLICE)} , {FieldThreatment(this.GE408_NUM_ENDOSSO)} , {FieldThreatment(this.GE408_SEQ_CONTROL_CARTAO)} , {FieldThreatment(this.GE408_SEQ_RET_CONTROL_HIST)} , {FieldThreatment(this.GE408_DTA_MOVIMENTO)} , {FieldThreatment(this.GE408_NUM_COM_CIELO)} , {FieldThreatment(this.GE408_COD_BCO_CRED)} , {FieldThreatment(this.GE408_NUM_AGE_CRED)} , {FieldThreatment(this.GE408_NUM_CTA_CRED)} , {FieldThreatment(this.GE408_NUM_DIG_CTA_CRED)} , {FieldThreatment(this.GE408_COD_CART_BANDEIRA)} , {FieldThreatment(this.GE408_NUM_CARTAO)} , {FieldThreatment(this.GE408_COD_TOKEN_CARTAO)} , {FieldThreatment(this.GE408_STA_CART_PADRAO_SAP)} , {FieldThreatment(this.GE408_COD_TID_CIELO)} , {FieldThreatment(this.GE408_VLR_COBRANCA)} , {FieldThreatment(this.GE408_VLR_LIQUIDO)} , {FieldThreatment(this.GE408_VLR_TAX_ADM)} , {FieldThreatment(this.GE408_DTA_VENCIMENTO)} , {FieldThreatment(this.GE408_DTA_CREDITO)} , {FieldThreatment(this.GE408_DTA_DEB_TARIFA_ADM)} , {FieldThreatment(this.GE408_DTA_AJU_CAPTURA)} , {FieldThreatment(this.GE408_COD_MOVIMENTO)} , {FieldThreatment(this.GE408_COD_RETORNO)} , {FieldThreatment(this.GE408_COD_USUARIO)} , CURRENT TIMESTAMP ,  {FieldThreatment((this.VIND_PROC_ADVERT?.ToInt() == -1 ? null : this.GE408_COD_PROCE_ADVERTENCIA))} ,  {FieldThreatment((this.VIND_NIVE_ADVERT?.ToInt() == -1 ? null : this.GE408_COD_NIVEL_ADVERTENCIA))} )";

            return query;
        }
        public string GE408_NUM_PROPOSTA { get; set; }
        public string GE408_NUM_CERTIFICADO { get; set; }
        public string GE408_NUM_PARCELA { get; set; }
        public string GE408_NUM_APOLICE { get; set; }
        public string GE408_NUM_ENDOSSO { get; set; }
        public string GE408_SEQ_CONTROL_CARTAO { get; set; }
        public string GE408_SEQ_RET_CONTROL_HIST { get; set; }
        public string GE408_DTA_MOVIMENTO { get; set; }
        public string GE408_NUM_COM_CIELO { get; set; }
        public string GE408_COD_BCO_CRED { get; set; }
        public string GE408_NUM_AGE_CRED { get; set; }
        public string GE408_NUM_CTA_CRED { get; set; }
        public string GE408_NUM_DIG_CTA_CRED { get; set; }
        public string GE408_COD_CART_BANDEIRA { get; set; }
        public string GE408_NUM_CARTAO { get; set; }
        public string GE408_COD_TOKEN_CARTAO { get; set; }
        public string GE408_STA_CART_PADRAO_SAP { get; set; }
        public string GE408_COD_TID_CIELO { get; set; }
        public string GE408_VLR_COBRANCA { get; set; }
        public string GE408_VLR_LIQUIDO { get; set; }
        public string GE408_VLR_TAX_ADM { get; set; }
        public string GE408_DTA_VENCIMENTO { get; set; }
        public string GE408_DTA_CREDITO { get; set; }
        public string GE408_DTA_DEB_TARIFA_ADM { get; set; }
        public string GE408_DTA_AJU_CAPTURA { get; set; }
        public string GE408_COD_MOVIMENTO { get; set; }
        public string GE408_COD_RETORNO { get; set; }
        public string GE408_COD_USUARIO { get; set; }
        public string GE408_COD_PROCE_ADVERTENCIA { get; set; }
        public string VIND_PROC_ADVERT { get; set; }
        public string GE408_COD_NIVEL_ADVERTENCIA { get; set; }
        public string VIND_NIVE_ADVERT { get; set; }

        public static void Execute(R0550_00_INS_RETORNO_CA_CIELO_DB_INSERT_1_Insert1 r0550_00_INS_RETORNO_CA_CIELO_DB_INSERT_1_Insert1)
        {
            var ths = r0550_00_INS_RETORNO_CA_CIELO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0550_00_INS_RETORNO_CA_CIELO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}