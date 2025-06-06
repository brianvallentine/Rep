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
    public class M_3820_ATUALIZA_FONTE_DB_UPDATE_1_Update1 : QueryBasis<M_3820_ATUALIZA_FONTE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0FONTE
				SET PROPAUTOM =  '{this.FONTE_PROPAUTOM}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  FONTE =  '{this.PROPVA_FONTE}'";

            return query;
        }
        public string FONTE_PROPAUTOM { get; set; }
        public string PROPVA_FONTE { get; set; }

        public static void Execute(M_3820_ATUALIZA_FONTE_DB_UPDATE_1_Update1 m_3820_ATUALIZA_FONTE_DB_UPDATE_1_Update1)
        {
            var ths = m_3820_ATUALIZA_FONTE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_3820_ATUALIZA_FONTE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}