using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0641B
{
    public class R0655_LER_TELEFONE_DB_SELECT_1_Query1 : QueryBasis<R0655_LER_TELEFONE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SITUACAO_FONE
            INTO :DCLPESSOA-TELEFONE.SITUACAO-FONE
            FROM SEGUROS.PESSOA_TELEFONE
            WHERE COD_PESSOA = :DCLPESSOA-TELEFONE.COD-PESSOA
            AND TIPO_FONE = :DCLPESSOA-TELEFONE.TIPO-FONE
            AND NUM_FONE = :DCLPESSOA-TELEFONE.NUM-FONE
            AND DDD = :DCLPESSOA-TELEFONE.DDD
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SITUACAO_FONE
											FROM SEGUROS.PESSOA_TELEFONE
											WHERE COD_PESSOA = '{this.COD_PESSOA}'
											AND TIPO_FONE = '{this.TIPO_FONE}'
											AND NUM_FONE = '{this.NUM_FONE}'
											AND DDD = '{this.DDD}'
											WITH UR";

            return query;
        }
        public string SITUACAO_FONE { get; set; }
        public string COD_PESSOA { get; set; }
        public string TIPO_FONE { get; set; }
        public string NUM_FONE { get; set; }
        public string DDD { get; set; }

        public static R0655_LER_TELEFONE_DB_SELECT_1_Query1 Execute(R0655_LER_TELEFONE_DB_SELECT_1_Query1 r0655_LER_TELEFONE_DB_SELECT_1_Query1)
        {
            var ths = r0655_LER_TELEFONE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0655_LER_TELEFONE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0655_LER_TELEFONE_DB_SELECT_1_Query1();
            var i = 0;
            dta.SITUACAO_FONE = result[i++].Value?.ToString();
            return dta;
        }

    }
}