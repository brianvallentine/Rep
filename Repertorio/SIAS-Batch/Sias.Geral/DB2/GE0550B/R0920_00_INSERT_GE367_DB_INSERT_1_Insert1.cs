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
    public class R0920_00_INSERT_GE367_DB_INSERT_1_Insert1 : QueryBasis<R0920_00_INSERT_GE367_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.GE_LEGADO_PESSOA
            (NUM_PESSOA,
            NUM_OCORR_MOVTO,
            IND_RELACIONAMENTO,
            DTH_CADASTRAMENTO)
            VALUES
            (:GE367-NUM-PESSOA,
            :GE367-NUM-OCORR-MOVTO,
            :GE367-IND-RELACIONAMENTO,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.GE_LEGADO_PESSOA (NUM_PESSOA, NUM_OCORR_MOVTO, IND_RELACIONAMENTO, DTH_CADASTRAMENTO) VALUES ({FieldThreatment(this.GE367_NUM_PESSOA)}, {FieldThreatment(this.GE367_NUM_OCORR_MOVTO)}, {FieldThreatment(this.GE367_IND_RELACIONAMENTO)}, CURRENT TIMESTAMP)";

            return query;
        }
        public string GE367_NUM_PESSOA { get; set; }
        public string GE367_NUM_OCORR_MOVTO { get; set; }
        public string GE367_IND_RELACIONAMENTO { get; set; }

        public static void Execute(R0920_00_INSERT_GE367_DB_INSERT_1_Insert1 r0920_00_INSERT_GE367_DB_INSERT_1_Insert1)
        {
            var ths = r0920_00_INSERT_GE367_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0920_00_INSERT_GE367_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}