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
    public class R1270_00_TRATA_UF_DB_UPDATE_1_Update1 : QueryBasis<R1270_00_TRATA_UF_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.ENDERECOS
				SET SIGLA_UF =  '{this.ENDERECO_SIGLA_UF}'
				WHERE COD_CLIENTE =  '{this.PROPOVA_COD_CLIENTE}'
				AND OCORR_ENDERECO =  '{this.PROPOVA_OCOREND}'";

            return query;
        }
        public string ENDERECO_SIGLA_UF { get; set; }
        public string PROPOVA_COD_CLIENTE { get; set; }
        public string PROPOVA_OCOREND { get; set; }

        public static void Execute(R1270_00_TRATA_UF_DB_UPDATE_1_Update1 r1270_00_TRATA_UF_DB_UPDATE_1_Update1)
        {
            var ths = r1270_00_TRATA_UF_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1270_00_TRATA_UF_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}