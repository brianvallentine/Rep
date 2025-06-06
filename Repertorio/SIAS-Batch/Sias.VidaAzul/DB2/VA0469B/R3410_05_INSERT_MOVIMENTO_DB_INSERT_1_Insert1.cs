using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0469B
{
    public class R3410_05_INSERT_MOVIMENTO_DB_INSERT_1_Insert1 : QueryBasis<R3410_05_INSERT_MOVIMENTO_DB_INSERT_1_Insert1>
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
            VLR_CREDITO ,
            NUM_CERTIFICADO,
            COD_MOEDA ,
            PCT_INDICE ,
            VLR_ORIGINAL ,
            VLR_PRORATA ,
            VLR_JUROS ,
            VLR_MULTA ,
            DTA_ORIGINAL ,
            COD_IDLG )
            VALUES
            ( :MOVDEBCE-COD-EMPRESA ,
            :MOVDEBCE-NUM-APOLICE ,
            :MOVDEBCE-NUM-ENDOSSO ,
            :MOVDEBCE-NUM-PARCELA ,
            :MOVDEBCE-SITUACAO-COBRANCA ,
            :MOVDEBCE-DATA-VENCIMENTO ,
            :MOVDEBCE-VALOR-DEBITO,
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
            :MOVDEBCE-VLR-CREDITO:VIND-VLCRED ,
            :MOVDEBCE-NUM-CERTIFICADO ,
            :MOVDEBCE-COD-MOEDA :VIND-COD-MOEDA ,
            :MOVDEBCE-PCT-INDICE :VIND-PCT-INDICE ,
            :MOVDEBCE-VLR-ORIGINAL :VIND-VLR-ORIGINAL ,
            :MOVDEBCE-VLR-PRORATA :VIND-VLR-PRORATA ,
            :MOVDEBCE-VLR-JUROS :VIND-VLR-JUROS ,
            :MOVDEBCE-VLR-MULTA :VIND-VLR-MULTA ,
            :MOVDEBCE-DTA-ORIGINAL :VIND-DTA-ORIGINAL ,
            :MOVDEBCE-COD-IDLG :VIND-COD-IDLG)
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.MOVTO_DEBITOCC_CEF ( COD_EMPRESA , NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , SITUACAO_COBRANCA , DATA_VENCIMENTO , VALOR_DEBITO , DATA_MOVIMENTO , TIMESTAMP , DIA_DEBITO , COD_AGENCIA_DEB , OPER_CONTA_DEB , NUM_CONTA_DEB , DIG_CONTA_DEB , COD_CONVENIO , DATA_ENVIO , DATA_RETORNO , COD_RETORNO_CEF , NSAS , COD_USUARIO , NUM_REQUISICAO , NUM_CARTAO , SEQUENCIA , NUM_LOTE , DTCREDITO , STATUS_CARTAO , VLR_CREDITO , NUM_CERTIFICADO, COD_MOEDA , PCT_INDICE , VLR_ORIGINAL , VLR_PRORATA , VLR_JUROS , VLR_MULTA , DTA_ORIGINAL , COD_IDLG ) VALUES ( {FieldThreatment(this.MOVDEBCE_COD_EMPRESA)} , {FieldThreatment(this.MOVDEBCE_NUM_APOLICE)} , {FieldThreatment(this.MOVDEBCE_NUM_ENDOSSO)} , {FieldThreatment(this.MOVDEBCE_NUM_PARCELA)} , {FieldThreatment(this.MOVDEBCE_SITUACAO_COBRANCA)} , {FieldThreatment(this.MOVDEBCE_DATA_VENCIMENTO)} , {FieldThreatment(this.MOVDEBCE_VALOR_DEBITO)}, {FieldThreatment(this.MOVDEBCE_DATA_MOVIMENTO)} , CURRENT TIMESTAMP , {FieldThreatment(this.MOVDEBCE_DIA_DEBITO)} , {FieldThreatment(this.MOVDEBCE_COD_AGENCIA_DEB)} , {FieldThreatment(this.MOVDEBCE_OPER_CONTA_DEB)} , {FieldThreatment(this.MOVDEBCE_NUM_CONTA_DEB)} , {FieldThreatment(this.MOVDEBCE_DIG_CONTA_DEB)} , {FieldThreatment(this.MOVDEBCE_COD_CONVENIO)} ,  {FieldThreatment((this.VIND_DTENV?.ToInt() == -1 ? null : this.MOVDEBCE_DATA_ENVIO))} ,  {FieldThreatment((this.VIND_DTRET?.ToInt() == -1 ? null : this.MOVDEBCE_DATA_RETORNO))} ,  {FieldThreatment((this.VIND_CODRET?.ToInt() == -1 ? null : this.MOVDEBCE_COD_RETORNO_CEF))} , {FieldThreatment(this.MOVDEBCE_NSAS)} , {FieldThreatment(this.MOVDEBCE_COD_USUARIO)} ,  {FieldThreatment((this.VIND_NREQ?.ToInt() == -1 ? null : this.MOVDEBCE_NUM_REQUISICAO))} ,  {FieldThreatment((this.VIND_CCRE?.ToInt() == -1 ? null : this.MOVDEBCE_NUM_CARTAO))} ,  {FieldThreatment((this.VIND_SEQUEN?.ToInt() == -1 ? null : this.MOVDEBCE_SEQUENCIA))} ,  {FieldThreatment((this.VIND_NLOTE?.ToInt() == -1 ? null : this.MOVDEBCE_NUM_LOTE))} ,  {FieldThreatment((this.VIND_DTCRED?.ToInt() == -1 ? null : this.MOVDEBCE_DTCREDITO))} ,  {FieldThreatment((this.VIND_STATUS?.ToInt() == -1 ? null : this.MOVDEBCE_STATUS_CARTAO))} ,  {FieldThreatment((this.VIND_VLCRED?.ToInt() == -1 ? null : this.MOVDEBCE_VLR_CREDITO))} , {FieldThreatment(this.MOVDEBCE_NUM_CERTIFICADO)} ,  {FieldThreatment((this.VIND_COD_MOEDA?.ToInt() == -1 ? null : this.MOVDEBCE_COD_MOEDA))} ,  {FieldThreatment((this.VIND_PCT_INDICE?.ToInt() == -1 ? null : this.MOVDEBCE_PCT_INDICE))} ,  {FieldThreatment((this.VIND_VLR_ORIGINAL?.ToInt() == -1 ? null : this.MOVDEBCE_VLR_ORIGINAL))} ,  {FieldThreatment((this.VIND_VLR_PRORATA?.ToInt() == -1 ? null : this.MOVDEBCE_VLR_PRORATA))} ,  {FieldThreatment((this.VIND_VLR_JUROS?.ToInt() == -1 ? null : this.MOVDEBCE_VLR_JUROS))} ,  {FieldThreatment((this.VIND_VLR_MULTA?.ToInt() == -1 ? null : this.MOVDEBCE_VLR_MULTA))} ,  {FieldThreatment((this.VIND_DTA_ORIGINAL?.ToInt() == -1 ? null : this.MOVDEBCE_DTA_ORIGINAL))} ,  {FieldThreatment((this.VIND_COD_IDLG?.ToInt() == -1 ? null : this.MOVDEBCE_COD_IDLG))})";

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
        public string MOVDEBCE_NUM_CERTIFICADO { get; set; }
        public string MOVDEBCE_COD_MOEDA { get; set; }
        public string VIND_COD_MOEDA { get; set; }
        public string MOVDEBCE_PCT_INDICE { get; set; }
        public string VIND_PCT_INDICE { get; set; }
        public string MOVDEBCE_VLR_ORIGINAL { get; set; }
        public string VIND_VLR_ORIGINAL { get; set; }
        public string MOVDEBCE_VLR_PRORATA { get; set; }
        public string VIND_VLR_PRORATA { get; set; }
        public string MOVDEBCE_VLR_JUROS { get; set; }
        public string VIND_VLR_JUROS { get; set; }
        public string MOVDEBCE_VLR_MULTA { get; set; }
        public string VIND_VLR_MULTA { get; set; }
        public string MOVDEBCE_DTA_ORIGINAL { get; set; }
        public string VIND_DTA_ORIGINAL { get; set; }
        public string MOVDEBCE_COD_IDLG { get; set; }
        public string VIND_COD_IDLG { get; set; }

        public static void Execute(R3410_05_INSERT_MOVIMENTO_DB_INSERT_1_Insert1 r3410_05_INSERT_MOVIMENTO_DB_INSERT_1_Insert1)
        {
            var ths = r3410_05_INSERT_MOVIMENTO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3410_05_INSERT_MOVIMENTO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}