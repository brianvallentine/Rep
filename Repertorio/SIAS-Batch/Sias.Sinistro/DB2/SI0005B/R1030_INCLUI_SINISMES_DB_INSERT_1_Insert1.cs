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
    public class R1030_INCLUI_SINISMES_DB_INSERT_1_Insert1 : QueryBasis<R1030_INCLUI_SINISMES_DB_INSERT_1_Insert1>
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
            VALUES (:SINISMES-COD-EMPRESA,
            :SINISMES-TIPO-REGISTRO,
            :SINISMES-COD-FONTE,
            :SINISMES-NUM-PROTOCOLO-SINI,
            :SINISMES-DAC-PROTOCOLO-SINI,
            :SINISMES-NUM-APOL-SINISTRO,
            :SINISMES-NUM-APOLICE,
            :SINISMES-NUM-ENDOSSO,
            :SINISMES-COD-SUBGRUPO,
            :SINISMES-NUM-CERTIFICADO,
            :SINISMES-DAC-CERTIFICADO,
            :SINISMES-TIPO-SEGURADO,
            :SINISMES-NUM-EMBARQUE,
            :SINISMES-REF-EMBARQUE,
            :SINISMES-OCORR-HISTORICO,
            :SINISMES-COD-LIDER,
            :SINISMES-NUM-SINI-LIDER,
            :SINISMES-DATA-COMUNICADO,
            :SINISMES-DATA-OCORRENCIA,
            :SINISMES-DATA-TECNICA,
            :SINISMES-COD-CAUSA,
            :SINISMES-NUM-IRB,
            :SINISMES-NUM-AVISO-IRB,
            :SINISMES-COD-MOEDA-SINI,
            :SINISMES-SALDO-PAGAR-IX,
            :SINISMES-TOT-PAGAMENTO-IX,
            :SINISMES-SALDO-RECUPERAR-IX,
            :SINISMES-TOT-RECUPERADO-IX,
            :SINISMES-SALDO-RESSARCIR-IX,
            :SINISMES-TOT-RESSARCIDO-IX,
            :SINISMES-TOT-DESPESAS-IX,
            :SINISMES-TOT-HONORARIOS-IX,
            :SINISMES-ADIA-RECUPERAR-IX,
            :SINISMES-ADIA-RECUPERADO-IX,
            :SINISMES-IMP-SEGURADA-IX,
            :SINISMES-PCT-PART-COSSEGURO,
            :SINISMES-PCT-PART-RESSEGURO,
            :SINISMES-APROVACAO-ALCADA,
            :SINISMES-IND-SALVADO,
            :SINISMES-INTEGRAL-ESPECIAL,
            :SINISMES-NUM-MOV-SINI-ATU,
            :SINISMES-NUM-MOV-SINI-ANT,
            :SINISMES-DATA-ULT-MOVIMENTO,
            :SINISMES-SIT-REGISTRO,
            CURRENT TIMESTAMP,
            :SINISMES-BANCO-ORDEM-PAG,
            :SINISMES-AGENCIA-ORDEM-PAG,
            :SINISMES-TIPO-PAGAMENTO,
            :SINISMES-RAMO,
            :SINISMES-NUMERO-ORDEM,
            :SINISMES-COD-PRODUTO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.SINISTRO_MESTRE (COD_EMPRESA, TIPO_REGISTRO, COD_FONTE, NUM_PROTOCOLO_SINI, DAC_PROTOCOLO_SINI, NUM_APOL_SINISTRO, NUM_APOLICE, NUM_ENDOSSO, COD_SUBGRUPO, NUM_CERTIFICADO, DAC_CERTIFICADO, TIPO_SEGURADO, NUM_EMBARQUE, REF_EMBARQUE, OCORR_HISTORICO, COD_LIDER, NUM_SINI_LIDER, DATA_COMUNICADO, DATA_OCORRENCIA, DATA_TECNICA, COD_CAUSA, NUM_IRB, NUM_AVISO_IRB, COD_MOEDA_SINI, SALDO_PAGAR_IX, TOT_PAGAMENTO_IX, SALDO_RECUPERAR_IX, TOT_RECUPERADO_IX, SALDO_RESSARCIR_IX, TOT_RESSARCIDO_IX, TOT_DESPESAS_IX, TOT_HONORARIOS_IX, ADIA_RECUPERAR_IX, ADIA_RECUPERADO_IX, IMP_SEGURADA_IX, PCT_PART_COSSEGURO, PCT_PART_RESSEGURO, APROVACAO_ALCADA, IND_SALVADO, INTEGRAL_ESPECIAL, NUM_MOV_SINI_ATU, NUM_MOV_SINI_ANT, DATA_ULT_MOVIMENTO, SIT_REGISTRO, TIMESTAMP, BANCO_ORDEM_PAG, AGENCIA_ORDEM_PAG, TIPO_PAGAMENTO, RAMO, NUMERO_ORDEM, COD_PRODUTO) VALUES ({FieldThreatment(this.SINISMES_COD_EMPRESA)}, {FieldThreatment(this.SINISMES_TIPO_REGISTRO)}, {FieldThreatment(this.SINISMES_COD_FONTE)}, {FieldThreatment(this.SINISMES_NUM_PROTOCOLO_SINI)}, {FieldThreatment(this.SINISMES_DAC_PROTOCOLO_SINI)}, {FieldThreatment(this.SINISMES_NUM_APOL_SINISTRO)}, {FieldThreatment(this.SINISMES_NUM_APOLICE)}, {FieldThreatment(this.SINISMES_NUM_ENDOSSO)}, {FieldThreatment(this.SINISMES_COD_SUBGRUPO)}, {FieldThreatment(this.SINISMES_NUM_CERTIFICADO)}, {FieldThreatment(this.SINISMES_DAC_CERTIFICADO)}, {FieldThreatment(this.SINISMES_TIPO_SEGURADO)}, {FieldThreatment(this.SINISMES_NUM_EMBARQUE)}, {FieldThreatment(this.SINISMES_REF_EMBARQUE)}, {FieldThreatment(this.SINISMES_OCORR_HISTORICO)}, {FieldThreatment(this.SINISMES_COD_LIDER)}, {FieldThreatment(this.SINISMES_NUM_SINI_LIDER)}, {FieldThreatment(this.SINISMES_DATA_COMUNICADO)}, {FieldThreatment(this.SINISMES_DATA_OCORRENCIA)}, {FieldThreatment(this.SINISMES_DATA_TECNICA)}, {FieldThreatment(this.SINISMES_COD_CAUSA)}, {FieldThreatment(this.SINISMES_NUM_IRB)}, {FieldThreatment(this.SINISMES_NUM_AVISO_IRB)}, {FieldThreatment(this.SINISMES_COD_MOEDA_SINI)}, {FieldThreatment(this.SINISMES_SALDO_PAGAR_IX)}, {FieldThreatment(this.SINISMES_TOT_PAGAMENTO_IX)}, {FieldThreatment(this.SINISMES_SALDO_RECUPERAR_IX)}, {FieldThreatment(this.SINISMES_TOT_RECUPERADO_IX)}, {FieldThreatment(this.SINISMES_SALDO_RESSARCIR_IX)}, {FieldThreatment(this.SINISMES_TOT_RESSARCIDO_IX)}, {FieldThreatment(this.SINISMES_TOT_DESPESAS_IX)}, {FieldThreatment(this.SINISMES_TOT_HONORARIOS_IX)}, {FieldThreatment(this.SINISMES_ADIA_RECUPERAR_IX)}, {FieldThreatment(this.SINISMES_ADIA_RECUPERADO_IX)}, {FieldThreatment(this.SINISMES_IMP_SEGURADA_IX)}, {FieldThreatment(this.SINISMES_PCT_PART_COSSEGURO)}, {FieldThreatment(this.SINISMES_PCT_PART_RESSEGURO)}, {FieldThreatment(this.SINISMES_APROVACAO_ALCADA)}, {FieldThreatment(this.SINISMES_IND_SALVADO)}, {FieldThreatment(this.SINISMES_INTEGRAL_ESPECIAL)}, {FieldThreatment(this.SINISMES_NUM_MOV_SINI_ATU)}, {FieldThreatment(this.SINISMES_NUM_MOV_SINI_ANT)}, {FieldThreatment(this.SINISMES_DATA_ULT_MOVIMENTO)}, {FieldThreatment(this.SINISMES_SIT_REGISTRO)}, CURRENT TIMESTAMP, {FieldThreatment(this.SINISMES_BANCO_ORDEM_PAG)}, {FieldThreatment(this.SINISMES_AGENCIA_ORDEM_PAG)}, {FieldThreatment(this.SINISMES_TIPO_PAGAMENTO)}, {FieldThreatment(this.SINISMES_RAMO)}, {FieldThreatment(this.SINISMES_NUMERO_ORDEM)}, {FieldThreatment(this.SINISMES_COD_PRODUTO)})";

            return query;
        }
        public string SINISMES_COD_EMPRESA { get; set; }
        public string SINISMES_TIPO_REGISTRO { get; set; }
        public string SINISMES_COD_FONTE { get; set; }
        public string SINISMES_NUM_PROTOCOLO_SINI { get; set; }
        public string SINISMES_DAC_PROTOCOLO_SINI { get; set; }
        public string SINISMES_NUM_APOL_SINISTRO { get; set; }
        public string SINISMES_NUM_APOLICE { get; set; }
        public string SINISMES_NUM_ENDOSSO { get; set; }
        public string SINISMES_COD_SUBGRUPO { get; set; }
        public string SINISMES_NUM_CERTIFICADO { get; set; }
        public string SINISMES_DAC_CERTIFICADO { get; set; }
        public string SINISMES_TIPO_SEGURADO { get; set; }
        public string SINISMES_NUM_EMBARQUE { get; set; }
        public string SINISMES_REF_EMBARQUE { get; set; }
        public string SINISMES_OCORR_HISTORICO { get; set; }
        public string SINISMES_COD_LIDER { get; set; }
        public string SINISMES_NUM_SINI_LIDER { get; set; }
        public string SINISMES_DATA_COMUNICADO { get; set; }
        public string SINISMES_DATA_OCORRENCIA { get; set; }
        public string SINISMES_DATA_TECNICA { get; set; }
        public string SINISMES_COD_CAUSA { get; set; }
        public string SINISMES_NUM_IRB { get; set; }
        public string SINISMES_NUM_AVISO_IRB { get; set; }
        public string SINISMES_COD_MOEDA_SINI { get; set; }
        public string SINISMES_SALDO_PAGAR_IX { get; set; }
        public string SINISMES_TOT_PAGAMENTO_IX { get; set; }
        public string SINISMES_SALDO_RECUPERAR_IX { get; set; }
        public string SINISMES_TOT_RECUPERADO_IX { get; set; }
        public string SINISMES_SALDO_RESSARCIR_IX { get; set; }
        public string SINISMES_TOT_RESSARCIDO_IX { get; set; }
        public string SINISMES_TOT_DESPESAS_IX { get; set; }
        public string SINISMES_TOT_HONORARIOS_IX { get; set; }
        public string SINISMES_ADIA_RECUPERAR_IX { get; set; }
        public string SINISMES_ADIA_RECUPERADO_IX { get; set; }
        public string SINISMES_IMP_SEGURADA_IX { get; set; }
        public string SINISMES_PCT_PART_COSSEGURO { get; set; }
        public string SINISMES_PCT_PART_RESSEGURO { get; set; }
        public string SINISMES_APROVACAO_ALCADA { get; set; }
        public string SINISMES_IND_SALVADO { get; set; }
        public string SINISMES_INTEGRAL_ESPECIAL { get; set; }
        public string SINISMES_NUM_MOV_SINI_ATU { get; set; }
        public string SINISMES_NUM_MOV_SINI_ANT { get; set; }
        public string SINISMES_DATA_ULT_MOVIMENTO { get; set; }
        public string SINISMES_SIT_REGISTRO { get; set; }
        public string SINISMES_BANCO_ORDEM_PAG { get; set; }
        public string SINISMES_AGENCIA_ORDEM_PAG { get; set; }
        public string SINISMES_TIPO_PAGAMENTO { get; set; }
        public string SINISMES_RAMO { get; set; }
        public string SINISMES_NUMERO_ORDEM { get; set; }
        public string SINISMES_COD_PRODUTO { get; set; }

        public static void Execute(R1030_INCLUI_SINISMES_DB_INSERT_1_Insert1 r1030_INCLUI_SINISMES_DB_INSERT_1_Insert1)
        {
            var ths = r1030_INCLUI_SINISMES_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1030_INCLUI_SINISMES_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}