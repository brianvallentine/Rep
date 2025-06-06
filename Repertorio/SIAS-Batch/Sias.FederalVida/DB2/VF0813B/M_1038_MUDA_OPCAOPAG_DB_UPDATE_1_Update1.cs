using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0813B
{
    public class M_1038_MUDA_OPCAOPAG_DB_UPDATE_1_Update1 : QueryBasis<M_1038_MUDA_OPCAOPAG_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0OPCAOPAGVA
				SET DTTERVIG =  '{this.V0HCOB_DTALTOPC}',
				TIMESTAMP = CURRENT TIMESTAMP,
				CODUSU = 'VF0813B'
				WHERE  NRCERTIF =  '{this.V0HCTA_NRCERTIF}'
				AND DTTERVIG = '9999-12-31'";

            return query;
        }
        public string V0HCOB_DTALTOPC { get; set; }
        public string V0HCTA_NRCERTIF { get; set; }

        public static void Execute(M_1038_MUDA_OPCAOPAG_DB_UPDATE_1_Update1 m_1038_MUDA_OPCAOPAG_DB_UPDATE_1_Update1)
        {
            var ths = m_1038_MUDA_OPCAOPAG_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1038_MUDA_OPCAOPAG_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}