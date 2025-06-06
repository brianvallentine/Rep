using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0458B
{
    public class R1015_00_SELECT_OPCAOPAG_Query1 : QueryBasis<R1015_00_SELECT_OPCAOPAG_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT OPCAO_PAGAMENTO
            INTO :OPCPAGVI-OPC-PAGTO
            FROM SEGUROS.OPCAO_PAG_VIDAZUL
            WHERE NUM_CERTIFICADO = :V0PROP-NRCERTIF
            AND DATA_TERVIGENCIA = '9999-12-31'
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT OPCAO_PAGAMENTO
											FROM SEGUROS.OPCAO_PAG_VIDAZUL
											WHERE NUM_CERTIFICADO = '{this.V0PROP_NRCERTIF}'
											AND DATA_TERVIGENCIA = '9999-12-31'
											WITH UR";

            return query;
        }
        public string OPCPAGVI_OPC_PAGTO { get; set; }
        public string V0PROP_NRCERTIF { get; set; }

        public static R1015_00_SELECT_OPCAOPAG_Query1 Execute(R1015_00_SELECT_OPCAOPAG_Query1 r1015_00_SELECT_OPCAOPAG_Query1)
        {
            var ths = r1015_00_SELECT_OPCAOPAG_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1015_00_SELECT_OPCAOPAG_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1015_00_SELECT_OPCAOPAG_Query1();
            var i = 0;
            dta.OPCPAGVI_OPC_PAGTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}