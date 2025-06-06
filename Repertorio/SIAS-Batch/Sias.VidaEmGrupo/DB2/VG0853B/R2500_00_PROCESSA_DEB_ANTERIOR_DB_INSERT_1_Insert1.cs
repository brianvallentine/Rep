using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0853B
{
    public class R2500_00_PROCESSA_DEB_ANTERIOR_DB_INSERT_1_Insert1 : QueryBasis<R2500_00_PROCESSA_DEB_ANTERIOR_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.HIST_LANC_CTA
            (NUM_CERTIFICADO
            ,NUM_PARCELA
            ,OCORR_HISTORICOCTA
            ,COD_AGENCIA_DEBITO
            ,OPE_CONTA_DEBITO
            ,NUM_CONTA_DEBITO
            ,DIG_CONTA_DEBITO
            ,DATA_VENCIMENTO
            ,PRM_TOTAL
            ,SIT_REGISTRO
            ,TIPLANC
            ,TIMESTAMP
            ,OCORR_HISTORICO
            ,CODCONV
            ,NSAS
            ,NSL
            ,NSAC
            ,CODRET
            ,COD_USUARIO
            ,NUM_CARTAO_CREDITO )
            VALUES (:HISLANCT-NUM-CERTIFICADO
            ,:HISLANCT-NUM-PARCELA
            ,:HISLANCT-OCORR-HISTORICOCTA
            ,:HISLANCT-COD-AGENCIA-DEBITO
            ,:HISLANCT-OPE-CONTA-DEBITO
            ,:HISLANCT-NUM-CONTA-DEBITO
            ,:HISLANCT-DIG-CONTA-DEBITO
            ,:V0PROP-DTVENCTO
            ,:HISLANCT-PRM-TOTAL
            , '0'
            , '1'
            ,CURRENT_TIMESTAMP
            ,:HISLANCT-OCORR-HISTORICO
            ,:HISLANCT-CODCONV
            ,NULL
            ,NULL
            ,NULL
            ,NULL
            , 'VG0853B'
            ,0)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.HIST_LANC_CTA (NUM_CERTIFICADO ,NUM_PARCELA ,OCORR_HISTORICOCTA ,COD_AGENCIA_DEBITO ,OPE_CONTA_DEBITO ,NUM_CONTA_DEBITO ,DIG_CONTA_DEBITO ,DATA_VENCIMENTO ,PRM_TOTAL ,SIT_REGISTRO ,TIPLANC ,TIMESTAMP ,OCORR_HISTORICO ,CODCONV ,NSAS ,NSL ,NSAC ,CODRET ,COD_USUARIO ,NUM_CARTAO_CREDITO ) VALUES ({FieldThreatment(this.HISLANCT_NUM_CERTIFICADO)} ,{FieldThreatment(this.HISLANCT_NUM_PARCELA)} ,{FieldThreatment(this.HISLANCT_OCORR_HISTORICOCTA)} ,{FieldThreatment(this.HISLANCT_COD_AGENCIA_DEBITO)} ,{FieldThreatment(this.HISLANCT_OPE_CONTA_DEBITO)} ,{FieldThreatment(this.HISLANCT_NUM_CONTA_DEBITO)} ,{FieldThreatment(this.HISLANCT_DIG_CONTA_DEBITO)} ,{FieldThreatment(this.V0PROP_DTVENCTO)} ,{FieldThreatment(this.HISLANCT_PRM_TOTAL)} , '0' , '1' ,CURRENT_TIMESTAMP ,{FieldThreatment(this.HISLANCT_OCORR_HISTORICO)} ,{FieldThreatment(this.HISLANCT_CODCONV)} ,NULL ,NULL ,NULL ,NULL , 'VG0853B' ,0)";

            return query;
        }
        public string HISLANCT_NUM_CERTIFICADO { get; set; }
        public string HISLANCT_NUM_PARCELA { get; set; }
        public string HISLANCT_OCORR_HISTORICOCTA { get; set; }
        public string HISLANCT_COD_AGENCIA_DEBITO { get; set; }
        public string HISLANCT_OPE_CONTA_DEBITO { get; set; }
        public string HISLANCT_NUM_CONTA_DEBITO { get; set; }
        public string HISLANCT_DIG_CONTA_DEBITO { get; set; }
        public string V0PROP_DTVENCTO { get; set; }
        public string HISLANCT_PRM_TOTAL { get; set; }
        public string HISLANCT_OCORR_HISTORICO { get; set; }
        public string HISLANCT_CODCONV { get; set; }

        public static void Execute(R2500_00_PROCESSA_DEB_ANTERIOR_DB_INSERT_1_Insert1 r2500_00_PROCESSA_DEB_ANTERIOR_DB_INSERT_1_Insert1)
        {
            var ths = r2500_00_PROCESSA_DEB_ANTERIOR_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2500_00_PROCESSA_DEB_ANTERIOR_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}