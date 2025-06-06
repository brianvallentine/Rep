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
    public class B4000_ATUALIZA_ENDOSSO_DB_UPDATE_1_Update1 : QueryBasis<B4000_ATUALIZA_ENDOSSO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0ENDOSSO
				SET SITUACAO =  '{this.WSITUACAO}'
				,DTEMIS =  '{this.SIST_DTMOVABE}'
				WHERE  NUM_APOLICE =  '{this.ENDO_NUM_APOLICE}'
				AND NRENDOS =  '{this.ENDO_NRENDOS}'";

            return query;
        }
        public string SIST_DTMOVABE { get; set; }
        public string WSITUACAO { get; set; }
        public string ENDO_NUM_APOLICE { get; set; }
        public string ENDO_NRENDOS { get; set; }

        public static void Execute(B4000_ATUALIZA_ENDOSSO_DB_UPDATE_1_Update1 b4000_ATUALIZA_ENDOSSO_DB_UPDATE_1_Update1)
        {
            var ths = b4000_ATUALIZA_ENDOSSO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override B4000_ATUALIZA_ENDOSSO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}