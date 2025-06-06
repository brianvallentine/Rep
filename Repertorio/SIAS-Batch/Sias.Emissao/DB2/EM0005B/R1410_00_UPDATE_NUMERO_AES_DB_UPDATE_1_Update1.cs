using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0005B
{
    public class R1410_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1 : QueryBasis<R1410_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.V0NUMERO_AES
				SET SEQ_APOLICE =  '{this.V0NAES_SEQ_APOLICE}',
				ENDOSCOB =  '{this.V0NAES_ENDOSCOB}' ,
				NRENDOCA =  '{this.V0NAES_NRENDOCA}' ,
				ENDOSRES =  '{this.V0NAES_ENDOSRES}' ,
				ENDOSSEM =  '{this.V0NAES_ENDOSSEM}' ,
				ENDOSCCR =  '{this.V0NAES_ENDOSCCR}' ,
				ENDOSMVC =  '{this.V0NAES_ENDOSMVC}' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  COD_ORGAO =  '{this.V1FONT_ORGAOEMIS}'
				AND COD_RAMO =  '{this.V1PROP_RAMO}'";

            return query;
        }
        public string V0NAES_SEQ_APOLICE { get; set; }
        public string V0NAES_ENDOSCOB { get; set; }
        public string V0NAES_NRENDOCA { get; set; }
        public string V0NAES_ENDOSRES { get; set; }
        public string V0NAES_ENDOSSEM { get; set; }
        public string V0NAES_ENDOSCCR { get; set; }
        public string V0NAES_ENDOSMVC { get; set; }
        public string V1FONT_ORGAOEMIS { get; set; }
        public string V1PROP_RAMO { get; set; }

        public static void Execute(R1410_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1 r1410_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1)
        {
            var ths = r1410_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1410_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}