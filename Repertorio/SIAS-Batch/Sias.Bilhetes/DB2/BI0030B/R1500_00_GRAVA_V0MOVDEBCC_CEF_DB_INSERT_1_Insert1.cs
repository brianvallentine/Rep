using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0030B
{
    public class R1500_00_GRAVA_V0MOVDEBCC_CEF_DB_INSERT_1_Insert1 : QueryBasis<R1500_00_GRAVA_V0MOVDEBCC_CEF_DB_INSERT_1_Insert1>
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
            (0,
            :V0MOVDE-NUM-APOLICE,
            :V0MOVDE-NRENDOS,
            0,
            :V0MOVDE-SIT-COBRANCA,
            :V0MOVDE-DTVENCTO,
            :V0MOVDE-VLR-DEBITO,
            :V0MOVDE-DTMOVTO,
            CURRENT TIMESTAMP,
            :V0MOVDE-DIA-DEBITO,
            :V0MOVDE-COD-AGE-DEB,
            :V0MOVDE-OPER-CTA-DEB,
            :V0MOVDE-NUM-CTA-DEB,
            :V0MOVDE-DIG-CTA-DEB,
            :V0MOVDE-COD-CONVENIO,
            NULL,
            NULL,
            NULL,
            0,
            'BI0030B' ,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0MOVDEBCC_CEF ( COD_EMPRESA ,NUM_APOLICE ,NRENDOS ,NRPARCEL ,SIT_COBRANCA ,DTVENCTO ,VLR_DEBITO ,DTMOVTO ,TIMESTAMP ,DIA_DEBITO ,COD_AGENCIA_DEB ,OPER_CONTA_DEB ,NUM_CONTA_DEB ,DIG_CONTA_DEB ,COD_CONVENIO ,DTENVIO ,DTRETORNO ,COD_RETORNO_CEF ,NSAS ,COD_USUARIO ,NUM_REQUISICAO ,NUM_CARTAO ,SEQUENCIA ,NUM_LOTE ,DTCREDITO ,STATUS_CARTAO ,VLR_CREDITO ) VALUES (0, {FieldThreatment(this.V0MOVDE_NUM_APOLICE)}, {FieldThreatment(this.V0MOVDE_NRENDOS)}, 0, {FieldThreatment(this.V0MOVDE_SIT_COBRANCA)}, {FieldThreatment(this.V0MOVDE_DTVENCTO)}, {FieldThreatment(this.V0MOVDE_VLR_DEBITO)}, {FieldThreatment(this.V0MOVDE_DTMOVTO)}, CURRENT TIMESTAMP, {FieldThreatment(this.V0MOVDE_DIA_DEBITO)}, {FieldThreatment(this.V0MOVDE_COD_AGE_DEB)}, {FieldThreatment(this.V0MOVDE_OPER_CTA_DEB)}, {FieldThreatment(this.V0MOVDE_NUM_CTA_DEB)}, {FieldThreatment(this.V0MOVDE_DIG_CTA_DEB)}, {FieldThreatment(this.V0MOVDE_COD_CONVENIO)}, NULL, NULL, NULL, 0, 'BI0030B' , NULL, NULL, NULL, NULL, NULL, NULL, NULL)";

            return query;
        }
        public string V0MOVDE_NUM_APOLICE { get; set; }
        public string V0MOVDE_NRENDOS { get; set; }
        public string V0MOVDE_SIT_COBRANCA { get; set; }
        public string V0MOVDE_DTVENCTO { get; set; }
        public string V0MOVDE_VLR_DEBITO { get; set; }
        public string V0MOVDE_DTMOVTO { get; set; }
        public string V0MOVDE_DIA_DEBITO { get; set; }
        public string V0MOVDE_COD_AGE_DEB { get; set; }
        public string V0MOVDE_OPER_CTA_DEB { get; set; }
        public string V0MOVDE_NUM_CTA_DEB { get; set; }
        public string V0MOVDE_DIG_CTA_DEB { get; set; }
        public string V0MOVDE_COD_CONVENIO { get; set; }

        public static void Execute(R1500_00_GRAVA_V0MOVDEBCC_CEF_DB_INSERT_1_Insert1 r1500_00_GRAVA_V0MOVDEBCC_CEF_DB_INSERT_1_Insert1)
        {
            var ths = r1500_00_GRAVA_V0MOVDEBCC_CEF_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1500_00_GRAVA_V0MOVDEBCC_CEF_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}