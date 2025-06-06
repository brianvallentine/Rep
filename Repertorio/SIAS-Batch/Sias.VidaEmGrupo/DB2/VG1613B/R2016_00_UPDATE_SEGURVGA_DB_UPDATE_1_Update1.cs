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
    public class R2016_00_UPDATE_SEGURVGA_DB_UPDATE_1_Update1 : QueryBasis<R2016_00_UPDATE_SEGURVGA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.SEGURADOS_VGAP
				SET
				COD_PROFISSAO = 9999
				WHERE 
				NUM_CERTIFICADO =  '{this.SEGURVGA_NUM_CERTIFICADO}'
				AND TIPO_SEGURADO = '1'";

            return query;
        }
        public string SEGURVGA_NUM_CERTIFICADO { get; set; }

        public static void Execute(R2016_00_UPDATE_SEGURVGA_DB_UPDATE_1_Update1 r2016_00_UPDATE_SEGURVGA_DB_UPDATE_1_Update1)
        {
            var ths = r2016_00_UPDATE_SEGURVGA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2016_00_UPDATE_SEGURVGA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}