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
    public class R2150_05_INSERT_HISTLANCCTA_DB_INSERT_1_Insert1 : QueryBasis<R2150_05_INSERT_HISTLANCCTA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.HIST_LANC_CTA
            (NUM_CERTIFICADO,
            NUM_PARCELA,
            OCORR_HISTORICOCTA,
            COD_AGENCIA_DEBITO,
            OPE_CONTA_DEBITO,
            NUM_CONTA_DEBITO,
            DIG_CONTA_DEBITO,
            DATA_VENCIMENTO,
            PRM_TOTAL,
            SIT_REGISTRO,
            TIPLANC,
            TIMESTAMP,
            OCORR_HISTORICO,
            CODCONV,
            NSAS,
            NSL,
            NSAC,
            CODRET,
            COD_USUARIO,
            NUM_CARTAO_CREDITO,
            COD_BANCO)
            VALUES (:RELATORI-NUM-CERTIFICADO,
            :RELATORI-NUM-PARCELA,
            :PARCEVID-OCORR-HISTORICO,
            :OPCPAGVI-COD-AGENCIA-DEBITO,
            :OPCPAGVI-OPE-CONTA-DEBITO,
            :OPCPAGVI-NUM-CONTA-DEBITO,
            :OPCPAGVI-DIG-CONTA-DEBITO,
            :WHOST-DATA-CRED,
            :WHOST-NEW-PRM,
            :HISLANCT-SIT-REGISTRO,
            :HISLANCT-TIPLANC,
            CURRENT TIMESTAMP,
            1,
            :CONVEVG-COD-NAOACEITE,
            NULL,
            NULL,
            NULL,
            :HISLANCT-CODRET :VIND-CODRET,
            :RELATORI-COD-USUARIO,
            0,
            :HISLANCT-COD-BANCO:VIND-BANCO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.HIST_LANC_CTA (NUM_CERTIFICADO, NUM_PARCELA, OCORR_HISTORICOCTA, COD_AGENCIA_DEBITO, OPE_CONTA_DEBITO, NUM_CONTA_DEBITO, DIG_CONTA_DEBITO, DATA_VENCIMENTO, PRM_TOTAL, SIT_REGISTRO, TIPLANC, TIMESTAMP, OCORR_HISTORICO, CODCONV, NSAS, NSL, NSAC, CODRET, COD_USUARIO, NUM_CARTAO_CREDITO, COD_BANCO) VALUES ({FieldThreatment(this.RELATORI_NUM_CERTIFICADO)}, {FieldThreatment(this.RELATORI_NUM_PARCELA)}, {FieldThreatment(this.PARCEVID_OCORR_HISTORICO)}, {FieldThreatment(this.OPCPAGVI_COD_AGENCIA_DEBITO)}, {FieldThreatment(this.OPCPAGVI_OPE_CONTA_DEBITO)}, {FieldThreatment(this.OPCPAGVI_NUM_CONTA_DEBITO)}, {FieldThreatment(this.OPCPAGVI_DIG_CONTA_DEBITO)}, {FieldThreatment(this.WHOST_DATA_CRED)}, {FieldThreatment(this.WHOST_NEW_PRM)}, {FieldThreatment(this.HISLANCT_SIT_REGISTRO)}, {FieldThreatment(this.HISLANCT_TIPLANC)}, CURRENT TIMESTAMP, 1, {FieldThreatment(this.CONVEVG_COD_NAOACEITE)}, NULL, NULL, NULL,  {FieldThreatment((this.VIND_CODRET?.ToInt() == -1 ? null : this.HISLANCT_CODRET))}, {FieldThreatment(this.RELATORI_COD_USUARIO)}, 0,  {FieldThreatment((this.VIND_BANCO?.ToInt() == -1 ? null : this.HISLANCT_COD_BANCO))})";

            return query;
        }
        public string RELATORI_NUM_CERTIFICADO { get; set; }
        public string RELATORI_NUM_PARCELA { get; set; }
        public string PARCEVID_OCORR_HISTORICO { get; set; }
        public string OPCPAGVI_COD_AGENCIA_DEBITO { get; set; }
        public string OPCPAGVI_OPE_CONTA_DEBITO { get; set; }
        public string OPCPAGVI_NUM_CONTA_DEBITO { get; set; }
        public string OPCPAGVI_DIG_CONTA_DEBITO { get; set; }
        public string WHOST_DATA_CRED { get; set; }
        public string WHOST_NEW_PRM { get; set; }
        public string HISLANCT_SIT_REGISTRO { get; set; }
        public string HISLANCT_TIPLANC { get; set; }
        public string CONVEVG_COD_NAOACEITE { get; set; }
        public string HISLANCT_CODRET { get; set; }
        public string VIND_CODRET { get; set; }
        public string RELATORI_COD_USUARIO { get; set; }
        public string HISLANCT_COD_BANCO { get; set; }
        public string VIND_BANCO { get; set; }

        public static void Execute(R2150_05_INSERT_HISTLANCCTA_DB_INSERT_1_Insert1 r2150_05_INSERT_HISTLANCCTA_DB_INSERT_1_Insert1)
        {
            var ths = r2150_05_INSERT_HISTLANCCTA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2150_05_INSERT_HISTLANCCTA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}