using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0550B
{
    public class R2000_00_PROCESSA_OPERACAO_2_DB_INSERT_1_Insert1 : QueryBasis<R2000_00_PROCESSA_OPERACAO_2_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.CB_PESS_REC_ANT
            ( NUM_OCORR_MOVTO,
            COD_FONTE,
            NUM_RCAP)
            VALUES
            (:CB040-NUM-OCORR-MOVTO,
            :CB040-COD-FONTE,
            :CB040-NUM-RCAP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.CB_PESS_REC_ANT ( NUM_OCORR_MOVTO, COD_FONTE, NUM_RCAP) VALUES ({FieldThreatment(this.CB040_NUM_OCORR_MOVTO)}, {FieldThreatment(this.CB040_COD_FONTE)}, {FieldThreatment(this.CB040_NUM_RCAP)})";

            return query;
        }
        public string CB040_NUM_OCORR_MOVTO { get; set; }
        public string CB040_COD_FONTE { get; set; }
        public string CB040_NUM_RCAP { get; set; }

        public static void Execute(R2000_00_PROCESSA_OPERACAO_2_DB_INSERT_1_Insert1 r2000_00_PROCESSA_OPERACAO_2_DB_INSERT_1_Insert1)
        {
            var ths = r2000_00_PROCESSA_OPERACAO_2_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2000_00_PROCESSA_OPERACAO_2_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}