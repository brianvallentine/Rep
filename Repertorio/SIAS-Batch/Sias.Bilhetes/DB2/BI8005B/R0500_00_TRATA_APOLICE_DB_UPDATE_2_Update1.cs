using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI8005B
{
    public class R0500_00_TRATA_APOLICE_DB_UPDATE_2_Update1 : QueryBasis<R0500_00_TRATA_APOLICE_DB_UPDATE_2_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0BILHETE
				SET NUM_APOLICE =  '{this.V0APOL_NUM_APOL}',
				SITUACAO =  '{this.V0BILH_SITUACAO}',
				COD_USUARIO = 'BI8005B' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NUMBIL =  '{this.V0BILH_NUMBIL}'";

            return query;
        }
        public string V0APOL_NUM_APOL { get; set; }
        public string V0BILH_SITUACAO { get; set; }
        public string V0BILH_NUMBIL { get; set; }

        public static void Execute(R0500_00_TRATA_APOLICE_DB_UPDATE_2_Update1 r0500_00_TRATA_APOLICE_DB_UPDATE_2_Update1)
        {
            var ths = r0500_00_TRATA_APOLICE_DB_UPDATE_2_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0500_00_TRATA_APOLICE_DB_UPDATE_2_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}