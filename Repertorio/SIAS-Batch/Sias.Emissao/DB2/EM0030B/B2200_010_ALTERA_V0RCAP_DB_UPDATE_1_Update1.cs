using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0030B
{
    public class B2200_010_ALTERA_V0RCAP_DB_UPDATE_1_Update1 : QueryBasis<B2200_010_ALTERA_V0RCAP_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0RCAP
				SET SITUACAO = '1'
				,OPERACAO = 220
				,NUM_APOLICE =  '{this.HIST_NUM_APOLICE}'
				,NRENDOS =  '{this.HIST_NRENDOS}'
				,NRPARCEL =  '{this.HIST_NRPARCEL}'
				,TIMESTAMP = CURRENT TIMESTAMP
				WHERE  FONTE =  '{this.V0RCAP_FONTE}'
				AND NRRCAP =  '{this.V0RCAP_NRRCAP}'";

            return query;
        }
        public string HIST_NUM_APOLICE { get; set; }
        public string HIST_NRPARCEL { get; set; }
        public string HIST_NRENDOS { get; set; }
        public string V0RCAP_NRRCAP { get; set; }
        public string V0RCAP_FONTE { get; set; }

        public static void Execute(B2200_010_ALTERA_V0RCAP_DB_UPDATE_1_Update1 b2200_010_ALTERA_V0RCAP_DB_UPDATE_1_Update1)
        {
            var ths = b2200_010_ALTERA_V0RCAP_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override B2200_010_ALTERA_V0RCAP_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}