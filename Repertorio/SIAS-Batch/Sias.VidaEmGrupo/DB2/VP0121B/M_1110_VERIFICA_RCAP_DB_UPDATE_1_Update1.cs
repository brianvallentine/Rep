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
    public class M_1110_VERIFICA_RCAP_DB_UPDATE_1_Update1 : QueryBasis<M_1110_VERIFICA_RCAP_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0RCAP
				SET SITUACAO = '1' ,
				OPERACAO = 220 ,
				NUM_APOLICE =  '{this.PROPVA_NUM_APOLICE}',
				NRENDOS = 0,
				NRPARCEL = 0,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  FONTE =  '{this.V0RCAP_FONTE}'
				AND NRRCAP =  '{this.V0RCAP_NRRCAP}'";

            return query;
        }
        public string PROPVA_NUM_APOLICE { get; set; }
        public string V0RCAP_NRRCAP { get; set; }
        public string V0RCAP_FONTE { get; set; }

        public static void Execute(M_1110_VERIFICA_RCAP_DB_UPDATE_1_Update1 m_1110_VERIFICA_RCAP_DB_UPDATE_1_Update1)
        {
            var ths = m_1110_VERIFICA_RCAP_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1110_VERIFICA_RCAP_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}