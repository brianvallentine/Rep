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
    public class R0340_INSERT_HIST_CHEQUE_DB_INSERT_1_Insert1 : QueryBasis<R0340_INSERT_HIST_CHEQUE_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT INTO SEGUROS.HISTORICO_CHEQUES
            (NUM_CHEQUE_INTERNO,
            DIG_CHEQUE_INTERNO,
            DATA_MOVIMENTO,
            HORA_OPERACAO,
            COD_OPERACAO,
            COD_EMPRESA,
            TIMESTAMP,
            DATA_COMPENSACAO)
            VALUES
            (:HISTOCHE-NUM-CHEQUE-INTERNO,
            :HISTOCHE-DIG-CHEQUE-INTERNO,
            :HISTOCHE-DATA-MOVIMENTO,
            :HISTOCHE-HORA-OPERACAO,
            :HISTOCHE-COD-OPERACAO,
            :HISTOCHE-COD-EMPRESA,
            CURRENT TIMESTAMP,
            NULL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.HISTORICO_CHEQUES (NUM_CHEQUE_INTERNO, DIG_CHEQUE_INTERNO, DATA_MOVIMENTO, HORA_OPERACAO, COD_OPERACAO, COD_EMPRESA, TIMESTAMP, DATA_COMPENSACAO) VALUES ({FieldThreatment(this.HISTOCHE_NUM_CHEQUE_INTERNO)}, {FieldThreatment(this.HISTOCHE_DIG_CHEQUE_INTERNO)}, {FieldThreatment(this.HISTOCHE_DATA_MOVIMENTO)}, {FieldThreatment(this.HISTOCHE_HORA_OPERACAO)}, {FieldThreatment(this.HISTOCHE_COD_OPERACAO)}, {FieldThreatment(this.HISTOCHE_COD_EMPRESA)}, CURRENT TIMESTAMP, NULL)";

            return query;
        }
        public string HISTOCHE_NUM_CHEQUE_INTERNO { get; set; }
        public string HISTOCHE_DIG_CHEQUE_INTERNO { get; set; }
        public string HISTOCHE_DATA_MOVIMENTO { get; set; }
        public string HISTOCHE_HORA_OPERACAO { get; set; }
        public string HISTOCHE_COD_OPERACAO { get; set; }
        public string HISTOCHE_COD_EMPRESA { get; set; }

        public static void Execute(R0340_INSERT_HIST_CHEQUE_DB_INSERT_1_Insert1 r0340_INSERT_HIST_CHEQUE_DB_INSERT_1_Insert1)
        {
            var ths = r0340_INSERT_HIST_CHEQUE_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0340_INSERT_HIST_CHEQUE_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}