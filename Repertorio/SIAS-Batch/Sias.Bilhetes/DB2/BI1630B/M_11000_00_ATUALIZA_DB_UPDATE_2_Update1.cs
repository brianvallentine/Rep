using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI1630B
{
    public class M_11000_00_ATUALIZA_DB_UPDATE_2_Update1 : QueryBasis<M_11000_00_ATUALIZA_DB_UPDATE_2_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PROP_SASSE_BILHETE
				SET DATA_INCLUSAO =  '{this.WS_DATA_PROC}'
				WHERE  NUM_IDENTIFICACAO =  '{this.PROPOFID_NUM_IDENTIFICACAO}'";

            return query;
        }
        public string WS_DATA_PROC { get; set; }
        public string PROPOFID_NUM_IDENTIFICACAO { get; set; }

        public static void Execute(M_11000_00_ATUALIZA_DB_UPDATE_2_Update1 m_11000_00_ATUALIZA_DB_UPDATE_2_Update1)
        {
            var ths = m_11000_00_ATUALIZA_DB_UPDATE_2_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_11000_00_ATUALIZA_DB_UPDATE_2_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}