using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0031B
{
    public class R2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1 : QueryBasis<R2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.RELATORIOS
				SET SIT_REGISTRO = '3'
				WHERE  NUM_APOLICE =  '{this.RELATORI_NUM_APOLICE}'
				AND COD_SUBGRUPO =  '{this.RELATORI_COD_SUBGRUPO}'
				AND COD_RELATORIO = 'VE0030B'
				AND COD_USUARIO IN ( 'VA0851B' , 'VE0436B' )
				AND SIT_REGISTRO = '2'";

            return query;
        }
        public string RELATORI_COD_SUBGRUPO { get; set; }
        public string RELATORI_NUM_APOLICE { get; set; }

        public static void Execute(R2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1 r2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1)
        {
            var ths = r2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}