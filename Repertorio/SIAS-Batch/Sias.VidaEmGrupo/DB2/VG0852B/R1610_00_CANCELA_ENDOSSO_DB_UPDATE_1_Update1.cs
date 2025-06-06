using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0852B
{
    public class R1610_00_CANCELA_ENDOSSO_DB_UPDATE_1_Update1 : QueryBasis<R1610_00_CANCELA_ENDOSSO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.ENDOSSOS
				SET SIT_REGISTRO = '2' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NUM_APOLICE =  '{this.PROPOVA_NUM_APOLICE}'
				AND NUM_ENDOSSO = 0";

            return query;
        }
        public string PROPOVA_NUM_APOLICE { get; set; }

        public static void Execute(R1610_00_CANCELA_ENDOSSO_DB_UPDATE_1_Update1 r1610_00_CANCELA_ENDOSSO_DB_UPDATE_1_Update1)
        {
            var ths = r1610_00_CANCELA_ENDOSSO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1610_00_CANCELA_ENDOSSO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}