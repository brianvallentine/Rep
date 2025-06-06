using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0001B
{
    public class M_2800_INSERT_HISTCONTAVA_DB_INSERT_1_Insert1 : QueryBasis<M_2800_INSERT_HISTCONTAVA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.HIST_LANC_CTA
            (NUM_CERTIFICADO ,
            NUM_PARCELA ,
            OCORR_HISTORICOCTA ,
            COD_AGENCIA_DEBITO ,
            OPE_CONTA_DEBITO ,
            NUM_CONTA_DEBITO ,
            DIG_CONTA_DEBITO ,
            DATA_VENCIMENTO ,
            PRM_TOTAL ,
            SIT_REGISTRO ,
            TIPLANC ,
            TIMESTAMP ,
            OCORR_HISTORICO ,
            CODCONV ,
            NSAS ,
            NSL ,
            NSAC ,
            CODRET ,
            COD_USUARIO)
            VALUES (:NUMEROUT-NUM-CERT-VGAP,
            :PROPOVA-NUM-PARCELA,
            1,
            :OPCPAGVI-COD-AGENCIA-DEBITO,
            :OPCPAGVI-OPE-CONTA-DEBITO,
            :OPCPAGVI-NUM-CONTA-DEBITO,
            :OPCPAGVI-DIG-CONTA-DEBITO,
            :PROPOVA-DATA-VENCIMENTO,
            :COBHISVI-PRM-TOTAL,
            :HISLANCT-SIT-REGISTRO,
            :HISLANCT-TIPLANC,
            CURRENT TIMESTAMP,
            :HISLANCT-OCORR-HISTORICO,
            :HISLANCT-CODCONV,
            NULL,
            NULL,
            NULL,
            NULL,
            :HISLANCT-COD-USUARIO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.HIST_LANC_CTA (NUM_CERTIFICADO , NUM_PARCELA , OCORR_HISTORICOCTA , COD_AGENCIA_DEBITO , OPE_CONTA_DEBITO , NUM_CONTA_DEBITO , DIG_CONTA_DEBITO , DATA_VENCIMENTO , PRM_TOTAL , SIT_REGISTRO , TIPLANC , TIMESTAMP , OCORR_HISTORICO , CODCONV , NSAS , NSL , NSAC , CODRET , COD_USUARIO) VALUES ({FieldThreatment(this.NUMEROUT_NUM_CERT_VGAP)}, {FieldThreatment(this.PROPOVA_NUM_PARCELA)}, 1, {FieldThreatment(this.OPCPAGVI_COD_AGENCIA_DEBITO)}, {FieldThreatment(this.OPCPAGVI_OPE_CONTA_DEBITO)}, {FieldThreatment(this.OPCPAGVI_NUM_CONTA_DEBITO)}, {FieldThreatment(this.OPCPAGVI_DIG_CONTA_DEBITO)}, {FieldThreatment(this.PROPOVA_DATA_VENCIMENTO)}, {FieldThreatment(this.COBHISVI_PRM_TOTAL)}, {FieldThreatment(this.HISLANCT_SIT_REGISTRO)}, {FieldThreatment(this.HISLANCT_TIPLANC)}, CURRENT TIMESTAMP, {FieldThreatment(this.HISLANCT_OCORR_HISTORICO)}, {FieldThreatment(this.HISLANCT_CODCONV)}, NULL, NULL, NULL, NULL, {FieldThreatment(this.HISLANCT_COD_USUARIO)})";

            return query;
        }
        public string NUMEROUT_NUM_CERT_VGAP { get; set; }
        public string PROPOVA_NUM_PARCELA { get; set; }
        public string OPCPAGVI_COD_AGENCIA_DEBITO { get; set; }
        public string OPCPAGVI_OPE_CONTA_DEBITO { get; set; }
        public string OPCPAGVI_NUM_CONTA_DEBITO { get; set; }
        public string OPCPAGVI_DIG_CONTA_DEBITO { get; set; }
        public string PROPOVA_DATA_VENCIMENTO { get; set; }
        public string COBHISVI_PRM_TOTAL { get; set; }
        public string HISLANCT_SIT_REGISTRO { get; set; }
        public string HISLANCT_TIPLANC { get; set; }
        public string HISLANCT_OCORR_HISTORICO { get; set; }
        public string HISLANCT_CODCONV { get; set; }
        public string HISLANCT_COD_USUARIO { get; set; }

        public static void Execute(M_2800_INSERT_HISTCONTAVA_DB_INSERT_1_Insert1 m_2800_INSERT_HISTCONTAVA_DB_INSERT_1_Insert1)
        {
            var ths = m_2800_INSERT_HISTCONTAVA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_2800_INSERT_HISTCONTAVA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}