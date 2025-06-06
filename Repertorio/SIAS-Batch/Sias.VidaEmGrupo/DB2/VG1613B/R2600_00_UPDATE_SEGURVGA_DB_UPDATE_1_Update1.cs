using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1613B
{
    public class R2600_00_UPDATE_SEGURVGA_DB_UPDATE_1_Update1 : QueryBasis<R2600_00_UPDATE_SEGURVGA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.SEGURADOS_VGAP
				SET COD_PROFISSAO = 7777
				WHERE  NUM_APOLICE =  '{this.SUBGVGAP_NUM_APOLICE}'
				AND COD_SUBGRUPO =  '{this.SUBGVGAP_COD_SUBGRUPO}'
				AND SIT_REGISTRO = '0'";

            return query;
        }
        public string SUBGVGAP_COD_SUBGRUPO { get; set; }
        public string SUBGVGAP_NUM_APOLICE { get; set; }

        public static void Execute(R2600_00_UPDATE_SEGURVGA_DB_UPDATE_1_Update1 r2600_00_UPDATE_SEGURVGA_DB_UPDATE_1_Update1)
        {
            var ths = r2600_00_UPDATE_SEGURVGA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2600_00_UPDATE_SEGURVGA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}