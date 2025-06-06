using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0280B
{
    public class R1170_00_TRATA_PROFISSAO_DB_UPDATE_2_Update1 : QueryBasis<R1170_00_TRATA_PROFISSAO_DB_UPDATE_2_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PESSOA_FISICA
				SET COD_CBO =  '{this.PESSOFIS_COD_CBO}'
				WHERE COD_PESSOA =  '{this.PROPOVA_COD_CLIENTE}'";

            return query;
        }
        public string PESSOFIS_COD_CBO { get; set; }
        public string PROPOVA_COD_CLIENTE { get; set; }

        public static void Execute(R1170_00_TRATA_PROFISSAO_DB_UPDATE_2_Update1 r1170_00_TRATA_PROFISSAO_DB_UPDATE_2_Update1)
        {
            var ths = r1170_00_TRATA_PROFISSAO_DB_UPDATE_2_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1170_00_TRATA_PROFISSAO_DB_UPDATE_2_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}