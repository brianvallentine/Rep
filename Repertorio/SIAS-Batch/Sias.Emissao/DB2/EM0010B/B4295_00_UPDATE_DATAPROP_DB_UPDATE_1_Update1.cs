using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0010B
{
    public class B4295_00_UPDATE_DATAPROP_DB_UPDATE_1_Update1 : QueryBasis<B4295_00_UPDATE_DATAPROP_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0ENDOSSO
				SET DATPRO =  '{this.ENDO_DATPRO}'
				WHERE  NUM_APOLICE =  '{this.ENDO_NUM_APOLICE}'
				AND NRENDOS =  '{this.ENDO_NRENDOS}'";

            return query;
        }
        public string ENDO_DATPRO { get; set; }
        public string ENDO_NUM_APOLICE { get; set; }
        public string ENDO_NRENDOS { get; set; }

        public static void Execute(B4295_00_UPDATE_DATAPROP_DB_UPDATE_1_Update1 b4295_00_UPDATE_DATAPROP_DB_UPDATE_1_Update1)
        {
            var ths = b4295_00_UPDATE_DATAPROP_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override B4295_00_UPDATE_DATAPROP_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}