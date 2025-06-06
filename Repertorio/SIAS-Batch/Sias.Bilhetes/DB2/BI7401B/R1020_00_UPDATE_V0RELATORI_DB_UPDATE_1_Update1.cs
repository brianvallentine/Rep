using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI7401B
{
    public class R1020_00_UPDATE_V0RELATORI_DB_UPDATE_1_Update1 : QueryBasis<R1020_00_UPDATE_V0RELATORI_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.RELATORIOS
				SET SIT_REGISTRO = '2'
				,IND_PREV_DEFINIT =  '{this.RELATORI_IND_PREV_DEFINIT}'
				,IND_ANAL_RESUMO =  '{this.RELATORI_IND_ANAL_RESUMO}'
				WHERE  COD_RELATORIO = 'BI6401B1'
				AND NUM_TITULO =  '{this.RELATORI_NUM_TITULO}'";

            return query;
        }
        public string RELATORI_IND_PREV_DEFINIT { get; set; }
        public string RELATORI_IND_ANAL_RESUMO { get; set; }
        public string RELATORI_NUM_TITULO { get; set; }

        public static void Execute(R1020_00_UPDATE_V0RELATORI_DB_UPDATE_1_Update1 r1020_00_UPDATE_V0RELATORI_DB_UPDATE_1_Update1)
        {
            var ths = r1020_00_UPDATE_V0RELATORI_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1020_00_UPDATE_V0RELATORI_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}