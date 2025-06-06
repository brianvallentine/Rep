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
    public class R3210_20_CROT_DB_SELECT_1_Query1 : QueryBasis<R3210_20_CROT_DB_SELECT_1_Query1>
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
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CGCCPF
							,
											NOME_RAZAO
											FROM SEGUROS.V0CLIENTE
											WHERE COD_CLIENTE = '{this.V0BILH_CODCLIEN}'";

            return query;
        }
        public string V0BILH_CGCCPF { get; set; }
        public string V0BILH_NOME { get; set; }
        public string V0BILH_CODCLIEN { get; set; }

        public static R3210_20_CROT_DB_SELECT_1_Query1 Execute(R3210_20_CROT_DB_SELECT_1_Query1 r3210_20_CROT_DB_SELECT_1_Query1)
        {
            var ths = r3210_20_CROT_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3210_20_CROT_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3210_20_CROT_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0BILH_CGCCPF = result[i++].Value?.ToString();
            dta.V0BILH_NOME = result[i++].Value?.ToString();
            return dta;
        }

    }
}