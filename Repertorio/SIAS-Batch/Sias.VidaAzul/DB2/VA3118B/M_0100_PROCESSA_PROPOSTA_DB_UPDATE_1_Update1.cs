using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA3118B
{
    public class M_0100_PROCESSA_PROPOSTA_DB_UPDATE_1_Update1 : QueryBasis<M_0100_PROCESSA_PROPOSTA_DB_UPDATE_1_Update1>
    {

        private VA3118B_CPROPVA CurrentOf { get; set; }

        public M_0100_PROCESSA_PROPOSTA_DB_UPDATE_1_Update1(VA3118B_CPROPVA currentOf)
        {
            CurrentOf = currentOf;
        }

        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0PROPOSTAVA
				SET SITUACAO = '0' ,
				CODUSU = 'VA3118B'
				WHERE
				(
					 SITUACAO IN ( '1', '9' ) AND  DTQITBCO > '2007-01-15' AND  NRCERTIF NOT IN (84677241829, 84547054344, 84690719095, 84547054344, 84691024538, 84547054344, 10022577049, 10023181831, 84500413070, 84507108249, 84628255846, 84628255854, 57391776129896, 10759460000143, 84691591092)
				)
				AND '       ' ) {FieldThreatment(CurrentOf.PROPVA_NUM_APOLICE, ThreatmentType.InsertWhereField)}
				";

            return query;
        }

        public static void Execute(M_0100_PROCESSA_PROPOSTA_DB_UPDATE_1_Update1 m_0100_PROCESSA_PROPOSTA_DB_UPDATE_1_Update1)
        {
            var ths = m_0100_PROCESSA_PROPOSTA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0100_PROCESSA_PROPOSTA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}