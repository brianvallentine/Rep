using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6252B
{
    public class R8500_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 : QueryBasis<R8500_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.BILHETE
				SET NUM_APOLICE =  '{this.BILHETE_NUM_APOLICE}' ,
				FONTE =  '{this.BILHETE_FONTE}' ,
				DATA_QUITACAO =  '{this.BILHETE_DATA_QUITACAO}' ,
				SITUACAO =  '{this.BILHETE_SITUACAO}' ,
				COD_USUARIO = 'BI6252B'
				WHERE  NUM_BILHETE =  '{this.BILHETE_NUM_BILHETE}'";

            return query;
        }
        public string BILHETE_DATA_QUITACAO { get; set; }
        public string BILHETE_NUM_APOLICE { get; set; }
        public string BILHETE_SITUACAO { get; set; }
        public string BILHETE_FONTE { get; set; }
        public string BILHETE_NUM_BILHETE { get; set; }

        public static void Execute(R8500_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 r8500_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1)
        {
            var ths = r8500_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R8500_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}