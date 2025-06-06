using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0601B
{
    public class R3520_00_INSERT_HISTCONTAVA_DB_INSERT_1_Insert1 : QueryBasis<R3520_00_INSERT_HISTCONTAVA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.HIST_LANC_CTA
            ( NUM_CERTIFICADO
            , NUM_PARCELA
            , OCORR_HISTORICOCTA
            , COD_AGENCIA_DEBITO
            , OPE_CONTA_DEBITO
            , NUM_CONTA_DEBITO
            , DIG_CONTA_DEBITO
            , DATA_VENCIMENTO
            , PRM_TOTAL
            , SIT_REGISTRO
            , TIPLANC
            , TIMESTAMP
            , OCORR_HISTORICO
            , CODCONV
            , NSAS
            , NSL
            , NSAC
            , CODRET
            , COD_USUARIO
            , NUM_CARTAO_CREDITO
            , COD_BANCO
            )
            VALUES
            ( :HISLANCT-NUM-CERTIFICADO
            , :HISLANCT-NUM-PARCELA
            , :HISLANCT-OCORR-HISTORICOCTA
            , :HISLANCT-COD-AGENCIA-DEBITO
            , :HISLANCT-OPE-CONTA-DEBITO
            , :HISLANCT-NUM-CONTA-DEBITO
            , :HISLANCT-DIG-CONTA-DEBITO
            , :HISLANCT-DATA-VENCIMENTO
            , :HISLANCT-PRM-TOTAL
            , :HISLANCT-SIT-REGISTRO
            , :HISLANCT-TIPLANC
            , CURRENT TIMESTAMP
            , :HISLANCT-OCORR-HISTORICO
            , :HISLANCT-CODCONV
            , NULL
            , NULL
            , NULL
            , NULL
            , :HISLANCT-COD-USUARIO
            , :HISLANCT-NUM-CARTAO-CREDITO
            , NULL
            )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.HIST_LANC_CTA ( NUM_CERTIFICADO , NUM_PARCELA , OCORR_HISTORICOCTA , COD_AGENCIA_DEBITO , OPE_CONTA_DEBITO , NUM_CONTA_DEBITO , DIG_CONTA_DEBITO , DATA_VENCIMENTO , PRM_TOTAL , SIT_REGISTRO , TIPLANC , TIMESTAMP , OCORR_HISTORICO , CODCONV , NSAS , NSL , NSAC , CODRET , COD_USUARIO , NUM_CARTAO_CREDITO , COD_BANCO ) VALUES ( {FieldThreatment(this.HISLANCT_NUM_CERTIFICADO)} , {FieldThreatment(this.HISLANCT_NUM_PARCELA)} , {FieldThreatment(this.HISLANCT_OCORR_HISTORICOCTA)} , {FieldThreatment(this.HISLANCT_COD_AGENCIA_DEBITO)} , {FieldThreatment(this.HISLANCT_OPE_CONTA_DEBITO)} , {FieldThreatment(this.HISLANCT_NUM_CONTA_DEBITO)} , {FieldThreatment(this.HISLANCT_DIG_CONTA_DEBITO)} , {FieldThreatment(this.HISLANCT_DATA_VENCIMENTO)} , {FieldThreatment(this.HISLANCT_PRM_TOTAL)} , {FieldThreatment(this.HISLANCT_SIT_REGISTRO)} , {FieldThreatment(this.HISLANCT_TIPLANC)} , CURRENT TIMESTAMP , {FieldThreatment(this.HISLANCT_OCORR_HISTORICO)} , {FieldThreatment(this.HISLANCT_CODCONV)} , NULL , NULL , NULL , NULL , {FieldThreatment(this.HISLANCT_COD_USUARIO)} , {FieldThreatment(this.HISLANCT_NUM_CARTAO_CREDITO)} , NULL )";

            return query;
        }
        public string HISLANCT_NUM_CERTIFICADO { get; set; }
        public string HISLANCT_NUM_PARCELA { get; set; }
        public string HISLANCT_OCORR_HISTORICOCTA { get; set; }
        public string HISLANCT_COD_AGENCIA_DEBITO { get; set; }
        public string HISLANCT_OPE_CONTA_DEBITO { get; set; }
        public string HISLANCT_NUM_CONTA_DEBITO { get; set; }
        public string HISLANCT_DIG_CONTA_DEBITO { get; set; }
        public string HISLANCT_DATA_VENCIMENTO { get; set; }
        public string HISLANCT_PRM_TOTAL { get; set; }
        public string HISLANCT_SIT_REGISTRO { get; set; }
        public string HISLANCT_TIPLANC { get; set; }
        public string HISLANCT_OCORR_HISTORICO { get; set; }
        public string HISLANCT_CODCONV { get; set; }
        public string HISLANCT_COD_USUARIO { get; set; }
        public string HISLANCT_NUM_CARTAO_CREDITO { get; set; }

        public static void Execute(R3520_00_INSERT_HISTCONTAVA_DB_INSERT_1_Insert1 r3520_00_INSERT_HISTCONTAVA_DB_INSERT_1_Insert1)
        {
            var ths = r3520_00_INSERT_HISTCONTAVA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3520_00_INSERT_HISTCONTAVA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}