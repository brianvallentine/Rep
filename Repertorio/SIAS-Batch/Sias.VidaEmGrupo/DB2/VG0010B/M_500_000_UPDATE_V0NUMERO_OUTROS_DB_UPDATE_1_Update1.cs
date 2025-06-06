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
    public class M_500_000_UPDATE_V0NUMERO_OUTROS_DB_UPDATE_1_Update1 : QueryBasis<M_500_000_UPDATE_V0NUMERO_OUTROS_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.V0NUMERO_OUTROS
				SET NUMCERVG =  '{this.H_NUM_CERTIFICADO}'
				WHERE  NUMCERVG =  '{this.NUMCERVG}'";

            return query;
        }
        public string H_NUM_CERTIFICADO { get; set; }
        public string NUMCERVG { get; set; }

        public static void Execute(M_500_000_UPDATE_V0NUMERO_OUTROS_DB_UPDATE_1_Update1 m_500_000_UPDATE_V0NUMERO_OUTROS_DB_UPDATE_1_Update1)
        {
            var ths = m_500_000_UPDATE_V0NUMERO_OUTROS_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_500_000_UPDATE_V0NUMERO_OUTROS_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}