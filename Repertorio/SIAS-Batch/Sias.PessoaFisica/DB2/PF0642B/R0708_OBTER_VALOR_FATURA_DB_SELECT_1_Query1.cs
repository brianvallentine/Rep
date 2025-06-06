using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0642B
{
    public class R0708_OBTER_VALOR_FATURA_DB_SELECT_1_Query1 : QueryBasis<R0708_OBTER_VALOR_FATURA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            VALUE (SUM(VLR_PREMIO),0)
            INTO
            :VGFUNCOB-VLR-PREMIO
            FROM
            SEGUROS.VG_FUNC_COBERTURA
            WHERE
            NUM_PROPOSTA_SIVPF = :VGFUNCOB-NUM-PROPOSTA-SIVPF
            AND DTH_INI_VIGENCIA = :VGFUNCOB-DTH-INI-VIGENCIA
            AND COD_GARANTIA = :VGFUNCOB-COD-GARANTIA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VALUE (SUM(VLR_PREMIO)
							,0)
											FROM
											SEGUROS.VG_FUNC_COBERTURA
											WHERE
											NUM_PROPOSTA_SIVPF = '{this.VGFUNCOB_NUM_PROPOSTA_SIVPF}'
											AND DTH_INI_VIGENCIA = '{this.VGFUNCOB_DTH_INI_VIGENCIA}'
											AND COD_GARANTIA = '{this.VGFUNCOB_COD_GARANTIA}'
											WITH UR";

            return query;
        }
        public string VGFUNCOB_VLR_PREMIO { get; set; }
        public string VGFUNCOB_NUM_PROPOSTA_SIVPF { get; set; }
        public string VGFUNCOB_DTH_INI_VIGENCIA { get; set; }
        public string VGFUNCOB_COD_GARANTIA { get; set; }

        public static R0708_OBTER_VALOR_FATURA_DB_SELECT_1_Query1 Execute(R0708_OBTER_VALOR_FATURA_DB_SELECT_1_Query1 r0708_OBTER_VALOR_FATURA_DB_SELECT_1_Query1)
        {
            var ths = r0708_OBTER_VALOR_FATURA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0708_OBTER_VALOR_FATURA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0708_OBTER_VALOR_FATURA_DB_SELECT_1_Query1();
            var i = 0;
            dta.VGFUNCOB_VLR_PREMIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}