using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0344B
{
    public class M_1000_PROCESSA_DEBITO_DB_UPDATE_1_Update1 : QueryBasis<M_1000_PROCESSA_DEBITO_DB_UPDATE_1_Update1>
    {

        private VA0344B_DEBITO CurrentOf { get; set; }

        public M_1000_PROCESSA_DEBITO_DB_UPDATE_1_Update1(VA0344B_DEBITO currentOf)
        {
            CurrentOf = currentOf;
        }

        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0HISTCONTAVA
				SET SITUACAO = '3' ,
				NSAS =  {FieldThreatment((this.SQL_NOT_NULL?.ToInt() == -1 ? null : $"{this.PARM_NSA}"))}
				WHERE
				(
					CODCONV = 6088 AND SITUACAO = '0' AND NUMCTADEB > 0 AND TIPLANC = '4'
				)
				AND NSL {FieldThreatment(CurrentOf.NRCERTIF, ThreatmentType.InsertWhereField)}
				";

            return query;
        }
        public string PARM_NSA { get; set; }
        public string SQL_NOT_NULL { get; set; }

        public static void Execute(M_1000_PROCESSA_DEBITO_DB_UPDATE_1_Update1 m_1000_PROCESSA_DEBITO_DB_UPDATE_1_Update1)
        {
            var ths = m_1000_PROCESSA_DEBITO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1000_PROCESSA_DEBITO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}