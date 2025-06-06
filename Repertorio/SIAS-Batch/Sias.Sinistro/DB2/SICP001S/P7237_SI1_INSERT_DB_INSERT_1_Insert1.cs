using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SICP001S
{
    public class P7237_SI1_INSERT_DB_INSERT_1_Insert1 : QueryBasis<P7237_SI1_INSERT_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.SI_MOVTO_PGTO_COB (
            NUM_SINISTRO
            ,OCORR_HISTORICO
            ,IDE_SISTEMA
            ,COD_OPERACAO
            ,NUM_ID_ENVIO
            ,SEQ_ID_ENVIO_HIST
            ,STA_ENVIO_MOVIMENTO
            ,DTA_SI_ENVIO
            ,DTA_SI_RETORNO_H
            ,DTA_EFETIVO_PGTO
            ,COD_USUARIO
            ,COD_PROGRAMA
            ,DTH_CADASTRAMENTO
            ,SEQ_MOVTO_ARQH
            ,STA_MOVTO_HISTORICO
            ,QTD_RETORNO_ARQH
            ,COD_EMPRESA
            )
            VALUES (
            :SI237-NUM-SINISTRO
            ,:SI237-OCORR-HISTORICO
            ,:SI237-IDE-SISTEMA
            ,:SI237-COD-OPERACAO
            ,:SI237-NUM-ID-ENVIO
            :WH-ID-ENVIO-NULL
            ,:SI237-SEQ-ID-ENVIO-HIST
            :WH-ID-ENVIO-HIST-NULL
            ,:SI237-STA-ENVIO-MOVIMENTO
            ,:SI237-DTA-SI-ENVIO
            :WH-SI-ENVIO-NULL
            ,:SI237-DTA-SI-RETORNO-H
            :WH-SI-RETORNO-H-NULL
            ,:SI237-DTA-EFETIVO-PGTO
            :WH-EFETIVO-PGTO-NULL
            ,:SI237-COD-USUARIO
            ,:SI237-COD-PROGRAMA
            ,CURRENT TIMESTAMP
            ,:SI237-SEQ-MOVTO-ARQH
            :WH-MOVTO-ARQH-NULL
            ,:SI237-STA-MOVTO-HISTORICO
            :WH-MOVTO-HISTORICO-NULL
            ,:SI237-QTD-RETORNO-ARQH
            ,:SI237-COD-EMPRESA
            )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.SI_MOVTO_PGTO_COB ( NUM_SINISTRO ,OCORR_HISTORICO ,IDE_SISTEMA ,COD_OPERACAO ,NUM_ID_ENVIO ,SEQ_ID_ENVIO_HIST ,STA_ENVIO_MOVIMENTO ,DTA_SI_ENVIO ,DTA_SI_RETORNO_H ,DTA_EFETIVO_PGTO ,COD_USUARIO ,COD_PROGRAMA ,DTH_CADASTRAMENTO ,SEQ_MOVTO_ARQH ,STA_MOVTO_HISTORICO ,QTD_RETORNO_ARQH ,COD_EMPRESA ) VALUES ( {FieldThreatment(this.SI237_NUM_SINISTRO)} ,{FieldThreatment(this.SI237_OCORR_HISTORICO)} ,{FieldThreatment(this.SI237_IDE_SISTEMA)} ,{FieldThreatment(this.SI237_COD_OPERACAO)} , {FieldThreatment((this.WH_ID_ENVIO_NULL?.ToInt() == -1 ? null : this.SI237_NUM_ID_ENVIO))} , {FieldThreatment((this.WH_ID_ENVIO_HIST_NULL?.ToInt() == -1 ? null : this.SI237_SEQ_ID_ENVIO_HIST))} ,{FieldThreatment(this.SI237_STA_ENVIO_MOVIMENTO)} , {FieldThreatment((this.WH_SI_ENVIO_NULL?.ToInt() == -1 ? null : this.SI237_DTA_SI_ENVIO))} , {FieldThreatment((this.WH_SI_RETORNO_H_NULL?.ToInt() == -1 ? null : this.SI237_DTA_SI_RETORNO_H))} , {FieldThreatment((this.WH_EFETIVO_PGTO_NULL?.ToInt() == -1 ? null : this.SI237_DTA_EFETIVO_PGTO))} ,{FieldThreatment(this.SI237_COD_USUARIO)} ,{FieldThreatment(this.SI237_COD_PROGRAMA)} ,CURRENT TIMESTAMP , {FieldThreatment((this.WH_MOVTO_ARQH_NULL?.ToInt() == -1 ? null : this.SI237_SEQ_MOVTO_ARQH))} , {FieldThreatment((this.WH_MOVTO_HISTORICO_NULL?.ToInt() == -1 ? null : this.SI237_STA_MOVTO_HISTORICO))} ,{FieldThreatment(this.SI237_QTD_RETORNO_ARQH)} ,{FieldThreatment(this.SI237_COD_EMPRESA)} )";

            return query;
        }
        public string SI237_NUM_SINISTRO { get; set; }
        public string SI237_OCORR_HISTORICO { get; set; }
        public string SI237_IDE_SISTEMA { get; set; }
        public string SI237_COD_OPERACAO { get; set; }
        public string SI237_NUM_ID_ENVIO { get; set; }
        public string WH_ID_ENVIO_NULL { get; set; }
        public string SI237_SEQ_ID_ENVIO_HIST { get; set; }
        public string WH_ID_ENVIO_HIST_NULL { get; set; }
        public string SI237_STA_ENVIO_MOVIMENTO { get; set; }
        public string SI237_DTA_SI_ENVIO { get; set; }
        public string WH_SI_ENVIO_NULL { get; set; }
        public string SI237_DTA_SI_RETORNO_H { get; set; }
        public string WH_SI_RETORNO_H_NULL { get; set; }
        public string SI237_DTA_EFETIVO_PGTO { get; set; }
        public string WH_EFETIVO_PGTO_NULL { get; set; }
        public string SI237_COD_USUARIO { get; set; }
        public string SI237_COD_PROGRAMA { get; set; }
        public string SI237_SEQ_MOVTO_ARQH { get; set; }
        public string WH_MOVTO_ARQH_NULL { get; set; }
        public string SI237_STA_MOVTO_HISTORICO { get; set; }
        public string WH_MOVTO_HISTORICO_NULL { get; set; }
        public string SI237_QTD_RETORNO_ARQH { get; set; }
        public string SI237_COD_EMPRESA { get; set; }

        public static void Execute(P7237_SI1_INSERT_DB_INSERT_1_Insert1 p7237_SI1_INSERT_DB_INSERT_1_Insert1)
        {
            var ths = p7237_SI1_INSERT_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override P7237_SI1_INSERT_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}