using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI7401B
{
    public class R0335_00_SELECT_CONVERSI_DB_SELECT_1_Query1 : QueryBasis<R0335_00_SELECT_CONVERSI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_PROPOSTA_SIVPF
            ,NUM_SICOB
            ,COD_PRODUTO_SIVPF
            INTO :CONVERSI-NUM-PROPOSTA-SIVPF
            ,:CONVERSI-NUM-SICOB
            ,:CONVERSI-COD-PRODUTO-SIVPF
            FROM SEGUROS.CONVERSAO_SICOB
            WHERE NUM_SICOB = :BILHETE-NUM-BILHETE
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_PROPOSTA_SIVPF
											,NUM_SICOB
											,COD_PRODUTO_SIVPF
											FROM SEGUROS.CONVERSAO_SICOB
											WHERE NUM_SICOB = '{this.BILHETE_NUM_BILHETE}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string CONVERSI_NUM_PROPOSTA_SIVPF { get; set; }
        public string CONVERSI_NUM_SICOB { get; set; }
        public string CONVERSI_COD_PRODUTO_SIVPF { get; set; }
        public string BILHETE_NUM_BILHETE { get; set; }

        public static R0335_00_SELECT_CONVERSI_DB_SELECT_1_Query1 Execute(R0335_00_SELECT_CONVERSI_DB_SELECT_1_Query1 r0335_00_SELECT_CONVERSI_DB_SELECT_1_Query1)
        {
            var ths = r0335_00_SELECT_CONVERSI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0335_00_SELECT_CONVERSI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0335_00_SELECT_CONVERSI_DB_SELECT_1_Query1();
            var i = 0;
            dta.CONVERSI_NUM_PROPOSTA_SIVPF = result[i++].Value?.ToString();
            dta.CONVERSI_NUM_SICOB = result[i++].Value?.ToString();
            dta.CONVERSI_COD_PRODUTO_SIVPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}