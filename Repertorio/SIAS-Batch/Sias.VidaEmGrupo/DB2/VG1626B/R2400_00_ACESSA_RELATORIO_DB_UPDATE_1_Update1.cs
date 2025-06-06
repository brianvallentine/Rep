using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1626B
{
    public class R2400_00_ACESSA_RELATORIO_DB_UPDATE_1_Update1 : QueryBasis<R2400_00_ACESSA_RELATORIO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.RELATORIOS
				SET SIT_REGISTRO = '1'
				WHERE  COD_RELATORIO = 'VG1626B'
				AND NUM_APOLICE =  '{this.PROPOVA_NUM_APOLICE}'
				AND COD_SUBGRUPO =  '{this.WS_COD_SUBGRUPO}'
				AND SIT_REGISTRO = '0'";

            return query;
        }
        public string PROPOVA_NUM_APOLICE { get; set; }
        public string WS_COD_SUBGRUPO { get; set; }

        public static void Execute(R2400_00_ACESSA_RELATORIO_DB_UPDATE_1_Update1 r2400_00_ACESSA_RELATORIO_DB_UPDATE_1_Update1)
        {
            var ths = r2400_00_ACESSA_RELATORIO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2400_00_ACESSA_RELATORIO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}