using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0121B
{
    public class M_8600_CONTINUA_DB_UPDATE_1_Update1 : QueryBasis<M_8600_CONTINUA_DB_UPDATE_1_Update1>
    {

        private VP0121B_CPROPVA CurrentOf { get; set; }

        public M_8600_CONTINUA_DB_UPDATE_1_Update1(VP0121B_CPROPVA currentOf)
        {
            CurrentOf = currentOf;
        }

        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0PROPOSTAVA
				SET DTVENCTO =  '{this.HISTCB_DTVENCTO}'
				WHERE
				(
					 SITUACAO IN ( '0', '7' ) AND  NUM_APOLICE BETWEEN 107700000000 AND 107799999999 AND  NRCERTIF NOT IN ( 84537054344, 84599746247, 84546927298, 10203110003278, 10011110000404, 11688110000619, 10628460000090, 10840460000394, 84613048394)
				)
				AND 0) {FieldThreatment(CurrentOf.PROPVA_NUM_APOLICE, ThreatmentType.InsertWhereField)}
				";

            return query;
        }
        public string HISTCB_DTVENCTO { get; set; }

        public static void Execute(M_8600_CONTINUA_DB_UPDATE_1_Update1 m_8600_CONTINUA_DB_UPDATE_1_Update1)
        {
            var ths = m_8600_CONTINUA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_8600_CONTINUA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}