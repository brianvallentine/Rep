using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6005B
{
    public class R2990_00_VERIFICA_PROFISSAO_DB_SELECT_1_Query1 : QueryBasis<R2990_00_VERIFICA_PROFISSAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_PESSOA
            INTO :PRPFIDEL-COD-PESSOA
            FROM SEGUROS.PROPOSTA_FIDELIZ
            WHERE NUM_PROPOSTA_SIVPF = :V0BILH-NUMBIL
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_PESSOA
											FROM SEGUROS.PROPOSTA_FIDELIZ
											WHERE NUM_PROPOSTA_SIVPF = '{this.V0BILH_NUMBIL}'
											WITH UR";

            return query;
        }
        public string PRPFIDEL_COD_PESSOA { get; set; }
        public string V0BILH_NUMBIL { get; set; }

        public static R2990_00_VERIFICA_PROFISSAO_DB_SELECT_1_Query1 Execute(R2990_00_VERIFICA_PROFISSAO_DB_SELECT_1_Query1 r2990_00_VERIFICA_PROFISSAO_DB_SELECT_1_Query1)
        {
            var ths = r2990_00_VERIFICA_PROFISSAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2990_00_VERIFICA_PROFISSAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2990_00_VERIFICA_PROFISSAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.PRPFIDEL_COD_PESSOA = result[i++].Value?.ToString();
            return dta;
        }

    }
}