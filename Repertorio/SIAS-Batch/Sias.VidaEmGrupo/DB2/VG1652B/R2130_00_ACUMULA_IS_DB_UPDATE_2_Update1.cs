using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1652B
{
    public class R2130_00_ACUMULA_IS_DB_UPDATE_2_Update1 : QueryBasis<R2130_00_ACUMULA_IS_DB_UPDATE_2_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.MOVIMENTO_VGAP
				SET DATA_FATURA =  {FieldThreatment((this.VIND_DATA_FATURA_U?.ToInt() == -1 ? null : $"{this.SISTEMAS_DATA_MOV_ABERTO}"))}
				WHERE 
				COD_FONTE =  '{this.MOVIMVGA_COD_FONTE}'
				AND NUM_PROPOSTA =  '{this.MOVIMVGA_NUM_PROPOSTA}'";

            return query;
        }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string VIND_DATA_FATURA_U { get; set; }
        public string MOVIMVGA_NUM_PROPOSTA { get; set; }
        public string MOVIMVGA_COD_FONTE { get; set; }

        public static void Execute(R2130_00_ACUMULA_IS_DB_UPDATE_2_Update1 r2130_00_ACUMULA_IS_DB_UPDATE_2_Update1)
        {
            var ths = r2130_00_ACUMULA_IS_DB_UPDATE_2_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2130_00_ACUMULA_IS_DB_UPDATE_2_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}