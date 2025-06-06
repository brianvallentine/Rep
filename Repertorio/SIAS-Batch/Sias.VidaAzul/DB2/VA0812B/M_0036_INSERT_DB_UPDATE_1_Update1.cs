using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0812B
{
    public class M_0036_INSERT_DB_UPDATE_1_Update1 : QueryBasis<M_0036_INSERT_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0HISTCOBVA
				SET OCORHIST =  '{this.HCVA_OCORHIST}'
				, SITUACAO = '7'
				WHERE  NRCERTIF = '{this.HCTA_NRCERTIF}'
				AND NRPARCEL = '{this.HCTA_NRPARCEL}'";

            return query;
        }
        public string HCVA_OCORHIST { get; set; }
        public string HCTA_NRCERTIF { get; set; }
        public string HCTA_NRPARCEL { get; set; }

        public static void Execute(M_0036_INSERT_DB_UPDATE_1_Update1 m_0036_INSERT_DB_UPDATE_1_Update1)
        {
            var ths = m_0036_INSERT_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0036_INSERT_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}