using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0341B
{
    public class M_1000_PROCESSA_DEBITO_DB_UPDATE_1_Update1 : QueryBasis<M_1000_PROCESSA_DEBITO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0PARCELVA
				SET DTVENCTO =  '{this.DTVENCTO}'
				WHERE  NRCERTIF =  '{this.NRCERTIF}'
				AND NRPARCEL =  '{this.NRPARCEL}'";

            return query;
        }
        public string DTVENCTO { get; set; }
        public string NRCERTIF { get; set; }
        public string NRPARCEL { get; set; }

        public static void Execute(M_1000_PROCESSA_DEBITO_DB_UPDATE_1_Update1 m_1000_PROCESSA_DEBITO_DB_UPDATE_1_Update1)
        {
            var ths = m_1000_PROCESSA_DEBITO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1000_PROCESSA_DEBITO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}