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
    public class R0050_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1 : QueryBasis<R0050_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.SEGURADOS_VGAP
				SET COD_PROFISSAO = 9521
				WHERE  NUM_CERTIFICADO =  '{this.SEGURVGA_NUM_CERTIFICADO}'
				AND TIPO_SEGURADO = '1'";

            return query;
        }
        public string SEGURVGA_NUM_CERTIFICADO { get; set; }

        public static void Execute(R0050_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1 r0050_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1)
        {
            var ths = r0050_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0050_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}