using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM8024B
{
    public class R0403_00_VERIFICA_PROPOSTA_DB_SELECT_1_Query1 : QueryBasis<R0403_00_VERIFICA_PROPOSTA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_PRODUTO_SIVPF
            INTO :PROPOFID-COD-PRODUTO-SIVPF
            FROM SEGUROS.PROPOSTA_FIDELIZ
            WHERE NUM_PROPOSTA_SIVPF = :PROPOFID-NUM-PROPOSTA-SIVPF
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COD_PRODUTO_SIVPF
											FROM SEGUROS.PROPOSTA_FIDELIZ
											WHERE NUM_PROPOSTA_SIVPF = '{this.PROPOFID_NUM_PROPOSTA_SIVPF}'
											WITH UR";

            return query;
        }
        public string PROPOFID_COD_PRODUTO_SIVPF { get; set; }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }

        public static R0403_00_VERIFICA_PROPOSTA_DB_SELECT_1_Query1 Execute(R0403_00_VERIFICA_PROPOSTA_DB_SELECT_1_Query1 r0403_00_VERIFICA_PROPOSTA_DB_SELECT_1_Query1)
        {
            var ths = r0403_00_VERIFICA_PROPOSTA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0403_00_VERIFICA_PROPOSTA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0403_00_VERIFICA_PROPOSTA_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOFID_COD_PRODUTO_SIVPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}