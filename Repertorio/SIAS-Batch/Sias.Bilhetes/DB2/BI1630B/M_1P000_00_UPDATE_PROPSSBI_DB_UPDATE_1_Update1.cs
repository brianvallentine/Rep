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
    public class M_1P000_00_UPDATE_PROPSSBI_DB_UPDATE_1_Update1 : QueryBasis<M_1P000_00_UPDATE_PROPSSBI_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PROP_SASSE_BILHETE
				SET DATA_INCLUSAO =  '{this.WS_DATA_PROC}' ,
				COD_USUARIO = 'BI1630B'
				WHERE  NUM_IDENTIFICACAO =  '{this.PROPOFID_NUM_IDENTIFICACAO}'";

            return query;
        }
        public string WS_DATA_PROC { get; set; }
        public string PROPOFID_NUM_IDENTIFICACAO { get; set; }

        public static void Execute(M_1P000_00_UPDATE_PROPSSBI_DB_UPDATE_1_Update1 m_1P000_00_UPDATE_PROPSSBI_DB_UPDATE_1_Update1)
        {
            var ths = m_1P000_00_UPDATE_PROPSSBI_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1P000_00_UPDATE_PROPSSBI_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}