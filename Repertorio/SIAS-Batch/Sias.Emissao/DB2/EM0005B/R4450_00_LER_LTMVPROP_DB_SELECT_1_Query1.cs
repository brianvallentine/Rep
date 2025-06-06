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
    public class R4450_00_LER_LTMVPROP_DB_SELECT_1_Query1 : QueryBasis<R4450_00_LER_LTMVPROP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PCT_JUROS
            INTO :LTMVPROP-PCT-JUROS
            FROM SEGUROS.LT_MOV_PROPOSTA
            WHERE COD_FONTE = :V1PROP-FONTE
            AND NUM_PROPOSTA = :V1PROP-NRPROPOS
            AND COD_MOVIMENTO = '9'
            AND SIT_MOVIMENTO = '1'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PCT_JUROS
											FROM SEGUROS.LT_MOV_PROPOSTA
											WHERE COD_FONTE = '{this.V1PROP_FONTE}'
											AND NUM_PROPOSTA = '{this.V1PROP_NRPROPOS}'
											AND COD_MOVIMENTO = '9'
											AND SIT_MOVIMENTO = '1'";

            return query;
        }
        public string LTMVPROP_PCT_JUROS { get; set; }
        public string V1PROP_NRPROPOS { get; set; }
        public string V1PROP_FONTE { get; set; }

        public static R4450_00_LER_LTMVPROP_DB_SELECT_1_Query1 Execute(R4450_00_LER_LTMVPROP_DB_SELECT_1_Query1 r4450_00_LER_LTMVPROP_DB_SELECT_1_Query1)
        {
            var ths = r4450_00_LER_LTMVPROP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R4450_00_LER_LTMVPROP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R4450_00_LER_LTMVPROP_DB_SELECT_1_Query1();
            var i = 0;
            dta.LTMVPROP_PCT_JUROS = result[i++].Value?.ToString();
            return dta;
        }

    }
}