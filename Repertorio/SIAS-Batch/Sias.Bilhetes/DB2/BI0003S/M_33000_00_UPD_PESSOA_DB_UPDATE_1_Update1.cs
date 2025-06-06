using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0003S
{
    public class M_33000_00_UPD_PESSOA_DB_UPDATE_1_Update1 : QueryBasis<M_33000_00_UPD_PESSOA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PESSOA_FISICA
				SET NUM_IDENTIDADE =
				 '{this.NUM_IDENTIDADE}' ,
				ORGAO_EXPEDIDOR =
				 '{this.ORGAO_EXPEDIDOR}' ,
				UF_EXPEDIDORA =
				 '{this.UF_EXPEDIDORA}' ,
				DATA_EXPEDICAO =
				 '{this.DATA_EXPEDICAO}'
				WHERE  COD_PESSOA =  '{this.WS_COD_PES_ATU}'";

            return query;
        }
        public string ORGAO_EXPEDIDOR { get; set; }
        public string NUM_IDENTIDADE { get; set; }
        public string DATA_EXPEDICAO { get; set; }
        public string UF_EXPEDIDORA { get; set; }
        public string WS_COD_PES_ATU { get; set; }

        public static void Execute(M_33000_00_UPD_PESSOA_DB_UPDATE_1_Update1 m_33000_00_UPD_PESSOA_DB_UPDATE_1_Update1)
        {
            var ths = m_33000_00_UPD_PESSOA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_33000_00_UPD_PESSOA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}