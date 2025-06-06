using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI9101B
{
    public class R2800_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1 : QueryBasis<R2800_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.SINISTRO_HISTORICO
            (COD_EMPRESA,
            TIPO_REGISTRO,
            NUM_APOL_SINISTRO,
            OCORR_HISTORICO,
            COD_OPERACAO,
            DATA_MOVIMENTO,
            HORA_OPERACAO,
            NOME_FAVORECIDO,
            VAL_OPERACAO,
            DATA_LIM_CORRECAO,
            TIPO_FAVORECIDO,
            DATA_NEGOCIADA,
            FONTE_PAGAMENTO,
            COD_PREST_SERVICO,
            COD_SERVICO,
            ORDEM_PAGAMENTO,
            NUM_RECIBO,
            NUM_MOV_SINISTRO,
            COD_USUARIO,
            SIT_CONTABIL,
            SIT_REGISTRO,
            TIMESTAMP,
            NUM_APOLICE,
            COD_PRODUTO,
            NOM_PROGRAMA)
            VALUES (0,
            '1' ,
            :SINISMES-NUM-APOL-SINISTRO,
            1,
            :SIARDEVC-COD-OPERACAO,
            :SISTEMAS-DATA-MOV-ABERTO,
            CURRENT TIME,
            ' ' ,
            :SIARDEVC-VAL-TOT-MOVIMENTO,
            '9999-12-31' ,
            '0' ,
            '9999-12-31' ,
            0,
            0,
            0,
            0,
            0,
            0,
            'VERACRUZ' ,
            '0' ,
            '0' ,
            CURRENT TIMESTAMP ,
            :SIARDEVC-NUM-APOLICE,
            :ENDOSSOS-COD-PRODUTO,
            'SI9101B' )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.SINISTRO_HISTORICO (COD_EMPRESA, TIPO_REGISTRO, NUM_APOL_SINISTRO, OCORR_HISTORICO, COD_OPERACAO, DATA_MOVIMENTO, HORA_OPERACAO, NOME_FAVORECIDO, VAL_OPERACAO, DATA_LIM_CORRECAO, TIPO_FAVORECIDO, DATA_NEGOCIADA, FONTE_PAGAMENTO, COD_PREST_SERVICO, COD_SERVICO, ORDEM_PAGAMENTO, NUM_RECIBO, NUM_MOV_SINISTRO, COD_USUARIO, SIT_CONTABIL, SIT_REGISTRO, TIMESTAMP, NUM_APOLICE, COD_PRODUTO, NOM_PROGRAMA) VALUES (0, '1' , {FieldThreatment(this.SINISMES_NUM_APOL_SINISTRO)}, 1, {FieldThreatment(this.SIARDEVC_COD_OPERACAO)}, {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)}, CURRENT TIME, ' ' , {FieldThreatment(this.SIARDEVC_VAL_TOT_MOVIMENTO)}, '9999-12-31' , '0' , '9999-12-31' , 0, 0, 0, 0, 0, 0, 'VERACRUZ' , '0' , '0' , CURRENT TIMESTAMP , {FieldThreatment(this.SIARDEVC_NUM_APOLICE)}, {FieldThreatment(this.ENDOSSOS_COD_PRODUTO)}, 'SI9101B' )";

            return query;
        }
        public string SINISMES_NUM_APOL_SINISTRO { get; set; }
        public string SIARDEVC_COD_OPERACAO { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string SIARDEVC_VAL_TOT_MOVIMENTO { get; set; }
        public string SIARDEVC_NUM_APOLICE { get; set; }
        public string ENDOSSOS_COD_PRODUTO { get; set; }

        public static void Execute(R2800_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1 r2800_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1)
        {
            var ths = r2800_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2800_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}