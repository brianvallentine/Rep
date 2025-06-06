using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0009B
{
    public class R7170_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 : QueryBasis<R7170_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1>
    {

        private CB0009B_V1BILHETE CurrentOf { get; set; }

        public R7170_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1(CB0009B_V1BILHETE currentOf)
        {
            CurrentOf = currentOf;
        }

        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0BILHETE
				SET SITUACAO =  '{this.V0BILH_SITUACAO}',
				DTCANCEL =  {FieldThreatment((this.VIND_DTCANCEL?.ToInt() == -1 ? null : $"{this.V0BILH_DTCANCEL}"))},
				RAMO =  '{this.V0BILH_RAMO}',
				COD_USUARIO = 'CB0009B'
				WHERE
				(
					SITUACAO BETWEEN '0' AND '4' AND DTMOVTO >= '{this.V0SIST_DTLIBERA}'
				)
				AND RAMO {FieldThreatment(CurrentOf.V0BILH_NUMBIL, ThreatmentType.InsertWhereField)}
				";

            return query;
        }
        public string V0BILH_DTCANCEL { get; set; }
        public string VIND_DTCANCEL { get; set; }
        public string V0BILH_SITUACAO { get; set; }
        public string V0BILH_RAMO { get; set; }
        public string V0SIST_DTLIBERA { get; set; }

        public static void Execute(R7170_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 r7170_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1)
        {
            var ths = r7170_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R7170_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}