using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI5066B
{
    public class R0120_GRAVA_RALCHEDO_DB_INSERT_1_Insert1 : QueryBasis<R0120_GRAVA_RALCHEDO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT INTO SEGUROS.RALACAO_CHEQ_DOCTO
            (COD_EMPRESA,
            NUM_CHEQUE_INTERNO,
            DIG_CHEQUE_INTERNO,
            NUM_DOCUMENTO,
            OCORR_HISTORICO,
            TIPO_MOVIMENTO,
            TIMESTAMP,
            AGENCIA_CONTRATO,
            NUMERO_SIVAT,
            DV_SIVAT,
            DATA_SIVAT,
            AGE_CENTRAL_PROD01,
            NUMDOC_NUM01)
            VALUES
            (:RALCHEDO-COD-EMPRESA,
            :RALCHEDO-NUM-CHEQUE-INTERNO,
            :RALCHEDO-DIG-CHEQUE-INTERNO,
            :RALCHEDO-NUM-DOCUMENTO,
            :RALCHEDO-OCORR-HISTORICO,
            :RALCHEDO-TIPO-MOVIMENTO,
            :RALCHEDO-TIMESTAMP,
            :RALCHEDO-AGENCIA-CONTRATO,
            :RALCHEDO-NUMERO-SIVAT,
            :RALCHEDO-DV-SIVAT,
            NULL,
            :RALCHEDO-AGE-CENTRAL-PROD01,
            :RALCHEDO-NUMDOC-NUM01)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.RALACAO_CHEQ_DOCTO (COD_EMPRESA, NUM_CHEQUE_INTERNO, DIG_CHEQUE_INTERNO, NUM_DOCUMENTO, OCORR_HISTORICO, TIPO_MOVIMENTO, TIMESTAMP, AGENCIA_CONTRATO, NUMERO_SIVAT, DV_SIVAT, DATA_SIVAT, AGE_CENTRAL_PROD01, NUMDOC_NUM01) VALUES ({FieldThreatment(this.RALCHEDO_COD_EMPRESA)}, {FieldThreatment(this.RALCHEDO_NUM_CHEQUE_INTERNO)}, {FieldThreatment(this.RALCHEDO_DIG_CHEQUE_INTERNO)}, {FieldThreatment(this.RALCHEDO_NUM_DOCUMENTO)}, {FieldThreatment(this.RALCHEDO_OCORR_HISTORICO)}, {FieldThreatment(this.RALCHEDO_TIPO_MOVIMENTO)}, {FieldThreatment(this.RALCHEDO_TIMESTAMP)}, {FieldThreatment(this.RALCHEDO_AGENCIA_CONTRATO)}, {FieldThreatment(this.RALCHEDO_NUMERO_SIVAT)}, {FieldThreatment(this.RALCHEDO_DV_SIVAT)}, NULL, {FieldThreatment(this.RALCHEDO_AGE_CENTRAL_PROD01)}, {FieldThreatment(this.RALCHEDO_NUMDOC_NUM01)})";

            return query;
        }
        public string RALCHEDO_COD_EMPRESA { get; set; }
        public string RALCHEDO_NUM_CHEQUE_INTERNO { get; set; }
        public string RALCHEDO_DIG_CHEQUE_INTERNO { get; set; }
        public string RALCHEDO_NUM_DOCUMENTO { get; set; }
        public string RALCHEDO_OCORR_HISTORICO { get; set; }
        public string RALCHEDO_TIPO_MOVIMENTO { get; set; }
        public string RALCHEDO_TIMESTAMP { get; set; }
        public string RALCHEDO_AGENCIA_CONTRATO { get; set; }
        public string RALCHEDO_NUMERO_SIVAT { get; set; }
        public string RALCHEDO_DV_SIVAT { get; set; }
        public string RALCHEDO_AGE_CENTRAL_PROD01 { get; set; }
        public string RALCHEDO_NUMDOC_NUM01 { get; set; }

        public static void Execute(R0120_GRAVA_RALCHEDO_DB_INSERT_1_Insert1 r0120_GRAVA_RALCHEDO_DB_INSERT_1_Insert1)
        {
            var ths = r0120_GRAVA_RALCHEDO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0120_GRAVA_RALCHEDO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}