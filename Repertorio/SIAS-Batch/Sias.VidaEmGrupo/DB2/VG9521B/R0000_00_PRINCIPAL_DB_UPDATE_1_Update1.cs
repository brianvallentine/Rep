using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG9521B
{
    public class R0000_00_PRINCIPAL_DB_UPDATE_1_Update1 : QueryBasis<R0000_00_PRINCIPAL_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.SEGURADOS_VGAP
				SET COD_PROFISSAO = 0
				WHERE  NUM_APOLICE =  '{this.SEGURVGA_NUM_APOLICE}'
				AND COD_SUBGRUPO =  '{this.SEGURVGA_COD_SUBGRUPO}'";

            return query;
        }
        public string SEGURVGA_COD_SUBGRUPO { get; set; }
        public string SEGURVGA_NUM_APOLICE { get; set; }

        public static void Execute(R0000_00_PRINCIPAL_DB_UPDATE_1_Update1 r0000_00_PRINCIPAL_DB_UPDATE_1_Update1)
        {
            var ths = r0000_00_PRINCIPAL_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0000_00_PRINCIPAL_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}