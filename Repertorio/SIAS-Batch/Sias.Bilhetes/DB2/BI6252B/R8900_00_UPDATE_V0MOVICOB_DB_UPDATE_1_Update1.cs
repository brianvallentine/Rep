using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6252B
{
    public class R8900_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1 : QueryBasis<R8900_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1>
    {

        private BI6252B_V0MOVIMCOB CurrentOf { get; set; }

        public R8900_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1(BI6252B_V0MOVIMCOB currentOf)
        {
            CurrentOf = currentOf;
        }

        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.MOVIMENTO_COBRANCA
				SET NUM_TITULO =  '{this.MOVIMCOB_NUM_TITULO}' ,
				NUM_APOLICE =  '{this.MOVIMCOB_NUM_APOLICE}' ,
				SIT_REGISTRO =  '{this.MOVIMCOB_SIT_REGISTRO}'
				WHERE
				(
					SIT_REGISTRO = ' ' AND TIPO_MOVIMENTO = 'Y'
				)
				AND DATA_MOVIMENTO {FieldThreatment(CurrentOf.MOVIMCOB_COD_EMPRESA, ThreatmentType.InsertWhereField)}
				";

            return query;
        }
        public string MOVIMCOB_SIT_REGISTRO { get; set; }
        public string MOVIMCOB_NUM_APOLICE { get; set; }
        public string MOVIMCOB_NUM_TITULO { get; set; }

        public static void Execute(R8900_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1 r8900_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1)
        {
            var ths = r8900_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R8900_00_UPDATE_V0MOVICOB_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}