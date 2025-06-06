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
    public class R0930_00_INSERT_GE368_DB_INSERT_1_Insert1 : QueryBasis<R0930_00_INSERT_GE368_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.GE_LEG_PESS_EVENTO
            (NUM_PESSOA,
            NUM_OCORR_MOVTO,
            SEQ_ENTIDADE,
            IND_ENTIDADE,
            DTH_CADASTRAMENTO)
            VALUES
            (:GE368-NUM-PESSOA,
            :GE368-NUM-OCORR-MOVTO,
            :GE368-SEQ-ENTIDADE,
            :GE368-IND-ENTIDADE,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.GE_LEG_PESS_EVENTO (NUM_PESSOA, NUM_OCORR_MOVTO, SEQ_ENTIDADE, IND_ENTIDADE, DTH_CADASTRAMENTO) VALUES ({FieldThreatment(this.GE368_NUM_PESSOA)}, {FieldThreatment(this.GE368_NUM_OCORR_MOVTO)}, {FieldThreatment(this.GE368_SEQ_ENTIDADE)}, {FieldThreatment(this.GE368_IND_ENTIDADE)}, CURRENT TIMESTAMP)";

            return query;
        }
        public string GE368_NUM_PESSOA { get; set; }
        public string GE368_NUM_OCORR_MOVTO { get; set; }
        public string GE368_SEQ_ENTIDADE { get; set; }
        public string GE368_IND_ENTIDADE { get; set; }

        public static void Execute(R0930_00_INSERT_GE368_DB_INSERT_1_Insert1 r0930_00_INSERT_GE368_DB_INSERT_1_Insert1)
        {
            var ths = r0930_00_INSERT_GE368_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0930_00_INSERT_GE368_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}