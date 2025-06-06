using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0103B
{
    public class R0605_TAB_ENDERECO_NOVOS_DB_SELECT_1_Query1 : QueryBasis<R0605_TAB_ENDERECO_NOVOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(OCORR_ENDERECO),0)
            INTO :DCLPESSOA-ENDERECO.OCORR-ENDERECO
            FROM SEGUROS.PESSOA_ENDERECO
            WHERE COD_PESSOA = :DCLPESSOA.PESSOA-COD-PESSOA
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(OCORR_ENDERECO)
							,0)
											FROM SEGUROS.PESSOA_ENDERECO
											WHERE COD_PESSOA = '{this.PESSOA_COD_PESSOA}'
											WITH UR";

            return query;
        }
        public string OCORR_ENDERECO { get; set; }
        public string PESSOA_COD_PESSOA { get; set; }

        public static R0605_TAB_ENDERECO_NOVOS_DB_SELECT_1_Query1 Execute(R0605_TAB_ENDERECO_NOVOS_DB_SELECT_1_Query1 r0605_TAB_ENDERECO_NOVOS_DB_SELECT_1_Query1)
        {
            var ths = r0605_TAB_ENDERECO_NOVOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0605_TAB_ENDERECO_NOVOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0605_TAB_ENDERECO_NOVOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.OCORR_ENDERECO = result[i++].Value?.ToString();
            return dta;
        }

    }
}