using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0123B
{
    public class R1650_00_DEBITO_CARTAO_DB_INSERT_1_Insert1 : QueryBasis<R1650_00_DEBITO_CARTAO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.MOVTO_DEBITOCC_CEF
            ( COD_EMPRESA ,
            NUM_APOLICE ,
            NUM_ENDOSSO ,
            NUM_PARCELA ,
            SITUACAO_COBRANCA ,
            DATA_VENCIMENTO ,
            VALOR_DEBITO ,
            DATA_MOVIMENTO ,
            TIMESTAMP ,
            DIA_DEBITO ,
            COD_AGENCIA_DEB ,
            OPER_CONTA_DEB ,
            NUM_CONTA_DEB ,
            DIG_CONTA_DEB ,
            COD_CONVENIO ,
            DATA_ENVIO ,
            DATA_RETORNO ,
            COD_RETORNO_CEF ,
            NSAS ,
            COD_USUARIO ,
            NUM_REQUISICAO ,
            NUM_CARTAO ,
            SEQUENCIA ,
            NUM_LOTE ,
            DTCREDITO ,
            STATUS_CARTAO ,
            VLR_CREDITO )
            VALUES
            ( :MOVDEBCE-COD-EMPRESA ,
            :MOVDEBCE-NUM-APOLICE ,
            :MOVDEBCE-NUM-ENDOSSO ,
            :MOVDEBCE-NUM-PARCELA ,
            :MOVDEBCE-SITUACAO-COBRANCA ,
            :MOVDEBCE-DATA-VENCIMENTO ,
            :MOVDEBCE-VALOR-DEBITO ,
            :MOVDEBCE-DATA-MOVIMENTO ,
            CURRENT TIMESTAMP ,
            :MOVDEBCE-DIA-DEBITO ,
            :MOVDEBCE-COD-AGENCIA-DEB ,
            :MOVDEBCE-OPER-CONTA-DEB ,
            :MOVDEBCE-NUM-CONTA-DEB ,
            :MOVDEBCE-DIG-CONTA-DEB ,
            :MOVDEBCE-COD-CONVENIO ,
            :MOVDEBCE-DATA-ENVIO:VIND-DTENV ,
            :MOVDEBCE-DATA-RETORNO:VIND-DTRET ,
            :MOVDEBCE-COD-RETORNO-CEF:VIND-CODRET ,
            :MOVDEBCE-NSAS ,
            :MOVDEBCE-COD-USUARIO ,
            :MOVDEBCE-NUM-REQUISICAO:VIND-NREQ ,
            :MOVDEBCE-NUM-CARTAO:VIND-CCRE ,
            :MOVDEBCE-SEQUENCIA:VIND-SEQUEN ,
            :MOVDEBCE-NUM-LOTE:VIND-NLOTE ,
            :MOVDEBCE-DTCREDITO:VIND-DTCRED ,
            :MOVDEBCE-STATUS-CARTAO:VIND-STATUS ,
            :MOVDEBCE-VLR-CREDITO:VIND-VLCRED )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.MOVTO_DEBITOCC_CEF ( COD_EMPRESA , NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , SITUACAO_COBRANCA , DATA_VENCIMENTO , VALOR_DEBITO , DATA_MOVIMENTO , TIMESTAMP , DIA_DEBITO , COD_AGENCIA_DEB , OPER_CONTA_DEB , NUM_CONTA_DEB , DIG_CONTA_DEB , COD_CONVENIO , DATA_ENVIO , DATA_RETORNO , COD_RETORNO_CEF , NSAS , COD_USUARIO , NUM_REQUISICAO , NUM_CARTAO , SEQUENCIA , NUM_LOTE , DTCREDITO , STATUS_CARTAO , VLR_CREDITO ) VALUES ( {FieldThreatment(this.MOVDEBCE_COD_EMPRESA)} , {FieldThreatment(this.MOVDEBCE_NUM_APOLICE)} , {FieldThreatment(this.MOVDEBCE_NUM_ENDOSSO)} , {FieldThreatment(this.MOVDEBCE_NUM_PARCELA)} , {FieldThreatment(this.MOVDEBCE_SITUACAO_COBRANCA)} , {FieldThreatment(this.MOVDEBCE_DATA_VENCIMENTO)} , {FieldThreatment(this.MOVDEBCE_VALOR_DEBITO)} , {FieldThreatment(this.MOVDEBCE_DATA_MOVIMENTO)} , CURRENT TIMESTAMP , {FieldThreatment(this.MOVDEBCE_DIA_DEBITO)} , {FieldThreatment(this.MOVDEBCE_COD_AGENCIA_DEB)} , {FieldThreatment(this.MOVDEBCE_OPER_CONTA_DEB)} , {FieldThreatment(this.MOVDEBCE_NUM_CONTA_DEB)} , {FieldThreatment(this.MOVDEBCE_DIG_CONTA_DEB)} , {FieldThreatment(this.MOVDEBCE_COD_CONVENIO)} ,  {FieldThreatment((this.VIND_DTENV?.ToInt() == -1 ? null : this.MOVDEBCE_DATA_ENVIO))} ,  {FieldThreatment((this.VIND_DTRET?.ToInt() == -1 ? null : this.MOVDEBCE_DATA_RETORNO))} ,  {FieldThreatment((this.VIND_CODRET?.ToInt() == -1 ? null : this.MOVDEBCE_COD_RETORNO_CEF))} , {FieldThreatment(this.MOVDEBCE_NSAS)} , {FieldThreatment(this.MOVDEBCE_COD_USUARIO)} ,  {FieldThreatment((this.VIND_NREQ?.ToInt() == -1 ? null : this.MOVDEBCE_NUM_REQUISICAO))} ,  {FieldThreatment((this.VIND_CCRE?.ToInt() == -1 ? null : this.MOVDEBCE_NUM_CARTAO))} ,  {FieldThreatment((this.VIND_SEQUEN?.ToInt() == -1 ? null : this.MOVDEBCE_SEQUENCIA))} ,  {FieldThreatment((this.VIND_NLOTE?.ToInt() == -1 ? null : this.MOVDEBCE_NUM_LOTE))} ,  {FieldThreatment((this.VIND_DTCRED?.ToInt() == -1 ? null : this.MOVDEBCE_DTCREDITO))} ,  {FieldThreatment((this.VIND_STATUS?.ToInt() == -1 ? null : this.MOVDEBCE_STATUS_CARTAO))} ,  {FieldThreatment((this.VIND_VLCRED?.ToInt() == -1 ? null : this.MOVDEBCE_VLR_CREDITO))} )";

            return query;
        }
        public string MOVDEBCE_COD_EMPRESA { get; set; }
        public string MOVDEBCE_NUM_APOLICE { get; set; }
        public string MOVDEBCE_NUM_ENDOSSO { get; set; }
        public string MOVDEBCE_NUM_PARCELA { get; set; }
        public string MOVDEBCE_SITUACAO_COBRANCA { get; set; }
        public string MOVDEBCE_DATA_VENCIMENTO { get; set; }
        public string MOVDEBCE_VALOR_DEBITO { get; set; }
        public string MOVDEBCE_DATA_MOVIMENTO { get; set; }
        public string MOVDEBCE_DIA_DEBITO { get; set; }
        public string MOVDEBCE_COD_AGENCIA_DEB { get; set; }
        public string MOVDEBCE_OPER_CONTA_DEB { get; set; }
        public string MOVDEBCE_NUM_CONTA_DEB { get; set; }
        public string MOVDEBCE_DIG_CONTA_DEB { get; set; }
        public string MOVDEBCE_COD_CONVENIO { get; set; }
        public string MOVDEBCE_DATA_ENVIO { get; set; }
        public string VIND_DTENV { get; set; }
        public string MOVDEBCE_DATA_RETORNO { get; set; }
        public string VIND_DTRET { get; set; }
        public string MOVDEBCE_COD_RETORNO_CEF { get; set; }
        public string VIND_CODRET { get; set; }
        public string MOVDEBCE_NSAS { get; set; }
        public string MOVDEBCE_COD_USUARIO { get; set; }
        public string MOVDEBCE_NUM_REQUISICAO { get; set; }
        public string VIND_NREQ { get; set; }
        public string MOVDEBCE_NUM_CARTAO { get; set; }
        public string VIND_CCRE { get; set; }
        public string MOVDEBCE_SEQUENCIA { get; set; }
        public string VIND_SEQUEN { get; set; }
        public string MOVDEBCE_NUM_LOTE { get; set; }
        public string VIND_NLOTE { get; set; }
        public string MOVDEBCE_DTCREDITO { get; set; }
        public string VIND_DTCRED { get; set; }
        public string MOVDEBCE_STATUS_CARTAO { get; set; }
        public string VIND_STATUS { get; set; }
        public string MOVDEBCE_VLR_CREDITO { get; set; }
        public string VIND_VLCRED { get; set; }

        public static void Execute(R1650_00_DEBITO_CARTAO_DB_INSERT_1_Insert1 r1650_00_DEBITO_CARTAO_DB_INSERT_1_Insert1)
        {
            var ths = r1650_00_DEBITO_CARTAO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1650_00_DEBITO_CARTAO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}