using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0020B
{
    public class M_1230_UPDATE_FUNC_DB_UPDATE_1_Update1 : QueryBasis<M_1230_UPDATE_FUNC_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0FUNCIOCEF
				SET
				TIPO_VINCULO = 'INATIVO'
				WHERE  TIPO_VINCULO = 'EMPREGADO CEF'";

            return query;
        }

        public static void Execute(M_1230_UPDATE_FUNC_DB_UPDATE_1_Update1 m_1230_UPDATE_FUNC_DB_UPDATE_1_Update1)
        {
            var ths = m_1230_UPDATE_FUNC_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1230_UPDATE_FUNC_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}