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
    public class R0430_GRAVA_SINI_CHEQUE_DB_INSERT_1_Insert1 : QueryBasis<R0430_GRAVA_SINI_CHEQUE_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT INTO SEGUROS.SI_SINI_CHEQUE
            (NUM_APOL_SINISTRO,
            COD_OPERACAO,
            OCORR_HISTORICO,
            NUM_CHEQUE_INTERNO,
            COD_DESPESA,
            COD_EMPRESA)
            VALUES
            (:SISINCHE-NUM-APOL-SINISTRO,
            :SISINCHE-COD-OPERACAO,
            :SISINCHE-OCORR-HISTORICO,
            :SISINCHE-NUM-CHEQUE-INTERNO,
            :SISINCHE-COD-DESPESA,
            :SISINCHE-COD-EMPRESA)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.SI_SINI_CHEQUE (NUM_APOL_SINISTRO, COD_OPERACAO, OCORR_HISTORICO, NUM_CHEQUE_INTERNO, COD_DESPESA, COD_EMPRESA) VALUES ({FieldThreatment(this.SISINCHE_NUM_APOL_SINISTRO)}, {FieldThreatment(this.SISINCHE_COD_OPERACAO)}, {FieldThreatment(this.SISINCHE_OCORR_HISTORICO)}, {FieldThreatment(this.SISINCHE_NUM_CHEQUE_INTERNO)}, {FieldThreatment(this.SISINCHE_COD_DESPESA)}, {FieldThreatment(this.SISINCHE_COD_EMPRESA)})";

            return query;
        }
        public string SISINCHE_NUM_APOL_SINISTRO { get; set; }
        public string SISINCHE_COD_OPERACAO { get; set; }
        public string SISINCHE_OCORR_HISTORICO { get; set; }
        public string SISINCHE_NUM_CHEQUE_INTERNO { get; set; }
        public string SISINCHE_COD_DESPESA { get; set; }
        public string SISINCHE_COD_EMPRESA { get; set; }

        public static void Execute(R0430_GRAVA_SINI_CHEQUE_DB_INSERT_1_Insert1 r0430_GRAVA_SINI_CHEQUE_DB_INSERT_1_Insert1)
        {
            var ths = r0430_GRAVA_SINI_CHEQUE_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0430_GRAVA_SINI_CHEQUE_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}