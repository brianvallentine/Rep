using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0128B
{
    public class M_0300_CORRIGE_IOF_DB_UPDATE_3_Update1 : QueryBasis<M_0300_CORRIGE_IOF_DB_UPDATE_3_Update1>
    {

        private VA0128B_CPROPVA CurrentOf { get; set; }

        public M_0300_CORRIGE_IOF_DB_UPDATE_3_Update1(VA0128B_CPROPVA currentOf)
        {
            CurrentOf = currentOf;
        }

        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0PROPOSTAVA
				SET CODOPER =  '{this.COD_OPERACAO}',
				DTMOVTO =  '{this.DATA_MOVIMENTO}',
				OCORHIST =  '{this.PROPVA_OCORHIST}',
				SIT_INTERFACE = '0' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE
				(
					SITUACAO IN ( '3', '6' ) AND NUM_APOLICE <> 109300000635
				)
				AND IDADE {FieldThreatment(CurrentOf.PROPVA_NUM_APOLICE, ThreatmentType.InsertWhereField)}
				";

            return query;
        }
        public string PROPVA_OCORHIST { get; set; }
        public string DATA_MOVIMENTO { get; set; }
        public string COD_OPERACAO { get; set; }

        public static void Execute(M_0300_CORRIGE_IOF_DB_UPDATE_3_Update1 m_0300_CORRIGE_IOF_DB_UPDATE_3_Update1)
        {
            var ths = m_0300_CORRIGE_IOF_DB_UPDATE_3_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0300_CORRIGE_IOF_DB_UPDATE_3_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}