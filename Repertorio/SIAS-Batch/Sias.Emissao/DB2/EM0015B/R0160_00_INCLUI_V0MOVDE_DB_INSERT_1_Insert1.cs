using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0015B
{
    public class R0160_00_INCLUI_V0MOVDE_DB_INSERT_1_Insert1 : QueryBasis<R0160_00_INCLUI_V0MOVDE_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0MOVDEBCC_CEF
            ( COD_EMPRESA
            ,NUM_APOLICE
            ,NRENDOS
            ,NRPARCEL
            ,SIT_COBRANCA
            ,DTVENCTO
            ,VLR_DEBITO
            ,DTMOVTO
            ,TIMESTAMP
            ,DIA_DEBITO
            ,COD_AGENCIA_DEB
            ,OPER_CONTA_DEB
            ,NUM_CONTA_DEB
            ,DIG_CONTA_DEB
            ,COD_CONVENIO
            ,DTENVIO
            ,DTRETORNO
            ,COD_RETORNO_CEF
            ,NSAS
            ,COD_USUARIO
            ,NUM_REQUISICAO
            ,NUM_CARTAO
            ,SEQUENCIA
            ,NUM_LOTE
            ,DTCREDITO
            ,STATUS_CARTAO
            ,VLR_CREDITO )
            VALUES
            ( :V0MOVDE-COD-EMPRESA,
            :V0MOVDE-NUM-APOLICE,
            :V0MOVDE-NRENDOS,
            :V0MOVDE-NRPARCEL,
            :V0MOVDE-SIT-COBRANCA,
            :V0MOVDE-DTVENCTO,
            :V0MOVDE-VLR-DEBITO,
            :V0MOVDE-DTMOVTO,
            CURRENT TIMESTAMP,
            :V0MOVDE-DIA-DEBITO,
            :V0MOVDE-COD-AGENCIA-DEB:V0MOVDE-COD-AGENCIA-DEB-NULL,
            :V0MOVDE-OPER-CONTA-DEB:V0MOVDE-OPER-CONTA-DEB-NULL,
            :V0MOVDE-NUM-CONTA-DEB:V0MOVDE-NUM-CONTA-DEB-NULL,
            :V0MOVDE-DIG-CONTA-DEB:V0MOVDE-DIG-CONTA-DEB-NULL,
            :V0MOVDE-COD-CONVENIO,
            :V0MOVDE-DTENVIO,
            NULL,
            NULL,
            :V0MOVDE-NSAS,
            :V0MOVDE-COD-USUARIO,
            NULL,
            :V0MOVDE-NUM-CARTAO:V0MOVDE-NUM-CARTAO-NULL,
            NULL,
            NULL,
            :V0MOVDE-DTCREDITO:V0MOVDE-DTCREDITO-NULL,
            :V0MOVDE-STATUS-CARTAO:V0MOVDE-STATUS-CARTAO-NULL,
            :V0MOVDE-VLR-CREDITO:V0MOVDE-VLR-CREDITO-NULL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0MOVDEBCC_CEF ( COD_EMPRESA ,NUM_APOLICE ,NRENDOS ,NRPARCEL ,SIT_COBRANCA ,DTVENCTO ,VLR_DEBITO ,DTMOVTO ,TIMESTAMP ,DIA_DEBITO ,COD_AGENCIA_DEB ,OPER_CONTA_DEB ,NUM_CONTA_DEB ,DIG_CONTA_DEB ,COD_CONVENIO ,DTENVIO ,DTRETORNO ,COD_RETORNO_CEF ,NSAS ,COD_USUARIO ,NUM_REQUISICAO ,NUM_CARTAO ,SEQUENCIA ,NUM_LOTE ,DTCREDITO ,STATUS_CARTAO ,VLR_CREDITO ) VALUES ( {FieldThreatment(this.V0MOVDE_COD_EMPRESA)}, {FieldThreatment(this.V0MOVDE_NUM_APOLICE)}, {FieldThreatment(this.V0MOVDE_NRENDOS)}, {FieldThreatment(this.V0MOVDE_NRPARCEL)}, {FieldThreatment(this.V0MOVDE_SIT_COBRANCA)}, {FieldThreatment(this.V0MOVDE_DTVENCTO)}, {FieldThreatment(this.V0MOVDE_VLR_DEBITO)}, {FieldThreatment(this.V0MOVDE_DTMOVTO)}, CURRENT TIMESTAMP, {FieldThreatment(this.V0MOVDE_DIA_DEBITO)},  {FieldThreatment((this.V0MOVDE_COD_AGENCIA_DEB_NULL?.ToInt() == -1 ? null : this.V0MOVDE_COD_AGENCIA_DEB))},  {FieldThreatment((this.V0MOVDE_OPER_CONTA_DEB_NULL?.ToInt() == -1 ? null : this.V0MOVDE_OPER_CONTA_DEB))},  {FieldThreatment((this.V0MOVDE_NUM_CONTA_DEB_NULL?.ToInt() == -1 ? null : this.V0MOVDE_NUM_CONTA_DEB))},  {FieldThreatment((this.V0MOVDE_DIG_CONTA_DEB_NULL?.ToInt() == -1 ? null : this.V0MOVDE_DIG_CONTA_DEB))}, {FieldThreatment(this.V0MOVDE_COD_CONVENIO)}, {FieldThreatment(this.V0MOVDE_DTENVIO)}, NULL, NULL, {FieldThreatment(this.V0MOVDE_NSAS)}, {FieldThreatment(this.V0MOVDE_COD_USUARIO)}, NULL,  {FieldThreatment((this.V0MOVDE_NUM_CARTAO_NULL?.ToInt() == -1 ? null : this.V0MOVDE_NUM_CARTAO))}, NULL, NULL,  {FieldThreatment((this.V0MOVDE_DTCREDITO_NULL?.ToInt() == -1 ? null : this.V0MOVDE_DTCREDITO))},  {FieldThreatment((this.V0MOVDE_STATUS_CARTAO_NULL?.ToInt() == -1 ? null : this.V0MOVDE_STATUS_CARTAO))},  {FieldThreatment((this.V0MOVDE_VLR_CREDITO_NULL?.ToInt() == -1 ? null : this.V0MOVDE_VLR_CREDITO))})";

            return query;
        }
        public string V0MOVDE_COD_EMPRESA { get; set; }
        public string V0MOVDE_NUM_APOLICE { get; set; }
        public string V0MOVDE_NRENDOS { get; set; }
        public string V0MOVDE_NRPARCEL { get; set; }
        public string V0MOVDE_SIT_COBRANCA { get; set; }
        public string V0MOVDE_DTVENCTO { get; set; }
        public string V0MOVDE_VLR_DEBITO { get; set; }
        public string V0MOVDE_DTMOVTO { get; set; }
        public string V0MOVDE_DIA_DEBITO { get; set; }
        public string V0MOVDE_COD_AGENCIA_DEB { get; set; }
        public string V0MOVDE_COD_AGENCIA_DEB_NULL { get; set; }
        public string V0MOVDE_OPER_CONTA_DEB { get; set; }
        public string V0MOVDE_OPER_CONTA_DEB_NULL { get; set; }
        public string V0MOVDE_NUM_CONTA_DEB { get; set; }
        public string V0MOVDE_NUM_CONTA_DEB_NULL { get; set; }
        public string V0MOVDE_DIG_CONTA_DEB { get; set; }
        public string V0MOVDE_DIG_CONTA_DEB_NULL { get; set; }
        public string V0MOVDE_COD_CONVENIO { get; set; }
        public string V0MOVDE_DTENVIO { get; set; }
        public string V0MOVDE_NSAS { get; set; }
        public string V0MOVDE_COD_USUARIO { get; set; }
        public string V0MOVDE_NUM_CARTAO { get; set; }
        public string V0MOVDE_NUM_CARTAO_NULL { get; set; }
        public string V0MOVDE_DTCREDITO { get; set; }
        public string V0MOVDE_DTCREDITO_NULL { get; set; }
        public string V0MOVDE_STATUS_CARTAO { get; set; }
        public string V0MOVDE_STATUS_CARTAO_NULL { get; set; }
        public string V0MOVDE_VLR_CREDITO { get; set; }
        public string V0MOVDE_VLR_CREDITO_NULL { get; set; }

        public static void Execute(R0160_00_INCLUI_V0MOVDE_DB_INSERT_1_Insert1 r0160_00_INCLUI_V0MOVDE_DB_INSERT_1_Insert1)
        {
            var ths = r0160_00_INCLUI_V0MOVDE_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0160_00_INCLUI_V0MOVDE_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}