using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0618B
{
    public class R0155_00_VALIDAR_PROP_FIDELIZ_DB_SELECT_1_Query1 : QueryBasis<R0155_00_VALIDAR_PROP_FIDELIZ_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_IDENTIFICACAO
            , COD_PRODUTO_SIVPF
            , COD_EMPRESA_SIVPF
            INTO :PROPOFID-NUM-IDENTIFICACAO
            , :PROPOFID-COD-PRODUTO-SIVPF
            , :PROPOFID-COD-EMPRESA-SIVPF
            FROM SEGUROS.PROPOSTA_FIDELIZ
            WHERE NUM_PROPOSTA_SIVPF =
            :PROPOFID-NUM-PROPOSTA-SIVPF
            AND COD_PRODUTO_SIVPF <> 48
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_IDENTIFICACAO
											, COD_PRODUTO_SIVPF
											, COD_EMPRESA_SIVPF
											FROM SEGUROS.PROPOSTA_FIDELIZ
											WHERE NUM_PROPOSTA_SIVPF =
											'{this.PROPOFID_NUM_PROPOSTA_SIVPF}'
											AND COD_PRODUTO_SIVPF <> 48
											WITH UR";

            return query;
        }
        public string PROPOFID_NUM_IDENTIFICACAO { get; set; }
        public string PROPOFID_COD_PRODUTO_SIVPF { get; set; }
        public string PROPOFID_COD_EMPRESA_SIVPF { get; set; }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }

        public static R0155_00_VALIDAR_PROP_FIDELIZ_DB_SELECT_1_Query1 Execute(R0155_00_VALIDAR_PROP_FIDELIZ_DB_SELECT_1_Query1 r0155_00_VALIDAR_PROP_FIDELIZ_DB_SELECT_1_Query1)
        {
            var ths = r0155_00_VALIDAR_PROP_FIDELIZ_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0155_00_VALIDAR_PROP_FIDELIZ_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0155_00_VALIDAR_PROP_FIDELIZ_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOFID_NUM_IDENTIFICACAO = result[i++].Value?.ToString();
            dta.PROPOFID_COD_PRODUTO_SIVPF = result[i++].Value?.ToString();
            dta.PROPOFID_COD_EMPRESA_SIVPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}