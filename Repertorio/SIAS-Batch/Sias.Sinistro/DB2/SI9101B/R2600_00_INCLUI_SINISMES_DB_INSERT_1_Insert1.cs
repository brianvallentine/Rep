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
    public class R2600_00_INCLUI_SINISMES_DB_INSERT_1_Insert1 : QueryBasis<R2600_00_INCLUI_SINISMES_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.SINISTRO_MESTRE
            (COD_EMPRESA,
            TIPO_REGISTRO,
            COD_FONTE,
            NUM_PROTOCOLO_SINI,
            DAC_PROTOCOLO_SINI,
            NUM_APOL_SINISTRO,
            NUM_APOLICE,
            NUM_ENDOSSO,
            COD_SUBGRUPO,
            NUM_CERTIFICADO,
            DAC_CERTIFICADO,
            TIPO_SEGURADO,
            NUM_EMBARQUE,
            REF_EMBARQUE,
            OCORR_HISTORICO,
            COD_LIDER,
            NUM_SINI_LIDER,
            DATA_COMUNICADO,
            DATA_OCORRENCIA,
            DATA_TECNICA,
            COD_CAUSA,
            NUM_IRB,
            NUM_AVISO_IRB,
            COD_MOEDA_SINI,
            SALDO_PAGAR_IX,
            TOT_PAGAMENTO_IX,
            SALDO_RECUPERAR_IX,
            TOT_RECUPERADO_IX,
            SALDO_RESSARCIR_IX,
            TOT_RESSARCIDO_IX,
            TOT_DESPESAS_IX,
            TOT_HONORARIOS_IX,
            ADIA_RECUPERAR_IX,
            ADIA_RECUPERADO_IX,
            IMP_SEGURADA_IX,
            PCT_PART_COSSEGURO,
            PCT_PART_RESSEGURO,
            APROVACAO_ALCADA,
            IND_SALVADO,
            INTEGRAL_ESPECIAL,
            NUM_MOV_SINI_ATU,
            NUM_MOV_SINI_ANT,
            DATA_ULT_MOVIMENTO,
            SIT_REGISTRO,
            TIMESTAMP,
            BANCO_ORDEM_PAG,
            AGENCIA_ORDEM_PAG,
            TIPO_PAGAMENTO,
            RAMO,
            NUMERO_ORDEM,
            COD_PRODUTO)
            VALUES (0,
            '1' ,
            :ENDOSSOS-COD-FONTE,
            :SINISCON-NUM-PROTOCOLO-SINI,
            :SINISCON-DAC-PROTOCOLO-SINI,
            :SINISMES-NUM-APOL-SINISTRO,
            :SIARDEVC-NUM-APOLICE,
            :APOLIAUT-NUM-ENDOSSO,
            0,
            0,
            ' ' ,
            ' ' ,
            0,
            0,
            1,
            0,
            ' ' ,
            :SIARDEVC-DATA-COMUNICADO,
            :SIARDEVC-DATA-OCORRENCIA,
            :SISTEMAS-DATA-MOV-ABERTO,
            :SIARDEVC-COD-CAUSA,
            0,
            ' ' ,
            :SINISMES-COD-MOEDA-SINI,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            :AUTOCOBE-IMP-SEGURADA-IX,
            :APOLCOSS-PCT-PART-COSSEGURO,
            :SINISMES-PCT-PART-RESSEGURO,
            31,
            ' ' ,
            ' ' ,
            0,
            0,
            :SISTEMAS-DATA-MOV-ABERTO,
            '0' ,
            CURRENT TIMESTAMP,
            0,
            0,
            '1' ,
            :SIARDEVC-COD-RAMO,
            0,
            :ENDOSSOS-COD-PRODUTO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.SINISTRO_MESTRE (COD_EMPRESA, TIPO_REGISTRO, COD_FONTE, NUM_PROTOCOLO_SINI, DAC_PROTOCOLO_SINI, NUM_APOL_SINISTRO, NUM_APOLICE, NUM_ENDOSSO, COD_SUBGRUPO, NUM_CERTIFICADO, DAC_CERTIFICADO, TIPO_SEGURADO, NUM_EMBARQUE, REF_EMBARQUE, OCORR_HISTORICO, COD_LIDER, NUM_SINI_LIDER, DATA_COMUNICADO, DATA_OCORRENCIA, DATA_TECNICA, COD_CAUSA, NUM_IRB, NUM_AVISO_IRB, COD_MOEDA_SINI, SALDO_PAGAR_IX, TOT_PAGAMENTO_IX, SALDO_RECUPERAR_IX, TOT_RECUPERADO_IX, SALDO_RESSARCIR_IX, TOT_RESSARCIDO_IX, TOT_DESPESAS_IX, TOT_HONORARIOS_IX, ADIA_RECUPERAR_IX, ADIA_RECUPERADO_IX, IMP_SEGURADA_IX, PCT_PART_COSSEGURO, PCT_PART_RESSEGURO, APROVACAO_ALCADA, IND_SALVADO, INTEGRAL_ESPECIAL, NUM_MOV_SINI_ATU, NUM_MOV_SINI_ANT, DATA_ULT_MOVIMENTO, SIT_REGISTRO, TIMESTAMP, BANCO_ORDEM_PAG, AGENCIA_ORDEM_PAG, TIPO_PAGAMENTO, RAMO, NUMERO_ORDEM, COD_PRODUTO) VALUES (0, '1' , {FieldThreatment(this.ENDOSSOS_COD_FONTE)}, {FieldThreatment(this.SINISCON_NUM_PROTOCOLO_SINI)}, {FieldThreatment(this.SINISCON_DAC_PROTOCOLO_SINI)}, {FieldThreatment(this.SINISMES_NUM_APOL_SINISTRO)}, {FieldThreatment(this.SIARDEVC_NUM_APOLICE)}, {FieldThreatment(this.APOLIAUT_NUM_ENDOSSO)}, 0, 0, ' ' , ' ' , 0, 0, 1, 0, ' ' , {FieldThreatment(this.SIARDEVC_DATA_COMUNICADO)}, {FieldThreatment(this.SIARDEVC_DATA_OCORRENCIA)}, {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)}, {FieldThreatment(this.SIARDEVC_COD_CAUSA)}, 0, ' ' , {FieldThreatment(this.SINISMES_COD_MOEDA_SINI)}, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, {FieldThreatment(this.AUTOCOBE_IMP_SEGURADA_IX)}, {FieldThreatment(this.APOLCOSS_PCT_PART_COSSEGURO)}, {FieldThreatment(this.SINISMES_PCT_PART_RESSEGURO)}, 31, ' ' , ' ' , 0, 0, {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)}, '0' , CURRENT TIMESTAMP, 0, 0, '1' , {FieldThreatment(this.SIARDEVC_COD_RAMO)}, 0, {FieldThreatment(this.ENDOSSOS_COD_PRODUTO)})";

            return query;
        }
        public string ENDOSSOS_COD_FONTE { get; set; }
        public string SINISCON_NUM_PROTOCOLO_SINI { get; set; }
        public string SINISCON_DAC_PROTOCOLO_SINI { get; set; }
        public string SINISMES_NUM_APOL_SINISTRO { get; set; }
        public string SIARDEVC_NUM_APOLICE { get; set; }
        public string APOLIAUT_NUM_ENDOSSO { get; set; }
        public string SIARDEVC_DATA_COMUNICADO { get; set; }
        public string SIARDEVC_DATA_OCORRENCIA { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string SIARDEVC_COD_CAUSA { get; set; }
        public string SINISMES_COD_MOEDA_SINI { get; set; }
        public string AUTOCOBE_IMP_SEGURADA_IX { get; set; }
        public string APOLCOSS_PCT_PART_COSSEGURO { get; set; }
        public string SINISMES_PCT_PART_RESSEGURO { get; set; }
        public string SIARDEVC_COD_RAMO { get; set; }
        public string ENDOSSOS_COD_PRODUTO { get; set; }

        public static void Execute(R2600_00_INCLUI_SINISMES_DB_INSERT_1_Insert1 r2600_00_INCLUI_SINISMES_DB_INSERT_1_Insert1)
        {
            var ths = r2600_00_INCLUI_SINISMES_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2600_00_INCLUI_SINISMES_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}