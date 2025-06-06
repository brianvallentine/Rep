using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI2002B
{
    public class R0250_00_UPDATE_MOVIMCOB_DB_UPDATE_1_Update1 : QueryBasis<R0250_00_UPDATE_MOVIMCOB_DB_UPDATE_1_Update1>
    {

        private BI2002B_V0MOVIMCOB CurrentOf { get; set; }

        public R0250_00_UPDATE_MOVIMCOB_DB_UPDATE_1_Update1(BI2002B_V0MOVIMCOB currentOf)
        {
            CurrentOf = currentOf;
        }

        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.MOVIMENTO_COBRANCA
				SET SIT_REGISTRO = '1'
				WHERE
				(
					TIPO_MOVIMENTO = 'B' AND SIT_REGISTRO = ' '
				)
				AND NUM_NOSSO_TITULO {FieldThreatment(CurrentOf.MOVIMCOB_COD_BANCO, ThreatmentType.InsertWhereField)}
				";

            return query;
        }

        public static void Execute(R0250_00_UPDATE_MOVIMCOB_DB_UPDATE_1_Update1 r0250_00_UPDATE_MOVIMCOB_DB_UPDATE_1_Update1)
        {
            var ths = r0250_00_UPDATE_MOVIMCOB_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0250_00_UPDATE_MOVIMCOB_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}