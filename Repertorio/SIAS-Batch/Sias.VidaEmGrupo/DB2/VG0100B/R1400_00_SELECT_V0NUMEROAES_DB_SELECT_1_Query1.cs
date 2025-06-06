using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0100B
{
    public class R1400_00_SELECT_V0NUMEROAES_DB_SELECT_1_Query1 : QueryBasis<R1400_00_SELECT_V0NUMEROAES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            ENDOSCOB ,
            ENDOSRES ,
            ENDOSSEM
            INTO :V0NAES-ENDOSCOB ,
            :V0NAES-ENDOSRES ,
            :V0NAES-ENDOSSEM
            FROM SEGUROS.V0NUMERO_AES
            WHERE COD_ORGAO = :V1APOL-ORGAO
            AND COD_RAMO = :V1APOL-RAMO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											ENDOSCOB 
							,
											ENDOSRES 
							,
											ENDOSSEM
											FROM SEGUROS.V0NUMERO_AES
											WHERE COD_ORGAO = '{this.V1APOL_ORGAO}'
											AND COD_RAMO = '{this.V1APOL_RAMO}'";

            return query;
        }
        public string V0NAES_ENDOSCOB { get; set; }
        public string V0NAES_ENDOSRES { get; set; }
        public string V0NAES_ENDOSSEM { get; set; }
        public string V1APOL_ORGAO { get; set; }
        public string V1APOL_RAMO { get; set; }

        public static R1400_00_SELECT_V0NUMEROAES_DB_SELECT_1_Query1 Execute(R1400_00_SELECT_V0NUMEROAES_DB_SELECT_1_Query1 r1400_00_SELECT_V0NUMEROAES_DB_SELECT_1_Query1)
        {
            var ths = r1400_00_SELECT_V0NUMEROAES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1400_00_SELECT_V0NUMEROAES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1400_00_SELECT_V0NUMEROAES_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0NAES_ENDOSCOB = result[i++].Value?.ToString();
            dta.V0NAES_ENDOSRES = result[i++].Value?.ToString();
            dta.V0NAES_ENDOSSEM = result[i++].Value?.ToString();
            return dta;
        }

    }
}