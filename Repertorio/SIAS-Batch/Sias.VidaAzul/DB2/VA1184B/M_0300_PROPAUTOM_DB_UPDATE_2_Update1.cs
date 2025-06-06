using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1184B
{
    public class M_0300_PROPAUTOM_DB_UPDATE_2_Update1 : QueryBasis<M_0300_PROPAUTOM_DB_UPDATE_2_Update1>
    {

        private VA1184B_CPROPVA CurrentOf { get; set; }

        public M_0300_PROPAUTOM_DB_UPDATE_2_Update1(VA1184B_CPROPVA currentOf)
        {
            CurrentOf = currentOf;
        }

        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0RELATORIOS
				SET SITUACAO = '1'
				WHERE
				(
					CODRELAT = 'VA1184B' AND SITUACAO = '0'
				)
				AND SITUACAO {FieldThreatment(CurrentOf.RELATO_DTSOLICITACAO, ThreatmentType.InsertWhereField)}
				";

            return query;
        }

        public static void Execute(M_0300_PROPAUTOM_DB_UPDATE_2_Update1 m_0300_PROPAUTOM_DB_UPDATE_2_Update1)
        {
            var ths = m_0300_PROPAUTOM_DB_UPDATE_2_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0300_PROPAUTOM_DB_UPDATE_2_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}