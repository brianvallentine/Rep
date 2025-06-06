using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0414B
{
    public class R5000_00_ATU_RELATORIOS_DB_UPDATE_1_Update1 : QueryBasis<R5000_00_ATU_RELATORIOS_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.RELATORIOS
				SET SIT_REGISTRO = '1'
				,TIMESTAMP = CURRENT TIMESTAMP
				WHERE  COD_RELATORIO =  '{this.RELATORI_COD_RELATORIO}'
				AND SIT_REGISTRO =  '{this.RELATORI_SIT_REGISTRO}'
				AND NUM_APOLICE =  '{this.RELATORI_NUM_APOLICE}'
				AND COD_SUBGRUPO =  '{this.RELATORI_COD_SUBGRUPO}'";

            return query;
        }
        public string RELATORI_COD_RELATORIO { get; set; }
        public string RELATORI_SIT_REGISTRO { get; set; }
        public string RELATORI_COD_SUBGRUPO { get; set; }
        public string RELATORI_NUM_APOLICE { get; set; }

        public static void Execute(R5000_00_ATU_RELATORIOS_DB_UPDATE_1_Update1 r5000_00_ATU_RELATORIOS_DB_UPDATE_1_Update1)
        {
            var ths = r5000_00_ATU_RELATORIOS_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R5000_00_ATU_RELATORIOS_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}