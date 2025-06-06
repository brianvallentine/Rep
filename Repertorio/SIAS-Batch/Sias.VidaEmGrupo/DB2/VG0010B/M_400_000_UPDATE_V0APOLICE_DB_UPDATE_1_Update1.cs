using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0010B
{
    public class M_400_000_UPDATE_V0APOLICE_DB_UPDATE_1_Update1 : QueryBasis<M_400_000_UPDATE_V0APOLICE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.V0APOLICE
				SET NUM_ITEM =  '{this.SNUM_ITEM}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE 
				NUM_APOLICE =  '{this.V0NUM_APOLICE}'";

            return query;
        }
        public string SNUM_ITEM { get; set; }
        public string V0NUM_APOLICE { get; set; }

        public static void Execute(M_400_000_UPDATE_V0APOLICE_DB_UPDATE_1_Update1 m_400_000_UPDATE_V0APOLICE_DB_UPDATE_1_Update1)
        {
            var ths = m_400_000_UPDATE_V0APOLICE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_400_000_UPDATE_V0APOLICE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}