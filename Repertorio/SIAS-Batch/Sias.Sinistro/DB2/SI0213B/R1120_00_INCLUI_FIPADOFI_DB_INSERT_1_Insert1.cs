using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0213B
{
    public class R1120_00_INCLUI_FIPADOFI_DB_INSERT_1_Insert1 : QueryBasis<R1120_00_INCLUI_FIPADOFI_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.FI_PAGA_DOC_FISCAL
            (NUM_DOCF_INTERNO,
            IDTAB_FORNECEDOR,
            COD_CH1_FORNECEDOR,
            COD_FORNECEDOR,
            IDTAB_DOC_FISCAL,
            COD_CH1_DOC_FISCAL,
            COD_FONTE_LANC,
            TIPO_MOVIMENTO,
            COD_EMPRESA,
            NUM_CHEQUE_INTERNO,
            NUM_DOC_FISCAL,
            SERIE_DOC_FISCAL,
            DATA_EMISSAO_DOC,
            CGCCPF,
            DATA_MOVIMENTO,
            TIMESTAMP)
            VALUES (:FIPADOFI-NUM-DOCF-INTERNO,
            :FIPADOFI-IDTAB-FORNECEDOR,
            :FIPADOFI-COD-CH1-FORNECEDOR,
            :SINISHIS-COD-PREST-SERVICO,
            :FIPADOFI-IDTAB-DOC-FISCAL,
            :FIPADOFI-COD-CH1-DOC-FISCAL,
            :FIPADOFI-COD-FONTE-LANC,
            :FIPADOFI-TIPO-MOVIMENTO,
            :FIPADOFI-COD-EMPRESA,
            NULL,
            :FIPADOFI-NUM-DOC-FISCAL,
            :FIPADOFI-SERIE-DOC-FISCAL,
            NULL,
            :FORNECED-CGCCPF,
            :SISTEMAS-DATA-MOV-ABERTO,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.FI_PAGA_DOC_FISCAL (NUM_DOCF_INTERNO, IDTAB_FORNECEDOR, COD_CH1_FORNECEDOR, COD_FORNECEDOR, IDTAB_DOC_FISCAL, COD_CH1_DOC_FISCAL, COD_FONTE_LANC, TIPO_MOVIMENTO, COD_EMPRESA, NUM_CHEQUE_INTERNO, NUM_DOC_FISCAL, SERIE_DOC_FISCAL, DATA_EMISSAO_DOC, CGCCPF, DATA_MOVIMENTO, TIMESTAMP) VALUES ({FieldThreatment(this.FIPADOFI_NUM_DOCF_INTERNO)}, {FieldThreatment(this.FIPADOFI_IDTAB_FORNECEDOR)}, {FieldThreatment(this.FIPADOFI_COD_CH1_FORNECEDOR)}, {FieldThreatment(this.SINISHIS_COD_PREST_SERVICO)}, {FieldThreatment(this.FIPADOFI_IDTAB_DOC_FISCAL)}, {FieldThreatment(this.FIPADOFI_COD_CH1_DOC_FISCAL)}, {FieldThreatment(this.FIPADOFI_COD_FONTE_LANC)}, {FieldThreatment(this.FIPADOFI_TIPO_MOVIMENTO)}, {FieldThreatment(this.FIPADOFI_COD_EMPRESA)}, NULL, {FieldThreatment(this.FIPADOFI_NUM_DOC_FISCAL)}, {FieldThreatment(this.FIPADOFI_SERIE_DOC_FISCAL)}, NULL, {FieldThreatment(this.FORNECED_CGCCPF)}, {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)}, CURRENT TIMESTAMP)";

            return query;
        }
        public string FIPADOFI_NUM_DOCF_INTERNO { get; set; }
        public string FIPADOFI_IDTAB_FORNECEDOR { get; set; }
        public string FIPADOFI_COD_CH1_FORNECEDOR { get; set; }
        public string SINISHIS_COD_PREST_SERVICO { get; set; }
        public string FIPADOFI_IDTAB_DOC_FISCAL { get; set; }
        public string FIPADOFI_COD_CH1_DOC_FISCAL { get; set; }
        public string FIPADOFI_COD_FONTE_LANC { get; set; }
        public string FIPADOFI_TIPO_MOVIMENTO { get; set; }
        public string FIPADOFI_COD_EMPRESA { get; set; }
        public string FIPADOFI_NUM_DOC_FISCAL { get; set; }
        public string FIPADOFI_SERIE_DOC_FISCAL { get; set; }
        public string FORNECED_CGCCPF { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }

        public static void Execute(R1120_00_INCLUI_FIPADOFI_DB_INSERT_1_Insert1 r1120_00_INCLUI_FIPADOFI_DB_INSERT_1_Insert1)
        {
            var ths = r1120_00_INCLUI_FIPADOFI_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1120_00_INCLUI_FIPADOFI_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}