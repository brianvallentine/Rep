using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0211B
{
    public class R1610_INCLUI_SINISHIS_DB_INSERT_1_Insert1 : QueryBasis<R1610_INCLUI_SINISHIS_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT INTO SEGUROS.SINISTRO_HISTORICO
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
            VALUES (:H-SINISHIS-COD-EMPRESA,
            :H-SINISHIS-TIPO-REGISTRO,
            :SI111-NUM-APOL-SINISTRO,
            :SI111-OCORR-HISTORICO,
            :H-SINISHIS-COD-OPERACAO,
            :H-SINISHIS-DATA-MOVIMENTO,
            :H-SINISHIS-HORA-OPERACAO,
            :H-SINISHIS-NOME-FAVORECIDO,
            :H-SINISHIS-VAL-OPERACAO,
            :H-SINISHIS-DATA-LIM-CORRECAO,
            :H-SINISHIS-TIPO-FAVORECIDO,
            :H-SINISHIS-DATA-NEGOCIADA,
            :H-SINISHIS-FONTE-PAGAMENTO,
            :H-SINISHIS-COD-PREST-SERVICO,
            :H-SINISHIS-COD-SERVICO,
            :H-SINISHIS-ORDEM-PAGAMENTO,
            :H-SINISHIS-NUM-RECIBO,
            :H-SINISHIS-NUM-MOV-SINISTRO,
            :H-SINISHIS-COD-USUARIO,
            :H-SINISHIS-SIT-CONTABIL,
            :H-SINISHIS-SIT-REGISTRO,
            :H-SINISHIS-TIMESTAMP,
            :H-SINISHIS-NUM-APOLICE,
            :H-SINISHIS-COD-PRODUTO,
            'SI0211B' )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.SINISTRO_HISTORICO (COD_EMPRESA, TIPO_REGISTRO, NUM_APOL_SINISTRO, OCORR_HISTORICO, COD_OPERACAO, DATA_MOVIMENTO, HORA_OPERACAO, NOME_FAVORECIDO, VAL_OPERACAO, DATA_LIM_CORRECAO, TIPO_FAVORECIDO, DATA_NEGOCIADA, FONTE_PAGAMENTO, COD_PREST_SERVICO, COD_SERVICO, ORDEM_PAGAMENTO, NUM_RECIBO, NUM_MOV_SINISTRO, COD_USUARIO, SIT_CONTABIL, SIT_REGISTRO, TIMESTAMP, NUM_APOLICE, COD_PRODUTO, NOM_PROGRAMA) VALUES ({FieldThreatment(this.H_SINISHIS_COD_EMPRESA)}, {FieldThreatment(this.H_SINISHIS_TIPO_REGISTRO)}, {FieldThreatment(this.SI111_NUM_APOL_SINISTRO)}, {FieldThreatment(this.SI111_OCORR_HISTORICO)}, {FieldThreatment(this.H_SINISHIS_COD_OPERACAO)}, {FieldThreatment(this.H_SINISHIS_DATA_MOVIMENTO)}, {FieldThreatment(this.H_SINISHIS_HORA_OPERACAO)}, {FieldThreatment(this.H_SINISHIS_NOME_FAVORECIDO)}, {FieldThreatment(this.H_SINISHIS_VAL_OPERACAO)}, {FieldThreatment(this.H_SINISHIS_DATA_LIM_CORRECAO)}, {FieldThreatment(this.H_SINISHIS_TIPO_FAVORECIDO)}, {FieldThreatment(this.H_SINISHIS_DATA_NEGOCIADA)}, {FieldThreatment(this.H_SINISHIS_FONTE_PAGAMENTO)}, {FieldThreatment(this.H_SINISHIS_COD_PREST_SERVICO)}, {FieldThreatment(this.H_SINISHIS_COD_SERVICO)}, {FieldThreatment(this.H_SINISHIS_ORDEM_PAGAMENTO)}, {FieldThreatment(this.H_SINISHIS_NUM_RECIBO)}, {FieldThreatment(this.H_SINISHIS_NUM_MOV_SINISTRO)}, {FieldThreatment(this.H_SINISHIS_COD_USUARIO)}, {FieldThreatment(this.H_SINISHIS_SIT_CONTABIL)}, {FieldThreatment(this.H_SINISHIS_SIT_REGISTRO)}, {FieldThreatment(this.H_SINISHIS_TIMESTAMP)}, {FieldThreatment(this.H_SINISHIS_NUM_APOLICE)}, {FieldThreatment(this.H_SINISHIS_COD_PRODUTO)}, 'SI0211B' )";

            return query;
        }
        public string H_SINISHIS_COD_EMPRESA { get; set; }
        public string H_SINISHIS_TIPO_REGISTRO { get; set; }
        public string SI111_NUM_APOL_SINISTRO { get; set; }
        public string SI111_OCORR_HISTORICO { get; set; }
        public string H_SINISHIS_COD_OPERACAO { get; set; }
        public string H_SINISHIS_DATA_MOVIMENTO { get; set; }
        public string H_SINISHIS_HORA_OPERACAO { get; set; }
        public string H_SINISHIS_NOME_FAVORECIDO { get; set; }
        public string H_SINISHIS_VAL_OPERACAO { get; set; }
        public string H_SINISHIS_DATA_LIM_CORRECAO { get; set; }
        public string H_SINISHIS_TIPO_FAVORECIDO { get; set; }
        public string H_SINISHIS_DATA_NEGOCIADA { get; set; }
        public string H_SINISHIS_FONTE_PAGAMENTO { get; set; }
        public string H_SINISHIS_COD_PREST_SERVICO { get; set; }
        public string H_SINISHIS_COD_SERVICO { get; set; }
        public string H_SINISHIS_ORDEM_PAGAMENTO { get; set; }
        public string H_SINISHIS_NUM_RECIBO { get; set; }
        public string H_SINISHIS_NUM_MOV_SINISTRO { get; set; }
        public string H_SINISHIS_COD_USUARIO { get; set; }
        public string H_SINISHIS_SIT_CONTABIL { get; set; }
        public string H_SINISHIS_SIT_REGISTRO { get; set; }
        public string H_SINISHIS_TIMESTAMP { get; set; }
        public string H_SINISHIS_NUM_APOLICE { get; set; }
        public string H_SINISHIS_COD_PRODUTO { get; set; }

        public static void Execute(R1610_INCLUI_SINISHIS_DB_INSERT_1_Insert1 r1610_INCLUI_SINISHIS_DB_INSERT_1_Insert1)
        {
            var ths = r1610_INCLUI_SINISHIS_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1610_INCLUI_SINISHIS_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}