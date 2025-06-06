using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0010B
{
    public class M_1000_JA_INTEGRADO_DB_UPDATE_1_Update1 : QueryBasis<M_1000_JA_INTEGRADO_DB_UPDATE_1_Update1>
    {

        private VA0010B_CSEGURAVG CurrentOf { get; set; }

        public M_1000_JA_INTEGRADO_DB_UPDATE_1_Update1(VA0010B_CSEGURAVG currentOf)
        {
            CurrentOf = currentOf;
        }

        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0SEGURAVG
				SET NUM_CARNE = 0
				WHERE
				(
					NUM_APOLICE = 97010000889 AND COD_SUBGRUPO IN (1, 1948, 1949, 1950, 1951, 2910) AND NUM_MATRICULA >= 0 AND TIPO_SEGURADO = '1' AND SIT_REGISTRO IN ( '0', '1' ) AND NUM_CARNE > 0
				)
				AND NUM_CARNE {FieldThreatment(CurrentOf.V1SEGV_NUM_APOLICE, ThreatmentType.InsertWhereField)}
				";

            return query;
        }

        public static void Execute(M_1000_JA_INTEGRADO_DB_UPDATE_1_Update1 m_1000_JA_INTEGRADO_DB_UPDATE_1_Update1)
        {
            var ths = m_1000_JA_INTEGRADO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1000_JA_INTEGRADO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}