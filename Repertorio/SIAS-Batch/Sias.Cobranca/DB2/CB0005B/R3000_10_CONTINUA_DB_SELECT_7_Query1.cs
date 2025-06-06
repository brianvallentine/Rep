using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0005B
{
    public class R3000_10_CONTINUA_DB_SELECT_7_Query1 : QueryBasis<R3000_10_CONTINUA_DB_SELECT_7_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CGCCPF ,
            BILH_AP ,
            BILH_RES ,
            BILH_VDAZUL ,
            DTMOVABE
            INTO :V1CROT-CGCCPF ,
            :V1CROT-BILH-AP ,
            :V1CROT-BILH-RES ,
            :V1CROT-BILH-VDAZUL ,
            :V1CROT-DTMOVABE
            FROM SEGUROS.V1CLIENTE_CROT
            WHERE CGCCPF = :V0BILH-CGCCPF
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT CGCCPF 
							,
											BILH_AP 
							,
											BILH_RES 
							,
											BILH_VDAZUL 
							,
											DTMOVABE
											FROM SEGUROS.V1CLIENTE_CROT
											WHERE CGCCPF = '{this.V0BILH_CGCCPF}'";

            return query;
        }
        public string V1CROT_CGCCPF { get; set; }
        public string V1CROT_BILH_AP { get; set; }
        public string V1CROT_BILH_RES { get; set; }
        public string V1CROT_BILH_VDAZUL { get; set; }
        public string V1CROT_DTMOVABE { get; set; }
        public string V0BILH_CGCCPF { get; set; }

        public static R3000_10_CONTINUA_DB_SELECT_7_Query1 Execute(R3000_10_CONTINUA_DB_SELECT_7_Query1 r3000_10_CONTINUA_DB_SELECT_7_Query1)
        {
            var ths = r3000_10_CONTINUA_DB_SELECT_7_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3000_10_CONTINUA_DB_SELECT_7_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3000_10_CONTINUA_DB_SELECT_7_Query1();
            var i = 0;
            dta.V1CROT_CGCCPF = result[i++].Value?.ToString();
            dta.V1CROT_BILH_AP = result[i++].Value?.ToString();
            dta.V1CROT_BILH_RES = result[i++].Value?.ToString();
            dta.V1CROT_BILH_VDAZUL = result[i++].Value?.ToString();
            dta.V1CROT_DTMOVABE = result[i++].Value?.ToString();
            return dta;
        }

    }
}