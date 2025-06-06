using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0006B
{
    public class R4600_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1 : QueryBasis<R4600_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            SEQ_APOLICE,
            ENDOSCOB ,
            NRENDOCA ,
            ENDOSRES ,
            ENDOSSEM ,
            ENDOSCCR ,
            ENDOSMVC
            INTO :V0NAES-SEQ-APOL ,
            :V0NAES-ENDOSCOB ,
            :V0NAES-NRENDOCA ,
            :V0NAES-ENDOSRES ,
            :V0NAES-ENDOSSEM ,
            :V0NAES-ENDOSCCR ,
            :V0NAES-ENDOSMVC
            FROM SEGUROS.V0NUMERO_AES
            WHERE COD_ORGAO = :V1FONT-ORGAOEMIS
            AND COD_RAMO = :V1PROP-RAMO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											SEQ_APOLICE
							,
											ENDOSCOB 
							,
											NRENDOCA 
							,
											ENDOSRES 
							,
											ENDOSSEM 
							,
											ENDOSCCR 
							,
											ENDOSMVC
											FROM SEGUROS.V0NUMERO_AES
											WHERE COD_ORGAO = '{this.V1FONT_ORGAOEMIS}'
											AND COD_RAMO = '{this.V1PROP_RAMO}'";

            return query;
        }
        public string V0NAES_SEQ_APOL { get; set; }
        public string V0NAES_ENDOSCOB { get; set; }
        public string V0NAES_NRENDOCA { get; set; }
        public string V0NAES_ENDOSRES { get; set; }
        public string V0NAES_ENDOSSEM { get; set; }
        public string V0NAES_ENDOSCCR { get; set; }
        public string V0NAES_ENDOSMVC { get; set; }
        public string V1FONT_ORGAOEMIS { get; set; }
        public string V1PROP_RAMO { get; set; }

        public static R4600_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1 Execute(R4600_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1 r4600_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1)
        {
            var ths = r4600_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R4600_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R4600_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0NAES_SEQ_APOL = result[i++].Value?.ToString();
            dta.V0NAES_ENDOSCOB = result[i++].Value?.ToString();
            dta.V0NAES_NRENDOCA = result[i++].Value?.ToString();
            dta.V0NAES_ENDOSRES = result[i++].Value?.ToString();
            dta.V0NAES_ENDOSSEM = result[i++].Value?.ToString();
            dta.V0NAES_ENDOSCCR = result[i++].Value?.ToString();
            dta.V0NAES_ENDOSMVC = result[i++].Value?.ToString();
            return dta;
        }

    }
}