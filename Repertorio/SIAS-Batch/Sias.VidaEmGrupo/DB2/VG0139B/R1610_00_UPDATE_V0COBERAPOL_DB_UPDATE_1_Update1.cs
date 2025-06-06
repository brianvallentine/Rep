using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0139B
{
    public class R1610_00_UPDATE_V0COBERAPOL_DB_UPDATE_1_Update1 : QueryBasis<R1610_00_UPDATE_V0COBERAPOL_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0COBERAPOL
				SET PRM_TARIFARIO_IX =  '{this.V0COBA_PRM_TAR_IX}' ,
				PRM_TARIFARIO_VAR =  '{this.V0COBA_PRM_TAR_VR}' ,
				PCT_COBERTURA =  '{this.V0COBA_PCT_COBERT}'
				WHERE  NUM_APOLICE =  '{this.V0COBA_NUM_APOL}'
				AND NRENDOS =  '{this.V0COBA_NRENDOS}'
				AND NUM_ITEM =  '{this.V0COBA_NUM_ITEM}'
				AND OCORHIST =  '{this.V0COBA_OCORHIST}'
				AND RAMOFR =  '{this.V0COBA_RAMOFR}'
				AND MODALIFR =  '{this.V0COBA_MODALIFR}'
				AND COD_COBERTURA =  '{this.V0COBA_COD_COBER}'";

            return query;
        }
        public string V0COBA_PRM_TAR_IX { get; set; }
        public string V0COBA_PRM_TAR_VR { get; set; }
        public string V0COBA_PCT_COBERT { get; set; }
        public string V0COBA_COD_COBER { get; set; }
        public string V0COBA_NUM_APOL { get; set; }
        public string V0COBA_NUM_ITEM { get; set; }
        public string V0COBA_OCORHIST { get; set; }
        public string V0COBA_MODALIFR { get; set; }
        public string V0COBA_NRENDOS { get; set; }
        public string V0COBA_RAMOFR { get; set; }

        public static void Execute(R1610_00_UPDATE_V0COBERAPOL_DB_UPDATE_1_Update1 r1610_00_UPDATE_V0COBERAPOL_DB_UPDATE_1_Update1)
        {
            var ths = r1610_00_UPDATE_V0COBERAPOL_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1610_00_UPDATE_V0COBERAPOL_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}