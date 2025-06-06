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
    public class R1100_INSERT_HISTSINI_DB_INSERT_1_Insert1 : QueryBasis<R1100_INSERT_HISTSINI_DB_INSERT_1_Insert1>
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
            VALUES (:SINISHIS-COD-EMPRESA,
            :SINISHIS-TIPO-REGISTRO,
            :SINISHIS-NUM-APOL-SINISTRO,
            :SINISHIS-OCORR-HISTORICO,
            :SINISHIS-COD-OPERACAO,
            :SINISHIS-DATA-MOVIMENTO,
            CURRENT TIME ,
            :SINISHIS-NOME-FAVORECIDO,
            :SINISHIS-VAL-OPERACAO,
            :SINISHIS-DATA-LIM-CORRECAO,
            :SINISHIS-TIPO-FAVORECIDO,
            :SINISHIS-DATA-NEGOCIADA,
            :SINISHIS-FONTE-PAGAMENTO,
            :SINISHIS-COD-PREST-SERVICO,
            :SINISHIS-COD-SERVICO,
            :SINISHIS-ORDEM-PAGAMENTO,
            :SINISHIS-NUM-RECIBO,
            :SINISHIS-NUM-MOV-SINISTRO,
            'RESSARC' ,
            :SINISHIS-SIT-CONTABIL,
            :SINISHIS-SIT-REGISTRO,
            CURRENT TIMESTAMP,
            :SINISHIS-NUM-APOLICE,
            :SINISHIS-COD-PRODUTO,
            'SI0211B' )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.SINISTRO_HISTORICO (COD_EMPRESA, TIPO_REGISTRO, NUM_APOL_SINISTRO, OCORR_HISTORICO, COD_OPERACAO, DATA_MOVIMENTO, HORA_OPERACAO, NOME_FAVORECIDO, VAL_OPERACAO, DATA_LIM_CORRECAO, TIPO_FAVORECIDO, DATA_NEGOCIADA, FONTE_PAGAMENTO, COD_PREST_SERVICO, COD_SERVICO, ORDEM_PAGAMENTO, NUM_RECIBO, NUM_MOV_SINISTRO, COD_USUARIO, SIT_CONTABIL, SIT_REGISTRO, TIMESTAMP, NUM_APOLICE, COD_PRODUTO, NOM_PROGRAMA) VALUES ({FieldThreatment(this.SINISHIS_COD_EMPRESA)}, {FieldThreatment(this.SINISHIS_TIPO_REGISTRO)}, {FieldThreatment(this.SINISHIS_NUM_APOL_SINISTRO)}, {FieldThreatment(this.SINISHIS_OCORR_HISTORICO)}, {FieldThreatment(this.SINISHIS_COD_OPERACAO)}, {FieldThreatment(this.SINISHIS_DATA_MOVIMENTO)}, CURRENT TIME , {FieldThreatment(this.SINISHIS_NOME_FAVORECIDO)}, {FieldThreatment(this.SINISHIS_VAL_OPERACAO)}, {FieldThreatment(this.SINISHIS_DATA_LIM_CORRECAO)}, {FieldThreatment(this.SINISHIS_TIPO_FAVORECIDO)}, {FieldThreatment(this.SINISHIS_DATA_NEGOCIADA)}, {FieldThreatment(this.SINISHIS_FONTE_PAGAMENTO)}, {FieldThreatment(this.SINISHIS_COD_PREST_SERVICO)}, {FieldThreatment(this.SINISHIS_COD_SERVICO)}, {FieldThreatment(this.SINISHIS_ORDEM_PAGAMENTO)}, {FieldThreatment(this.SINISHIS_NUM_RECIBO)}, {FieldThreatment(this.SINISHIS_NUM_MOV_SINISTRO)}, 'RESSARC' , {FieldThreatment(this.SINISHIS_SIT_CONTABIL)}, {FieldThreatment(this.SINISHIS_SIT_REGISTRO)}, CURRENT TIMESTAMP, {FieldThreatment(this.SINISHIS_NUM_APOLICE)}, {FieldThreatment(this.SINISHIS_COD_PRODUTO)}, 'SI0211B' )";

            return query;
        }
        public string SINISHIS_COD_EMPRESA { get; set; }
        public string SINISHIS_TIPO_REGISTRO { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }
        public string SINISHIS_COD_OPERACAO { get; set; }
        public string SINISHIS_DATA_MOVIMENTO { get; set; }
        public string SINISHIS_NOME_FAVORECIDO { get; set; }
        public string SINISHIS_VAL_OPERACAO { get; set; }
        public string SINISHIS_DATA_LIM_CORRECAO { get; set; }
        public string SINISHIS_TIPO_FAVORECIDO { get; set; }
        public string SINISHIS_DATA_NEGOCIADA { get; set; }
        public string SINISHIS_FONTE_PAGAMENTO { get; set; }
        public string SINISHIS_COD_PREST_SERVICO { get; set; }
        public string SINISHIS_COD_SERVICO { get; set; }
        public string SINISHIS_ORDEM_PAGAMENTO { get; set; }
        public string SINISHIS_NUM_RECIBO { get; set; }
        public string SINISHIS_NUM_MOV_SINISTRO { get; set; }
        public string SINISHIS_SIT_CONTABIL { get; set; }
        public string SINISHIS_SIT_REGISTRO { get; set; }
        public string SINISHIS_NUM_APOLICE { get; set; }
        public string SINISHIS_COD_PRODUTO { get; set; }

        public static void Execute(R1100_INSERT_HISTSINI_DB_INSERT_1_Insert1 r1100_INSERT_HISTSINI_DB_INSERT_1_Insert1)
        {
            var ths = r1100_INSERT_HISTSINI_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1100_INSERT_HISTSINI_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}