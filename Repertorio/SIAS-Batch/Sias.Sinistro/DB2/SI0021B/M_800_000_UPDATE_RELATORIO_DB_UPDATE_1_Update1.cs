using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0021B
{
    public class M_800_000_UPDATE_RELATORIO_DB_UPDATE_1_Update1 : QueryBasis<M_800_000_UPDATE_RELATORIO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.RELATORIOS
				SET SIT_REGISTRO = '1'
				WHERE  COD_RELATORIO = 'SI0021B'
				AND SIT_REGISTRO = '0'";

            return query;
        }

        public static void Execute(M_800_000_UPDATE_RELATORIO_DB_UPDATE_1_Update1 m_800_000_UPDATE_RELATORIO_DB_UPDATE_1_Update1)
        {
            var ths = m_800_000_UPDATE_RELATORIO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_800_000_UPDATE_RELATORIO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}