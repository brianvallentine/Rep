using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0071B
{
    public class R0118_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1 : QueryBasis<R0118_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0MOVDEBCC_CEF
				SET DTVENCTO =  '{this.V0MOVDE_DTVENCTO}'
				WHERE  NUM_APOLICE =  '{this.V0MOVDE_NUM_APOLICE}'
				AND NRENDOS =  '{this.V0MOVDE_NRENDOS}'
				AND NRPARCEL =  '{this.V0MOVDE_NRPARCEL}'
				AND SIT_COBRANCA IN ( '0' , ' ' , 'A' )
				AND COD_CONVENIO =  '{this.V0MOVDE_COD_CONVENIO}'";

            return query;
        }
        public string V0MOVDE_DTVENCTO { get; set; }
        public string V0MOVDE_COD_CONVENIO { get; set; }
        public string V0MOVDE_NUM_APOLICE { get; set; }
        public string V0MOVDE_NRPARCEL { get; set; }
        public string V0MOVDE_NRENDOS { get; set; }

        public static void Execute(R0118_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1 r0118_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1)
        {
            var ths = r0118_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0118_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}