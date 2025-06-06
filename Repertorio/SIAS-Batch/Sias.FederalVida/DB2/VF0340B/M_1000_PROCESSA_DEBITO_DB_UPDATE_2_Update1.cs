using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0340B
{
    public class M_1000_PROCESSA_DEBITO_DB_UPDATE_2_Update1 : QueryBasis<M_1000_PROCESSA_DEBITO_DB_UPDATE_2_Update1>
    {

        private VF0340B_DEBITO CurrentOf { get; set; }

        public M_1000_PROCESSA_DEBITO_DB_UPDATE_2_Update1(VF0340B_DEBITO currentOf)
        {
            CurrentOf = currentOf;
        }

        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0HISTCONTAVA
				SET SITUACAO = '3' ,
				DTVENCTO =  '{this.DTVENCTO}',
				NSAS =  {FieldThreatment((this.SQL_NOT_NULL?.ToInt() == -1 ? null : $"{this.PARM_NSA}"))},
				NSL =  {FieldThreatment((this.SQL_NOT_NULL?.ToInt() == -1 ? null : $"{this.NSL}"))}
				WHERE
				(
					CODCONV = 6131 AND SITUACAO = '0' AND TIPLANC = '1' AND DTVENCTO <= '{this.SIST_DTMAXDEB}'
				)
				AND NSL {FieldThreatment(CurrentOf.NRCERTIF, ThreatmentType.InsertWhereField)}
				";

            return query;
        }
        public string PARM_NSA { get; set; }
        public string SQL_NOT_NULL { get; set; }
        public string NSL { get; set; }
        public string DTVENCTO { get; set; }
        public string SIST_DTMAXDEB { get; set; }

        public static void Execute(M_1000_PROCESSA_DEBITO_DB_UPDATE_2_Update1 m_1000_PROCESSA_DEBITO_DB_UPDATE_2_Update1)
        {
            var ths = m_1000_PROCESSA_DEBITO_DB_UPDATE_2_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1000_PROCESSA_DEBITO_DB_UPDATE_2_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}