using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI9108B
{
    public class R2100_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1 : QueryBasis<R2100_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1>
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
            :SIARDEVC-NUM-APOL-SINISTRO,
            :SINISMES-OCORR-HISTORICO,
            :SINISHIS-COD-OPERACAO,
            :SISTEMAS-DATA-MOV-ABERTO,
            CURRENT TIME,
            :SINISHIS-NOME-FAVORECIDO,
            :SINISHIS-VAL-OPERACAO,
            '9999-12-31' ,
            :SINISHIS-TIPO-FAVORECIDO,
            '9999-12-31' ,
            :SINISMES-COD-FONTE,
            0,
            0,
            0,
            0,
            0,
            'VERACRUZ' ,
            :SINISHIS-SIT-CONTABIL,
            :SINISHIS-SIT-REGISTRO,
            CURRENT TIMESTAMP ,
            :SIARDEVC-NUM-APOLICE,
            :SINISMES-COD-PRODUTO,
            'SI9108B' )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.SINISTRO_HISTORICO (COD_EMPRESA, TIPO_REGISTRO, NUM_APOL_SINISTRO, OCORR_HISTORICO, COD_OPERACAO, DATA_MOVIMENTO, HORA_OPERACAO, NOME_FAVORECIDO, VAL_OPERACAO, DATA_LIM_CORRECAO, TIPO_FAVORECIDO, DATA_NEGOCIADA, FONTE_PAGAMENTO, COD_PREST_SERVICO, COD_SERVICO, ORDEM_PAGAMENTO, NUM_RECIBO, NUM_MOV_SINISTRO, COD_USUARIO, SIT_CONTABIL, SIT_REGISTRO, TIMESTAMP, NUM_APOLICE, COD_PRODUTO, NOM_PROGRAMA) VALUES (0, '1' , {FieldThreatment(this.SIARDEVC_NUM_APOL_SINISTRO)}, {FieldThreatment(this.SINISMES_OCORR_HISTORICO)}, {FieldThreatment(this.SINISHIS_COD_OPERACAO)}, {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)}, CURRENT TIME, {FieldThreatment(this.SINISHIS_NOME_FAVORECIDO)}, {FieldThreatment(this.SINISHIS_VAL_OPERACAO)}, '9999-12-31' , {FieldThreatment(this.SINISHIS_TIPO_FAVORECIDO)}, '9999-12-31' , {FieldThreatment(this.SINISMES_COD_FONTE)}, 0, 0, 0, 0, 0, 'VERACRUZ' , {FieldThreatment(this.SINISHIS_SIT_CONTABIL)}, {FieldThreatment(this.SINISHIS_SIT_REGISTRO)}, CURRENT TIMESTAMP , {FieldThreatment(this.SIARDEVC_NUM_APOLICE)}, {FieldThreatment(this.SINISMES_COD_PRODUTO)}, 'SI9108B' )";

            return query;
        }
        public string SIARDEVC_NUM_APOL_SINISTRO { get; set; }
        public string SINISMES_OCORR_HISTORICO { get; set; }
        public string SINISHIS_COD_OPERACAO { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string SINISHIS_NOME_FAVORECIDO { get; set; }
        public string SINISHIS_VAL_OPERACAO { get; set; }
        public string SINISHIS_TIPO_FAVORECIDO { get; set; }
        public string SINISMES_COD_FONTE { get; set; }
        public string SINISHIS_SIT_CONTABIL { get; set; }
        public string SINISHIS_SIT_REGISTRO { get; set; }
        public string SIARDEVC_NUM_APOLICE { get; set; }
        public string SINISMES_COD_PRODUTO { get; set; }

        public static void Execute(R2100_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1 r2100_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1)
        {
            var ths = r2100_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2100_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}