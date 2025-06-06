using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB2005B
{
    public class R3000_91_LE_ENDOSSO_DB_SELECT_2_Query1 : QueryBasis<R3000_91_LE_ENDOSSO_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CGCCPF,
            NOME_RAZAO
            INTO :V0BILH-CGCCPF,
            :V0BILH-NOME
            FROM SEGUROS.V0CLIENTE
            WHERE COD_CLIENTE = :V0BILH-CODCLIEN
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CGCCPF
							,
											NOME_RAZAO
											FROM SEGUROS.V0CLIENTE
											WHERE COD_CLIENTE = '{this.V0BILH_CODCLIEN}'
											WITH UR";

            return query;
        }
        public string V0BILH_CGCCPF { get; set; }
        public string V0BILH_NOME { get; set; }
        public string V0BILH_CODCLIEN { get; set; }

        public static R3000_91_LE_ENDOSSO_DB_SELECT_2_Query1 Execute(R3000_91_LE_ENDOSSO_DB_SELECT_2_Query1 r3000_91_LE_ENDOSSO_DB_SELECT_2_Query1)
        {
            var ths = r3000_91_LE_ENDOSSO_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3000_91_LE_ENDOSSO_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3000_91_LE_ENDOSSO_DB_SELECT_2_Query1();
            var i = 0;
            dta.V0BILH_CGCCPF = result[i++].Value?.ToString();
            dta.V0BILH_NOME = result[i++].Value?.ToString();
            return dta;
        }

    }
}