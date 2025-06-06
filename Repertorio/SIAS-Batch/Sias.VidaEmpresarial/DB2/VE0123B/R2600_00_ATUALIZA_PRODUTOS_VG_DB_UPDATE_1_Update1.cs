using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0123B
{
    public class R2600_00_ATUALIZA_PRODUTOS_VG_DB_UPDATE_1_Update1 : QueryBasis<R2600_00_ATUALIZA_PRODUTOS_VG_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PRODUTOS_VG
				SET COD_PRODUTO =  '{this.PROPOVA_COD_PRODUTO}' ,
				PERI_PAGAMENTO = 1
				WHERE  NUM_APOLICE =  '{this.PROPOVA_NUM_APOLICE}'
				AND COD_SUBGRUPO =  '{this.PROPOVA_COD_SUBGRUPO}'";

            return query;
        }
        public string PROPOVA_COD_PRODUTO { get; set; }
        public string PROPOVA_COD_SUBGRUPO { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }

        public static void Execute(R2600_00_ATUALIZA_PRODUTOS_VG_DB_UPDATE_1_Update1 r2600_00_ATUALIZA_PRODUTOS_VG_DB_UPDATE_1_Update1)
        {
            var ths = r2600_00_ATUALIZA_PRODUTOS_VG_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2600_00_ATUALIZA_PRODUTOS_VG_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}