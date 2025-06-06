using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1601B
{
    public class M_530_000_ATUALIZA_FONTE_DB_UPDATE_1_Update1 : QueryBasis<M_530_000_ATUALIZA_FONTE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0FONTE
				SET PROPAUTOM =  '{this.FONTE_PROPAUTOM}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  FONTE =  '{this.FONTE_FONTE}'";

            return query;
        }
        public string FONTE_PROPAUTOM { get; set; }
        public string FONTE_FONTE { get; set; }

        public static void Execute(M_530_000_ATUALIZA_FONTE_DB_UPDATE_1_Update1 m_530_000_ATUALIZA_FONTE_DB_UPDATE_1_Update1)
        {
            var ths = m_530_000_ATUALIZA_FONTE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_530_000_ATUALIZA_FONTE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}