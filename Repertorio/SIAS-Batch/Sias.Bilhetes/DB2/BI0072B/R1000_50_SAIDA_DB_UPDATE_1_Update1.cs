using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0072B
{
    public class R1000_50_SAIDA_DB_UPDATE_1_Update1 : QueryBasis<R1000_50_SAIDA_DB_UPDATE_1_Update1>
    {

        private BI0072B_V0MOVIMCOB CurrentOf { get; set; }

        public R1000_50_SAIDA_DB_UPDATE_1_Update1(BI0072B_V0MOVIMCOB currentOf)
        {
            CurrentOf = currentOf;
        }

        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.MOVIMENTO_COBRANCA
				SET SIT_REGISTRO =  '{this.MOVIMCOB_SIT_REGISTRO}'
				WHERE
				(
					SIT_REGISTRO = ' ' AND TIPO_MOVIMENTO IN ( 'T', 'U' ) AND DATA_MOVIMENTO <= '{this.V1SIST_DTMOVABE}'
				)
				AND TIPO_MOVIMENTO {FieldThreatment(CurrentOf.MOVIMCOB_COD_EMPRESA, ThreatmentType.InsertWhereField)}
				";

            return query;
        }
        public string MOVIMCOB_SIT_REGISTRO { get; set; }
        public string V1SIST_DTMOVABE { get; set; }

        public static void Execute(R1000_50_SAIDA_DB_UPDATE_1_Update1 r1000_50_SAIDA_DB_UPDATE_1_Update1)
        {
            var ths = r1000_50_SAIDA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1000_50_SAIDA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}