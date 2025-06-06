using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0031B
{
    public class R0220_20_UPDATE_SUBGRUPO_ZERO_DB_UPDATE_2_Update1 : QueryBasis<R0220_20_UPDATE_SUBGRUPO_ZERO_DB_UPDATE_2_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.V0PROPOSTAVA
				SET SITUACAO = '4' ,
				CODUSU = 'VG0031B' ,
				CODOPER =  '{this.V0PROP_CODOPER}',
				DTMOVTO =  '{this.V1SIST_DTMOVABE}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NUM_APOLICE =  '{this.V1REL_NUM_APOL}'
				AND CODSUBES = 0
				AND SITUACAO IN ( '3' , '6' )";

            return query;
        }
        public string V1SIST_DTMOVABE { get; set; }
        public string V0PROP_CODOPER { get; set; }
        public string V1REL_NUM_APOL { get; set; }

        public static void Execute(R0220_20_UPDATE_SUBGRUPO_ZERO_DB_UPDATE_2_Update1 r0220_20_UPDATE_SUBGRUPO_ZERO_DB_UPDATE_2_Update1)
        {
            var ths = r0220_20_UPDATE_SUBGRUPO_ZERO_DB_UPDATE_2_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0220_20_UPDATE_SUBGRUPO_ZERO_DB_UPDATE_2_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}