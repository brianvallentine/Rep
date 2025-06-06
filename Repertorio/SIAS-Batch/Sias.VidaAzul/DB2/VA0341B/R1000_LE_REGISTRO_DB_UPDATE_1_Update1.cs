using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0341B
{
    public class R1000_LE_REGISTRO_DB_UPDATE_1_Update1 : QueryBasis<R1000_LE_REGISTRO_DB_UPDATE_1_Update1>
    {

        private VA0341B_RESSARC CurrentOf { get; set; }

        public R1000_LE_REGISTRO_DB_UPDATE_1_Update1(VA0341B_RESSARC currentOf)
        {
            CurrentOf = currentOf;
        }

        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0HISTCONTAVA
				SET SITUACAO = '3' ,
				DTVENCTO =  '{this.SIST_DTCREDITO}',
				NSAS =  {FieldThreatment((this.SQL_NOT_NULL?.ToInt() == -1 ? null : $"{this.PARM_NSA}"))},
				NSL =  {FieldThreatment((this.SQL_NOT_NULL?.ToInt() == -1 ? null : $"{this.NSL}"))}
				WHERE
				(
					CODCONV = 6090 AND SITUACAO = '0' AND NUMCTADEB > 0 AND TIPLANC = '2'
				)
				AND NRPARCEL {FieldThreatment(CurrentOf.AGECTADEB, ThreatmentType.InsertWhereField)}
				";

            return query;
        }
        public string PARM_NSA { get; set; }
        public string SQL_NOT_NULL { get; set; }
        public string NSL { get; set; }
        public string SIST_DTCREDITO { get; set; }

        public static void Execute(R1000_LE_REGISTRO_DB_UPDATE_1_Update1 r1000_LE_REGISTRO_DB_UPDATE_1_Update1)
        {
            var ths = r1000_LE_REGISTRO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1000_LE_REGISTRO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}