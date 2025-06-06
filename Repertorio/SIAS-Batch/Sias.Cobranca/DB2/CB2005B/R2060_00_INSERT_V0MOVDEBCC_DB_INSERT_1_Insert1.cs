using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB2005B
{
    public class R2060_00_INSERT_V0MOVDEBCC_DB_INSERT_1_Insert1 : QueryBasis<R2060_00_INSERT_V0MOVDEBCC_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0MOVDEBCC_CEF
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
            VALUES (:V0MVDB-COD-EMPRESA ,
            :V0MVDB-NUM-APOL ,
            :V0MVDB-NRENDOS ,
            :V0MVDB-NRPARCEL ,
            :V0MVDB-SITUACAO,
            :V0MVDB-DTVENCTO,
            :V0MVDB-VLR-DEBITO,
            :V0MVDB-DTMOVTO ,
            CURRENT TIMESTAMP,
            :V0MVDB-DIA-DEBITO:VIND-DIADEBITO,
            :V0MVDB-AGENCIA-DEB:VIND-AGENCIA,
            :V0MVDB-OPERACAO-DEB:VIND-OPERACAO,
            :V0MVDB-NUMCTA-DEB:VIND-NUMCONTA,
            :V0MVDB-DIGCTA-DEB:VIND-DIGCONTA,
            :V0MVDB-CONVENIO ,
            :V0MVDB-DTENVIO:VIND-DTENVIO,
            :V0MVDB-DTRETORNO:VIND-DTRETORNO,
            :V0MVDB-COD-RETORNO:VIND-CODRETORNO,
            :V0MVDB-NSAS ,
            :V0MVDB-COD-USUARIO:VIND-USUARIO,
            :V0MVDB-REQUISICAO:VIND-REQUISICAO,
            :V0MVDB-NUM-CARTAO:VIND-NUMCARTAO,
            :V0MVDB-SEQUENCIA:VIND-SEQUENCIA,
            :V0MVDB-NUM-LOTE:VIND-NUM-LOTE,
            :V0MVDB-DTCREDITO:VIND-DTCREDITO,
            :V0MVDB-STATUS:VIND-STATUS,
            :V0MVDB-VLR-CREDITO:VIND-VLCREDITO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0MOVDEBCC_CEF ( COD_EMPRESA ,NUM_APOLICE ,NRENDOS ,NRPARCEL ,SIT_COBRANCA ,DTVENCTO ,VLR_DEBITO ,DTMOVTO ,TIMESTAMP ,DIA_DEBITO ,COD_AGENCIA_DEB ,OPER_CONTA_DEB ,NUM_CONTA_DEB ,DIG_CONTA_DEB ,COD_CONVENIO ,DTENVIO ,DTRETORNO ,COD_RETORNO_CEF ,NSAS ,COD_USUARIO ,NUM_REQUISICAO ,NUM_CARTAO ,SEQUENCIA ,NUM_LOTE ,DTCREDITO ,STATUS_CARTAO ,VLR_CREDITO ) VALUES ({FieldThreatment(this.V0MVDB_COD_EMPRESA)} , {FieldThreatment(this.V0MVDB_NUM_APOL)} , {FieldThreatment(this.V0MVDB_NRENDOS)} , {FieldThreatment(this.V0MVDB_NRPARCEL)} , {FieldThreatment(this.V0MVDB_SITUACAO)}, {FieldThreatment(this.V0MVDB_DTVENCTO)}, {FieldThreatment(this.V0MVDB_VLR_DEBITO)}, {FieldThreatment(this.V0MVDB_DTMOVTO)} , CURRENT TIMESTAMP,  {FieldThreatment((this.VIND_DIADEBITO?.ToInt() == -1 ? null : this.V0MVDB_DIA_DEBITO))},  {FieldThreatment((this.VIND_AGENCIA?.ToInt() == -1 ? null : this.V0MVDB_AGENCIA_DEB))},  {FieldThreatment((this.VIND_OPERACAO?.ToInt() == -1 ? null : this.V0MVDB_OPERACAO_DEB))},  {FieldThreatment((this.VIND_NUMCONTA?.ToInt() == -1 ? null : this.V0MVDB_NUMCTA_DEB))},  {FieldThreatment((this.VIND_DIGCONTA?.ToInt() == -1 ? null : this.V0MVDB_DIGCTA_DEB))}, {FieldThreatment(this.V0MVDB_CONVENIO)} ,  {FieldThreatment((this.VIND_DTENVIO?.ToInt() == -1 ? null : this.V0MVDB_DTENVIO))},  {FieldThreatment((this.VIND_DTRETORNO?.ToInt() == -1 ? null : this.V0MVDB_DTRETORNO))},  {FieldThreatment((this.VIND_CODRETORNO?.ToInt() == -1 ? null : this.V0MVDB_COD_RETORNO))}, {FieldThreatment(this.V0MVDB_NSAS)} ,  {FieldThreatment((this.VIND_USUARIO?.ToInt() == -1 ? null : this.V0MVDB_COD_USUARIO))},  {FieldThreatment((this.VIND_REQUISICAO?.ToInt() == -1 ? null : this.V0MVDB_REQUISICAO))},  {FieldThreatment((this.VIND_NUMCARTAO?.ToInt() == -1 ? null : this.V0MVDB_NUM_CARTAO))},  {FieldThreatment((this.VIND_SEQUENCIA?.ToInt() == -1 ? null : this.V0MVDB_SEQUENCIA))},  {FieldThreatment((this.VIND_NUM_LOTE?.ToInt() == -1 ? null : this.V0MVDB_NUM_LOTE))},  {FieldThreatment((this.VIND_DTCREDITO?.ToInt() == -1 ? null : this.V0MVDB_DTCREDITO))},  {FieldThreatment((this.VIND_STATUS?.ToInt() == -1 ? null : this.V0MVDB_STATUS))},  {FieldThreatment((this.VIND_VLCREDITO?.ToInt() == -1 ? null : this.V0MVDB_VLR_CREDITO))})";

            return query;
        }
        public string V0MVDB_COD_EMPRESA { get; set; }
        public string V0MVDB_NUM_APOL { get; set; }
        public string V0MVDB_NRENDOS { get; set; }
        public string V0MVDB_NRPARCEL { get; set; }
        public string V0MVDB_SITUACAO { get; set; }
        public string V0MVDB_DTVENCTO { get; set; }
        public string V0MVDB_VLR_DEBITO { get; set; }
        public string V0MVDB_DTMOVTO { get; set; }
        public string V0MVDB_DIA_DEBITO { get; set; }
        public string VIND_DIADEBITO { get; set; }
        public string V0MVDB_AGENCIA_DEB { get; set; }
        public string VIND_AGENCIA { get; set; }
        public string V0MVDB_OPERACAO_DEB { get; set; }
        public string VIND_OPERACAO { get; set; }
        public string V0MVDB_NUMCTA_DEB { get; set; }
        public string VIND_NUMCONTA { get; set; }
        public string V0MVDB_DIGCTA_DEB { get; set; }
        public string VIND_DIGCONTA { get; set; }
        public string V0MVDB_CONVENIO { get; set; }
        public string V0MVDB_DTENVIO { get; set; }
        public string VIND_DTENVIO { get; set; }
        public string V0MVDB_DTRETORNO { get; set; }
        public string VIND_DTRETORNO { get; set; }
        public string V0MVDB_COD_RETORNO { get; set; }
        public string VIND_CODRETORNO { get; set; }
        public string V0MVDB_NSAS { get; set; }
        public string V0MVDB_COD_USUARIO { get; set; }
        public string VIND_USUARIO { get; set; }
        public string V0MVDB_REQUISICAO { get; set; }
        public string VIND_REQUISICAO { get; set; }
        public string V0MVDB_NUM_CARTAO { get; set; }
        public string VIND_NUMCARTAO { get; set; }
        public string V0MVDB_SEQUENCIA { get; set; }
        public string VIND_SEQUENCIA { get; set; }
        public string V0MVDB_NUM_LOTE { get; set; }
        public string VIND_NUM_LOTE { get; set; }
        public string V0MVDB_DTCREDITO { get; set; }
        public string VIND_DTCREDITO { get; set; }
        public string V0MVDB_STATUS { get; set; }
        public string VIND_STATUS { get; set; }
        public string V0MVDB_VLR_CREDITO { get; set; }
        public string VIND_VLCREDITO { get; set; }

        public static void Execute(R2060_00_INSERT_V0MOVDEBCC_DB_INSERT_1_Insert1 r2060_00_INSERT_V0MOVDEBCC_DB_INSERT_1_Insert1)
        {
            var ths = r2060_00_INSERT_V0MOVDEBCC_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2060_00_INSERT_V0MOVDEBCC_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}