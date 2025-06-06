using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0121B
{
    public class M_0700_000_UPDATE_DB_UPDATE_1_Update1 : QueryBasis<M_0700_000_UPDATE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0RELATORIOS
				SET SITUACAO = '1' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  CODRELAT = 'VG0121B'
				AND IDSISTEM = 'VG'
				AND SITUACAO = '0'
				AND OPERACAO >= 1
				AND OPERACAO <= 3";

            return query;
        }

        public static void Execute(M_0700_000_UPDATE_DB_UPDATE_1_Update1 m_0700_000_UPDATE_DB_UPDATE_1_Update1)
        {
            var ths = m_0700_000_UPDATE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0700_000_UPDATE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}