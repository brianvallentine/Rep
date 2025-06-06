using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.SPBFC003
{
    public class P050_PROCESSA_FC_SEQUENCE_DB_UPDATE_1_Update1 : QueryBasis<P050_PROCESSA_FC_SEQUENCE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE FDRCAP.FC_SEQUENCE
				SET NUM_SEQ =  '{this.FCSEQUEN_NUM_SEQ}'
				WHERE  COD_SEQ =  '{this.FCSEQUEN_COD_SEQ}'";

            return query;
        }
        public string FCSEQUEN_NUM_SEQ { get; set; }
        public string FCSEQUEN_COD_SEQ { get; set; }

        public static void Execute(P050_PROCESSA_FC_SEQUENCE_DB_UPDATE_1_Update1 p050_PROCESSA_FC_SEQUENCE_DB_UPDATE_1_Update1)
        {
            var ths = p050_PROCESSA_FC_SEQUENCE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override P050_PROCESSA_FC_SEQUENCE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}