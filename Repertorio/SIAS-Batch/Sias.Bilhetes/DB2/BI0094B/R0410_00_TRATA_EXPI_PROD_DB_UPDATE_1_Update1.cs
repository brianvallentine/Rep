using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0094B
{
    public class R0410_00_TRATA_EXPI_PROD_DB_UPDATE_1_Update1 : QueryBasis<R0410_00_TRATA_EXPI_PROD_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.BILHETE
				SET SITUACAO = 'V' ,
				TIP_CANCELAMENTO = '4' ,
				COD_USUARIO = 'BI0094B' ,
				DATA_CANCELAMENTO = CURRENT DATE ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NUM_BILHETE =  '{this.BILHETE_NUM_BILHETE}'";

            return query;
        }
        public string BILHETE_NUM_BILHETE { get; set; }

        public static void Execute(R0410_00_TRATA_EXPI_PROD_DB_UPDATE_1_Update1 r0410_00_TRATA_EXPI_PROD_DB_UPDATE_1_Update1)
        {
            var ths = r0410_00_TRATA_EXPI_PROD_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0410_00_TRATA_EXPI_PROD_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}