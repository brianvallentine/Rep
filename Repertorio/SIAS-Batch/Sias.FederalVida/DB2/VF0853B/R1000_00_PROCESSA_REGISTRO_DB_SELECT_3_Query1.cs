using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0853B
{
    public class R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1 : QueryBasis<R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_SEGURO
            INTO :V0CONV-CODCONV
            FROM SEGUROS.V0CONVSICOV
            WHERE CODPRODU = :V0PROP-CODPRODU
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COD_SEGURO
											FROM SEGUROS.V0CONVSICOV
											WHERE CODPRODU = '{this.V0PROP_CODPRODU}'";

            return query;
        }
        public string V0CONV_CODCONV { get; set; }
        public string V0PROP_CODPRODU { get; set; }

        public static R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1 Execute(R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1 r1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1)
        {
            var ths = r1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1();
            var i = 0;
            dta.V0CONV_CODCONV = result[i++].Value?.ToString();
            return dta;
        }

    }
}