using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6032B
{
    public class R0145_00_INSERT_V0MOVDEBCC_CEF_DB_INSERT_1_Insert1 : QueryBasis<R0145_00_INSERT_V0MOVDEBCC_CEF_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT INTO SEGUROS.V0MOVDEBCC_CEF
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
            VALUES (0 ,
            :V1BILH-NUM-APOL ,
            :WS-ENDOSSO,
            :WS-PARCELA,
            '1' ,
            :V0MOVDE-DTVENCTO ,
            :WS-VLPREMIO,
            :V1SISTE-DTMOVABE,
            CURRENT TIMESTAMP,
            :V0MOVDE-DIA-DEBITO ,
            :V1BILH-AGENCIA-DEB,
            :V1BILH-OPERACAO-DEB,
            :V1BILH-CONTA-DEB,
            :V1BILH-DIGITO-DEB,
            :V0PARAMC-COD-CONVENIO,
            CURRENT DATE,
            NULL ,
            NULL ,
            :V0PARAMC-NSAS ,
            'BI6032B' ,
            NULL ,
            NULL ,
            NULL ,
            NULL ,
            :V1SISTE-DTMOVABE,
            NULL ,
            NULL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0MOVDEBCC_CEF ( COD_EMPRESA ,NUM_APOLICE ,NRENDOS ,NRPARCEL ,SIT_COBRANCA ,DTVENCTO ,VLR_DEBITO ,DTMOVTO ,TIMESTAMP ,DIA_DEBITO ,COD_AGENCIA_DEB ,OPER_CONTA_DEB ,NUM_CONTA_DEB ,DIG_CONTA_DEB ,COD_CONVENIO ,DTENVIO ,DTRETORNO ,COD_RETORNO_CEF ,NSAS ,COD_USUARIO ,NUM_REQUISICAO ,NUM_CARTAO ,SEQUENCIA ,NUM_LOTE ,DTCREDITO ,STATUS_CARTAO ,VLR_CREDITO ) VALUES (0 , {FieldThreatment(this.V1BILH_NUM_APOL)} , {FieldThreatment(this.WS_ENDOSSO)}, {FieldThreatment(this.WS_PARCELA)}, '1' , {FieldThreatment(this.V0MOVDE_DTVENCTO)} , {FieldThreatment(this.WS_VLPREMIO)}, {FieldThreatment(this.V1SISTE_DTMOVABE)}, CURRENT TIMESTAMP, {FieldThreatment(this.V0MOVDE_DIA_DEBITO)} , {FieldThreatment(this.V1BILH_AGENCIA_DEB)}, {FieldThreatment(this.V1BILH_OPERACAO_DEB)}, {FieldThreatment(this.V1BILH_CONTA_DEB)}, {FieldThreatment(this.V1BILH_DIGITO_DEB)}, {FieldThreatment(this.V0PARAMC_COD_CONVENIO)}, CURRENT DATE, NULL , NULL , {FieldThreatment(this.V0PARAMC_NSAS)} , 'BI6032B' , NULL , NULL , NULL , NULL , {FieldThreatment(this.V1SISTE_DTMOVABE)}, NULL , NULL)";

            return query;
        }
        public string V1BILH_NUM_APOL { get; set; }
        public string WS_ENDOSSO { get; set; }
        public string WS_PARCELA { get; set; }
        public string V0MOVDE_DTVENCTO { get; set; }
        public string WS_VLPREMIO { get; set; }
        public string V1SISTE_DTMOVABE { get; set; }
        public string V0MOVDE_DIA_DEBITO { get; set; }
        public string V1BILH_AGENCIA_DEB { get; set; }
        public string V1BILH_OPERACAO_DEB { get; set; }
        public string V1BILH_CONTA_DEB { get; set; }
        public string V1BILH_DIGITO_DEB { get; set; }
        public string V0PARAMC_COD_CONVENIO { get; set; }
        public string V0PARAMC_NSAS { get; set; }

        public static void Execute(R0145_00_INSERT_V0MOVDEBCC_CEF_DB_INSERT_1_Insert1 r0145_00_INSERT_V0MOVDEBCC_CEF_DB_INSERT_1_Insert1)
        {
            var ths = r0145_00_INSERT_V0MOVDEBCC_CEF_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0145_00_INSERT_V0MOVDEBCC_CEF_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}