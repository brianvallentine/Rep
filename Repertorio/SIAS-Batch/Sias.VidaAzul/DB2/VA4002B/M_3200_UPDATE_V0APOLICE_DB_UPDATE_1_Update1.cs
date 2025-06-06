using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA4002B
{
    public class M_3200_UPDATE_V0APOLICE_DB_UPDATE_1_Update1 : QueryBasis<M_3200_UPDATE_V0APOLICE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0APOLICE
				SET NUM_ITEM =  '{this.APOLICES_NUM_ITEM}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NUM_APOLICE =  '{this.PROPVA_NUM_APOLICE}'";

            return query;
        }
        public string APOLICES_NUM_ITEM { get; set; }
        public string PROPVA_NUM_APOLICE { get; set; }

        public static void Execute(M_3200_UPDATE_V0APOLICE_DB_UPDATE_1_Update1 m_3200_UPDATE_V0APOLICE_DB_UPDATE_1_Update1)
        {
            var ths = m_3200_UPDATE_V0APOLICE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_3200_UPDATE_V0APOLICE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}