using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Auto.DB2.AU2055B
{
    public class R3215_00_SELECT_AU085_DB_SELECT_1_Query1 : QueryBasis<R3215_00_SELECT_AU085_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IND_FORMA_PAGTO_AD
            INTO :AU085-IND-FORMA-PAGTO-AD
            FROM SEGUROS.AU_PROPOSTA_COMPL
            WHERE COD_FONTE = :AU085-COD-FONTE
            AND NUM_PROPOSTA = :AU085-NUM-PROPOSTA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT IND_FORMA_PAGTO_AD
											FROM SEGUROS.AU_PROPOSTA_COMPL
											WHERE COD_FONTE = '{this.AU085_COD_FONTE}'
											AND NUM_PROPOSTA = '{this.AU085_NUM_PROPOSTA}'";

            return query;
        }
        public string AU085_IND_FORMA_PAGTO_AD { get; set; }
        public string AU085_NUM_PROPOSTA { get; set; }
        public string AU085_COD_FONTE { get; set; }

        public static R3215_00_SELECT_AU085_DB_SELECT_1_Query1 Execute(R3215_00_SELECT_AU085_DB_SELECT_1_Query1 r3215_00_SELECT_AU085_DB_SELECT_1_Query1)
        {
            var ths = r3215_00_SELECT_AU085_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3215_00_SELECT_AU085_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3215_00_SELECT_AU085_DB_SELECT_1_Query1();
            var i = 0;
            dta.AU085_IND_FORMA_PAGTO_AD = result[i++].Value?.ToString();
            return dta;
        }

    }
}