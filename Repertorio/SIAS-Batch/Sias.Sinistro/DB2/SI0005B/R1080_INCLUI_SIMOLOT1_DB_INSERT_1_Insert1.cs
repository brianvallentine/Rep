using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0005B
{
    public class R1080_INCLUI_SIMOLOT1_DB_INSERT_1_Insert1 : QueryBasis<R1080_INCLUI_SIMOLOT1_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.SI_MOV_LOTERICO1
            (NUM_APOL_SINISTRO,
            COD_LOT_CEF,
            NOME_LOTERICO,
            DATA_OCORRENCIA,
            HORA_OCORRENCIA,
            DATA_GERACAO_MOV,
            DATA_AVISO,
            HORA_AVISO,
            VALOR_INFORMADO,
            NATUREZA,
            COD_CAUSA,
            IND_CRITICA,
            MENSAGEM,
            VALOR_REGISTRADO,
            VAL_IS,
            VAL_ADIANTAMENTO,
            PERC_ADIANTAMENTO,
            COD_LOT_SASSE,
            DATA_MOVIMENTO,
            QTD_SINI_AVISADO,
            QTD_SINI_PAGOS,
            QTD_MESES,
            TIMESTAMP,
            DATA_ULT_DOC,
            NUM_SINI_PREST,
            QTD_PORTADORES,
            IND_ADIANTAMENTO)
            VALUES (:SIMOLOT1-NUM-APOL-SINISTRO,
            :SIMOLOT1-COD-LOT-CEF,
            :SIMOLOT1-NOME-LOTERICO,
            :SIMOLOT1-DATA-OCORRENCIA,
            :SIMOLOT1-HORA-OCORRENCIA,
            :SIMOLOT1-DATA-GERACAO-MOV,
            :SIMOLOT1-DATA-AVISO,
            :SIMOLOT1-HORA-AVISO,
            :SIMOLOT1-VALOR-INFORMADO,
            :SIMOLOT1-NATUREZA,
            :SIMOLOT1-COD-CAUSA,
            :SIMOLOT1-IND-CRITICA,
            :SIMOLOT1-MENSAGEM,
            :SIMOLOT1-VALOR-REGISTRADO,
            :SIMOLOT1-VAL-IS,
            :SIMOLOT1-VAL-ADIANTAMENTO,
            :SIMOLOT1-PERC-ADIANTAMENTO,
            :SIMOLOT1-COD-LOT-SASSE,
            :SIMOLOT1-DATA-MOVIMENTO,
            :SIMOLOT1-QTD-SINI-AVISADO,
            :SIMOLOT1-QTD-SINI-PAGOS,
            :SIMOLOT1-QTD-MESES,
            CURRENT TIMESTAMP,
            :SIMOLOT1-DATA-ULT-DOC,
            :SIMOLOT1-NUM-SINI-PREST,
            :SIMOLOT1-QTD-PORTADORES,
            :SIMOLOT1-IND-ADIANTAMENTO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.SI_MOV_LOTERICO1 (NUM_APOL_SINISTRO, COD_LOT_CEF, NOME_LOTERICO, DATA_OCORRENCIA, HORA_OCORRENCIA, DATA_GERACAO_MOV, DATA_AVISO, HORA_AVISO, VALOR_INFORMADO, NATUREZA, COD_CAUSA, IND_CRITICA, MENSAGEM, VALOR_REGISTRADO, VAL_IS, VAL_ADIANTAMENTO, PERC_ADIANTAMENTO, COD_LOT_SASSE, DATA_MOVIMENTO, QTD_SINI_AVISADO, QTD_SINI_PAGOS, QTD_MESES, TIMESTAMP, DATA_ULT_DOC, NUM_SINI_PREST, QTD_PORTADORES, IND_ADIANTAMENTO) VALUES ({FieldThreatment(this.SIMOLOT1_NUM_APOL_SINISTRO)}, {FieldThreatment(this.SIMOLOT1_COD_LOT_CEF)}, {FieldThreatment(this.SIMOLOT1_NOME_LOTERICO)}, {FieldThreatment(this.SIMOLOT1_DATA_OCORRENCIA)}, {FieldThreatment(this.SIMOLOT1_HORA_OCORRENCIA)}, {FieldThreatment(this.SIMOLOT1_DATA_GERACAO_MOV)}, {FieldThreatment(this.SIMOLOT1_DATA_AVISO)}, {FieldThreatment(this.SIMOLOT1_HORA_AVISO)}, {FieldThreatment(this.SIMOLOT1_VALOR_INFORMADO)}, {FieldThreatment(this.SIMOLOT1_NATUREZA)}, {FieldThreatment(this.SIMOLOT1_COD_CAUSA)}, {FieldThreatment(this.SIMOLOT1_IND_CRITICA)}, {FieldThreatment(this.SIMOLOT1_MENSAGEM)}, {FieldThreatment(this.SIMOLOT1_VALOR_REGISTRADO)}, {FieldThreatment(this.SIMOLOT1_VAL_IS)}, {FieldThreatment(this.SIMOLOT1_VAL_ADIANTAMENTO)}, {FieldThreatment(this.SIMOLOT1_PERC_ADIANTAMENTO)}, {FieldThreatment(this.SIMOLOT1_COD_LOT_SASSE)}, {FieldThreatment(this.SIMOLOT1_DATA_MOVIMENTO)}, {FieldThreatment(this.SIMOLOT1_QTD_SINI_AVISADO)}, {FieldThreatment(this.SIMOLOT1_QTD_SINI_PAGOS)}, {FieldThreatment(this.SIMOLOT1_QTD_MESES)}, CURRENT TIMESTAMP, {FieldThreatment(this.SIMOLOT1_DATA_ULT_DOC)}, {FieldThreatment(this.SIMOLOT1_NUM_SINI_PREST)}, {FieldThreatment(this.SIMOLOT1_QTD_PORTADORES)}, {FieldThreatment(this.SIMOLOT1_IND_ADIANTAMENTO)})";

            return query;
        }
        public string SIMOLOT1_NUM_APOL_SINISTRO { get; set; }
        public string SIMOLOT1_COD_LOT_CEF { get; set; }
        public string SIMOLOT1_NOME_LOTERICO { get; set; }
        public string SIMOLOT1_DATA_OCORRENCIA { get; set; }
        public string SIMOLOT1_HORA_OCORRENCIA { get; set; }
        public string SIMOLOT1_DATA_GERACAO_MOV { get; set; }
        public string SIMOLOT1_DATA_AVISO { get; set; }
        public string SIMOLOT1_HORA_AVISO { get; set; }
        public string SIMOLOT1_VALOR_INFORMADO { get; set; }
        public string SIMOLOT1_NATUREZA { get; set; }
        public string SIMOLOT1_COD_CAUSA { get; set; }
        public string SIMOLOT1_IND_CRITICA { get; set; }
        public string SIMOLOT1_MENSAGEM { get; set; }
        public string SIMOLOT1_VALOR_REGISTRADO { get; set; }
        public string SIMOLOT1_VAL_IS { get; set; }
        public string SIMOLOT1_VAL_ADIANTAMENTO { get; set; }
        public string SIMOLOT1_PERC_ADIANTAMENTO { get; set; }
        public string SIMOLOT1_COD_LOT_SASSE { get; set; }
        public string SIMOLOT1_DATA_MOVIMENTO { get; set; }
        public string SIMOLOT1_QTD_SINI_AVISADO { get; set; }
        public string SIMOLOT1_QTD_SINI_PAGOS { get; set; }
        public string SIMOLOT1_QTD_MESES { get; set; }
        public string SIMOLOT1_DATA_ULT_DOC { get; set; }
        public string SIMOLOT1_NUM_SINI_PREST { get; set; }
        public string SIMOLOT1_QTD_PORTADORES { get; set; }
        public string SIMOLOT1_IND_ADIANTAMENTO { get; set; }

        public static void Execute(R1080_INCLUI_SIMOLOT1_DB_INSERT_1_Insert1 r1080_INCLUI_SIMOLOT1_DB_INSERT_1_Insert1)
        {
            var ths = r1080_INCLUI_SIMOLOT1_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1080_INCLUI_SIMOLOT1_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}