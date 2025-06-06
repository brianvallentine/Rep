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
    public class M_0100_OPCAOPAGVA_DB_UPDATE_2_Update1 : QueryBasis<M_0100_OPCAOPAGVA_DB_UPDATE_2_Update1>
    {

        private VP0121B_CPROPVA CurrentOf { get; set; }

        public M_0100_OPCAOPAGVA_DB_UPDATE_2_Update1(VP0121B_CPROPVA currentOf)
        {
            CurrentOf = currentOf;
        }

        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0PROPOSTAVA
				SET CODPRODU =  '{this.PROPVA_CODPRODU}',
				CODOPER =  '{this.PROPVA_CODOPER}',
				DTMOVTO =  '{this.MDTMOVTO}',
				DTPROXVEN =  '{this.PROPVA_DTPROXVEN}',
				SITUACAO =  '{this.PROPVA_SITUACAO}',
				CODSUBES =  '{this.PROPVA_CODSUBES}',
				NRPARCE = 1,
				SIT_INTERFACE = '0' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE
				(
					 SITUACAO IN ( '0', '7' ) AND  NUM_APOLICE BETWEEN 107700000000 AND 107799999999 AND  NRCERTIF NOT IN ( 84537054344, 84599746247, 84546927298, 10203110003278, 10011110000404, 11688110000619, 10628460000090, 10840460000394, 84613048394)
				)
				AND 0) {FieldThreatment(CurrentOf.PROPVA_NUM_APOLICE, ThreatmentType.InsertWhereField)}
				";

            return query;
        }
        public string PROPVA_DTPROXVEN { get; set; }
        public string PROPVA_CODPRODU { get; set; }
        public string PROPVA_SITUACAO { get; set; }
        public string PROPVA_CODSUBES { get; set; }
        public string PROPVA_CODOPER { get; set; }
        public string MDTMOVTO { get; set; }

        public static void Execute(M_0100_OPCAOPAGVA_DB_UPDATE_2_Update1 m_0100_OPCAOPAGVA_DB_UPDATE_2_Update1)
        {
            var ths = m_0100_OPCAOPAGVA_DB_UPDATE_2_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0100_OPCAOPAGVA_DB_UPDATE_2_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}