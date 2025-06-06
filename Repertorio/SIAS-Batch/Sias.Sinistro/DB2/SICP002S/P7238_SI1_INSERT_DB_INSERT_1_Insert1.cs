using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SICP002S
{
    public class P7238_SI1_INSERT_DB_INSERT_1_Insert1 : QueryBasis<P7238_SI1_INSERT_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.SI_MOVTO_PGTO_COB_HIST
            ( SELECT
            NUM_SINISTRO
            ,OCORR_HISTORICO
            ,IDE_SISTEMA
            ,COD_OPERACAO
            ,SEQ_ID_ENVIO_HIST AS SEQ_SI_PGTO_COB_HIST
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
            FROM SEGUROS.SI_MOVTO_PGTO_COB
            WHERE NUM_SINISTRO = :SI238-NUM-SINISTRO
            AND COD_OPERACAO = :SI238-COD-OPERACAO
            AND OCORR_HISTORICO = :SI238-OCORR-HISTORICO
            )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.SI_MOVTO_PGTO_COB_HIST ( SELECT NUM_SINISTRO ,OCORR_HISTORICO ,IDE_SISTEMA ,COD_OPERACAO ,SEQ_ID_ENVIO_HIST AS SEQ_SI_PGTO_COB_HIST ,NUM_ID_ENVIO ,SEQ_ID_ENVIO_HIST ,STA_ENVIO_MOVIMENTO ,DTA_SI_ENVIO ,DTA_SI_RETORNO_H ,DTA_EFETIVO_PGTO ,COD_USUARIO ,COD_PROGRAMA ,DTH_CADASTRAMENTO ,SEQ_MOVTO_ARQH ,STA_MOVTO_HISTORICO ,QTD_RETORNO_ARQH ,COD_EMPRESA FROM SEGUROS.SI_MOVTO_PGTO_COB WHERE NUM_SINISTRO = {FieldThreatment(this.SI238_NUM_SINISTRO)} AND COD_OPERACAO = {FieldThreatment(this.SI238_COD_OPERACAO)} AND OCORR_HISTORICO = {FieldThreatment(this.SI238_OCORR_HISTORICO)} )";

            return query;
        }
        public string SI238_NUM_SINISTRO { get; set; }
        public string SI238_COD_OPERACAO { get; set; }
        public string SI238_OCORR_HISTORICO { get; set; }

        public static void Execute(P7238_SI1_INSERT_DB_INSERT_1_Insert1 p7238_SI1_INSERT_DB_INSERT_1_Insert1)
        {
            var ths = p7238_SI1_INSERT_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override P7238_SI1_INSERT_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}