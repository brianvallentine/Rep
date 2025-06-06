using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0032B
{
    public class M_420_000_UPDATE_V0PROPOSTAVA_DB_UPDATE_1_Update1 : QueryBasis<M_420_000_UPDATE_V0PROPOSTAVA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PROPOSTAS_VA
				SET SIT_REGISTRO = '4' ,
				COD_USUARIO = 'VG0032B' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NUM_CERTIFICADO =  '{this.SEGURVGA_NUM_CERTIFICADO}'";

            return query;
        }
        public string SEGURVGA_NUM_CERTIFICADO { get; set; }

        public static void Execute(M_420_000_UPDATE_V0PROPOSTAVA_DB_UPDATE_1_Update1 m_420_000_UPDATE_V0PROPOSTAVA_DB_UPDATE_1_Update1)
        {
            var ths = m_420_000_UPDATE_V0PROPOSTAVA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_420_000_UPDATE_V0PROPOSTAVA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}