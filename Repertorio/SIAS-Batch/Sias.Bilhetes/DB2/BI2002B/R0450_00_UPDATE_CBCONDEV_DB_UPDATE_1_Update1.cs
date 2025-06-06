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
    public class R0450_00_UPDATE_CBCONDEV_DB_UPDATE_1_Update1 : QueryBasis<R0450_00_UPDATE_CBCONDEV_DB_UPDATE_1_Update1>
    {

        private BI2002B_V0CBCONDEV CurrentOf { get; set; }

        public R0450_00_UPDATE_CBCONDEV_DB_UPDATE_1_Update1(BI2002B_V0CBCONDEV currentOf)
        {
            CurrentOf = currentOf;
        }

        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.CB_CONTR_DEVPREMIO
				SET SIT_REGISTRO = '2'
				WHERE
				(
					COD_EMPRESA = 0 AND TIPO_MOVIMENTO = 'A' AND NUM_CHEQUE_INTERNO = 1 AND DIG_CHEQUE_INTERNO = 0 AND NUM_CERTIFICADO = '{this.CBCONDEV_NUM_CERTIFICADO}' AND SIT_REGISTRO = '1'
				)
				AND VAL_TITULO {FieldThreatment(CurrentOf.CBCONDEV_NUM_TITULO, ThreatmentType.InsertWhereField)}
				";

            return query;
        }
        public string CBCONDEV_NUM_CERTIFICADO { get; set; }

        public static void Execute(R0450_00_UPDATE_CBCONDEV_DB_UPDATE_1_Update1 r0450_00_UPDATE_CBCONDEV_DB_UPDATE_1_Update1)
        {
            var ths = r0450_00_UPDATE_CBCONDEV_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0450_00_UPDATE_CBCONDEV_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}