using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2646B
{
    public class R1810_00_SELECT_PESSOJUR_DB_SELECT_1_Query1 : QueryBasis<R1810_00_SELECT_PESSOJUR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            COD_PESSOA
            INTO
            :PESSOA-COD-PESSOA
            FROM SEGUROS.PESSOA_JURIDICA
            WHERE CGC =:CLIENTES-CGCCPF
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											COD_PESSOA
											FROM SEGUROS.PESSOA_JURIDICA
											WHERE CGC ='{this.CLIENTES_CGCCPF}'";

            return query;
        }
        public string PESSOA_COD_PESSOA { get; set; }
        public string CLIENTES_CGCCPF { get; set; }

        public static R1810_00_SELECT_PESSOJUR_DB_SELECT_1_Query1 Execute(R1810_00_SELECT_PESSOJUR_DB_SELECT_1_Query1 r1810_00_SELECT_PESSOJUR_DB_SELECT_1_Query1)
        {
            var ths = r1810_00_SELECT_PESSOJUR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1810_00_SELECT_PESSOJUR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1810_00_SELECT_PESSOJUR_DB_SELECT_1_Query1();
            var i = 0;
            dta.PESSOA_COD_PESSOA = result[i++].Value?.ToString();
            return dta;
        }

    }
}